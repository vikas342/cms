import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { DataserviceService } from '../services/dataservice.service';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private dataserv: DataserviceService,private api:ApiService,
    private route: Router
  ) {}
  signup_form!: FormGroup;
  myobj!: Array<object>;
  data: any;

  ngOnInit(): void {
    this.signup_form = this.fb.group({
      Uname: ['',[Validators.required]],

      Email: ['',[Validators.required,Validators.email]],
      Password: ['',[Validators.required]],
    });
  }

  onsubmit() {
    this.data = this.signup_form.value;

    console.log(this.data);

    this.api.signup(this.signup_form.value).subscribe({
      next: (x) => {
        var data = x;

        this.dataserv.userdata = data;
        console.log(data);
        alert("Account created sucessfully")
        this.route.navigateByUrl("/login")
      },
      error: (er) => {
        console.log(er);
        alert('Account not created');
      },
    });

  }
}
