using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistics_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        freight_master_tableDB freightdb = new();
        city_master_tableDB objdb = new();
        auth_master_tableDB authdb = new();
        tracking_master_tableDB trackingdb = new();
        customer_master_tableDB custdb = new();
        transport_master_tableDB transportdb = new();
        trasportitems_master_tableDB transportitemsdb = new();
        consignment_master_tableDB consignmentdb = new();
        container_master_tableDB containerdb = new();

        [HttpPost("AddFreight")]
        public JsonResult AddFreight(freight_master_tableEntities freight)
        {

            int res = freightdb.OnInsert(freight);

            if (res == 1)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = res });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("FreightList")]
        public JsonResult FreightList()
        {

            List<freight_master_tableEntities> freight = freightdb.OnGetListdt();

            if (freight.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = freight });
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

            auth_master_tableEntities auths = authdb.OnLoginData(entities.Employee_email, entities.Password);

            if (auths.Auth_id_pk != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = auths });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("TrackingList/{id}")]
        public JsonResult TrackingList(string id)
        {

            List<tracking_master_tableEntities> tracking = trackingdb.OnGetTrackingList(id);

            if (tracking.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = tracking });
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

        [HttpGet("TransportitemsList")]
        public JsonResult TransportitemsList()
        {

            List<trasportitems_master_tableEntities> transportitems = transportitemsdb.OnGetListdt();

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

        [HttpGet("ContainerData/{id}")]
        public JsonResult ContainerData(int id)
        {

            container_master_tableEntities container = containerdb.OnGetDataByTracking(id);

            if (container.Tracking_id != 0) 
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = container });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }

        [HttpGet("ConsigmentData/{id}")]
        public JsonResult ConsigmentData(int id)
        {

            consignment_master_tableEntities consignment = consignmentdb.OnGetDataByTracking(id);

            if (consignment.Tracking_id != 0)
            {
                return new JsonResult(new { result = "success", message = "Data Found", data = consignment });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Data Not Found" });
            }
        }
    }
}
