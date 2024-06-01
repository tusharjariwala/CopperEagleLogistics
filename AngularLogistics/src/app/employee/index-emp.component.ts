import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { showconsignmentdashboarddata } from '../models/showconsignmentdashboarddata';
import { showcontainerdashboard } from '../models/showcontainerdashboard';
import { showcustomerdashboarddata } from '../models/showcustomerdashboarddata';
import { showwarehousedashboarddata } from '../models/showwarehousedashboarddata';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-index-emp',
  templateUrl: './index-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class IndexEmpComponent implements OnInit {
  customerlist : showcustomerdashboarddata | undefined;
   containerlist : showcontainerdashboard | undefined;
   consignmentlist : showconsignmentdashboarddata | undefined;
  warehosuelist : showwarehousedashboarddata | undefined;
data1=0;
data2=0;
data3=0;
data4=0;
  constructor(private service:restapiemployee,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.service.CustomerListCount()
    .subscribe(res=>{
      this.customerlist = res as  showcustomerdashboarddata;
      this.data1  =  this.customerlist.data
      console.log(this.data1)
    },err=>{
      console.log(err);
    })
    this.service.ContainerListCount()
    .subscribe(res=>{
      this.containerlist = res as  showcontainerdashboard;
      this.data2  =  this.containerlist.data
      console.log(this.data2)
    },err=>{
      console.log(err);
    })
    this.service.ConsigmentListCount()
    .subscribe(res=>{
      this.consignmentlist = res as  showconsignmentdashboarddata;
      this.data3  =  this.consignmentlist.data
      console.log(this.data3)
    },err=>{
      console.log(err);
    })
    this.service.WarehouseListCount()
    .subscribe(res=>{
      this.warehosuelist = res as  showwarehousedashboarddata;
      this.data4  =  this.warehosuelist.data
      console.log(this.data4)
    },err=>{
      console.log(err);
    })
  }

}
