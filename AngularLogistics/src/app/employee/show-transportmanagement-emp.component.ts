import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showtrasportdata } from '../models/showtrasportdata';
import { showtrasportresponse } from '../models/showtrasportresponse';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-show-transportmanagement-emp',
  templateUrl: './show-transportmanagement-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowTransportmanagementEmpComponent implements OnInit {
  transportlist:showtrasportdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showtrasportresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapiemployee) { }

  ngOnInit(): void {
    this.TransportList();
  }
  TransportList()
  {
    this.service.TransportList()
    .subscribe(res=>{
      this.listresponse = res as showtrasportresponse;
      this.transportlist = this.listresponse.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeleteTransport(id:number)
  {
    console.log("Transport  ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteTransport(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.TransportList();
      },err=>{
        console.log(err);
      });
    }
  }


}
