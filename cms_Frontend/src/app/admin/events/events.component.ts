import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { DataserviceService } from 'src/app/services/dataservice.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit{

  data:any;

  constructor(private api:ApiService,private dataserv:DataserviceService,private route:Router){}

  ngOnInit(): void {


    this.api.get_allevents().subscribe((x)=>{
      this.data=this.dataserv.dataparser(x);
      console.log(this.data);


    })




  }

  delete(id:number){
    alert(id);
    this.api.delete(id).subscribe((x)=>{
      // alert("deleted");
      this.api.get_allevents().subscribe((x)=>{
        this.data=this.dataserv.dataparser(x);
        console.log(this.data);


      })
    })
  }

  edit(id:number){
    alert(id);

    this.route.navigate(['/adminmodule/adminstruct/editevent', id]);

  }
}
