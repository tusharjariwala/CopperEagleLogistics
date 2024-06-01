import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showdriverdata } from '../models/showdriverdata';
import { showdriverresponse } from '../models/showdriverresponse';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-show-driver-emp',
  templateUrl: './show-driver-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowDriverEmpComponent implements OnInit {
  driverlist:showdriverdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showdriverresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapiemployee) { }

  ngOnInit(): void {
    this.DriverList();
  }
  DriverList()
  {
    this.service.DriverList()
    .subscribe(res=>{
      this.listresponse = res as showdriverresponse;
      this.driverlist = this.listresponse.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeleteDriver(id:number)
  {
    console.log("Driver  ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteDriver(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.DriverList();
      },err=>{
        console.log(err);
      });
    }
  }

}
