import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataserviceService } from '../services/dataservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  sigin_form!: FormGroup;

  constructor(
    private api: ApiService,
    private fb: FormBuilder,
    private dataserv: DataserviceService,
    private route: Router
  ) {}

  ngOnInit(): void {
    this.sigin_form = this.fb.group({
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', [Validators.required]],
    });
  }

  onsubmit() {
    console.log(this.sigin_form.value);

    this.api.login(this.sigin_form.value).subscribe({
      next: (x) => {
        var data = x;

        this.dataserv.userdata = data;
        localStorage.setItem('uid', this.dataserv.userdata.id);
        localStorage.setItem('uemail', this.dataserv.userdata.email);
        if (this.dataserv.userdata.role == 2) {
          this.dataserv.role = 'user';
          this.route.navigateByUrl('/usermodule');
        } else {
          this.dataserv.role = 'admin';
          this.route.navigateByUrl('/adminmodule');
        }

        console.log(data);
      },
      error: (er) => {
        console.log(er);
        alert('Invalid credetials');
      },
    });
  }
}
