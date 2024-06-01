import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showtrackingdata } from '../models/showtrackingdata';
import { showtrackingresponse } from '../models/showtrackingresponse';
import { restapiemployee } from '../services/restapiserviceemployee';

@Component({
  selector: 'app-show-tracking-emp',
  templateUrl: './show-tracking-emp.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowTrackingEmpComponent implements OnInit {
  trackinglist:showtrackingdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showtrackingresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapiemployee) { }

  ngOnInit(): void {
    this.TrackingList();
  }
  TrackingList()
  {
    this.service.TrackingList()
    .subscribe(res=>{
      this.listresponse = res as showtrackingresponse;
      this.trackinglist = this.listresponse.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeleteTracking(id:number)
  {
    console.log("Tracking  ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteTracking(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.TrackingList();
      },err=>{
        console.log(err);
      });
    }
  }


}
