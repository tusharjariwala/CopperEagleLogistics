import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showemployeedata } from '../models/showemployeedata';
import { showemployeeresponse } from '../models/showemployeeresponse';

import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-show-employee',
  templateUrl: './show-employee.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowEmployeeComponent implements OnInit {
  employeelist:showemployeedata[] | undefined
  listresponse:showemployeeresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapi) { }

  ngOnInit(): void {
    this.Employelist();
  }
  Employelist()
  {
    this.service.Employelist()
    .subscribe(res=>{
      this.listresponse = res as showemployeeresponse;
      this.employeelist = this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeleteEmployee(id:number)
  {
    console.log("employe ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteEmployee(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.Employelist();
      },err=>{
        console.log(err);
      });
    }
  }
}
