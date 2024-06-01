import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showarehouseresponse } from '../models/showarehouseresponse';
import { showconsignmentdata } from '../models/showconsignmentdata';
import { showconsignmentresponse } from '../models/showconsignmentresponse';
import { showtrasportdata } from '../models/showtrasportdata';
import { showtrasportidresponse } from '../models/showtrasportidresponse';
import { showvehicledata } from '../models/showvehicledata';
import { showvehicleresponse } from '../models/showvehicleresponse';
import { showarehousedata } from '../models/showwarehousedata';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-add-transportmanagement',
  templateUrl: './add-transportmanagement.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddTransportmanagementComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  transportRespone:showtrasportidresponse|undefined;
  insertRespone!:insertresponse;

  listrespone!:showconsignmentresponse;
  cosignmentlist!:showconsignmentdata[];

  warehouserespone!:showarehouseresponse;
  warehouselist!:showarehousedata[];

  vehiclerespone!:showvehicleresponse;
  vehiclelist!:showvehicledata[];

  transportlist!:showtrasportdata[];
  transportData:showtrasportdata={
    transport_id_pk: 0,
    pick_up_date: "",
    devlivery_date: "",
    vehicle_id_fk: 0,
    vehicle_name: "",
    vehicle_type: "",
    vehicle_number: "",
  
    fromwarehouse_fk: 0,
    towarehouse_fk: 0,
    isactive: 1,
    added_by:0,
    type: "",
    cargo_type: "",
  
};
transport_id_pk=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.transport_id_pk=params['id'];
    });
    this.ConsignmentList();
    this.WarehouseList();
    this.vehicleList();
    if(this.transport_id_pk==0||this.transport_id_pk==undefined)
    {
      this.transportData=new showtrasportdata();
    }
    else{
      console.log();
      this.TransportListData();
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
  vehicleList()
  {
    this.service.vehicleList()
    .subscribe(res=>{
      this.vehiclerespone = res as showvehicleresponse;
      this.vehiclelist = this.vehiclerespone.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
 
  
  TransportListData(){
    console.log("transport  ID:"+this.transport_id_pk);
    this.service.TransportListData(this.transport_id_pk).subscribe(res=>{
      this.transportRespone=res as showtrasportidresponse;
      this.transportData=this.transportRespone.data;
    },err=>{
      console.log(err);
    });
  }
  compareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  consignementFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  warehousecompareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  warehouseseccompareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }

  onSubmit(form:NgForm)
  { 
    console.log("transport   ID:"+this.transport_id_pk);
    if(this.transport_id_pk== 0||this.transport_id_pk==undefined)
    {
      this.AddTransport(form);
    }
    else{
      this.UpdateTransport(form);
    }
  }
  AddTransport(form:NgForm)
  {
    // console.log("Vehicle Data");
    // console.log(this.vehicleData);
    this.transportData.added_by=1;
    this.service.AddTransport(this.transportData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/add-transportitems',this.insertRespone.data],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdateTransport(form:NgForm)
  {
    this.service.UpdateTransport(this.transportData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-transportmanagement'],{relativeTo:this.route});
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
    this.transportData=new showtrasportdata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }

}
