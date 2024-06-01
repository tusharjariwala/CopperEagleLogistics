import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { getdataid } from '../models/getdataid';
import { insertresponse } from '../models/insertresponse';
import { showauthdata } from '../models/showauthdata';
import { showemployeedata } from '../models/showemployeedata';
import { showemployeeidresponse } from '../models/showemployeeidresponse';



import { restapi } from '../services/restapiservice';


@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddEmployeeComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  EmployeeRespone:showemployeeidresponse|undefined;
  getdataresponse!:getdataid;
  insertRespone!:insertresponse;
  employeelist!:showemployeedata[];
employeeData:showemployeedata={
  employee_id_pk: 0,
  employee_name: "",
  employee_email: "",
  type:"",
  employee_contactno:"",
  isActive: 0,
};
authData:showauthdata ={
  employee_email: "",
    password:"",
    user_id_fk: 0,
    user_type:"",
    auth_id_pk:0
};
employee_id_pk=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.employee_id_pk=params['id'];
    });
    if(this.employee_id_pk==0||this.employee_id_pk==undefined)
    {
      this.employeeData=new showemployeedata();
    }
    else{
      console.log();
      this.EmployeeData();
    }
  }
  EmployeeData(){
    console.log("employee ID:"+this.employee_id_pk);
    this.service.EmployeeData(this.employee_id_pk).subscribe(res=>{
      this.EmployeeRespone=res as showemployeeidresponse;
      this.employeeData=this.EmployeeRespone.data;
    },err=>{
      console.log(err);
    });
  }
  compareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  onSubmit(form:NgForm)
  { 
    console.log("Employee ID:"+this.employee_id_pk);
    if(this.employee_id_pk==0||this.employee_id_pk==undefined)
    {
      this.AddEmployee(form);
    }
    else{
      this.UpdateEmployee(form);
    }
  }
  AddEmployee(form:NgForm)
  {
    this.service.AddEmployee(this.employeeData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
         this.service.Employegetid().subscribe(res=>{
          this.getdataresponse=res as getdataid;
           if(this.getdataresponse.result === "success")
           {
             var employeeid=this.getdataresponse.data;
             var employeeemail=this.employeeData.employee_email;
             var employeecontact=this.employeeData.employee_contactno;
             console.log("employee ID:"+employeeid);
             this.authData= {
              employee_email: employeeemail,
              password: employeecontact,
              user_id_fk: employeeid,
              user_type: "emp",
              auth_id_pk:0
             };
             this.service.AddAuth(this.authData).subscribe(res =>{
              this.resetForm(form);
             });
           }
         })
      
        this.router.navigate(['/admin/show-employee'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdateEmployee(form:NgForm)
  {
    this.service.UpdateEmployee(this.employeeData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-employee'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  resetForm(form:NgForm)
  {
    form.form.reset();
    this.employeeData=new showemployeedata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }

}
