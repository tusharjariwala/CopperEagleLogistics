import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { insertcustomerresponse } from '../models/insertcustomerresponse';
import { showcitydata } from '../models/showcitydata';
import { showcityresponse } from '../models/showcityresponse';
import { showcustomerdata } from '../models/showcustomerdata';
import { showcustomeridresponse } from '../models/showcustomeridresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-userprofile',
  templateUrl: './userprofile.component.html',
  styles: [
  ]
})
export class UserprofileComponent implements OnInit {

  citylist!:showcitydata[];
  citylistresponse!:showcityresponse;

  customerresponse!:showcustomeridresponse
  insertcustomerresponse! : insertcustomerresponse
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
  }
  customer_id_pk= 0;

  constructor(public service :restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.getCity();
    this.getCustomerData();

    this.customer_id_pk = Number(sessionStorage.getItem("user_id")?.toString());
    console.log("Customer ID :::"+this.customer_id_pk);
    

    this.customerdata = new showcustomerdata()
  }

  onsubmit(form: NgForm) {
    this.updatedetails(form)
  }

   getCustomerData(){
    this.customer_id_pk = Number(sessionStorage.getItem("user_id")?.toString());

    this.service.getCustomerData(this.customer_id_pk).subscribe(res=>{
      console.log(res);
      this.customerresponse=res as showcustomeridresponse;
      this.customerdata=this.customerresponse.data;
    },err=>{
      console.log(err);
    });
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

  updatedetails(form:NgForm)
  {
    this.service.updatecustomer(this.customerdata).subscribe(res=>{
      this.insertcustomerresponse = res as insertcustomerresponse
      if(this.insertcustomerresponse.result === "success")
      {
        // this.resetform(form)
        this.router.navigate(['/client/profile'],{relativeTo:this.route});
      }
      else
      {
        console.log(res)
      }
      },err => {
        console.log(err)
     })
    }

}
