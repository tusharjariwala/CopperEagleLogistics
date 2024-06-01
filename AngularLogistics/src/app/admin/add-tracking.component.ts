import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showarehouseresponse } from '../models/showarehouseresponse';
import { showconsignmentdata } from '../models/showconsignmentdata';
import { showconsignmentresponse } from '../models/showconsignmentresponse';
import { showtrackingdata } from '../models/showtrackingdata';
import { showtrackingidresponse } from '../models/showtrackingidresponse';
import { showarehousedata } from '../models/showwarehousedata';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-add-tracking',
  templateUrl: './add-tracking.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddTrackingComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  trackingRespone:showtrackingidresponse|undefined;
  insertRespone!:insertresponse;

  listrespone!:showconsignmentresponse;
  cosignmentlist!:showconsignmentdata[];

  warehouserespone!:showarehouseresponse;
  warehouselist!:showarehousedata[];

  trackinglist!:showtrackingdata[];
  trackingData:showtrackingdata={
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
    status: 1, 
    added_by:0
};
tracking_id_pk=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.tracking_id_pk=params['id'];
    });
    this.ConsignmentList();
    this.WarehouseList();
   
    if(this.tracking_id_pk==0||this.tracking_id_pk==undefined)
    {
      this.trackingData=new showtrackingdata();
    }
    else{
      console.log();
      this.TrackingData();
    }
  }
  ConsignmentList()
  {
    this.service.ConsignmentList()
    .subscribe(res=>{
      this.listrespone = res as showconsignmentresponse;
      this.cosignmentlist = this.listrespone.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  WarehouseList()
  {
    this.service.WarehouseList()
    .subscribe(res=>{
      this.warehouserespone = res as showarehouseresponse;
      this.warehouselist = this.warehouserespone.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
 
  
  TrackingData(){
    console.log("Tracking ID:"+this.tracking_id_pk);
    this.service.TrackingData(this.tracking_id_pk).subscribe(res=>{
      this.trackingRespone=res as showtrackingidresponse;
      this.trackingData=this.trackingRespone.data;
    },err=>{
      console.log(err);
    });
  }
  compareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  warehousecompareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }

  onSubmit(form:NgForm)
  { 
    console.log("tracking   ID:"+this.tracking_id_pk);
    if(this.tracking_id_pk== 0||this.tracking_id_pk==undefined)
    {
      this.AddTracking(form);
    }
    else{
      this.UpdateTracking(form);
    }
  }
  AddTracking(form:NgForm)
  {
    // console.log("Vehicle Data");
    // console.log(this.vehicleData);
    this.trackingData.added_by=1;
    this.service.AddTracking(this.trackingData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-tracking'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdateTracking(form:NgForm)
  {
    this.service.UpdateTracking(this.trackingData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-tracking'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  resetForm(form:NgForm)
  {
    form.form.reset();
    this.trackingData=new showtrackingdata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }

}
