import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { insertresponse } from '../models/insertresponse';
import { showreverselogisticsdata } from '../models/showreverselogisticsdata';
import { showreverselogisticsresponse } from '../models/showreverselogisticsresponse';
import { restapi } from '../services/restapiservice';

@Component({
  selector: 'app-show-reverselogistics',
  templateUrl: './show-reverselogistics.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ShowReverselogisticsComponent implements OnInit {
  reverselogisticslist:showreverselogisticsdata[] | undefined
  //Warehouseslist:showarehousedata[] |undefined;
  listresponse:showreverselogisticsresponse | undefined
  insertRespone!:insertresponse;
  constructor(public service:restapi) { }

  ngOnInit(): void {
    this.ReverseLogisticsList();
  }
  ReverseLogisticsList()
  {
    this.service.ReverseLogisticsList()
    .subscribe(res=>{
      this.listresponse = res as showreverselogisticsresponse;
      this.reverselogisticslist = this.listresponse.data;
      //this.Warehouseslist=this.listresponse.data;
    },err=>{
      console.log(err);
    })
  }
  DeleteReverseLogistics(id:number)
  {
    console.log(" ReverseLogistics  ID :::::"+id);
    if(confirm('Are You sure to delete this'))
    {
      this.service.DeleteReverseLogistics(id).subscribe(res=>{
        console.log(res);
        this.insertRespone=res as insertresponse;
        this.ReverseLogisticsList();
      },err=>{
        console.log(err);
      });
    }
  }


}
