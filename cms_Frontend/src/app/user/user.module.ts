import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { HomecomponentComponent } from './homecomponent/homecomponent.component';
import { OrdersComponent } from './orders/orders.component';
import { UsernavComponent } from './usernav/usernav.component';
import { UserstructComponent } from './userstruct/userstruct.component';
import { ViewComponent } from './view/view.component';
import { PaymentComponent } from './payment/payment.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    HomecomponentComponent,
    OrdersComponent,
    UsernavComponent,
    UserstructComponent,
    ViewComponent,
    PaymentComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,FormsModule,ReactiveFormsModule
  ]
})
export class UserModule { }
