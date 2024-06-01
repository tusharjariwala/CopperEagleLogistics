import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showcustomerdata } from '../models/showcustomerdata';
import { showcustomerresponse } from '../models/showcustomerresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-show-customer',
  templateUrl: './show-customer.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowCustomerComponent implements OnInit {
  customerlist:showcustomerdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showcustomerresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapi) { }

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
