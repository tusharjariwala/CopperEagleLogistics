import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showarehouseidresponse } from '../models/showarehouseidresponse';

import { showarehousedata } from '../models/showwarehousedata';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-add-warehousemanagemnet',
  templateUrl: './add-warehousemanagemnet.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddWarehousemanagemnetComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  warehouseRespone:showarehouseidresponse|undefined;
  insertRespone!:insertresponse;
  warehouseList!:showarehousedata[];
warehouseData:showarehousedata={
 
  warehouse_id_pk: 0,
    warehouse_name: "",
    type1: "",
    contactperson_name: "",
    contactperson_number:"",
    capacity:"",
    address: "",
    isactive: 0,
    added_by:0
};
warehouse_id_pk=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.warehouse_id_pk=params['id'];
    });
    if(this.warehouse_id_pk==0||this.warehouse_id_pk==undefined)
    {
      this.warehouseData=new showarehousedata();
    }
    else{
      console.log();
      this.WarehouseData();
    }
  }
  WarehouseData(){
    console.log("Warehouse  ID:"+this.warehouse_id_pk);
    this.service.WarehouseData(this.warehouse_id_pk).subscribe(res=>{
      this.warehouseRespone=res as showarehouseidresponse;
      this.warehouseData=this.warehouseRespone.data;
    },err=>{
      console.log(err);
    });
  }
  compareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  onSubmit(form:NgForm)
  { 
    console.log("warehouse ID:"+this.warehouse_id_pk);
    if(this.warehouse_id_pk==0||this.warehouse_id_pk==undefined)
    {
      this.AddWarehouse(form);
    }
    else{
      this.UpdateWarehouse(form);
    }
  }
  AddWarehouse(form:NgForm)
  {
    this.warehouseData.added_by=1;
    this.service.AddWarehouse(this.warehouseData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-warehousemanagemnet'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdateWarehouse(form:NgForm)
  {
    this.service.UpdateWarehouse(this.warehouseData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-warehousemanagemnet'],{relativeTo:this.route});
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
    this.warehouseData=new showarehousedata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }


}
