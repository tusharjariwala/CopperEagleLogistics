import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showconsignmentproductdata } from '../models/showconsignmentproductdata';
import { showconsignmentproductidresponse } from '../models/showconsignmentproductidresponse';
import { showconsignmentproductresponse } from '../models/showconsignmentproductresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-show-consignmentproduct',
  templateUrl: './show-consignmentproduct.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowConsignmentproductComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  consignmentproductRespone:showconsignmentproductidresponse|undefined;
  insertRespone!:insertresponse;
  listresponse:showconsignmentproductresponse | undefined
  consignmentproductlist!:showconsignmentproductdata[];
  consignmentproductData:showconsignmentproductdata={
    consignmentproduct_id_pk: 0,
    isfargile: 0,
    consignment_id_fk:0,
    name:"",
    isactive: 0,
    added_by:0

};
consignmentproduct_id_pk=0;
  
 
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.consignmentproductData.consignment_id_fk=params['id'];
    });
    this.ConsignmentProductList();
  }

  ConsignmentProductData(){
    console.log("packagetype ID:"+this.consignmentproduct_id_pk);
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
    
    this.AddConsignmentproduct(form);
    
  }
  AddConsignmentproduct(form:NgForm)
  {
    this.consignmentproductData.added_by=1;
    this.service.AddConsignmentproduct(this.consignmentproductData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
       
        this.router.navigate(['/admin/show-consingmentproduct'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  ConsignmentProductList()
  {
    this.service.ConsignmentProductList(this.consignmentproductData.consignment_id_fk)
    .subscribe(res=>{
      this.listresponse = res as showconsignmentproductresponse;
      this.consignmentproductlist = this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeleteConsignmentProduct(id:number)
  {
    console.log("ConsignmentProduct  ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteConsignmentProduct(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.ConsignmentProductList();
      },err=>{
        console.log(err);
      });
    }
  }
}
