using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class consignmentproduct_master_tableEntities
{

    private int consignmentproduct_id_pk = 0;

    private int consignment_id_fk = 0;

    private string consignment_number = "";
    private int  package_type = 0;
    private string deliver_date = "";
    private string booking_date = "";
    private string sender_address = "";
    private string receiver_address = "";
    private string receiver_person = "";




    private int isfargile = 0;
    private string name = "";
    private int isactive = 0;
    private int added_by = 0;
    public int Consignmentproduct_id_pk { get => consignmentproduct_id_pk; set => consignmentproduct_id_pk = value; }
    public int Isfargile { get => isfargile; set => isfargile = value; }
    public string Name { get => name; set => name = value; }
    public int Isactive { get => isactive; set => isactive = value; }
    public int Added_by { get => added_by; set => added_by = value; }
    public int Consignment_id_fk { get => consignment_id_fk; set => consignment_id_fk = value; }
    public string Consignment_number { get => consignment_number; set => consignment_number = value; }
    
    public string Deliver_date { get => deliver_date; set => deliver_date = value; }
    public string Booking_date { get => booking_date; set => booking_date = value; }
    public string Sender_address { get => sender_address; set => sender_address = value; }
    public string Receiver_address { get => receiver_address; set => receiver_address = value; }
    public string Receiver_person { get => receiver_person; set => receiver_person = value; }
    public int Package_type { get => package_type; set => package_type = value; }
}

   

