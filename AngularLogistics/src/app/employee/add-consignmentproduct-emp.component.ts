import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showconsignmentproductdata } from '../models/showconsignmentproductdata';
import { showconsignmentproductidresponse } from '../models/showconsignmentproductidresponse';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-add-consignmentproduct-emp',
  templateUrl: './add-consignmentproduct-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddConsignmentproductEmpComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  consignmentproductRespone:showconsignmentproductidresponse|undefined;
  insertRespone!:insertresponse;
  consignmentproductlist!:showconsignmentproductdata[];
  consignmentproductData:showconsignmentproductdata={
    consignmentproduct_id_pk: 0,
    consignment_id_fk:0,
    isfargile: 0,
    name:"",
    isactive: 0,
    added_by:0
};
consignmentproduct_id_pk=0;
  constructor(private service:restapiemployee,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.consignmentproductData.consignment_id_fk=params['id'];
    });
    // if(this.consignmentproduct_id_pk==0||this.consignmentproduct_id_pk==undefined)
    // {
    //   this.consignmentproductData=new showconsignmentproductdata();
    // }
    // else{
    //   console.log();
    //   this.ConsignmentProductData();
    // }
  }
  ConsignmentProductData(){
    console.log("consignmentproduct id :"+this.consignmentproduct_id_pk);
    this.service.ConsignmentProductData(this.consignmentproduct_id_pk).subscribe(res=>{
      this.consignmentproductRespone=res as showconsignmentproductidresponse;
      this.consignmentproductData=this.consignmentproductRespone.data;
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
    console.log("consignmentproduct ID:"+this.consignmentproduct_id_pk);
    // if(this.consignmentproduct_id_pk==0||this.consignmentproduct_id_pk==undefined)
    // {
    //   this.AddConsignmentproduct(form);
    // }
    // else{
    //   this.UpdateConsignmentProduct(form);
    // }
  
    this.AddConsignmentproduct(form);
  }
  AddConsignmentproduct(form:NgForm)
  {
    this.consignmentproductData.added_by=1;
    this.service.AddConsignmentproduct(this.consignmentproductData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/employee/show-consignment-emp'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
    
  }
  UpdateConsignmentProduct(form:NgForm)
  {
    this.service.UpdateConsignmentProduct(this.consignmentproductData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/employee/show-consingmentproduct-emp'],{relativeTo:this.route});
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
    this.consignmentproductData=new showconsignmentproductdata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }

}
