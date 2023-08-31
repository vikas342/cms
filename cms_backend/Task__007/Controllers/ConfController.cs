using Amazon.S3.Transfer;
using Amazon.S3;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Task__007.dtos;
using Task__007.Models;
using Amazon;
using Task__007.services;

namespace Task__007.Controllers
{

    [EnableCors("Policy1")]

    [Route("api/[controller]")]
    [ApiController]
    public class ConfController : ControllerBase
    {

        private readonly Task007Context context;


        private readonly Emailservice _emailService;

        private readonly IConfiguration _configuration;


        public ConfController(Task007Context context, Emailservice email, IConfiguration configuration)
        {
            this.context = context;
            _emailService = email;
            _configuration = configuration;


        }


        [HttpGet("getallData")]
        public async Task<IActionResult> getallData()
        {
            var data =  context.Getalldata_Sp.FromSqlRaw("EXEC getall_data");

            return Ok(data);
        }


        [HttpGet("getData")]
        public async Task<IActionResult> getallData(int cid)
        {
            var data = context.Getalldata_Sp.FromSqlRaw($"EXEC get_data @cid={cid}");

            return Ok(data);
        }


        [HttpGet("orderDetails")]
        public async Task<IActionResult> orderDetails(int uid)
        {
            var data = (from o in context.Orders
                        join u in context.Users on o.Uid equals u.Uid
                        join cd in context.ConfDetails on o.Cid equals cd.Cid
                        select new
                        {
                            orderid = o.Oid,
                            userid = u.Uid,
                            uname = u.Uname,
                            uemail = u.Email,
                            cid = cd.Cid,
                            ctitle = cd.Title,
                            cdate = cd.Date,
                            cimage = cd.Image
                        }).ToList();

            return Ok(data);
        }


        [HttpPost("add_address")]
        public async Task<IActionResult> add_address(AddadressDTO dto)
        {
            var check = context.Addresses.FirstOrDefault((x) => x.Buildingname == dto.Buildingname && x.City == dto.City && x.State == dto.State && x.Pincode == dto.Pincode);
            if (check == null)
            { 
            var data = new Address();
            data.Buildingname = dto.Buildingname;
            data.City = dto.City;
            data.State = dto.State;
            data.Pincode = dto.Pincode;

            context.Add(data);
            context.SaveChanges();
            return Ok(data.AddId);
            }
            else
            {
                return Ok(check.AddId);
            }

        }


        [HttpPost("add_conf")]
        public async Task<IActionResult> add_conf(ConfAddDTO dto)
        {
            var check = context.ConfDetails.FirstOrDefault((x) => x.Title == dto.title && x.Cadd == dto.cadd && x.Food == dto.food && x.Date == dto.date && x.Image==dto.image);
            if (check == null)
            {
                var data = new ConfDetail();
                data.Title = dto.title;
                data.Cadd = dto.cadd;
                data.Food = dto.food;
                data.Date = dto.date;
                data.Image = dto.image;
                data.status =6;


                context.Add(data);
                context.SaveChanges();
                return Ok(data.Cid);
            }
            else
            {
                return Ok(check.Cid);
            }

        }




        [HttpPost("add_hotels")]
        public async Task<IActionResult> add_hotels(AddhotelDTO dto)
        {

            var check = context.Hotels.FirstOrDefault((x) => x.Cid == dto.Cid && x.Hname == dto.Hname && x.City == dto.City && x.State == dto.State);
            if (check == null)
            {
                var data = new Hotel();
                data.Cid = dto.Cid;
                data.Hname = dto.Hname;
                data.City = dto.City;
                data.State = dto.State;
                context.Add(data);
                context.SaveChanges();
                return Ok(data.Hid);
            }
            else {
                return Ok(check.Hid);

            }
        }




        [HttpPost("add_speakers")]
        public async Task<IActionResult> add_speakers(AddspeakerDTO dto,int cid)
        {



            foreach (var item in dto.speakers)
            {
                if(context.Speakers.FirstOrDefault((x)=>x.Name==item.name && x.Image == item.image && x.Intime == item.intime && x.Outtime == item.outtime) != null)
                {
                    continue;
                }
                var data = new Speaker();
                data.Cid = cid;
                data.Name = item.name;
                data.Image = item.image;
                data.Intime = item.intime;
                data.Outtime = item.outtime;

                context.Add(data);
                context.SaveChanges();
            }
            

            

            return Ok();
           
        }



        [HttpPost("add_order")]
        public async Task<IActionResult> add_order(string name,string email,OrderDTO dto)
        {


            var data = new Order();
            data.Cid = dto.Cid;
            data.Uid = dto.Uid;
            data.Hid = dto.Hid;
            data.BookedDate = dto.BookedDate; 

            context.Add(data);
            context.SaveChanges();


            var data2 = context.ConfDetails.FirstOrDefault((x)=> x.Cid==dto.Cid);
            var data3= context.Hotels.FirstOrDefault((x) => x.Hid == dto.Hid);





            //     Send the email
            var r = email;
            var s = "About Conference";
            var b = $"Hello {name},\n Here's details about Conference:\n\nTitle:{data2.Title}\nDate:{data2.Date}\n\nHotel:{data3.Hname}\nFood:{data2.Food}";
               _emailService.SendEmail(r, s, b);
            var resp = new
            {
                message = $"Email sent to {r}"
            };

            return Ok(data);

        }



