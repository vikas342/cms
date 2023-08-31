import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-add-event',
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.css'],
})
export class AddEventComponent implements OnInit {

  currentDate: string;
  currentDateTime: string;
  confid!: any;
  add_id!: any;

  owner_id!: number;

  speakerimages: any[] = [];

  imgFile!: File;
  imgurl!: any;

  imgdata: any;
  uid!: number;

  adressdetails_visiblity: boolean = true;
  confdetails_visiblity: boolean = false;
  hotels_visiblity: boolean = false;
  speakersdetails_visiblity: boolean = false;




  //api data
  cities!: any;
  state!: any;

  adressdetails!: FormGroup;
  confdetails!: FormGroup;
  hoteldetails!: FormGroup;
  speakerdetails!: FormGroup;

  constructor(
    private api: ApiService,
    private fb: FormBuilder,
    private route: Router
  ) {

    this.currentDate = new Date().toISOString().split('T')[0];
    this.currentDateTime = new Date().toISOString().slice(0, 16);
  }

  ngOnInit(): void {
    this.uid = Number(localStorage.getItem('uid'));

    this.api.getcities().subscribe((x) => {
      this.cities = x;
      console.log(this.cities);
    });

    this.api.getstates().subscribe((x) => {
      this.state = x;
      console.log(this.state);
    });

    this.adressdetails = this.fb.group({
      buildingname: ['', [Validators.required]],
      city: ['', [Validators.required]],
      state: ['', [Validators.required]],
      pincode: ['', [Validators.required, Validators.maxLength(6)]],
    });

    this.confdetails = this.fb.group({
      title: ['', [Validators.required]],
      cadd: [''],
      food: ['', [Validators.required]],
      date: ['', [Validators.required]],
      image: ['', [Validators.required]],
    });

    this.hoteldetails = this.fb.group({
      cid: [''],
      hname: ['', [Validators.required]],
      city: ['', [Validators.required]],
      state: ['', [Validators.required]],
    });

    this.speakerdetails = this.fb.group({
      speakers: this.fb.array([
        this.fb.group({
          name: ['', [Validators.required]],
          image: ['', [Validators.required]],
          intime: ['', [Validators.required]],
          outtime: ['', [Validators.required]],
        }),
      ]),
    });
  }

  adressdetails_Submit() {
    console.log(this.adressdetails.value);
    this.api.add_address(this.adressdetails.value).subscribe((x) => {
      this.add_id = x;
      console.log(this.add_id);
      this.confdetails.patchValue({
        cadd: this.add_id,
      });

      this.adressdetails_visiblity = false;
      this.confdetails_visiblity = true;
      this.adressdetails.reset();
    });
  }

  confdetails_Submit() {
    console.log(this.confdetails.value);

    // {title: 'sdfd', cadd: '', food: 'sdg', date: '2023-08-27', image: 'C:\\fakepath\\Screenshot_20230210_112729.png'}

    var obj = {
      title: this.confdetails.value.title,
      cadd: 1,
      food: this.confdetails.value.food,
      date: this.confdetails.value.date,
      image: this.imgurl,
    };

    console.log(obj);

    this.api.add_confdetails(obj).subscribe((x) => {
      this.confid = x;
      this.hoteldetails.patchValue({ cid: this.confid });
      this.confdetails_visiblity = false;
      this.hotels_visiblity = true;
      this.confdetails.reset();
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

  hoteldetails_Submit() {
    console.log(this.hoteldetails.value);
    this.api.add_hoteldetails(this.hoteldetails.value).subscribe((x) => {
      console.log(x);
      this.hotels_visiblity = false;
      this.speakersdetails_visiblity = true;
      this.hoteldetails.reset();
    });
  }

  get getspeakes() {
    return this.speakerdetails.controls['speakers'] as FormArray;
  }

  addmoreImages() {
    const speakers = this.fb.group({
      name: ['', [Validators.required]],
      image: ['', [Validators.required]],
      intime: ['', [Validators.required]],
      outtime: ['', [Validators.required]],
    });

    this.getspeakes.push(speakers);
  }

  submitted() {
    console.log(this.speakerdetails.value);


    for(let i=0;i<this.speakerimages.length;i++){
      this.speakerdetails.value.speakers[i].image=this.speakerimages[i]
    }

    console.log(this.speakerdetails.value);
    this.api
      .add_speakerdetails(this.speakerdetails.value,1)
      .subscribe((x) => {
        alert('Event added');
        this.speakerdetails.reset();

          this.adressdetails_visiblity = true;
          this.confdetails_visiblity = false;
          this.hotels_visiblity = false;
          this.speakersdetails_visiblity = false;
        this.route.navigateByUrl("/adminmodule/adminstruct/eventlist")
      });
  }

  addspeakerphoto(event: any) {
    this.imgFile = event.target.files[0];
    // console.log(this.imgFile);
    const form = new FormData();
    form.append('file', this.imgFile as File);
    console.log(form);
    this.api.postimage(form).subscribe((res) => {
      this.imgdata = res;

      this.speakerimages.push(this.imgdata.imageurl);


      console.log(this.speakerimages);
    });
  }
}
