using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace logistics_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
       
        country_master_tableDB coudb = new();
        state_master_tableDB statedb = new();
        city_master_tableDB objdb = new();
        employee_master_tableDB employedb = new();
        customer_master_tableDB custdb = new();
        warehouse_master_tableDB waredb = new();
        vehicle_master_tableDB vehicledb = new();
        driver_master_tableDB driverdb = new();
        packagetype_master_tableDB packagedb = new();
        consignment_master_tableDB consignmentdb = new();
        tracking_master_tableDB trackingdb = new();
        consignmentproduct_master_tableDB consignmentproductdb = new();
        container_master_tableDB containerdb = new();
        containercustomer_master_tableDB containercustomerdb = new();
        reverselogistics_master_tableDB reverselogisticsdb = new();
        transport_master_tableDB transportdb = new();
        trasportitems_master_tableDB transportitemsdb = new();
        contact_master_tableDB contactdb = new();
        auth_master_tableDB authdb = new();

        [HttpGet("authList")]
        public JsonResult authList()
        {

            List<auth_master_tableEntities> auths = authdb.OnGetListdt();

            if (auths.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = auths });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddAuth")]
        public JsonResult AddAuth(auth_master_tableEntities auth)
        {

            int res = authdb.OnInsert(auth);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("LoginData")]
        public JsonResult LoginData(auth_master_tableEntities entities)
        {

            auth_master_tableEntities auths = authdb.OnLoginData(entities.Employee_email,entities.Password);

            if (auths.Auth_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = auths });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("cityList")]
        public JsonResult cityList()
        {

            List<city_master_tableEntities> citys = objdb.OnGetListdt();

            if (citys.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = citys });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("countryList")]
        public JsonResult countryList()
        {

            List<country_master_tableEntities> country = coudb.OnGetListdt();

            if (country.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = country });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("stateList")]
        public JsonResult stateList()
        {

            List<state_master_tableEntities> state = statedb.OnGetListdt();

            if (state.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = state });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("Employelist")]
        public JsonResult Employelist()
        {

            List<employee_master_tableEntities> employee = employedb.OnGetListdt();

            if (employee.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = employee });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("Employegetid")]
        public JsonResult Employegetid()
        {

            int  employee = employedb.OnLastRecordInserted();

            if (employee != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = employee });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("EmployeeData/{id}")]
        public JsonResult EmployeeData(int id)
        {

            employee_master_tableEntities employee= employedb.OnGetData(id);

            if (employee.Employee_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = employee });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddEmployee")]
        public JsonResult AddEmployee(employee_master_tableEntities employee)
        {

            int res = employedb.OnInsert(employee);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateEmployee")]
        public JsonResult UpdateEmployee(employee_master_tableEntities employee)
        {

            int res = employedb.OnUpdate(employee);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteEmployee/{id}")]
        public JsonResult DeleteEmployee(int id)
        {

            int res = employedb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("EmployeetListCount")]
        public JsonResult EmployeetListCount()
        {
            List<int> table = employedb.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddCustomer")]
        public JsonResult AddCustomer(customer_master_tableEntities customer)
        {

            int res = custdb.OnInsert(customer);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("CustomerList")]
        public JsonResult CustomerList()
        {

            List<customer_master_tableEntities> customer = custdb.OnGetListdt();

            if (customer.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = customer });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("Customergetid")]
        public JsonResult Customergetid()
        {

            int customer = custdb.OnLastRecordInserted();

            if (customer != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = customer });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("CustomerData/{id}")]
        public JsonResult CustomerData(int id)
        {

            customer_master_tableEntities customer = custdb.OnGetData(id);

            if (customer.Customer_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = customer });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateCustomer")]
        public JsonResult UpdateCustomer(customer_master_tableEntities customer)
        {

            int res = custdb.OnUpdate(customer);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteCustomer/{id}")]
        public JsonResult DeleteCustomer(int id)
        {

            int res = custdb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddWarehouse")]
        public JsonResult AddWarehouse(warehouse_master_tableEntities warehouse)
        {

            int res = waredb.OnInsert(warehouse);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("WarehouseList")]
        public JsonResult WarehouseList()
        {

            List<warehouse_master_tableEntities> warehouse = waredb.OnGetListdt();

            if (warehouse.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = warehouse });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("WarehouseData/{id}")]
        public JsonResult WarehouseData(int id)
        {

            warehouse_master_tableEntities warehouse = waredb.OnGetData(id);

            if (warehouse.Warehouse_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = warehouse });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateWarehouse")]
        public JsonResult UpdateWarehouse(warehouse_master_tableEntities warehouse)
        {

            int res = waredb.OnUpdate(warehouse);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteWarehouse/{id}")]
        public JsonResult DeleteWarehouse(int id)
        {

            int res = waredb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddVehicle")]
        public JsonResult AddVehicle(vehicle_master_tableEntities vehicle)
        {

            int res = vehicledb.OnInsert(vehicle);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("vehicleList")]
        public JsonResult vehicleList()
        {

            List<vehicle_master_tableEntities> vehicle = vehicledb.OnGetListdt();

            if (vehicle.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = vehicle });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("VehicleData/{id}")]
        public JsonResult VehicleData(int id)
        {

            vehicle_master_tableEntities vehicle = vehicledb.OnGetData(id);

            if (vehicle.Vehicle_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = vehicle });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateVehicle")]
        public JsonResult UpdateVehicle(vehicle_master_tableEntities vehicle)
        {

            int res = vehicledb.OnUpdate(vehicle);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteVehicle/{id}")]
        public JsonResult DeleteVehicle(int id)
        {

            int res = vehicledb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("VehicleListCount")]
        public JsonResult VehicleListCount()
        {
            List<int> table = vehicledb.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddDriver")]
        public JsonResult AddDriver(driver_master_tableEntities driver)
        {

            int res = driverdb.OnInsert(driver);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("DriverList")]
        public JsonResult DriverList()
        {

            List<driver_master_tableEntities> driver = driverdb.OnGetListdt();

            if (driver.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = driver });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("DriverData/{id}")]
        public JsonResult DriverData(int id)
        {

            driver_master_tableEntities driver = driverdb.OnGetData(id);

            if (driver.Driver_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = driver });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateDriver")]
        public JsonResult UpdateDriver(driver_master_tableEntities driver)
        {

            int res = driverdb.OnUpdate(driver);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteDriver/{id}")]
        public JsonResult DeleteDriver(int id)
        {

            int res = driverdb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("DriverListCount")]
        public JsonResult DriverListCount()
        {
            List<int> table = driverdb.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddPackagetype")]
        public JsonResult AddPackagetype(packagetype_master_tableEntities package)
        {

            int res = packagedb.OnInsert(package);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("PackagetypeList")]
        public JsonResult PackagetypeList()
        {

            List<packagetype_master_tableEntities> Packeage = packagedb.OnGetListdt();

            if (Packeage.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = Packeage });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("PackagetypeData/{id}")]
        public JsonResult PackagetypeData(int id)
        {

            packagetype_master_tableEntities packagetype = packagedb.OnGetData(id);

            if (packagetype.Packagetype_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = packagetype });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdatePackagetype")]
        public JsonResult UpdatePackagetype(packagetype_master_tableEntities packagetype)
        {

            int res = packagedb.OnUpdate(packagetype);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeletePackagetype/{id}")]
        public JsonResult DeletePackagetype(int id)
        {

            int res = packagedb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddConsignment")]
        public JsonResult AddConsignment(consignment_master_tableEntities consignment)
        {

            int res  =consignmentdb.OnInsert(consignment);

            if (res == 1)
            {
                int consignmentId = consignmentdb.OnLastRecordInserted();
                return new JsonResult(new { result = "success", message = "Data Found", data = consignmentId });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ConsignmentList")]
        public JsonResult ConsignmentList()
        {

            List<consignment_master_tableEntities> consignmet = consignmentdb.OnGetListdt();

            if (consignmet.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = consignmet });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ConsigmentStatus/{id}")]
        public JsonResult ConsigmentStatus(int id)
        {

          
            int result = consignmentdb.OnGetTableStatus(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("ConsigmentData/{id}")]
        public JsonResult ConsigmentData(int id)
        {

            consignment_master_tableEntities consignment = consignmentdb.OnGetData(id);

            if (consignment.Consignment_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = consignment });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateConsignment")]
        public JsonResult UpdateConsignment(consignment_master_tableEntities consignment)
        {

            int res = consignmentdb.OnUpdate(consignment);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteConsignment/{id}")]
        public JsonResult DeleteConsignment(int id)
        {

            int res = consignmentdb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddTracking")]
        public JsonResult AddTracking(tracking_master_tableEntities tracking)
        {

            int res = trackingdb.OnInsert(tracking);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("TrackingList")]
        public JsonResult TrackingList()
        {

            List<tracking_master_tableEntities> tracking = trackingdb.OnGetListdt();

            if (tracking.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = tracking });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("TrackingData/{id}")]
        public JsonResult TrackingData(int id)
        {

            tracking_master_tableEntities tracking = trackingdb.OnGetData(id);

            if (tracking.Tracking_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = tracking });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateTracking")]
        public JsonResult UpdateTracking(tracking_master_tableEntities tracking)
        {

            int res = trackingdb.OnUpdate(tracking);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteTracking/{id}")]
        public JsonResult DeleteTracking(int id)
        {

            int res = trackingdb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddConsignmentproduct")]
        public JsonResult AddConsignmentproduct(consignmentproduct_master_tableEntities consignmentproduct)
        {

            int res = consignmentproductdb.OnInsert(consignmentproduct);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ConsignmentProductList/{id}")]
        public JsonResult ConsignmentProductList(int id)
        {

            List<consignmentproduct_master_tableEntities> consignmentproduct = consignmentproductdb.OnGetListdt(id);

            if (consignmentproduct.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = consignmentproduct });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ConsignmentProductData/{id}")]
        public JsonResult ConsignmentProductData(int id)
        {

            consignmentproduct_master_tableEntities consignmentproduct = consignmentproductdb.OnGetData(id);

            if (consignmentproduct.Consignmentproduct_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = consignmentproduct });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateConsignmentProduct")]
        public JsonResult UpdateConsignmentProduct(consignmentproduct_master_tableEntities consignmentproduct)
        {

            int res = consignmentproductdb.OnUpdate(consignmentproduct);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteConsignmentProduct/{id}")]
        public JsonResult DeleteConsignmentProduct(int id)
        {

            int res = consignmentproductdb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddContainer")]
        public JsonResult AddContainer(container_master_tableEntities container)
        {

            int res = containerdb.OnInsert(container);

            if (res == 1)
            {
                int containerid = containerdb.OnLastRecordInserted();
                return new JsonResult(new { result = "success", message = "Data Found", data = containerid });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ContainerList")]
        public JsonResult ContainerList()
        {

            List<container_master_tableEntities> container = containerdb.OnGetListdt();

            if (container.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = container });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ContainerData/{id}")]
        public JsonResult ContainerData(int id)
        {

            container_master_tableEntities container =containerdb.OnGetData(id);

            if (container.Container_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = container });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateContainer")]
        public JsonResult UpdateContainer(container_master_tableEntities container)
        {

            int res = containerdb.OnUpdate(container);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteContainer/{id}")]
        public JsonResult DeleteContainer(int id)
        {

            int res = containerdb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddContainerCustomer")]
        public JsonResult AddContainerCustomer(containercustomer_master_tableEntities containercustomer)
        {

            int res = containercustomerdb.OnInsert(containercustomer);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("ContainerCustomerList/{id}")]
        public JsonResult ContainerCustomerList(int id)
        {

            List<containercustomer_master_tableEntities> containercustomer = containercustomerdb.OnGetListdt(id);

            if (containercustomer.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = containercustomer });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
       
        [HttpGet("ContainerCustomerData/{id}")]
        public JsonResult ContainerCustomerData(int id)
        {

            containercustomer_master_tableEntities containercustomer = containercustomerdb.OnGetData(id);

            if (containercustomer.Container_customerid_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = containercustomer });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateContainerCustomer")]
        public JsonResult UpdateContainerCustomer(containercustomer_master_tableEntities containercustomer)
        {

            int res = containercustomerdb.OnUpdate(containercustomer);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteContainerCustomer/{id}")]
        public JsonResult DeleteContainerCustomer(int id)
        {

            int res = containercustomerdb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("AddReverseLogistics")]
        public JsonResult AddReverseLogistics(reverselogistics_master_tableEntities reverselogistics)
        {

            int res = reverselogisticsdb.OnInsert(reverselogistics);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("ReverseLogisticsList")]
        public JsonResult ReverseLogisticsList()
        {

            List<reverselogistics_master_tableEntities> reverselogistics = reverselogisticsdb.OnGetListdt();

            if (reverselogistics.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = reverselogistics });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("ReverseLogisticsData/{id}")]
        public JsonResult ReverseLogisticsData(int id)
        {

            reverselogistics_master_tableEntities reverselogistics = reverselogisticsdb.OnGetData(id);

            if (reverselogistics.Reverselogistics_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = reverselogistics });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateReverseLogistics")]
        public JsonResult UpdateReverseLogistics(reverselogistics_master_tableEntities reverlogistics)
        {

            int res = reverselogisticsdb.OnUpdate(reverlogistics);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteReverseLogistics/{id}")]
        public JsonResult DeleteReverseLogistics(int id)
        {

            int res = reverselogisticsdb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("AddTransport")]
        public JsonResult AddTransport(transport_master_tableEntities trasport)
        {

            int res = transportdb.OnInsert(trasport);

            if (res == 1)
            {
                int trasportid = transportdb.OnLastRecordInserted();
                return new JsonResult(new { result = "success", message = "Data Found", data = trasportid });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("TransportList")]
        public JsonResult TransportList()
        {

            List<transport_master_tableEntities> transport = transportdb.OnGetListdt();

            if (transport.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = transport });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("TransportListData/{id1},{id2}")]
        public JsonResult TransportListData(int id1,int id2)
        {

            transport_master_tableEntities trasnport = transportdb.OnGetData(id1,id2);

            if (trasnport.Transport_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = trasnport });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("UpdateTransport")]
        public JsonResult UpdateTransport(transport_master_tableEntities trasport)
        {

            int res = transportdb.OnUpdate(trasport);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteTransport/{id}")]
        public JsonResult DeleteTransport(int id)
        {

            int res = transportdb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("TransportListCount")]
        public JsonResult TransportListCount()
        {
            List<int> table = transportdb.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpPost("AddTransportitems")]
        public JsonResult AddTransportitems(trasportitems_master_tableEntities trasportitems)
        {

            int res = transportitemsdb.OnInsert(trasportitems);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("TransportitemsList/{id}")]
        public JsonResult TransportitemsList(int id)
        {

            List<trasportitems_master_tableEntities> transportitems = transportitemsdb.OnGetListdt(id);

            if (transportitems.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = transportitems });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("TransportitemsListData/{id}")]
        public JsonResult TransportitemsListData(int id)
        {

            trasportitems_master_tableEntities trasnportitems = transportitemsdb.OnGetData(id);

            if (trasnportitems.Trasportitems_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = trasnportitems });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpPost("UpdateTransportitems")]
        public JsonResult UpdateTransportitems(trasportitems_master_tableEntities trasportitems)
        {

            int res = transportitemsdb.OnUpdate(trasportitems);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteTransportitems/{id}")]
        public JsonResult DeleteTransportitems(int id)
        {

            int res = transportitemsdb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
        [HttpGet("TransportitemsListCount")]
        public JsonResult TransportitemsListCount()
        {
            List<int> table = transportitemsdb.OnGetTableCount();
            if (table.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = table });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("contactusList")]
        public JsonResult contactusList()
        {

            List<contact_master_tableEntities> contact = contactdb.OnGetListdt();

            if (contact.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = contact });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpDelete("DeleteContact/{id}")]
        public JsonResult DeleteContact(int id)
        {

            int res = contactdb.OnDelete(id);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

    }
}
