using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class container_master_tableEntities
{

    private int container_id_pk = 0;
    private string container_name = "";

    private string container_number = "";
    private string delivery_days = "";
    private string departed_date = "";
    private string expected_date = "";
    private int status =0;
  

    

    private int employee_id_fk = 0;
    private string employee_name = "";
    private string employee_email = "";
    private string employee_contactno = "";
    private int tracking_id = 0;
    private int isactive = 0;

    public int Container_id_pk { get => container_id_pk; set => container_id_pk = value; }
    public string Container_name { get => container_name; set => container_name = value; }
  
    public string Delivery_days { get => delivery_days; set => delivery_days = value; }
    public string Departed_date { get => departed_date; set => departed_date = value; }
    public string Expected_date { get => expected_date; set => expected_date = value; }
    public int Status1 { get => status; set => status = value; }
    public int Employee_id_fk { get => employee_id_fk; set => employee_id_fk = value; }
    public string Employee_name { get => employee_name; set => employee_name = value; }
    public string Employee_email { get => employee_email; set => employee_email = value; }
    public string Employee_contactno { get => employee_contactno; set => employee_contactno = value; }
    public string Container_number1 { get => container_number; set => container_number = value; }
    public int Isactive { get => isactive; set => isactive = value; }
    public int Tracking_id { get => tracking_id; set => tracking_id = value; }
}

   

