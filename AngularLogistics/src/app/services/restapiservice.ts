import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { showauthdata } from '../models/showauthdata';
import { showconsignmentdata } from '../models/showconsignmentdata';
import { showconsignmentproductdata } from '../models/showconsignmentproductdata';
import { showcontainercustomerdata } from '../models/showcontainercustomerdata';
import { showcontainerdata } from '../models/showcontainerdata';
import { showcustomerdata } from '../models/showcustomerdata';
import { showdriverdata } from '../models/showdriverdata';
import { showemployeedata } from '../models/showemployeedata';
import { showpackagetypedata } from '../models/showpackagetypedata';
import { showreverselogisticsdata } from '../models/showreverselogisticsdata';
import { showtrackingdata } from '../models/showtrackingdata';
import { showtrasportdata } from '../models/showtrasportdata';
import { showtrasportitemsdata } from '../models/showtrasportitemsdata';
import { showvehicledata } from '../models/showvehicledata';
import { showarehousedata } from '../models/showwarehousedata';




@Injectable({
  providedIn: 'root'
})

export class restapi {
 
  constructor(private http: HttpClient) { }
  
  readonly baseUrl = 'http://localhost:13883/api/admin/';
  
  cityList(): Observable<any> {
    return this.http.get(this.baseUrl + "cityList");
  }
  LoginData(authData:showauthdata):Observable<any>{
    return this.http.post(this.baseUrl+"LoginData", authData)
  }
  Employelist(): Observable<any> {
    return this.http.get(this.baseUrl + "Employelist");
  }
  EmployeeData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "EmployeeData/" + id)
  }
  Employegetid(): Observable<any> {
    return this.http.get(this.baseUrl + "Employegetid");
  }
  AddAuth(auth: showauthdata): Observable<any> {
    return this.http.post(this.baseUrl + "AddAuth", auth);
  }

  AddEmployee(employee: showemployeedata): Observable<any> {
    return this.http.post(this.baseUrl + "AddEmployee", employee);
  }
  UpdateEmployee(employee: showemployeedata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateEmployee", employee);
  }

  DeleteEmployee(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteEmployee/" + id);
  }
  EmployeetListCount():Observable<any>{
    return this.http.get(this.baseUrl+"EmployeetListCount");
  }

  WarehouseList(): Observable<any> {
    return this.http.get(this.baseUrl + "WarehouseList");
  }
  WarehouseData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "WarehouseData/" + id)
  }
  AddWarehouse(warehouse: showarehousedata): Observable<any> {
    return this.http.post(this.baseUrl + "AddWarehouse", warehouse);
  }
  UpdateWarehouse(warehouse: showarehousedata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateWarehouse", warehouse);
  }
  DeleteWarehouse(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteWarehouse/" + id);
  }
  PackagetypeList(): Observable<any> {
    return this.http.get(this.baseUrl + "PackagetypeList");
  }
  PackagetypeData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "PackagetypeData/" + id)
  }
  AddPackagetype(packagetype: showpackagetypedata): Observable<any> {
    return this.http.post(this.baseUrl + "AddPackagetype", packagetype);
  }
  UpdatePackagetype(packagetype: showpackagetypedata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdatePackagetype", packagetype);
  }
  DeletePackagetype(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeletePackagetype/" + id);
  }
  ConsignmentProductList(id:number): Observable<any> {
    return this.http.get(this.baseUrl + "ConsignmentProductList/"+id);
  }
  ConsignmentProductData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "ConsignmentProductData/" + id)
  }
  AddConsignmentproduct(consignmentproduct: showconsignmentproductdata): Observable<any> {
    return this.http.post(this.baseUrl + "AddConsignmentproduct", consignmentproduct);
  }
  UpdateConsignmentProduct(consignmentproduct: showconsignmentproductdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateConsignmentProduct", consignmentproduct);
  }
  DeleteConsignmentProduct(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteConsignmentProduct/" + id);
  }
  vehicleList(): Observable<any> {
    return this.http.get(this.baseUrl + "vehicleList");
  }
  VehicleData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "VehicleData/" + id)
  }
  AddVehicle(vehicle: showvehicledata): Observable<any> {
    return this.http.post(this.baseUrl + "AddVehicle", vehicle);
  }
  UpdateVehicle(vehicle: showvehicledata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateVehicle", vehicle);
  }
  DeleteVehicle(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteVehicle/" + id);
  }
  VehicleListCount():Observable<any>{
    return this.http.get(this.baseUrl+"VehicleListCount");
  }
  DriverList(): Observable<any> {
    return this.http.get(this.baseUrl + "DriverList");
  }
  DriverData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "DriverData/" + id)
  }
  AddDriver(driver: showdriverdata): Observable<any> {
    return this.http.post(this.baseUrl + "AddDriver", driver);
  }
  UpdateDriver(driver: showdriverdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateDriver", driver);
  }
  DeleteDriver(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteDriver/" + id);
  }
  DriverListCount():Observable<any>{
    return this.http.get(this.baseUrl+"DriverListCount");
  }
  CustomerList(): Observable<any> {
    return this.http.get(this.baseUrl + "CustomerList");
  }
  CustomerData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "CustomerData/" + id)
  }
  Customergetid(): Observable<any> {
    return this.http.get(this.baseUrl + "Customergetid");
  }
  AddCustomer(customer: showcustomerdata): Observable<any> {
    return this.http.post(this.baseUrl + "AddCustomer", customer);
  }
  UpdateCustomer(customer: showcustomerdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateCustomer", customer);
  }
  DeleteCustomer(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteCustomer/" + id);
  }
  ConsignmentList(): Observable<any> {
    return this.http.get(this.baseUrl + "ConsignmentList");
  }
  ConsigmentData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "ConsigmentData/" + id)
  }
  getConsigmentStatus(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "ConsigmentStatus/" + id)
  }

  AddConsignment(consignment: showconsignmentdata): Observable<any> {
    return this.http.post(this.baseUrl + "AddConsignment", consignment);
  }
  UpdateConsignment(consignment: showconsignmentdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateConsignment", consignment);
  }
  DeleteConsignment(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteConsignment/" + id);
  }

  TrackingList(): Observable<any> {
    return this.http.get(this.baseUrl + "TrackingList");
  }
  TrackingData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "TrackingData/" + id)
  }
  AddTracking(tracking: showtrackingdata): Observable<any> {
    return this.http.post(this.baseUrl + "AddTracking", tracking);
  }
  UpdateTracking(tracking: showtrackingdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateTracking", tracking);
  }
  DeleteTracking(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteTracking/" + id);
  }

  ContainerList(): Observable<any> {
    return this.http.get(this.baseUrl + "ContainerList");
  }
  ContainerData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "ContainerData/" + id)
  }
  AddContainer(container: showcontainerdata): Observable<any> {
    return this.http.post(this.baseUrl + "AddContainer", container);
  }
  UpdateContainer(container: showcontainerdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateContainer", container);
  }
  DeleteContainer(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteContainer/" + id);

  }

  ContainerCustomerList(id:number): Observable<any> {
    return this.http.get(this.baseUrl + "ContainerCustomerList/"+id);
  }

  ContainerCustomerData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "ContainerCustomerData/" + id)
  }
  AddContainerCustomer(containercustomer: showcontainercustomerdata): Observable<any> {
    return this.http.post(this.baseUrl + "AddContainerCustomer", containercustomer);
  }
  UpdateContainerCustomer(containercustomer: showcontainercustomerdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateContainerCustomer", containercustomer);
  }
  DeleteContainerCustomer(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteContainerCustomer/" + id);

  }


  ReverseLogisticsList(): Observable<any> {
    return this.http.get(this.baseUrl + "ReverseLogisticsList");
  }

  ReverseLogisticsData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "ReverseLogisticsData/" + id)
  }
  AddReverseLogistics(reverserlogistics: showreverselogisticsdata): Observable<any> {
    return this.http.post(this.baseUrl + "AddReverseLogistics", reverserlogistics);
  }
  UpdateReverseLogistics(reverserlogistics: showreverselogisticsdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateReverseLogistics", reverserlogistics);
  }
  DeleteReverseLogistics(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteReverseLogistics/" + id);

  }


  TransportitemsList(id:number): Observable<any> {
    return this.http.get(this.baseUrl + "TransportitemsList/"+id);
  }
  TransportitemsListData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "TransportitemsListData/" + id)
  }
  AddTransportitems(trasportitems:showtrasportitemsdata ): Observable<any> {
    return this.http.post(this.baseUrl + "AddTransportitems", trasportitems);
  }
  UpdateTransportitems(trasportitems:showtrasportitemsdata ): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateTransportitems", trasportitems);
  }
  DeleteTransportitems(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteTransportitems/" + id);

  }
  TransportitemsListCount():Observable<any>{
    return this.http.get(this.baseUrl+"TransportitemsListCount");
  }

  TransportList(): Observable<any> {
    return this.http.get(this.baseUrl + "TransportList");
  }
  TransportListData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "TransportListData/" + id)
  }
  AddTransport(trasport: showtrasportdata): Observable<any> {
    return this.http.post(this.baseUrl + "AddTransport", trasport);
  }
  UpdateTransport(trasport: showtrasportdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateTransport", trasport);
  }
  DeleteTransport(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteTransport/" + id);

  }
  TransportListCount():Observable<any>{
    return this.http.get(this.baseUrl+"TransportListCount");
  }
}