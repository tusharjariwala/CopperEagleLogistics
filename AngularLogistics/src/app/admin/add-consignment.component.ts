import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showconsignmentdata } from '../models/showconsignmentdata';
import { showconsignmentidresponse } from '../models/showconsignmnetidresponse';
import { showcustomerdata } from '../models/showcustomerdata';
import { showcustomerresponse } from '../models/showcustomerresponse';
import { showemployeedata } from '../models/showemployeedata';
import { showemployeeresponse } from '../models/showemployeeresponse';
import { showpackagetypedata } from '../models/showpackagetypedata';
import { showpackagetyperesponse } from '../models/showpackagetyperesponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-add-consignment',
  templateUrl: './add-consignment.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddConsignmentComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  consignmentRespone:showconsignmentidresponse|undefined;
  insertRespone!:insertresponse;

  listrespone!:showemployeeresponse;
  employeelist!:showemployeedata[];

  customerrespone!:showcustomerresponse;
  customerlist!:showcustomerdata[];

  packagetyperespone!:showpackagetyperesponse;
  packagetypelist!:showpackagetypedata[];

  consignmentlist!:showconsignmentdata[];
consignmentData:showconsignmentdata={
  consignment_id_pk: 0,
    employee_id_fk: 0,
    customer_id_fk: 0,
    consignment_number: "",
    package_type: 0,
    deliver_date: "",
    booking_date: "",
    sender_address: "",
    receiver_address: "",
    receiver_person: "",
    packagetype_id_fk: 0,
    description: "",
    status: 1,
    weight: "",
    employee_name: "",
    employee_email: "",
    employee_contactno: "",
    customer_name: "",
    company_name: "",
    company_contact: "",
    phonenumber: "",
    code: "",
    name: "",
    isactive: 1,
    tracking_id: 0,
};
consignment_id_pk=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.consignment_id_pk=params['id'];
    });
    this.Employelist();
    this.CustomerList();
    this.PackagetypeList();
    if(this.consignment_id_pk==0||this.consignment_id_pk==undefined)
    {
      this.consignmentData=new showconsignmentdata();
    }
    else{
      console.log();
      this.ConsigmentData();
    }
  }
  Employelist()
  {
    this.service.Employelist()
    .subscribe(res=>{
      this.listrespone = res as showemployeeresponse;
      this.employeelist = this.listrespone.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  CustomerList()
  {
    this.service.CustomerList()
    .subscribe(res=>{
      this.customerrespone = res as showcustomerresponse;
      this.customerlist = this.customerrespone.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  PackagetypeList()
  {
    this.service.PackagetypeList()
    .subscribe(res=>{
      this.packagetyperespone = res as showpackagetyperesponse;
      this.packagetypelist = this.packagetyperespone.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  
  ConsigmentData(){
    console.log("Consigment ID:"+this.consignment_id_pk);
    this.service.ConsigmentData(this.consignment_id_pk).subscribe(res=>{
      this.consignmentRespone=res as showconsignmentidresponse;
      this.consignmentData=this.consignmentRespone.data;
    },err=>{
      console.log(err);
    });
  }
  compareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  customercompareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  packagetypecompareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
 
  onSubmit(form:NgForm)
  { 
    console.log("consignment  ID:"+this.consignment_id_pk);
    if(this.consignment_id_pk== 0||this.consignment_id_pk==undefined)
    {
      this.AddConsignment(form);
    }
    else{
      this.UpdateConsignment(form);
    }
  }
  AddConsignment(form:NgForm)
  {
    // console.log("Vehicle Data");
    // console.log(this.vehicleData);
    const number= Math.floor((Math.random()*100000));
    this.consignmentData.tracking_id=number;
    this.service.AddConsignment(this.consignmentData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/add-consingmentproduct',this.insertRespone.data],{relativeTo:this.route});
        // ,this.insertRespone.data
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdateConsignment(form:NgForm)
  {
    this.service.UpdateConsignment(this.consignmentData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-consignment'],{relativeTo:this.route});
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
    this.consignmentData=new showconsignmentdata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }
}
