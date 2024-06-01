import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { showauthdata } from "../models/showauthdata";
import { showcontactdata } from "../models/showcontactdata";
import { showcustomerdata } from "../models/showcustomerdata";
import { showfreightdata } from "../models/showfreightdata";


@Injectable({
    providedIn:'root'
  })

  export class restapi{
      constructor(private http:HttpClient){}
      readonly baseurl = 'http://localhost:13883/api/Customer/';
      

      AddContact(contact:showcontactdata):Observable<any>{
        return this.http.post("http://localhost:13883/api/Employee/AddContact",contact);
      }

      AddFreight(freight:showfreightdata):Observable<any>{
        return this.http.post(this.baseurl+"AddFreight",freight);
      }

      FreightList():Observable<any>{
        return this.http.get(this.baseurl+"FreightList");
      }

      cityList():Observable<any>{
          return this.http.get(this.baseurl+"cityList");
      }

      AddauthData(auth:showauthdata):Observable<any>{
        return this.http.post(this.baseurl+"AddAuth",auth);
      }

      getlogindata(authData:showauthdata):Observable<any>{
        return this.http.post(this.baseurl+"LoginData",authData);
      }
      
      Customergetid():Observable<any>{
        return this.http.get(this.baseurl+"Customergetid");
      }

      AddCustomer(customer:showcustomerdata):Observable<any>{
        return this.http.post("http://localhost:13883/api/Employee/AddCustomer",customer);
      }

      updatecustomer(customer:showcustomerdata):Observable<any>{
        return this.http.post("http://localhost:13883/api/Employee/UpdateCustomer",customer);
      }

      getCustomerData(id:Number):Observable<any>{
        return this.http.get("http://localhost:13883/api/Employee/CustomerData/"+id);
      }

      getConsignmentList():Observable<any>{
        return this.http.get("http://localhost:13883/api/Employee/ConsignmentList");
      }

      getCustomerConsignmentList(customerId:Number):Observable<any>{
        return this.http.get("http://localhost:13883/api/Employee/ConsigmentCustomer/"+customerId);
      }

      

      getTrackingData(id:String):Observable<any>{
        return this.http.get("http://localhost:13883/api/Customer/TrackingList/"+id);
      }

      getTransportData(id1:string,id2:string):Observable<any>{
        return this.http.get("http://localhost:13883/api/Customer/TransportListData/"+id1+id2)
      }

      getConsignmentData(id:string):Observable<any>{
      return this.http.get("http://localhost:13883/api/Customer/ConsigmentData/"+id);
      }

      getContainerData(id:string):Observable<any>{
        return this.http.get("http://localhost:13883/api/Customer/ContainerData/"+id);
      }


      
  }