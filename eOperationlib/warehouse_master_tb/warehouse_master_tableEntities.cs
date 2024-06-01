using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class warehouse_master_tableEntities
{

    private int warehouse_id_pk = 0;
    private string warehouse_name = "";
    private string address = "";
    private string type = "";
    private string contactperson_name = "";
    private string contactperson_number = "";
    private string capacity = "";
    private int isactive = 0;
    private int added_by = 0;



    public int Warehouse_id_pk { get => warehouse_id_pk; set => warehouse_id_pk = value; }
    public string Warehouse_name { get => warehouse_name; set => warehouse_name = value; }
    public string Type1 { get => type; set => type = value; }
    public string Contactperson_name { get => contactperson_name; set => contactperson_name = value; }
    public string Contactperson_number { get => contactperson_number; set => contactperson_number = value; }
    public string Capacity { get => capacity; set => capacity = value; }
    public string Address { get => address; set => address = value; }
    public int Isactive { get => isactive; set => isactive = value; }
    public int Added_by { get => added_by; set => added_by = value; }
}

   

