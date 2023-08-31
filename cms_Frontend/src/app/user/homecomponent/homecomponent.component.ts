import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { DataserviceService } from 'src/app/services/dataservice.service';

@Component({
  selector: 'app-homecomponent',
  templateUrl: './homecomponent.component.html',
  styleUrls: ['./homecomponent.component.css']
})
export class HomecomponentComponent  implements OnInit{


  data!:any;
  constructor(private api:ApiService,private dataserv:DataserviceService,private route:Router){

  }

  ngOnInit(): void {


    this.api.get_allevents().subscribe((x)=>{
      this.data=this.dataserv.dataparser(x);
    })



  }

  view(id:number){
  //  alert(id);

    this.route.navigate(['/usermodule/userstruct/view', id]);

  }
}
