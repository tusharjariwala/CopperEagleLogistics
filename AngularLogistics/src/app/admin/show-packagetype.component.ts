import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showpackagetypedata } from '../models/showpackagetypedata';
import { showpackagetyperesponse } from '../models/showpackagetyperesponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-show-packagetype',
  templateUrl: './show-packagetype.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowPackagetypeComponent implements OnInit {
  packagetypelist:showpackagetypedata[] | undefined
  listresponse:showpackagetyperesponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapi) { }

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
