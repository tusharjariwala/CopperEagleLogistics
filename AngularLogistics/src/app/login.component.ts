import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { showauthdata } from './models/showauthdata';
import { showauthidresponse } from './models/showauthidresponse';
import { restapi } from './services/restapiservice';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {
  @ViewChild('f') slForm: NgForm | undefined;
  editMode = false;
  showauthResponse!: showauthidresponse;
  authData: showauthdata = {
    employee_email: "",
    password: "",
    user_id_fk: 0,
    user_type: "",
    auth_id_pk: 0,
  };
  constructor(private service: restapi, private route: ActivatedRoute, private router: Router) { }


  ngOnInit(): void {

  }
  onSubmit(form: NgForm) {
    this.service.LoginData(this.authData).subscribe(res => {
      this.showauthResponse = res as showauthidresponse;
      if (this.showauthResponse.result === "success") {
        this.authData = this.showauthResponse.data;

        sessionStorage.setItem('isLoggedIn', "true");
        sessionStorage.setItem('user_id', this.authData.user_id_fk.toString());
        sessionStorage.setItem('user_type', this.authData.user_type);

        if (this.authData.user_type === "admin") {
          console.log("login success full:");
          this.router.navigate(['/admin']).then(() => {
            window.location.reload();
          });
        }
        else if (this.authData.user_type === "emp") {
          console.log("login success full:");
          this.router.navigate(['/employee']).then(() => {
            window.location.reload();
          });
        }
        else {
          console.log("login  fail:");
          this.router.navigate(['/admin/login']).then(() => {
            window.location.reload();
          });
        }

      }
    });
  }

}
