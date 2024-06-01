import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showdriverdata } from '../models/showdriverdata';
import { showdriverresponse } from '../models/showdriverresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-show-driver',
  templateUrl: './show-driver.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowDriverComponent implements OnInit {
  driverlist:showdriverdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showdriverresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapi) { }

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
