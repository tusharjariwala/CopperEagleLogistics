import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { showconsignmentdata } from "../models/showconsignmentdata";
import { showconsignmentproductdata } from "../models/showconsignmentproductdata";
import { showcontainercustomerdata } from "../models/showcontainercustomerdata";
import { showcontainerdata } from "../models/showcontainerdata";
import { showcustomerdata } from "../models/showcustomerdata";
import { showdriverdata } from "../models/showdriverdata";
import { showemployeedata } from "../models/showemployeedata";

import { showpackagetypedata } from "../models/showpackagetypedata";
import { showreverselogisticsdata } from "../models/showreverselogisticsdata";
import { showtrackingdata } from "../models/showtrackingdata";
import { showtrasportdata } from "../models/showtrasportdata";
import { showvehicledata } from "../models/showvehicledata";
import { showarehousedata } from "../models/showwarehousedata";

@Injectable({
    providedIn:'root'
  })
  export class restapiemployee{
    constructor(private http:HttpClient){}
    readonly baseUrl = 'http://localhost:13883/api/employee/';
    
    cityList():Observable<any>{
      return this.http.get("http://localhost:13883/api/admin/cityList");
    }
      Employelist():Observable<any>{
      return this.http.get(this.baseUrl+"Employelist");
    }
      EmployeeData(id:number):Observable<any>{
      return this.http.get(this.baseUrl+"EmployeeData/"+id)
  }
  
       AddEmployee(employee:showemployeedata):Observable<any>{
   return this.http.post(this.baseUrl+"AddEmployee",employee);
  }
       UpdateEmployee(employee:showemployeedata):Observable<any>{
   return this.http.post(this.baseUrl+"UpdateEmployee",employee);
  }
   
       WarehouseList():Observable<any>{
    return this.http.get(this.baseUrl+"WarehouseList");
  }
  WarehouseDetailsById(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"WarehouseDetailsById/"+id)
  }
      AddWarehouse(warehouse:showarehousedata):Observable<any>{
    return this.http.post(this.baseUrl+"AddWarehouse",warehouse);
   }
      UpdateWarehouse(warehouse:showarehousedata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateWarehouse",warehouse);
   }
      DeleteWarehouse(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteWarehouse/"+id);
  }
  WarehouseListCount():Observable<any>{
    return this.http.get(this.baseUrl+"WarehouseListCount");
  }
      PackagetypeList():Observable<any>{
    return this.http.get(this.baseUrl+"PackagetypeList");
  }
       PackagetypeData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"PackagetypeData/"+id)
  }
       AddPackagetype(packagetype:showpackagetypedata):Observable<any>{
    return this.http.post(this.baseUrl+"AddPackagetype",packagetype);
   }
      UpdatePackagetype(packagetype:showpackagetypedata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdatePackagetype",packagetype);
   }
      DeletePackagetype(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeletePackagetype/"+id);
  }
     ConsignmentProductList(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"ConsignmentProductList/"+id);
  } 
      ConsignmentProductData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"ConsignmentProductData/"+id)
  }
          AddConsignmentproduct(consignmentproduct:showconsignmentproductdata):Observable<any>{
       return this.http.post(this.baseUrl+"AddConsignmentproduct",consignmentproduct);
   }
       UpdateConsignmentProduct(consignmentproduct:showconsignmentproductdata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateConsignmentProduct",consignmentproduct);
   }
      DeleteConsignmentProduct(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteConsignmentProduct/"+id);
   }
        vehicleList():Observable<any>{
    return this.http.get(this.baseUrl+"vehicleList");
  }
      VehicleData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"VehicleData/"+id)
  }
       AddVehicle(vehicle:showvehicledata):Observable<any>{
       return this.http.post(this.baseUrl+"AddVehicle",vehicle);
   }
        UpdateVehicle(vehicle:showvehicledata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateVehicle",vehicle);
   }
       DeleteVehicle(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteVehicle/"+id);
   } 
       DriverList():Observable<any>{
    return this.http.get(this.baseUrl+"DriverList");
  }
       DriverData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"DriverData/"+id)
  }
    AddDriver(driver:showdriverdata):Observable<any>{
       return this.http.post(this.baseUrl+"AddDriver",driver);
   }
     UpdateDriver(driver:showdriverdata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateDriver",driver);
   }
     DeleteDriver(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteDriver/"+id);
   } 
      CustomerList():Observable<any>{
    return this.http.get(this.baseUrl+"CustomerList");
  }   
     CustomerData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"CustomerData/"+id)
  }
      AddCustomer(customer:showcustomerdata):Observable<any>{
    return this.http.post(this.baseUrl+"AddCustomer",customer);
  }
     UpdateCustomer(customer:showcustomerdata):Observable<any>{
  return this.http.post(this.baseUrl+"UpdateCustomer",customer);
  }
     DeleteCustomer(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteCustomer/"+id);
   } 
   CustomerListCount():Observable<any>{
    return this.http.get(this.baseUrl+"CustomerListCount");
  }
        ConsignmentList():Observable<any>{
    return this.http.get(this.baseUrl+"ConsignmentList");
  }
       ConsigmentData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"ConsigmentData/"+id)
  }
      AddConsignment(consignment:showconsignmentdata):Observable<any>{
       return this.http.post(this.baseUrl+"AddConsignment",consignment);
   }
       UpdateConsignment(consignment:showconsignmentdata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateConsignment",consignment);
   }
        DeleteConsignment(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteConsignment/"+id);
   } 
   ConsigmentListCount():Observable<any>{
    return this.http.get(this.baseUrl+"ConsigmentListCount");
  }
    
    TrackingList():Observable<any>{
    return this.http.get(this.baseUrl+"TrackingList");
  }
     TrackingData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"TrackingData/"+id)
  }
      AddTracking(tracking:showtrackingdata):Observable<any>{
    return this.http.post(this.baseUrl+"AddTracking",tracking);
  }
     UpdateTracking(tracking:showtrackingdata):Observable<any>{
  return this.http.post(this.baseUrl+"UpdateTracking",tracking);
  }
    DeleteTracking(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteTracking/"+id);
   }
   
     ContainerList():Observable<any>{
    return this.http.get(this.baseUrl+"ContainerList");
  }
  ContainerData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"ContainerData/"+id)
  }
      AddContainer(container:showcontainerdata):Observable<any>{
    return this.http.post(this.baseUrl+"AddContainer",container);
  }
       UpdateContainer(container:showcontainerdata):Observable<any>{
  return this.http.post(this.baseUrl+"UpdateContainer",container);
  }
      DeleteContainer(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteContainer/"+id);
    
   }   
   ContainerListCount():Observable<any>{
    return this.http.get(this.baseUrl+"ContainerListCount");
  }
      
       ContainerCustomerList(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"ContainerCustomerList/"+id);
  }
  
  ContainerCustomerData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"ContainerCustomerData/"+id)
  }
  AddContainerCustomer(containercustomer:showcontainercustomerdata):Observable<any>{
    return this.http.post(this.baseUrl+"AddContainerCustomer",containercustomer);
  }
  UpdateContainerCustomer(containercustomer:showcontainercustomerdata):Observable<any>{
  return this.http.post(this.baseUrl+"UpdateContainerCustomer",containercustomer);
  }
      DeleteContainerCustomer(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteContainerCustomer/"+id);
    
   } 
  
       
        ReverseLogisticsList():Observable<any>{
    return this.http.get(this.baseUrl+"ReverseLogisticsList");
  }
     
      ReverseLogisticsData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"ReverseLogisticsData/"+id)
  }
      AddReverseLogistics(reverserlogistics:showreverselogisticsdata):Observable<any>{
    return this.http.post(this.baseUrl+"AddReverseLogistics",reverserlogistics);
  }
      UpdateReverseLogistics(reverserlogistics:showreverselogisticsdata):Observable<any>{
  return this.http.post(this.baseUrl+"UpdateReverseLogistics",reverserlogistics);
  }
      DeleteReverseLogistics(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteReverseLogistics/"+id);
    
   }   
  
        
     TransportList():Observable<any>{
    return this.http.get(this.baseUrl+"TransportList");
  }   
      TransportListData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"TransportListData/"+id)
  }
     AddTransport(trasport:showtrasportdata):Observable<any>{
    return this.http.post(this.baseUrl+"AddTransport",trasport);
  }
      UpdateTransport(trasport:showtrasportdata):Observable<any>{
  return this.http.post(this.baseUrl+"UpdateTransport",trasport);
  }
     DeleteTransport(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteTransport/"+id);
    
   } 
  }