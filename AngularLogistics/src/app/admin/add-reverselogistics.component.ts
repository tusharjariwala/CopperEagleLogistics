import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { insertresponse } from '../models/insertresponse';
import { showconsignmentdata } from '../models/showconsignmentdata';
import { showconsignmentresponse } from '../models/showconsignmentresponse';
import { showreverselogisticsdata } from '../models/showreverselogisticsdata';
import { showreverselogisticsidresponse } from '../models/showreverselogisticsidresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-add-reverselogistics',
  templateUrl: './add-reverselogistics.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddReverselogisticsComponent implements OnInit {
  @ViewChild('f') slForm:NgForm | undefined;
  editMode=false;
  reverselogisticRespone:showreverselogisticsidresponse|undefined;
  insertRespone!:insertresponse;

  listrespone!:showconsignmentresponse;
  cosignmentlist!:showconsignmentdata[];

  
  reverselogisticlist!:showreverselogisticsdata[];
  reverselogisticData:showreverselogisticsdata={
    reverselogistics_id_pk: 0,
    datetime: "",
    consignment_id_fk: 0,
    consignment_number: "",
    deliver_date: "",
    sender_address: "",
    receiver_address: "",
    receiver_person: "",
    reason: "",
    return_status: 1,
    added_by:0
};
reverselogistics_id_pk=0;
  constructor(private service:restapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.reverselogistics_id_pk=params['id'];
    });
    this.ConsignmentList();
 
   
    if(this.reverselogistics_id_pk==0||this.reverselogistics_id_pk==undefined)
    {
      this.reverselogisticData=new showreverselogisticsdata();
    }
    else{
      console.log();
      this.ReverseLogisticsData();
    }
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
 
  ReverseLogisticsData(){
    console.log("ReverseLogistics ID:"+this.reverselogistics_id_pk);
    this.service.ReverseLogisticsData(this.reverselogistics_id_pk).subscribe(res=>{
      this.reverselogisticRespone=res as showreverselogisticsidresponse;
      this.reverselogisticData=this.reverselogisticRespone.data;
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
    console.log("reverselogistics    ID:"+this.reverselogistics_id_pk);
    if(this.reverselogistics_id_pk== 0||this.reverselogistics_id_pk==undefined)
    {
      this.AddReverseLogistics(form);
    }
    else{
      this.UpdateReverseLogistics(form);
    }
  }
  AddReverseLogistics(form:NgForm)
  {
    // console.log("Vehicle Data");
    // console.log(this.vehicleData);
    this.reverselogisticData.added_by=1;
    this.service.AddReverseLogistics(this.reverselogisticData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-reverselogistics'],{relativeTo:this.route});
      }
      else{
        console.log(res);
      }

    },err=>{
      console.log(err);
    });
  }
  UpdateReverseLogistics(form:NgForm)
  {
    this.service.UpdateReverseLogistics(this.reverselogisticData).subscribe(res=>{
      this.insertRespone=res as insertresponse;
      if(this.insertRespone.result=="success")
      {
        this.resetForm(form);
        this.router.navigate(['/admin/show-reverselogistics'],{relativeTo:this.route});
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
    this.reverselogisticData=new showreverselogisticsdata();
  }
  onClear()
  {
    this.slForm?.reset();
    this.editMode=false;
  }

}
