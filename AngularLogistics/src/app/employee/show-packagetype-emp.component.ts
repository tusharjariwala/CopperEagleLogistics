import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showpackagetypedata } from '../models/showpackagetypedata';
import { showpackagetyperesponse } from '../models/showpackagetyperesponse';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-show-packagetype-emp',
  templateUrl: './show-packagetype-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowPackagetypeEmpComponent implements OnInit {
  packagetypelist:showpackagetypedata[] | undefined
  listresponse:showpackagetyperesponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapiemployee) { }

  ngOnInit(): void {
    this.PackagetypeList();
  }
  PackagetypeList()
  {
    this.service.PackagetypeList()
    .subscribe(res=>{
      this.listresponse = res as showpackagetyperesponse;
      this.packagetypelist = this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeletePackagetype(id:number)
  {
    console.log("Packagetype  ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeletePackagetype(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.PackagetypeList();
      },err=>{
        console.log(err);
      });
    }
  }

}
