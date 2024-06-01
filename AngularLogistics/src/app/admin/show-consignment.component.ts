import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showconsignmentdata } from '../models/showconsignmentdata';
import { showconsignmentresponse } from '../models/showconsignmentresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-show-consignment',
  templateUrl: './show-consignment.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowConsignmentComponent implements OnInit {
  consignmentlist:showconsignmentdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showconsignmentresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapi) { }

  ngOnInit(): void {
    this.ConsignmentList();
  }
  ConsignmentList()
  {
    this.service.ConsignmentList()
    .subscribe(res=>{
      this.listresponse = res as showconsignmentresponse;
      this.consignmentlist = this.listresponse.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeleteConsignment(id:number)
  {
    console.log("Consignment  ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteConsignment(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.ConsignmentList();
      },err=>{
        console.log(err);
      });
    }

}

}
