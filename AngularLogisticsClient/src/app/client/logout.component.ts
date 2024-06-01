import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showauthdata } from '../models/showauthdata';
import { showauthidresponse } from '../models/showauthidresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styles: [
  ]
})
export class LogoutComponent implements OnInit {

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

    sessionStorage.setItem('isLoggedIn',"false");
    sessionStorage.setItem('user_id',"0");
    sessionStorage.setItem('user_type',"");
    this.router.navigate(['/client'],{relativeTo:this.route});

  }


  
  
  

}
