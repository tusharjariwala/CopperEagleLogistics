import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { showdriverdashboarddata } from '../models/showdriverdashboarddata';
import { showemployeedashboarddata } from '../models/showemployeedashboarddata';
import { showtransportdashboarddata } from '../models/showtransportdashboarddata';
import { showvehicledashboarddata } from '../models/showvehicledashboarddata';
import { restapi } from '../services/restapiservice';
import { Utils } from '../services/utils.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class IndexComponent implements OnInit {
driverlist:showdriverdashboarddata | undefined;
vehiclelist:showvehicledashboarddata | undefined;
trasportlist:showtransportdashboarddata | undefined;
employeelist:showemployeedashboarddata | undefined;
data1=0;
data2=0;
data3=0;
data4=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { 
  }

  ngOnInit(): void {
    this.service.DriverListCount()
    .subscribe(res=>{
      this.driverlist = res as  showdriverdashboarddata;
      this.data1  =  this.driverlist.data
      console.log(this.data1)
    },err=>{
      console.log(err);
    })
  
  this.service.VehicleListCount()
    .subscribe(res=>{
      this.vehiclelist = res as  showvehicledashboarddata;
      this.data2  =  this.vehiclelist.data
      console.log(this.data2)
    },err=>{
      console.log(err);
    })
    this.service.TransportListCount()
    .subscribe(res=>{
      this.trasportlist = res as  showtransportdashboarddata;
      this.data3  =  this.trasportlist.data
      console.log(this.data3)
    },err=>{
      console.log(err);
    })
    this.service.EmployeetListCount()
    .subscribe(res=>{
      this.employeelist = res as  showemployeedashboarddata;
      this.data4  =  this.employeelist.data
      console.log(this.data4)
    },err=>{
      console.log(err);
    })
  }
}



