import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddConsignmentComponent } from './admin/add-consignment.component';
import { AddConsignmentproductComponent } from './admin/add-consignmentproduct.component';
import { AddContainerComponent } from './admin/add-container.component';
import { AddContainercustomerComponent } from './admin/add-containercustomer.component';

import { AddCustomerComponent } from './admin/add-customer.component';
import { AddDriverComponent } from './admin/add-driver.component';
import { AddEmployeeComponent } from './admin/add-employee.component';
import { AddPackagetypeComponent } from './admin/add-packagetype.component';
import { AddReverselogisticsComponent } from './admin/add-reverselogistics.component';

import { AddTrackingComponent } from './admin/add-tracking.component';
import { AddTransportmanagementComponent } from './admin/add-transportmanagement.component';
import { AddVehicleComponent } from './admin/add-vehicle.component';
import { AddWarehousemanagemnetComponent } from './admin/add-warehousemanagemnet.component';
import { AdminComponent } from './admin/admin.component';
import { IndexComponent } from './admin/index.component';
import { LoginComponent } from './login.component';

import { ShowConsignmentComponent } from './admin/show-consignment.component';
import { ShowConsignmentproductComponent } from './admin/show-consignmentproduct.component';
import { ShowContainerComponent } from './admin/show-container.component';
import { ShowContainercustomerComponent } from './admin/show-containercustomer.component';

import { ShowCustomerComponent } from './admin/show-customer.component';
import { ShowDriverComponent } from './admin/show-driver.component';
import { ShowEmployeeComponent } from './admin/show-employee.component';
import { ShowPackagetypeComponent } from './admin/show-packagetype.component';
import { ShowReverselogisticsComponent } from './admin/show-reverselogistics.component';

import { ShowTrackingComponent } from './admin/show-tracking.component';
import { ShowTransportmanagementComponent } from './admin/show-transportmanagement.component';
import { ShowVehicleComponent } from './admin/show-vehicle.component';
import { ShowWarehousemanagemnetComponent } from './admin/show-warehousemanagemnet.component';
import { AddConsignmentEmpComponent } from './employee/add-consignment-emp.component';
import { AddConsignmentproductEmpComponent } from './employee/add-consignmentproduct-emp.component';
import { AddContainerEmpComponent } from './employee/add-container-emp.component';
import { AddContainercustomerEmpComponent } from './employee/add-containercustomer-emp.component';
import { AddCustomerEmpComponent } from './employee/add-customer-emp.component';
import { AddDriverEmpComponent } from './employee/add-driver-emp.component';
import { AddPackagetypeEmpComponent } from './employee/add-packagetype-emp.component';
import { AddReverselogisticsEmpComponent } from './employee/add-reverselogistics-emp.component';
import { AddTrackingEmpComponent } from './employee/add-tracking-emp.component';
import { AddTransportmanagementEmpComponent } from './employee/add-transportmanagement-emp.component';
import { AddVehicleEmpComponent } from './employee/add-vehicle-emp.component';
import { AddWarehousemanagemnetEmpComponent } from './employee/add-warehousemanagemnet-emp.component';
import { EmployeeComponent } from './employee/employee.component';
import { IndexEmpComponent } from './employee/index-emp.component';
import { ShowConsignmentEmpComponent } from './employee/show-consignment-emp.component';
import { ShowConsignmentproductEmpComponent } from './employee/show-consignmentproduct-emp.component';
import { ShowContainerEmpComponent } from './employee/show-container-emp.component';
import { ShowContainercustomerEmpComponent } from './employee/show-containercustomer-emp.component';
import { ShowCustomerEmpComponent } from './employee/show-customer-emp.component';
import { ShowDriverEmpComponent } from './employee/show-driver-emp.component';
import { ShowPackagetypeEmpComponent } from './employee/show-packagetype-emp.component';
import { ShowReverselogisticsEmpComponent } from './employee/show-reverselogistics-emp.component';
import { ShowTrackingEmpComponent } from './employee/show-tracking-emp.component';
import { ShowTransportmanagementEmpComponent } from './employee/show-transportmanagement-emp.component';
import { ShowVehicleEmpComponent } from './employee/show-vehicle-emp.component';
import { ShowWarehousemanagemnetEmpComponent } from './employee/show-warehousemanagemnet-emp.component';
import { AuthGuard } from './services/Auth.guard';
import { AddTransportitemsComponent } from './admin/add-transportitems.component';
import { ShowTransportitemsComponent } from './admin/show-transportitems.component';

