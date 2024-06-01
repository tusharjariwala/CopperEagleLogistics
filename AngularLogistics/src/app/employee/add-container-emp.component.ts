import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showcontainerdata } from '../models/showcontainerdata';
import { showcontaineridresponse } from '../models/showcontaineridresponse';
import { showemployeedata } from '../models/showemployeedata';
import { showemployeeresponse } from '../models/showemployeeresponse';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-add-container-emp',
  templateUrl: './add-container-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddContainerEmpComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  containerRespone:showcontaineridresponse|undefined;
  insertRespone!:insertresponse;

  listrespone!:showemployeeresponse;
  employeelist!:showemployeedata[];

  containerlist!:showcontainerdata[];
  containerData:showcontainerdata={
    container_id_pk:0,
    container_name: "",
    delivery_days: "",
    departed_date: "",
    expected_date: "",
    status1: 1,
    employee_id_fk: 0,
    employee_name: "",
    employee_email: "",
    employee_contactno: "",
    container_number1: "",
    isactive: 1,
    tracking_id:0,
};
container_id_pk=0;
  constructor(private service:restapiemployee,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.container_id_pk=params['id'];
    });
    this.Employelist();
   
    if(this.container_id_pk==0||this.container_id_pk==undefined)
    {
      this.containerData=new showcontainerdata();
    }
    else{
      console.log();
      this.ContainerData();
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
 
  ContainerData(){
    console.log("Container ID:"+this.container_id_pk);
    this.service.ContainerData(this.container_id_pk).subscribe(res=>{
      this.containerRespone=res as showcontaineridresponse;
      this.containerData=this.containerRespone.data;
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
    console.log("container  ID:"+this.container_id_pk);
    if(this.container_id_pk== 0||this.container_id_pk==undefined)
    {
      this.AddContainer(form);
    }
    else{
      this.UpdateContainer(form);
    }
  }
  AddContainer(form:NgForm)
  {
    // console.log("Vehicle Data");
    // console.log(this.vehicleData);
    this.containerData.employee_id_fk=1;
    const number= Math.floor((Math.random()*100000));
    this.containerData.tracking_id=number;
    this.service.AddContainer(this.containerData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/employee/add-containercustomer-emp',this.insertRespone.data],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdateContainer(form:NgForm)
  {
    this.service.UpdateContainer(this.containerData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/employee/show-container-emp'],{relativeTo:this.route});
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
    this.containerData=new showcontainerdata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }
}
