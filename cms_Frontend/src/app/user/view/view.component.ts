import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { DataserviceService } from 'src/app/services/dataservice.service';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit{


  cid!:number;
  data:any;
  constructor(private api:ApiService,private dataserv:DataserviceService,private router:ActivatedRoute){



  }

  ngOnInit(): void {

    this.router.paramMap.subscribe((value) => {
      this.cid = Number(value.get('id'));
      console.log(this.cid);
    });

    this.api.get_perticular(this.cid).subscribe((x) => {
      this.data = this.dataserv.dataparser(x);
    });

  }
}
