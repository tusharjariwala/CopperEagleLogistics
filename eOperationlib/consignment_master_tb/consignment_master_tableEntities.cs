using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class consignment_master_tableEntities
{

    private int consignment_id_pk = 0;
    private int employee_id_fk = 0;
    private string employee_name ="";
    private string employee_email = "";
    private string employee_contactno = "";

    private int customer_id_fk = 0;
    private string customer_name = "";
    private string company_name = "";
    private string company_contact = "";
    private string phonenumber = "";

    private string consignment_number = "";
    private int package_type = 0;
    private string deliver_date = ""; 
    private string booking_date = "";
    private string sender_address = "";
    private string receiver_address = "";
    private string receiver_person = "";
    private int packagetype_id_fk = 0;
    private string code = "";
    private string name = "";
    private string description = "";
    private int status = 0;
    private string weight = "";
    private int isactive = 0;
    private int tracking_id = 0;
    public int Consignment_id_pk { get => consignment_id_pk; set => consignment_id_pk = value; }
    public int Employee_id_fk { get => employee_id_fk; set => employee_id_fk = value; }
    public int Customer_id_fk { get => customer_id_fk; set => customer_id_fk = value; }
    public string Consignment_number { get => consignment_number; set => consignment_number = value; }
    public int Package_type { get => package_type; set => package_type = value; }
    public string Deliver_date { get => deliver_date; set => deliver_date = value; }
    public string Booking_date { get => booking_date; set => booking_date = value; }
    public string Sender_address { get => sender_address; set => sender_address = value; }
    public string Receiver_address { get => receiver_address; set => receiver_address = value; }
    public string Receiver_person { get => receiver_person; set => receiver_person = value; }
    public int Packagetype_id_fk { get => packagetype_id_fk; set => packagetype_id_fk = value; }
    public string Description { get => description; set => description = value; }
    public int Status { get => status; set => status = value; }
    public string Weight { get => weight; set => weight = value; }
    public string Employee_name { get => employee_name; set => employee_name = value; }
    public string Employee_email { get => employee_email; set => employee_email = value; }
    public string Employee_contactno { get => employee_contactno; set => employee_contactno = value; }
    public string Customer_name { get => customer_name; set => customer_name = value; }
    public string Company_name { get => company_name; set => company_name = value; }
    public string Company_contact { get => company_contact; set => company_contact = value; }
    public string Phonenumber { get => phonenumber; set => phonenumber = value; }
    public string Code { get => code; set => code = value; }
    public string Name { get => name; set => name = value; }
    public int Isactive { get => isactive; set => isactive = value; }
    public int Tracking_id { get => tracking_id; set => tracking_id = value; }
}

   

