using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class trasportitems_master_tableEntities
{

    private int trasportitems_id_pk = 0;
    private int transport_id_fk = 0;
    private string pick_up_date = "";
    private string devlivery_date = "";
    private string type = "";
    private string cargo_type = "";

    private int container_id_fk = 0;
    private string container_name = "";
    private string container_number = "";
    private string delivery_days = "";
    private string departed_date = "";
    private string expected_date = "";
    private int status = 0;
    private int tracking_id = 0;

    private int consignment_id_fk = 0;
    private string consignment_number = "";
    private int package_type = 0;
    private string deliver_date = "";
    private string booking_date = "";
    private string sender_address = "";
    private string receiver_address = "";
    private string receiver_person = "";
    private string weight = "";

    public int Trasportitems_id_pk { get => trasportitems_id_pk; set => trasportitems_id_pk = value; }
    public int Transport_id_fk { get => transport_id_fk; set => transport_id_fk = value; }
    public string Pick_up_date { get => pick_up_date; set => pick_up_date = value; }
    public string Devlivery_date { get => devlivery_date; set => devlivery_date = value; }
    public string Type { get => type; set => type = value; }
    public string Cargo_type { get => cargo_type; set => cargo_type = value; }
    public int Container_id_fk { get => container_id_fk; set => container_id_fk = value; }
    public string Container_name { get => container_name; set => container_name = value; }
    public string Container_number { get => container_number; set => container_number = value; }
    public string Delivery_days { get => delivery_days; set => delivery_days = value; }
    public string Departed_date { get => departed_date; set => departed_date = value; }
    public string Expected_date { get => expected_date; set => expected_date = value; }
 
    public int Consignment_id_fk { get => consignment_id_fk; set => consignment_id_fk = value; }
    public string Consignment_number { get => consignment_number; set => consignment_number = value; }
    public int Package_type { get => package_type; set => package_type = value; }
    public string Deliver_date { get => deliver_date; set => deliver_date = value; }
    public string Booking_date { get => booking_date; set => booking_date = value; }
    public string Sender_address { get => sender_address; set => sender_address = value; }
    public string Receiver_address { get => receiver_address; set => receiver_address = value; }
    public string Receiver_person { get => receiver_person; set => receiver_person = value; }
    public string Weight { get => weight; set => weight = value; }
    public int Status { get => status; set => status = value; }
    public int Tracking_id { get => tracking_id; set => tracking_id = value; }
}



