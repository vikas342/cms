import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';

const routes: Routes = [



       {
        path: '',

        component: LoginComponent,
      },
      {
        path: 'login',

        component: LoginComponent,
      },
      {
        path: 'signup',
        component: SignupComponent,
      },


  {
    path:"usermodule",loadChildren:()=> import('./user/user.module').then(m=> m.UserModule)
  },
  {
    path:"adminmodule",loadChildren:()=> import('./admin/admin.module').then(m=> m.AdminModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
