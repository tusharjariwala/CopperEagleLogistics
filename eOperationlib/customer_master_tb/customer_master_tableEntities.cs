using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class customer_master_tableEntities
{

    private int customer_id_pk = 0;
    private string customer_name = "";
    private string company_name = "";
    private string company_contact = "";
    private string phonenumber = "";
    private string email = "";
    private string address1 = "";
    private int city_id_fk = 0;
    private string city_name = "";
    private int isActive = 0;
    private int added_by = 0;
    public int Customer_id_pk { get => customer_id_pk; set => customer_id_pk = value; }
    public string Customer_name { get => customer_name; set => customer_name = value; }
    public string Company_name { get => company_name; set => company_name = value; }
    public string Company_contact { get => company_contact; set => company_contact = value; }
    public string Phonenumber { get => phonenumber; set => phonenumber = value; }
    public string Email { get => email; set => email = value; }
    public string Address1 { get => address1; set => address1 = value; }
    public int City_id_fk { get => city_id_fk; set => city_id_fk = value; }
    public string City_name { get => city_name; set => city_name = value; }
    public int IsActive { get => isActive; set => isActive = value; }
    public int Added_by { get => added_by; set => added_by = value; }
}

   

