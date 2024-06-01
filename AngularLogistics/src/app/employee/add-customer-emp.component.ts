import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showcitydata } from '../models/showcitydata';
import { showcityresponse } from '../models/showcityresponse';
import { showcustomerdata } from '../models/showcustomerdata';
import { showcustomeridresponse } from '../models/showcustomeridresponse';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-add-customer-emp',
  templateUrl: './add-customer-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddCustomerEmpComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  customerRespone:showcustomeridresponse|undefined;
  insertRespone!:insertresponse;
  listrespone!:showcityresponse;
  citylist!:showcitydata[];

  customerlist!:showcustomerdata[];
  customerData:showcustomerdata={
    customer_id_pk:0,
    customer_name:"",
    company_name: "",
    company_contact: "",
    phonenumber:"",
    email:"",
    address1:"",
    isActive:0,
    city_id_fk: 0,
    city_name: "",
    added_by:0
};
customer_id_pk=0;
  constructor(private service:restapiemployee,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.customer_id_pk=params['id'];
    });
    
    this.cityList();
    if(this.customer_id_pk==0||this.customer_id_pk==undefined)
    {
      this.customerData=new showcustomerdata();
    }
    else{
      console.log();
      this.CustomerData();
    }
  }
  cityList()
  {
    this.service.cityList()
    .subscribe(res=>{
      this.listrespone = res as showcityresponse;
      this.citylist = this.listrespone.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  CustomerData(){
    console.log("Customer ID:"+this.customer_id_pk);
    this.service.CustomerData(this.customer_id_pk).subscribe(res=>{
      this.customerRespone=res as showcustomeridresponse;
      this.customerData=this.customerRespone.data;
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
    console.log("customer  ID:"+this.customer_id_pk);
    if(this.customer_id_pk== 0||this.customer_id_pk==undefined)
    {
      this.AddCustomer(form);
    }
    else{
      this.UpdateCustomer(form);
    }
  }
  AddCustomer(form:NgForm)
  {
    // console.log("Vehicle Data");
    // console.log(this.vehicleData);
    this.customerData.added_by=1;
    this.service.AddCustomer(this.customerData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/employee/show-customer-emp'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdateCustomer(form:NgForm)
  {
    this.service.UpdateCustomer(this.customerData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/employee/show-customer-emp'],{relativeTo:this.route});
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
    this.customerData=new showcustomerdata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }

}
