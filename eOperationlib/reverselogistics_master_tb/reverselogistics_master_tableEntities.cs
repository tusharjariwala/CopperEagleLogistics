using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class reverselogistics_master_tableEntities
{

    private int reverselogistics_id_pk = 0;
    private string datetime = "";

    private int consignment_id_fk = 0;
    private string consignment_number = "";
    private string deliver_date = "";
    private string sender_address = "";
    private string receiver_address = "";
    private string receiver_person = "";

    private string reason = "";
    private int return_status = 0;
    private int added_by = 0;
    public int Reverselogistics_id_pk { get => reverselogistics_id_pk; set => reverselogistics_id_pk = value; }
    public string Datetime { get => datetime; set => datetime = value; }
    public int Consignment_id_fk { get => consignment_id_fk; set => consignment_id_fk = value; }
    public string Consignment_number { get => consignment_number; set => consignment_number = value; }
    public string Deliver_date { get => deliver_date; set => deliver_date = value; }
    public string Sender_address { get => sender_address; set => sender_address = value; }
    public string Receiver_address { get => receiver_address; set => receiver_address = value; }
    public string Receiver_person { get => receiver_person; set => receiver_person = value; }
    public string Reason { get => reason; set => reason = value; }
    public int Return_status { get => return_status; set => return_status = value; }
    public int Added_by { get => added_by; set => added_by = value; }
}

   

