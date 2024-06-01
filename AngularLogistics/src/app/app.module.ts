import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './admin/index.component';
import { HeaderComponent } from './admin/header.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { AdminComponent } from './admin/admin.component';
import { AddEmployeeComponent } from './admin/add-employee.component';
import { ShowEmployeeComponent } from './admin/show-employee.component';
import { AddCustomerComponent } from './admin/add-customer.component';
import { ShowCustomerComponent } from './admin/show-customer.component';
import { AddDriverComponent } from './admin/add-driver.component';
import { ShowDriverComponent } from './admin/show-driver.component';
import { AddVehicleComponent } from './admin/add-vehicle.component';
import { ShowVehicleComponent } from './admin/show-vehicle.component';
import { AddTransportmanagementComponent } from './admin/add-transportmanagement.component';
import { ShowTransportmanagementComponent } from './admin/show-transportmanagement.component';
import { AddConsignmentComponent } from './admin/add-consignment.component';
import { ShowConsignmentComponent } from './admin/show-consignment.component';
import { AddTrackingComponent } from './admin/add-tracking.component';
import { ShowTrackingComponent } from './admin/show-tracking.component';
import { AddPackagetypeComponent } from './admin/add-packagetype.component';
import { ShowPackagetypeComponent } from './admin/show-packagetype.component';
import { AddConsignmentproductComponent } from './admin/add-consignmentproduct.component';
import { ShowConsignmentproductComponent } from './admin/show-consignmentproduct.component';
import { AddWarehousemanagemnetComponent } from './admin/add-warehousemanagemnet.component';
import { ShowWarehousemanagemnetComponent } from './admin/show-warehousemanagemnet.component';
import { AddReverselogisticsComponent } from './admin/add-reverselogistics.component';
import { ShowReverselogisticsComponent } from './admin/show-reverselogistics.component';
import { AddContainerComponent } from './admin/add-container.component';
import { ShowContainerComponent } from './admin/show-container.component';
import { AddContainercustomerComponent } from './admin/add-containercustomer.component';
import { ShowContainercustomerComponent } from './admin/show-containercustomer.component';
import { HeaderEmpComponent } from './employee/header-emp.component';
import { IndexEmpComponent } from './employee/index-emp.component';
import { EmployeeComponent } from './employee/employee.component';
import { AddWarehousemanagemnetEmpComponent } from './employee/add-warehousemanagemnet-emp.component';
import { ShowWarehousemanagemnetEmpComponent } from './employee/show-warehousemanagemnet-emp.component';
import { AddVehicleEmpComponent } from './employee/add-vehicle-emp.component';
import { ShowVehicleEmpComponent } from './employee/show-vehicle-emp.component';
import { AddDriverEmpComponent } from './employee/add-driver-emp.component';
import { ShowDriverEmpComponent } from './employee/show-driver-emp.component';
import { AddPackagetypeEmpComponent } from './employee/add-packagetype-emp.component';
import { ShowPackagetypeEmpComponent } from './employee/show-packagetype-emp.component';
import { AddCustomerEmpComponent } from './employee/add-customer-emp.component';
import { ShowCustomerEmpComponent } from './employee/show-customer-emp.component';
import { AddContainerEmpComponent } from './employee/add-container-emp.component';
import { ShowContainerEmpComponent } from './employee/show-container-emp.component';
import { AddContainercustomerEmpComponent } from './employee/add-containercustomer-emp.component';
import { ShowContainercustomerEmpComponent } from './employee/show-containercustomer-emp.component';
import { AddConsignmentEmpComponent } from './employee/add-consignment-emp.component';
import { ShowConsignmentEmpComponent } from './employee/show-consignment-emp.component';
import { AddConsignmentproductEmpComponent } from './employee/add-consignmentproduct-emp.component';
import { ShowConsignmentproductEmpComponent } from './employee/show-consignmentproduct-emp.component';
import { AddTrackingEmpComponent } from './employee/add-tracking-emp.component';
import { ShowTrackingEmpComponent } from './employee/show-tracking-emp.component';
import { AddReverselogisticsEmpComponent } from './employee/add-reverselogistics-emp.component';
import { ShowReverselogisticsEmpComponent } from './employee/show-reverselogistics-emp.component';
import { AddTransportmanagementEmpComponent } from './employee/add-transportmanagement-emp.component';
import { ShowTransportmanagementEmpComponent } from './employee/show-transportmanagement-emp.component';
import { AddContactEmpComponent } from './employee/add-contact-emp.component';
import { ShowContactEmpComponent } from './employee/show-contact-emp.component';
import { LoginComponent } from './login.component';
import { AuthGuard } from './services/Auth.guard';
import { AddTransportitemsComponent } from './admin/add-transportitems.component';
import { ShowTransportitemsComponent } from './admin/show-transportitems.component';

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    HeaderComponent,
    AdminComponent,
    AddEmployeeComponent,
    ShowEmployeeComponent,
    AddCustomerComponent,
    ShowCustomerComponent,
    AddDriverComponent,
    ShowDriverComponent,
    AddVehicleComponent,
    ShowVehicleComponent,
    AddTransportmanagementComponent,
    ShowTransportmanagementComponent,
    AddConsignmentComponent,
    ShowConsignmentComponent,
    AddTrackingComponent,
    ShowTrackingComponent,
    AddPackagetypeComponent,
    ShowPackagetypeComponent,
    AddConsignmentproductComponent,
    ShowConsignmentproductComponent,
    AddWarehousemanagemnetComponent,
    ShowWarehousemanagemnetComponent,
    AddReverselogisticsComponent,
    ShowReverselogisticsComponent,
    AddContainerComponent,
    ShowContainerComponent,
    AddContainercustomerComponent,
    ShowContainercustomerComponent,
    HeaderEmpComponent,
    IndexEmpComponent,
    EmployeeComponent,
    AddWarehousemanagemnetEmpComponent,
    ShowWarehousemanagemnetEmpComponent,
    AddVehicleEmpComponent,
    ShowVehicleEmpComponent,
    AddDriverEmpComponent,
    ShowDriverEmpComponent,
    AddPackagetypeEmpComponent,
    ShowPackagetypeEmpComponent,
    AddCustomerEmpComponent,
    ShowCustomerEmpComponent,
    AddContainerEmpComponent,
    ShowContainerEmpComponent,
    AddContainercustomerEmpComponent,
    ShowContainercustomerEmpComponent,
    AddConsignmentEmpComponent,
    ShowConsignmentEmpComponent,
    AddConsignmentproductEmpComponent,
    ShowConsignmentproductEmpComponent,
    AddTrackingEmpComponent,
    ShowTrackingEmpComponent,
    AddReverselogisticsEmpComponent,
    ShowReverselogisticsEmpComponent,
    AddTransportmanagementEmpComponent,
    ShowTransportmanagementEmpComponent,
    AddContactEmpComponent,
    ShowContactEmpComponent,
    LoginComponent,
    AddTransportitemsComponent,
    ShowTransportitemsComponent,
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
