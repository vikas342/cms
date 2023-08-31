using Microsoft.EntityFrameworkCore;

namespace Task__007.Sp_models
{

    [Keyless]
    public class Getalldata_Sp
    {

        public int cid { get; set; }
        public int cadd { get; set; }

        public string title { get; set; }
        public string image { get; set; }
        public string food { get; set; }
        public DateTime date { get; set; }
             
        public string buildingname { get; set; }
        public int pincode { get; set; }

        public string city { get; set; }
        public string state { get; set; }
        public string? speakers { get; set; }

        public string? hotels { get; set; }
        //public List<Speaker> hotels { get; set; }
        //public List<Hotel> speakers { get; set; }

        //public string hotels { get; set; }
        //public string speakers { get; set; }


    }








}


    //public class Speaker
    //{
    //    public int sid { get; set; }
    //    public string name { get; set; }
    //    public string image { get; set; }
    //    public DateTime intime { get; set; }
    //    public DateTime outtime { get; set; }
    //}

    //public class Hotel
    //{
    //    public int hid { get; set; }
    //    public string hname { get; set; }
    //    public string city { get; set; }
    //    public string state { get; set; }
    //}
  