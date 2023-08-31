import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomecomponentComponent } from './homecomponent/homecomponent.component';
import { UserstructComponent } from './userstruct/userstruct.component';
import { OrdersComponent } from './orders/orders.component';
import { ViewComponent } from './view/view.component';
import { PaymentComponent } from './payment/payment.component';



const routes: Routes = [
  // {
  //   path: '',
  //   redirectTo: 'userhome',
  //   pathMatch: 'full',
  // },
  // {
  //   path:'userhome',
  //   component:HomecomponentComponent

  // }
  {
    path: '',
    redirectTo: 'userstruct/userhome',
    pathMatch: 'full',
  },
  {
    path: 'userstruct',
    component: UserstructComponent,
     children: [
      {
        path: 'userhome',
        component: HomecomponentComponent,

      },
      {
        path: 'view/:id',
        component: ViewComponent,

      },
      {
        path: 'payment/:id',
        component: PaymentComponent,

      },
      {
        path: 'orders',
        component: OrdersComponent,
      },
      // {
      //   path: 'eventlist',
      //   component: EventsComponent,
      // },
      // {
      //   path:'editevent/:id',
      //   component:EditeventComponent
      // }
    ],
  },
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
