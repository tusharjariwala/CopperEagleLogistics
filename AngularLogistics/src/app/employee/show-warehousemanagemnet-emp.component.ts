import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showarehouseresponse } from '../models/showarehouseresponse';
import { showarehousedata } from '../models/showwarehousedata';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-show-warehousemanagemnet-emp',
  templateUrl: './show-warehousemanagemnet-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowWarehousemanagemnetEmpComponent implements OnInit {
  Warehouseslist:showarehousedata[] | undefined
  listresponse:showarehouseresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapiemployee) { }

  ngOnInit(): void {
    this.WarehouseList();
  }
  WarehouseList()
  {
    this.service.WarehouseList()
    .subscribe(res=>{
      this.listresponse = res as showarehouseresponse;
      this.Warehouseslist = this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeleteWarehouse(id:number)
  {
    console.log("warehouse ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteWarehouse(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.WarehouseList();
      },err=>{
        console.log(err);
      });
    }
  }
}
