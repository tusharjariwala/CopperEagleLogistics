import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showconsignmentdata } from '../models/showconsignmentdata';
import { showconsignmentresponse } from '../models/showconsignmentresponse';
import { showcontainerdata } from '../models/showcontainerdata';
import { showcontainerresponse } from '../models/showcontainerresponse';
import { showtrasportdata } from '../models/showtrasportdata';
import { showtrasportitemsdata } from '../models/showtrasportitemsdata';
import { showtrasportitemsidresponse } from '../models/showtrasportitemsidresponse';
import { showtrasportresponse } from '../models/showtrasportresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-add-transportitems',
  templateUrl: './add-transportitems.component.html',
  styles: [
  ]
})
export class AddTransportitemsComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  transportitemsRespone:showtrasportitemsidresponse|undefined;
  insertRespone!:insertresponse;

  listrespone!:showconsignmentresponse;
  cosignmentlist!:showconsignmentdata[];

  transportrespone!:showtrasportresponse;
  transportlist!:showtrasportdata[];

  containerrespone!:showcontainerresponse;
  containerlist!:showcontainerdata[];

  transportitemslist!:showtrasportitemsdata[];
  transportitemsData:showtrasportitemsdata={
    trasportitems_id_pk: 0,
    transport_id_fk: 0,
    pick_up_date: "",
    devlivery_date: "",
    type: "",
    cargo_type: "",
    container_id_fk:0,
    container_name: "",
    container_number: "",
    delivery_days: "",
    departed_date: "",
    expected_date: "",
    consignment_id_fk: 0,
    consignment_number: "",
    package_type: 0,
    deliver_date: "",
    booking_date: "",
    sender_address: "",
    receiver_address: "",
    receiver_person: "",
    weight: "",
    status: 0,
    tracking_id: 0,
  
};
trasportitems_id_pk=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.transportitemsData.transport_id_fk=params['id'];
    });
    this.ConsignmentList();
    this.TransportList();
    this.ContainerList();
    // if(this.trasportitems_id_pk==0||this.trasportitems_id_pk==undefined)
    // {
    //   this.transportitemsData=new showtrasportitemsdata();
    // }
    // else{
    //   console.log();
    //   this.TransportitemsListData();
    // }
  }
  ConsignmentList()
  {
    this.service.ConsignmentList()
    .subscribe(res=>{
      this.listrespone = res as showconsignmentresponse;
      this.cosignmentlist = this.listrespone.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  TransportList()
  {
    this.service.TransportList()
    .subscribe(res=>{
      this.transportrespone = res as showtrasportresponse;
      this.transportlist = this.transportrespone.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  ContainerList()
  {
    this.service.ContainerList()
    .subscribe(res=>{
      this.containerrespone = res as showcontainerresponse;
      this.containerlist = this.containerrespone.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
 
  
  TransportitemsListData(){
    console.log("transportitems  ID:"+this.trasportitems_id_pk);
    this.service.TransportitemsListData(this.trasportitems_id_pk).subscribe(res=>{
      this.transportitemsRespone=res as showtrasportitemsidresponse;
      this.transportitemsData=this.transportitemsRespone.data;
    },err=>{
      console.log(err);
    });
  }
  
  consignementFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  conatinercompareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }
  trasportcompareFn(c1:any,c2:any):boolean
  {
   return c1 &&c2 ?c1.id ===c2.id: c1===c2;
  }

  onSubmit(form:NgForm)
  { 
    console.log("transportitems   ID:"+this.trasportitems_id_pk);
    this.AddTransportitems(form);
    // if(this.trasportitems_id_pk== 0||this.trasportitems_id_pk==undefined)
    // {
    //   this.AddTransportitems(form);
    // }
    // else{
    //   this.UpdateTransportitems(form);
    // }
  }
  AddTransportitems(form:NgForm)
  {
    // console.log("Vehicle Data");
    // console.log(this.vehicleData);
    // this.transportitemsData.added_by=1;
    this.service.AddTransportitems(this.transportitemsData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-transportmanagement'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdateTransportitems(form:NgForm)
  {
    this.service.UpdateTransportitems(this.transportitemsData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-transportitems'],{relativeTo:this.route});
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
    this.transportitemsData=new showtrasportitemsdata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }

}
