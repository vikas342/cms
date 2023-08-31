import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { DataserviceService } from 'src/app/services/dataservice.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit{

  cid!:number;
  data:any;

  paymentform!:FormGroup;


  constructor(private api:ApiService,private dataserv:DataserviceService ,private router:ActivatedRoute,private fb:FormBuilder,private route:Router){

  }
  ngOnInit(): void {
    this.router.paramMap.subscribe((value) => {
      this.cid = Number(value.get('id'));
      console.log(this.cid);
    });

    this.api.get_perticular(this.cid).subscribe((x) => {
      this.data = this.dataserv.dataparser(x);
    });

    this.paymentform=this.fb.group({
      name:['',[Validators.required]],
      email:['',[Validators.required,Validators.email]]

    })




  }

  paymentform_submit(){
    console.log(this.paymentform.value);
    alert(this.data[0].hotels[0].hid);

    var formdata={

      Uid:Number(localStorage.getItem('uid')),
      Cid:this.cid,
      Hid:this.data[0].hotels[0].hid,

    }

    console.log(formdata);

    this.api.add_order(this.paymentform.value.name,this.paymentform.value.email,formdata).subscribe(
     {next: (x)=>{
      this.paymentform.reset();
      alert("Order Placed Successfully");

      this.route.navigateByUrl("/usermodule/userstruct/orders");

    },

    error: ()=> {
        alert("error occured")
      this.paymentform.reset();

    },
  }
    )




  }

}
