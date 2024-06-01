using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class driver_master_tableEntities
{

    private int driver_id_pk = 0;
    private string driver_name = "";
    private string driver_licence = "";
    private string driver_contactno = "";
    private string address = "";
    private int vehicle_id_fk = 0; 
    private string vehicle_name = "";
    private string vehicle_number = "";
    private int isactive = 0;
    private int added_by = 0;
    public int Driver_id_pk { get => driver_id_pk; set => driver_id_pk = value; }
    public string Driver_name { get => driver_name; set => driver_name = value; }
    public string Driver_licence { get => driver_licence; set => driver_licence = value; }
    public string Driver_contactno { get => driver_contactno; set => driver_contactno = value; }
    public string Address { get => address; set => address = value; }
    public int Vehicle_id_fk { get => vehicle_id_fk; set => vehicle_id_fk = value; }
    public string Vehicle_name { get => vehicle_name; set => vehicle_name = value; }
  
    public int Isactive { get => isactive; set => isactive = value; }
    public string Vehicle_number { get => vehicle_number; set => vehicle_number = value; }
    public int Added_by { get => added_by; set => added_by = value; }
}

   

