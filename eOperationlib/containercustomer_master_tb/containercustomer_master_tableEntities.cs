using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class containercustomer_master_tableEntities
{

    private int container_customerid_pk = 0;

    private int container_id_fk = 0;
    private string container_name = "";
    private string container_number = "";
    private string delivery_days = "";
    private string departed_date = "";

    private int customer_id_fk = 0;
    private string customer_name = "";
    private string company_name = "";
    private string company_contact = "";
    private string phonenumber = "";

    private string no_of_parcels = "";
    private int added_by = 0;
    public int Container_customerid_pk { get => container_customerid_pk; set => container_customerid_pk = value; }
    public int Container_id_fk { get => container_id_fk; set => container_id_fk = value; }
    public string Container_name { get => container_name; set => container_name = value; }
    public string Container_number { get => container_number; set => container_number = value; }
    public string Delivery_days { get => delivery_days; set => delivery_days = value; }
    public string Departed_date { get => departed_date; set => departed_date = value; }
    public int Customer_id_fk { get => customer_id_fk; set => customer_id_fk = value; }
    public string Customer_name { get => customer_name; set => customer_name = value; }
    public string Company_name { get => company_name; set => company_name = value; }
    public string Company_contact { get => company_contact; set => company_contact = value; }
    public string Phonenumber { get => phonenumber; set => phonenumber = value; }
    public string No_of_parcels { get => no_of_parcels; set => no_of_parcels = value; }
    public int Added_by { get => added_by; set => added_by = value; }
}

   

