using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class tracking_master_tableEntities
{

    private int tracking_id_pk = 0;
    private string tracking_date_and_time = "";
    private string tracking_number = "";

    private int consignment_id_fk = 0;
    private string consignment_number = "";
    private string deliver_date = "";
    private string sender_address = "";
    private string receiver_address = "";
    private string receiver_person = "";

    private string remark = "";

    private int warehouse_id_fk =0;
    private string warehouse_name = "";
    private string address = "";
    private string contactperson_name = "";
    private string contactperson_number = "";

    private int status = 0;
    private int added_by = 0;



    public int Tracking_id_pk { get => tracking_id_pk; set => tracking_id_pk = value; }
    public string Tracking_date_and_time { get => tracking_date_and_time; set => tracking_date_and_time = value; }
    public int Consignment_id_fk { get => consignment_id_fk; set => consignment_id_fk = value; }
    public string Consignment_number { get => consignment_number; set => consignment_number = value; }
    public string Deliver_date { get => deliver_date; set => deliver_date = value; }
    public string Sender_address { get => sender_address; set => sender_address = value; }
    public string Receiver_address { get => receiver_address; set => receiver_address = value; }
    public string Receiver_person { get => receiver_person; set => receiver_person = value; }
    public string Remark { get => remark; set => remark = value; }
    public int Warehouse_id_fk1 { get => warehouse_id_fk; set => warehouse_id_fk = value; }
    public string Warehouse_name1 { get => warehouse_name; set => warehouse_name = value; }
    public string Address1 { get => address; set => address = value; }
    public string Contactperson_name { get => contactperson_name; set => contactperson_name = value; }
    public string Contactperson_number { get => contactperson_number; set => contactperson_number = value; }
    public int Status { get => status; set => status = value; }
    public int Added_by { get => added_by; set => added_by = value; }
    public string Tracking_number { get => tracking_number; set => tracking_number = value; }
}

   

