import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { getdataid } from '../models/getdataid';
import { insertcustomerresponse } from '../models/insertcustomerresponse';
import { showauthdata } from '../models/showauthdata';
import { showcitydata } from '../models/showcitydata';
import { showcityresponse } from '../models/showcityresponse';
import { showcustomerdata } from '../models/showcustomerdata';
import { showcustomeridresponse } from '../models/showcustomeridresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styles: [
  ]
})
export class SignupComponent implements OnInit {

  citylist!:showcitydata[];
  citylistresponse!:showcityresponse;

  insertresponse! : insertcustomerresponse
  getdataresponse!:getdataid;
  // customerresponse!:showcustomeridresponse
  // insertcustomerresponse! : insertcustomerresponse
  customerlist!:showcustomerdata[];
  customerdata: showcustomerdata = {
    customer_id_pk: 0,
    customer_name: "",
    company_name: "",
    company_contact: "",
    phonenumber: "",
    email: "",
    address1: "",
    city_id_fk: 0,
    city_name: "",
    isActive: 0,
    added_by:0
  };
  authData:showauthdata={
    employee_email: "",
      password:"",
      user_id_fk: 0,
      user_type:"",
      auth_id_pk:0
  };
  customer_id_pk= 0;

  constructor(public service :restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {

    this.getCity();
  }

  getCity()
  {
    this.service. cityList()
    .subscribe(res=>{
      this.citylistresponse=res as showcityresponse;
      //this.listresponse=res as showfreightresponse;
      this.citylist=this.citylistresponse.data;
    },err=>{
      console.log(err);
    })
  }


  compareFn(c1:any,c2:any):boolean{
    console.log("C1 ::::"+c1);
    console.log("C2 ::::"+c2);
    return c1 && c2 ? c1.id === c2.id : c1 === c2
  }

  onsubmit(form: NgForm) {
    this.insertdetails(form)
  }

  insertdetails(form:NgForm)
  {
    this.customerdata.added_by=1;
    this.service.AddCustomer(this.customerdata).subscribe(res=>{
    
      this.insertresponse = res as insertcustomerresponse
      
      if(this.insertresponse.result === "success")
      {

        
        var customerid=this.insertresponse.data;
        var customeremail=this.customerdata.email;
        var phonenumber=this.customerdata.phonenumber;
        console.log("customer ID:"+customerid);
        this.authData= {
         employee_email: customeremail,
         password: phonenumber,
         user_id_fk: customerid,
         user_type: "customer",
         auth_id_pk:0
        };
        this.router.navigate(['/client/login'],{relativeTo:this.route});
        this.service.AddauthData(this.authData).subscribe(res =>{
          console.log(res);
         this.resetform(form);
        });
    
        
      }
      else
      {
        console.log(res)
      }
      },err => {
        console.log(err)
     })
  }

  resetform(form:NgForm)
{
  form.form.reset();
  this.customerdata = new showcustomerdata();
}


}
