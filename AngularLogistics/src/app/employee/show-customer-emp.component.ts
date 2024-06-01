import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showcustomerdata } from '../models/showcustomerdata';
import { showcustomerresponse } from '../models/showcustomerresponse';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-show-customer-emp',
  templateUrl: './show-customer-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowCustomerEmpComponent implements OnInit {
  customerlist:showcustomerdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showcustomerresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapiemployee) { }

  ngOnInit(): void {
    this.CustomerList();
  }
  CustomerList()
  {
    this.service.CustomerList()
    .subscribe(res=>{
      this.listresponse = res as showcustomerresponse;
      this.customerlist = this.listresponse.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeleteCustomer(id:number)
  {
    console.log("Customer  ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteCustomer(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.CustomerList();
      },err=>{
        console.log(err);
      });
    }

}

}
