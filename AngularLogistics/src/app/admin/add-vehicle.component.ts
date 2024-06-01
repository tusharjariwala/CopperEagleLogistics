import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showarehouseresponse } from '../models/showarehouseresponse';
import { showvehicledata } from '../models/showvehicledata';
import { showvehicleidresponse } from '../models/showvehicleidresponse';
import { showarehousedata } from '../models/showwarehousedata';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-add-vehicle',
  templateUrl: './add-vehicle.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddVehicleComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  VehicleRespone:showvehicleidresponse|undefined;
  insertRespone!:insertresponse;
  listrespone!:showarehouseresponse;
  warehouseList!:showarehousedata[];
  vehiclelist!:showvehicledata[];
vehicleData:showvehicledata={
  vehicle_id_pk: 0,
  vehicle_name: "",
  vehicle_type: "",
  vehicle_number: "",
  vehicle_loadamount: "",
  warehouse_id_fk: 0,
  warehouse_name: "",
  address: "",
  type: "",
  isactive: 1,
  added_by:0
};
vehicle_id_pk=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.vehicle_id_pk=params['id'];
    });
    this.WarehouseList();
    if(this.vehicle_id_pk==0||this.vehicle_id_pk==undefined)
    {
      this.vehicleData=new showvehicledata();
    }
    else{
      console.log();
      this.VehicleData();
    }
  }
  WarehouseList()
  {
    this.service.WarehouseList()
    .subscribe(res=>{
      this.listrespone = res as showarehouseresponse;
      this.warehouseList = this.listrespone.data;
    },err=>{
      console.log(err);
    })
  }
  VehicleData(){
    console.log("Vehicle ID:"+this.vehicle_id_pk);
    this.service.VehicleData(this.vehicle_id_pk).subscribe(res=>{
      this.VehicleRespone=res as showvehicleidresponse;
      this.vehicleData=this.VehicleRespone.data;
    },err=>{
      console.log(err);
    });
  }
  compareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  warecompareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  onSubmit(form:NgForm)
  { 
    console.log("vehicle  ID:"+this.vehicle_id_pk);
    if(this.vehicle_id_pk== 0||this.vehicle_id_pk==undefined)
    {
      this.AddVehicle(form);
    }
    else{
      this.UpdateVehicle(form);
    }
  }
  AddVehicle(form:NgForm)
  {
    this.vehicleData.added_by=1;
    console.log("Vehicle Data");
    console.log(this.vehicleData);
    this.service.AddVehicle(this.vehicleData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-vehicle'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdateVehicle(form:NgForm)
  {
    this.service.UpdateVehicle(this.vehicleData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-vehicle'],{relativeTo:this.route});
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
    this.vehicleData=new showvehicledata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }

}
