import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showpackagetypedata } from '../models/showpackagetypedata';
import { showpackagetypeidresponse } from '../models/showpackagetypeidresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-add-packagetype',
  templateUrl: './add-packagetype.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddPackagetypeComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  PackagetypeRespone:showpackagetypeidresponse|undefined;
  insertRespone!:insertresponse;
  packagetypelist!:showpackagetypedata[];
packagetypeData:showpackagetypedata={
  packagetype_id_pk: 0,
    code :"",
    name: "",
    isactive: 0,
    added_by:0
};
packagetype_id_pk=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.packagetype_id_pk=params['id'];
    });
    if(this.packagetype_id_pk==0||this.packagetype_id_pk==undefined)
    {
      this.packagetypeData=new showpackagetypedata();
    }
    else{
      console.log();
      this.PackagetypeData();
    }
  }
  PackagetypeData(){
    console.log("packagetype ID:"+this.packagetype_id_pk);
    this.service.PackagetypeData(this.packagetype_id_pk).subscribe(res=>{
      this.PackagetypeRespone=res as showpackagetypeidresponse;
      this.packagetypeData=this.PackagetypeRespone.data;
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
    console.log("Employee ID:"+this.packagetype_id_pk);
    if(this.packagetype_id_pk==0||this.packagetype_id_pk==undefined)
    {
      this.AddPackagetype(form);
    }
    else{
      this.UpdatePackagetype(form);
    }
  }
  AddPackagetype(form:NgForm)
  {
    this.packagetypeData.added_by=1;
    this.service.AddPackagetype(this.packagetypeData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-packagetype'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdatePackagetype(form:NgForm)
  {
    this.service.UpdatePackagetype(this.packagetypeData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-packagetype'],{relativeTo:this.route});
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
    this.packagetypeData=new showpackagetypedata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }

}
