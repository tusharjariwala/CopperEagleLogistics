import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { showorderdata } from '../models/showorderdata';
import { showorderidresponse } from '../models/showorderidresponse';
import { showorderresponse } from '../models/showorderresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styles: [
  ]
})
export class OrderComponent implements OnInit {

  consignmentlist:showorderdata[] | undefined
  listresponse:showorderresponse | undefined
  consignmentresponse!:showorderidresponse
  orderdata: showorderdata={
    consignment_id_pk: 0,
    employee_id_fk: 0,
    customer_id_fk: 0,
    consignment_number: "",
    package_type: 0,
    deliver_date: "",
    booking_date: "",
    sender_address: "",
    receiver_address: "",
    receiver_person: "",
    packagetype_id_fk: 0,
    description: "",
    status: 0,
    weight: "",
    employee_name: "",
    employee_email: "",
    employee_contactno: "",
    customer_name: "",
    company_name: "",
    company_contact: "",
    phonenumbe: "",
    code: "",
    name: "",
    isactive: 0,
  }
  consignment_id_pk= 0;

  constructor(public service: restapi, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.showconsignmentlist();
    //this.showconsignmentdata();
  }

  showconsignmentlist()
  {
    this.consignment_id_pk = Number(sessionStorage.getItem("user_id")?.toString() );
    console.log("hii"+this.consignment_id_pk);

    this.service.getCustomerConsignmentList(this.consignment_id_pk)
    .subscribe(res=>{
      console.log(res);
      this.listresponse = res as showorderresponse;
      this.consignmentlist = this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }



}
