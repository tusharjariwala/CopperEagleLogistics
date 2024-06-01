import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { getdataid } from '../models/getdataid';
import { showemployeedata } from '../models/showemployeedata';
import { showemployeeidresponse } from '../models/showemployeeidresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class HeaderComponent implements OnInit {
  EmployeeRespone:showemployeeidresponse|undefined;
  employeeData:showemployeedata={
    employee_id_pk: 0,
    employee_name: "",
    employee_email: "",
    type:"",
    employee_contactno:"",
    isActive: 0,
  };
  employee_id_pk=0;
  getdataresponse!:getdataid;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {

    this.service.EmployeeData(this.employeeData.employee_id_pk).subscribe(res=>{
      this.EmployeeRespone=res as showemployeeidresponse;
      this.employeeData=this.EmployeeRespone.data;
    },err=>{
      console.log(err);
    });
   this.employeeData.employee_id_pk = Number(sessionStorage.getItem('user_id'));
   
  }
  
 logout()
 {
  sessionStorage.clear();
   this.router.navigate(['/login']).then(() => {
    window.location.reload();
  });
 }
}
