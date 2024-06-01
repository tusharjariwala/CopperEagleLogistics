import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { inserttrackingresponse } from '../models/inserttrackingresponse';
import { showcontainerdata } from '../models/showcontainerdata';
import { showtrackingdata } from '../models/showtrackingdata';
import { showtrackingidresponse } from '../models/showtrackingidresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-trackshipment',
  templateUrl: './trackshipment.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class TrackshipmentComponent implements OnInit {

  Trackingdata: showtrackingdata = {
    tracking_id_pk: 0,
    tracking_date_and_time: "",
    consignment_id_fk: 0,
    consignment_number: "",
    deliver_date: "",
    sender_address: "",
    receiver_address: "",
    receiver_person: "",
    remark: "",
    warehouse_id_fk1: 0,
    warehouse_name1: "",
    address1: "",
    contactperson_name: "",
    contactperson_number: "",
    status: 0,
    added_by: 0,
    tracking_number:""
  }

  Containerdata: showcontainerdata ={
    container_id_pk:0,
    container_name: "",
    delivery_days: "",
    departed_date: "",
    expected_date: "",
    status1: 1,
    employee_id_fk: 0,
    employee_name: "",
    employee_email: "",
    employee_contactno: "",
    container_number1: "",
    isactive: 1,
    tracking_id:0
  } 
  container_id_pk=0;

  constructor(public service: restapi, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {

  }

  onsubmit(form:NgForm)
  {

    this.router.navigate(['/client/show-tracking',this.Trackingdata.tracking_number],{relativeTo:this.route});
  }


}
