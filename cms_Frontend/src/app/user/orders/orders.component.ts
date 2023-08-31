import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { DataserviceService } from 'src/app/services/dataservice.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  uid!:number;
  data:any;
  constructor(private api:ApiService,private datserv:DataserviceService){

  }

  ngOnInit(): void {


    this.uid=Number(localStorage.getItem('uid'));

    this.api.get_orders(this.uid).subscribe((x)=>{
      this.data=this.datserv.dataparser(x);
    })


  }
}
