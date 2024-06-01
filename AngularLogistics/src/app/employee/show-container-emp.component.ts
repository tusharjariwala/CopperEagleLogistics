import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showcontainerdata } from '../models/showcontainerdata';
import { showcontainerresponse } from '../models/showcontainerresponse';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-show-container-emp',
  templateUrl: './show-container-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowContainerEmpComponent implements OnInit {
  containerlist:showcontainerdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showcontainerresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapiemployee) { }

  ngOnInit(): void {
    this.ContainerList();
  }
  
  ContainerList()
  {
    this.service.ContainerList()
    .subscribe(res=>{
      this.listresponse = res as showcontainerresponse;
      this.containerlist = this.listresponse.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeleteContainer(id:number)
  {
    console.log("Container  ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteContainer(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.ContainerList();
      },err=>{
        console.log(err);
      });
    }

}

}
