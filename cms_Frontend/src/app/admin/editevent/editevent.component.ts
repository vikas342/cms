import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { DataserviceService } from 'src/app/services/dataservice.service';

@Component({
  selector: 'app-editevent',
  templateUrl: './editevent.component.html',
  styleUrls: ['./editevent.component.css'],
})
export class EditeventComponent implements OnInit {



  currentDate: string;
  currentDateTime: string;
  cid!: number;
  data: any;

  cities:any;
  state:any;
  speakerid!:number;



  imgFile!: File;
  imgurl!: any;

  imgdata: any;



  confdetails!: FormGroup;
  adressdetails!: FormGroup;
  hoteldetails!:FormGroup;
  speakerdetails!:FormGroup;

  constructor(
    private api: ApiService,
    private dataserv: DataserviceService,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {

    this.currentDate = new Date().toISOString().split('T')[0];
    this.currentDateTime = new Date().toISOString().slice(0, 16);
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((value) => {
      this.cid = Number(value.get('id'));
      console.log(this.cid);
    });

    this.api.get_perticular(this.cid).subscribe((x) => {
      this.data = this.dataserv.dataparser(x);
    });

    this.api.getcities().subscribe((x) => {
      this.cities = x;
      console.log(this.cities);
    });

    this.api.getstates().subscribe((x) => {
      this.state = x;
      console.log(this.state);
    });


    this.confdetails = this.fb.group({
      cadd: [''],

      title: ['', [Validators.required]],
      food: ['', [Validators.required]],
      date: ['', [Validators.required]],
      image: ['', [Validators.required]],
    });


    this.adressdetails = this.fb.group({
      buildingname: ['', [Validators.required]],
      city: ['', [Validators.required]],
      state: ['', [Validators.required]],
      pincode: ['', [Validators.required, Validators.maxLength(6)]],
    });


    this.hoteldetails = this.fb.group({
      cid: [''],
      hname: ['', [Validators.required]],
      city: ['', [Validators.required]],
      state: ['', [Validators.required]],
    });


    this.speakerdetails = this.fb.group({


          name: ['', [Validators.required]],
          image: ['', [Validators.required]],
          intime: ['', [Validators.required]],
          outtime: ['', [Validators.required]],


    });

  }


  fileadd(event: any) {
    this.imgFile = event.target.files[0];
    // console.log(this.imgFile);
    const form = new FormData();
    form.append('file', this.imgFile as File);
    console.log(form);
    this.api.postimage(form).subscribe((res) => {
      this.imgdata = res;
      this.imgurl = this.imgdata.imageurl;

      console.log(this.imgurl);
    });
  }



  edit_conf() {
    this.confdetails.patchValue({

      cadd:this.data[0].cadd,
      title: this.data[0].title,
      food: this.data[0].food,
      date: this.data[0].date,
      // image: this.data[0].image,
    });

  }

  confdetails_Submit() {
    console.log(this.confdetails.value);
    this.confdetails.value.image=this.imgurl;

    var cid=this.data[0].cid;
    this.api.edit_confdetails(cid,this.confdetails.value).subscribe((x)=>{
      this.api.get_perticular(this.cid).subscribe((x) => {
        this.data = this.dataserv.dataparser(x);
      });
    })

  }



  edit_add(){

    alert(this.data[0].cadd);
    var findstate=this.state.filter((x:any)=> x.name==this.data[0].state);

    var findcity=this.cities.filter((x:any)=> x.name==this.data[0].city);
    console.log(findstate);

    this.adressdetails.patchValue({

      buildingname:this.data[0].buildingname,
      state: findstate[0].id,
      city: findcity[0].id,
      pincode: this.data[0].pincode,
      // image: this.data[0].image,
    });

  }

  adress_submit(){
    console.log(this.adressdetails.value);
    this.api.edit_addressdetails(this.data[0].cadd,this.adressdetails.value).subscribe((x)=>{
      this.api.get_perticular(this.cid).subscribe((x) => {
        this.data = this.dataserv.dataparser(x);
      });
    })
  }


  edit_hotel(){

    alert(this.data[0].hotels[0].hid);
    var findstate=this.state.filter((x:any)=> x.name==this.data[0].state);

    var findcity=this.cities.filter((x:any)=> x.name==this.data[0].city);
    this.hoteldetails.patchValue({

      cid:this.data[0].cid,
      hname:this.data[0].hotels[0].hname,
      state: findstate[0].id,
      city: findcity[0].id,

      // image: this.data[0].image,
    });

  }

  hotel_submit(){

    console.log(this.hoteldetails.value);
    this.api.edit_hoteldetails(this.data[0].hotels[0].hid,this.hoteldetails.value).subscribe((x)=>{
      this.api.get_perticular(this.cid).subscribe((x) => {
        this.data = this.dataserv.dataparser(x);
      });
    })


  }


  edit_speakers(id:number,index:number){
    alert(id)
    this.speakerid=id;
    var filterdata=this.data[0].speakers[index];
    console.log(filterdata);
    this.speakerdetails.patchValue({

      name:filterdata.name,

    })


  }

  speaker_submit(){
    this.speakerdetails.value.image=this.imgurl;
    console.log(this.speakerdetails.value);
    //alert(this.data[0].cid)
    this.api.edit_speakerdetails(this.data[0].cid,this.speakerid,this.speakerdetails.value).subscribe((x)=>{
      this.speakerdetails.reset();
     this.api.get_perticular(this.cid).subscribe((x) => {
        this.data = this.dataserv.dataparser(x);
      });
    })

  }


  addspeaker(){
    this.speakerdetails.value.image=this.imgurl;
    console.log(this.speakerdetails.value);
    this.api.addspeaker_edit(this.cid,this.speakerdetails.value).subscribe((x)=>{
      this.speakerdetails.reset();
      this.api.get_perticular(this.cid).subscribe((x) => {
         this.data = this.dataserv.dataparser(x);
       });
    })
  }

  delete_speakers(id:number){
    this.api.delete_speaker(id).subscribe((x)=>{
      this.api.get_perticular(this.cid).subscribe((x) => {
        this.data = this.dataserv.dataparser(x);
      });
    })
  }
}
