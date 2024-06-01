import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showdriverdata } from '../models/showdriverdata';
import { showdriveridresponse } from '../models/showdriveridresponse';
import { showvehicledata } from '../models/showvehicledata';
import { showvehicleresponse } from '../models/showvehicleresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-add-driver',
  templateUrl: './add-driver.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddDriverComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  driverRespone:showdriveridresponse|undefined;
  insertRespone!:insertresponse;
  listrespone!:showvehicleresponse;
  vehiclelist!:showvehicledata[];
  driverlist!:showdriverdata[];
driverData:showdriverdata={
  driver_id_pk: 0,
    driver_name: "",
    driver_licence:"",
    driver_contactno: "",
    address:"",
    vehicle_id_fk: 0,
    vehicle_name: "",
    isactive: 1,
    vehicle_number:"",
    added_by:0
};
driver_id_pk=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.driver_id_pk=params['id'];
    });
    this.vehicleList();
    if(this.driver_id_pk==0||this.driver_id_pk==undefined)
    {
      this.driverData=new showdriverdata();
    }
    else{
      console.log();
      this.DriverData();
    }
  }
  vehicleList()
  {
    this.service.vehicleList()
    .subscribe(res=>{
      this.listrespone = res as showvehicleresponse;
      this.vehiclelist = this.listrespone.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DriverData(){
    console.log("Driver ID:"+this.driver_id_pk);
    this.service.DriverData(this.driver_id_pk).subscribe(res=>{
      this.driverRespone=res as showdriveridresponse;
      this.driverData=this.driverRespone.data;
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
    console.log("vehicle  ID:"+this.driver_id_pk);
    if(this.driver_id_pk== 0||this.driver_id_pk==undefined)
    {
      this.AddDriver(form);
    }
    else{
      this.UpdateDriver(form);
    }
  }
  AddDriver(form:NgForm)
  {
    // console.log("Vehicle Data");
    // console.log(this.vehicleData);
    this.driverData.added_by=1;
    this.service.AddDriver(this.driverData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-driver'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdateDriver(form:NgForm)
  {
    this.service.UpdateDriver(this.driverData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-driver'],{relativeTo:this.route});
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
    this.driverData=new showdriverdata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }
}
