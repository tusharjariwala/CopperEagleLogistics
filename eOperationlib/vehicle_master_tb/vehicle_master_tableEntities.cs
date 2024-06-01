using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class vehicle_master_tableEntities
{

    private int vehicle_id_pk = 0;
    private string vehicle_name = "";
    private string vehicle_type = "";
    private string vehicle_number = "";
    private string vehicle_loadamount = "";
    private int warehouse_id_fk = 0; 
    private string warehouse_name = "";
    private string address = "";
    private string type = "";
    private int isactive = 0;
    private int added_by = 0;
    public int Vehicle_id_pk { get => vehicle_id_pk; set => vehicle_id_pk = value; }
    public string Vehicle_name { get => vehicle_name; set => vehicle_name = value; }
    public string Vehicle_type { get => vehicle_type; set => vehicle_type = value; }
    public string Vehicle_number { get => vehicle_number; set => vehicle_number = value; }
    public string Vehicle_loadamount { get => vehicle_loadamount; set => vehicle_loadamount = value; }
    public int Warehouse_id_fk { get => warehouse_id_fk; set => warehouse_id_fk = value; }
    public string Warehouse_name { get => warehouse_name; set => warehouse_name = value; }
    public string Address { get => address; set => address = value; }
    public string Type { get => type; set => type = value; }
    public int Isactive { get => isactive; set => isactive = value; }
    public int Added_by { get => added_by; set => added_by = value; }
}

   

