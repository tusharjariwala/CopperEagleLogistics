import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showconsignmentdata } from '../models/showconsignmentdata';
import { showconsignmentresponse } from '../models/showconsignmentresponse';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-show-consignment-emp',
  templateUrl: './show-consignment-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowConsignmentEmpComponent implements OnInit {
  
  consignmentlist:showconsignmentdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showconsignmentresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapiemployee) { }

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
