import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminhomeComponent } from './adminhome/adminhome.component';
import { AddEventComponent } from './add-event/add-event.component';
import { EventsComponent } from './events/events.component';
import { AdminstructComponent } from './adminstruct/adminstruct.component';
import { EditeventComponent } from './editevent/editevent.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'adminstruct/adminhome',
    pathMatch: 'full',
  },
  {
    path: 'adminstruct',
    component: AdminstructComponent,
     children: [
      {
        path: 'adminhome',
        component: AdminhomeComponent,

      },
      {
        path: 'addevent',
        component: AddEventComponent,
      },
      {
        path: 'eventlist',
        component: EventsComponent,
      },{
        path:'editevent/:id',
        component:EditeventComponent
      }
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
