import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showtrackingdata } from '../models/showtrackingdata';
import { showtrackingresponse } from '../models/showtrackingresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-show-tracking',
  templateUrl: './show-tracking.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowTrackingComponent implements OnInit {
  trackinglist:showtrackingdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showtrackingresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapi) { }

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
