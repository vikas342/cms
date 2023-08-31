import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
 import { AdminhomeComponent } from './adminhome/adminhome.component';
import { NavComponent } from './nav/nav.component';
import { AddEventComponent } from './add-event/add-event.component';
import { EventsComponent } from './events/events.component';
import { AdminstructComponent } from './adminstruct/adminstruct.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditeventComponent } from './editevent/editevent.component';


@NgModule({
  declarations: [

    AdminhomeComponent,
     NavComponent,
     AddEventComponent,
     EventsComponent,
     AdminstructComponent,
     EditeventComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,HttpClientModule,FormsModule,ReactiveFormsModule
  ]
})
export class AdminModule { }