const routes: Routes = [
  {
    path: '', redirectTo: '/login', pathMatch: 'full'
  },

  { path: 'login', component: LoginComponent },

  {
    path: 'admin', component: AdminComponent, children: [
      { path: '', component: IndexComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-employee', component: AddEmployeeComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-employee/:id', component: AddEmployeeComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-employee', component: ShowEmployeeComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-customer', component: AddCustomerComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-customer/:id', component: AddCustomerComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-customer', component: ShowCustomerComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-driver', component: AddDriverComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-driver/:id', component: AddDriverComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-driver', component: ShowDriverComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-vehicle', component: AddVehicleComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-vehicle/:id', component: AddVehicleComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-vehicle', component: ShowVehicleComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-transportmanagement', component: AddTransportmanagementComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-transportmanagement/:id', component: AddTransportmanagementComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-transportmanagement', component: ShowTransportmanagementComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-transportitems/:id', component: AddTransportitemsComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-transportitems/:id', component: AddTransportitemsComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-transportitems/:id', component: ShowTransportitemsComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-consignment', component: AddConsignmentComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-consignment/:id', component: AddConsignmentComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-consignment', component: ShowConsignmentComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-tracking', component: AddTrackingComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-tracking/:id', component: AddTrackingComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-tracking', component: ShowTrackingComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-packagetype', component: AddPackagetypeComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-packagetype/:id', component: AddPackagetypeComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-packagetype', component: ShowPackagetypeComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-consingmentproduct/:id', component: AddConsignmentproductComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-consingmentproduct/:id', component: AddConsignmentproductComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-consingmentproduct/:id', component: ShowConsignmentproductComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-warehousemanagemnet', component: AddWarehousemanagemnetComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-warehousemanagemnet/:id', component: AddWarehousemanagemnetComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-warehousemanagemnet', component: ShowWarehousemanagemnetComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-reverselogistics', component: AddReverselogisticsComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-reverselogistics/:id', component: AddReverselogisticsComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-reverselogistics', component: ShowReverselogisticsComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },


      { path: 'add-container', component: AddContainerComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-container/:id', component: AddContainerComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-container', component: ShowContainerComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-containercustomer/:id', component: AddContainercustomerComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-containercustomer/:id', component: AddContainercustomerComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-containercustomer/:id', component: ShowContainercustomerComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

    ]
  },
  {
    path: 'employee', component: EmployeeComponent, children: [
      { path: '', component: IndexEmpComponent },

      { path: 'add-warehousemanagemnet-emp', component: AddWarehousemanagemnetEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-warehousemanagemnet-emp/:id', component: AddWarehousemanagemnetEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-warehousemanagemnet-emp', component: ShowWarehousemanagemnetEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-vehicle-emp', component: AddVehicleEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-vehicle-emp/:id', component: AddVehicleEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-vehicle-emp', component: ShowVehicleEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-driver-emp', component: AddDriverEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-driver-emp/:id', component: AddDriverEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-driver-emp', component: ShowDriverEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-packagetype-emp', component: AddPackagetypeEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-packagetype-emp/:id', component: AddPackagetypeEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-packagetype-emp', component: ShowPackagetypeEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-customer-emp', component: AddCustomerEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-customer-emp/:id', component: AddCustomerEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-customer-emp', component: ShowCustomerEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },


      { path: 'add-container-emp', component: AddContainerEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-container-emp/:id', component: AddContainerEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-container-emp', component: ShowContainerEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-containercustomer-emp/:id', component: AddContainercustomerEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-containercustomer-emp/:id', component: AddContainercustomerEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-containercustomer-emp/:id', component: ShowContainercustomerEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },



      { path: 'add-consignment-emp', component: AddConsignmentEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-consignment-emp/:id', component: AddConsignmentEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-consignment-emp', component: ShowConsignmentEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-consingmentproduct-emp/:id', component: AddConsignmentproductEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-consingmentproduct-emp/:id', component: AddConsignmentproductEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-consingmentproduct-emp/:id', component: ShowConsignmentproductEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-tracking-emp', component: AddTrackingEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-tracking-emp/:id', component: AddTrackingEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-tracking-emp', component: ShowTrackingEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-reverselogistics-emp', component: AddReverselogisticsEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-reverselogistics-emp/:id', component: AddReverselogisticsEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-reverselogistics-emp', component: ShowReverselogisticsEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

      { path: 'add-transportmanagement-emp', component: AddTransportmanagementEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'edit-transportmanagement-emp/:id', component: AddTransportmanagementEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },
      { path: 'show-transportmanagement-emp', component: ShowTransportmanagementEmpComponent, canActivate: [AuthGuard],runGuardsAndResolvers: "always", },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
