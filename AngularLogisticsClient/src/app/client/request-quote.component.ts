import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { insertfreightresponse } from '../models/insertfreightresponse';
import { showcitydata } from '../models/showcitydata';
import { showcityresponse } from '../models/showcityresponse';
import { showfreightdata } from '../models/showfreightdata';
import { showfreightresponse } from '../models/showfreightresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-request-quote',
  templateUrl: './request-quote.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class RequestQuoteComponent implements OnInit {

  citylist!:showcitydata[];
  citylistresponse!:showcityresponse;

  insertresponse! : insertfreightresponse
  freightdata: showfreightdata = {
    freight_id_pk: 0,
    freight_type: '',
    departureCity_name: '',
    deliverCity_name:'',
    total_gross_weight: '',
    dimention: '',
    email: '',
    message: '',
    isactive: 1,
    departure_id: 0,
    deliverCity_id: 0,
  }

  freight_id_pk=0;

  constructor(public service :restapi,private route:ActivatedRoute,private router:Router) {}

  ngOnInit(): void {

    this.getCity()
    this.freightdata = new showfreightdata()
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

  onsubmit(form:NgForm)
  {
      this.insertdetails(form)
  }

  insertdetails(form:NgForm)
  {
    this.service.AddFreight(this.freightdata).subscribe(res=>{
      this.insertresponse = res as insertfreightresponse
      if(this.insertresponse.result === "success")
      {
        this.resetform(form)
        this.router.navigate(['/client/thank-you'],{relativeTo:this.route});
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
    this.freightdata = new showfreightdata();
  }

  compareFn(c1:any,c2:any):boolean{
    console.log("C1 ::::"+c1);
    console.log("C2 ::::"+c2);
    return c1 && c2 ? c1.id === c2.id : c1 === c2
  }

}
