import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { insertfreightresponse } from '../models/insertfreightresponse';
import { insertresponse } from '../models/insertresponse';
import { showauthdata } from '../models/showauthdata';
import { showauthidresponse } from '../models/showauthidresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class LoginComponent implements OnInit {
  
  editMode = false;
  insertresponse!: insertresponse;
  showauthResponse!: showauthidresponse;
  authData: showauthdata = {
    employee_email: "",
    password: "",
    user_id_fk: 0,
    user_type: "",
    auth_id_pk: 0,
  };

  auth_id_pk= 0;


  constructor(public service: restapi, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
  }


  onsubmit(form: NgForm) {

    console.log(this.authData);
    this.service.getlogindata(this.authData).subscribe(res => {
      this.showauthResponse = res as showauthidresponse;
      this.authData = res.data;
      sessionStorage.setItem('isLoggedIn',"true");
      sessionStorage.setItem('user_id',this.authData.user_id_fk.toString());
      sessionStorage.setItem('user_type',this.authData.user_type);


      if (this.showauthResponse.result == "success") {
        this.authData = this.showauthResponse.data
        console.log(this.authData);
        if (this.authData.user_type === 'customer') {
          console.log("success");
          this.router.navigate(['/client'], { relativeTo: this.route }).then(() => {
            window.location.reload();
          });
          
        }
        else {
          console.log("login failed");
        }
      }
    });

  }


}