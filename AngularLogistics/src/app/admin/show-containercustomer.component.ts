import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { insertresponse } from '../models/insertresponse';
import { showcontainercustomerdata } from '../models/showcontainercustomerdata';
import { showcontainercustomerrespone } from '../models/showcontainercustomerrespone';
import { showcustomerdata } from '../models/showcustomerdata';
import { showcustomerresponse } from '../models/showcustomerresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-show-containercustomer',
  templateUrl: './show-containercustomer.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowContainercustomerComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  containercustomerlist:showcontainercustomerdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showcontainercustomerrespone | undefined
  insertRespone!:insertresponse;
  customerrespone!:showcustomerresponse;
  customerlist!:showcustomerdata[];

  
  containercustomerData:showcontainercustomerdata={
    container_customerid_pk: 0,
    container_id_fk: 0,
    container_name: "",
    container_number: "",
    delivery_days: "",
    departed_date: "",
    customer_id_fk: 0,
    customer_name: "",
    company_name: "",
    company_contact: "",
    phonenumber: "",
    no_of_parcels: "",
    added_by:0
};
container_customerid_pk=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    

    this.route.params.subscribe((params:Params)=>{
      this.containercustomerData.container_id_fk=params['id'];
    });
    this.ContainerCustomerList();
    
    this.CustomerList();
  }
  customercompareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }

  onSubmit(form:NgForm)
  { 
    
    console.log("container customer   ID:"+this.container_customerid_pk);
    this.AddContainerCustomer(form);
  
   
  }
  AddContainerCustomer(form:NgForm)
  {
   
    this.containercustomerData.added_by=1;
    this.service.AddContainerCustomer(this.containercustomerData).subscribe(res=>{
      console.log(res);
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result==="success")
      {
        // this.resetForm(form);
        this.router.navigate(['/admin/show-containercustomer'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
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
  
  ContainerCustomerList()
  {
    this.service.ContainerCustomerList(this.containercustomerData.container_id_fk)
    .subscribe(res=>{
      this.listresponse = res as showcontainercustomerrespone;
      this.containercustomerlist = this.listresponse.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  
  DeleteContainerCustomer(id:number)
  {
    console.log("ContainerCustomer  ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteContainerCustomer(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.ContainerCustomerList();
      },err=>{
        console.log(err);
      });
    }

}

}