        [HttpGet("getstates")]
        public async Task<IActionResult> getstates()
        {
            var data = (from s in context.ObjectTypes where s.ParentId == 1 select new  { s.Id,s.Name}).ToList();
            return Ok(data);
        }

        [HttpGet("getcities")]
        public async Task<IActionResult> getcities()
        {
            var data = (from obj in context.Objects
                        join objType in context.ObjectTypes on obj.Typeid equals objType.Id
                        where objType.ParentId == 1
                        select new { obj.Id, obj.Name, obj.Typeid }).ToList();
            return Ok(data);
        }


        [HttpPut("delete")]
        public async Task<IActionResult> delete(int cid)
        {
            var data = context.ConfDetails.FirstOrDefault((x)=>x.Cid==cid);
            data.status = 7;
            context.SaveChanges();
            return Ok();
        }


        //edit 

        [HttpPut("edit_conf")]
        public async Task<IActionResult> edit_conf(int cid,ConfAddDTO dto)
        {
            var data = context.ConfDetails.FirstOrDefault((x) => x.Cid == cid);
            data.Date = dto.date;
            data.Cadd = dto.cadd;
            data.Title = dto.title;
            data.Food=dto.food;
            data.Image = dto.image;

            context.SaveChanges();
            return Ok();
        }



        [HttpPut("edit_address")]
        public async Task<IActionResult> edit_address(int addid, AddadressDTO dto)
        {
            var data = context.Addresses.FirstOrDefault((x) => x.AddId == addid);
            data.Buildingname = dto.Buildingname;
            data.State = dto.State;
            data.City = dto.City;
            data.Pincode = dto.Pincode;
        

            context.SaveChanges();
            return Ok();
        }


        [HttpPut("edit_hotel")]
        public async Task<IActionResult> edit_hotel(int hid, AddhotelDTO dto)
        {
            var data = context.Hotels.FirstOrDefault((x) => x.Hid == hid);
            data.Hname = dto.Hname;
            data.State = dto.State;
            data.City = dto.City; 


            context.SaveChanges();
            return Ok();
        }

        [HttpPut("edit_speaker")]
        public async Task<IActionResult> edit_speaker(int sid,speakerDTO dto)
        {
            var data = context.Speakers.FirstOrDefault((x) =>  x.Sid == sid);
            data.Image = dto.image;
            data.Name = dto.name;
            data.Intime = dto.intime;
            data.Outtime = dto.intime;
            context.SaveChanges();
            return Ok();

        }


        [HttpPost("addspeker")]
        public async Task<IActionResult> addspeker(int cid,speakerDTO dto) {

            var data = new Speaker();
            data.Cid = cid;
            data.Name = dto.name;
            data.Image = dto.image;
            data.Intime = dto.intime;
            data.Outtime = dto.outtime;

            context.Add(data);
            context.SaveChanges();


            return Ok();
        }



        [HttpPut("editspeker")]
        public async Task<IActionResult> editspeker(int sid, int cid, speakerDTO dto)
        {

            
            var data = context.Speakers.FirstOrDefault((x) => x.Sid == sid);
            data.Cid = cid;
            data.Name = dto.name;
            data.Image = dto.image;
            data.Intime = dto.intime;
            data.Outtime = dto.outtime;

             context.SaveChanges();


            return Ok();
        }

        [HttpDelete("del_speaker")]
        public async Task<IActionResult> del_speaker(int sid )
        {


            var data = context.Speakers.FirstOrDefault((x) => x.Sid == sid);
            context.Remove(data);

            context.SaveChanges();


            return Ok();
        }


        [HttpPost("ImageUrl")]
        public async Task<IActionResult> geturl(IFormFile file)
        {
            var accesskey = _configuration.GetSection("aws:accesskey").Value;
            var secretAccesskey = _configuration.GetSection("aws:secrateAccesskey").Value;
            var bucketname = _configuration.GetSection("aws:bucketname").Value;

            if (file == null || file.Length <= 0)
            {
                return BadRequest("No file specified.");
            }
            var destKey = $"Images/{file.FileName.ToLower()}";



            using (var client = new AmazonS3Client(accesskey, secretAccesskey,Amazon.RegionEndpoint.APSouth1))
            {
                using (var transferUtility = new TransferUtility(client))
                {
                    var transferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = bucketname,
                        Key = destKey,
                        InputStream = file.OpenReadStream(),
                        //CannedACL = S3CannedACL.PublicRead
                    };

                    await transferUtility.UploadAsync(transferUtilityRequest);
                }
            }
            var reg = RegionEndpoint.APSouth1;
            var url = $"https://{bucketname}.s3.{reg.SystemName}.amazonaws.com/{destKey}";
            var resp = new
            {
                imageurl = url
            };


            return Ok(resp);

        }
    }
}

