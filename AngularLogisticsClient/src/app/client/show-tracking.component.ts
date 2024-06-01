import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { showconsignmentdata } from '../models/showconsignmentdata';
import { showconsignmentidresponse } from '../models/showconsignmentidresponse';
import { showconsignmentresponse } from '../models/showconsignmentresponse';
import { showcontainerdata } from '../models/showcontainerdata';
import { showcontaineridresponse } from '../models/showcontaineridresponse';
import { showcontainerresponse } from '../models/showcontainerresponse';
import { showtrackingdata } from '../models/showtrackingdata';
import { showtrackingidresponse } from '../models/showtrackingidresponse';
import { showtrackingresponse } from '../models/showtrackingresponse';
import { showtransportdata } from '../models/showtransportdata';
import { showtransportresponse } from '../models/showtransportresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-show-tracking',
  templateUrl: './show-tracking.component.html',
  styles: [
  ]
})
export class ShowTrackingComponent implements OnInit {

  trackinglist:showtrackingdata[] | undefined
  listresponse:showtrackingresponse | undefined
  trackingresponse!:showtrackingidresponse
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
  tracking_id_pk= 0;
  tracking_number="";

  transportlist:showtransportdata[] | undefined
  transportlistresponse:showtransportresponse | undefined
  transport_id_pk= 0


  consignmentresponse!:showconsignmentidresponse
  consignmentlistresponse:showconsignmentresponse | undefined
  Consignmentdata: showconsignmentdata = {
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
    status: 1,
    weight: "",
    employee_name: "",
    employee_email: "",
    employee_contactno: "",
    customer_name: "",
    company_name: "",
    company_contact: "",
    phonenumber: "",
    code: "",
    name: "",
    isactive: 1,
    tracking_id:0,
 }
 consignment_id_pk= 0;

    showContainer=false;
    showConsignment=false;

  containerlistresponse:showcontainerresponse | undefined
  containerresponse:showcontaineridresponse | undefined
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
    this.route.params.subscribe((params:Params)=>{
      this.tracking_number=params['id'];
      console.log(this.tracking_number);
    }); 
    this.showContainerList();
  }

  showContainerList()
  {
    this.service.getContainerData(this.tracking_number).subscribe(res=>{
      console.log(res);
      this.containerresponse=res as showcontaineridresponse;
      if(this.containerresponse.result === "success"){
        this.showContainer = true;
        this.showConsignment = false;
        this.Containerdata=this.containerresponse.data;
      }
    },err=>{
      console.log(err);
    });
  
    if(this.Containerdata.container_id_pk == 0){
      this.service.getConsignmentData(this.tracking_number).subscribe(res=>{
        console.log(res);
        this.consignmentresponse=res as showconsignmentidresponse;
        if(this.consignmentresponse.result === "success"){
          this.showConsignment = true;
          this.showContainer = false;
          this.Consignmentdata = this.consignmentresponse.data;
        }
        this.Consignmentdata=this.consignmentresponse.data;
      },err=>{
        console.log(err);
      });  
    }

    // this.service.getTransportData(this.Containerdata.container_id_pk.toString(),this.Consignmentdata.consignment_id_pk.toString()).subscribe(res=>{
    //   console.log(res);
    //   this.transportlistresponse=res as showtransportresponse;
    //   this.transportlist=this.transportlistresponse.data;
    // },err=>{
    //   console.log(err);
    // });
 

 
  }


}
