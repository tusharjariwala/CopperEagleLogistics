import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showvehicledata } from '../models/showvehicledata';
import { showvehicleresponse } from '../models/showvehicleresponse';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-show-vehicle-emp',
  templateUrl: './show-vehicle-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowVehicleEmpComponent implements OnInit {
  vehiclelist:showvehicledata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showvehicleresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapiemployee) { }

  ngOnInit(): void {
    this.vehicleList();
  }
  vehicleList()
  {
    this.service.vehicleList()
    .subscribe(res=>{
      this.listresponse = res as showvehicleresponse;
      this.vehiclelist = this.listresponse.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeleteVehicle(id:number)
  {
    console.log("vehicle  ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteVehicle(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.vehicleList();
      },err=>{
        console.log(err);
      });
    }
  }

}
