using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class transport_master_tableEntities
{

    private int transport_id_pk = 0;
    private string pick_up_date = "";
    private string devlivery_date = "";

    private int vehicle_id_fk = 0;
    private string vehicle_name = "";
    private string vehicle_type = "";
    private string vehicle_number = "";
  

    private int fromwarehouse_fk = 0;
    private int towarehouse_fk = 0;

    private string type = "";
    private string cargo_type = "";
    private int isactive = 0;
    private int added_by = 0;
    public int Transport_id_pk { get => transport_id_pk; set => transport_id_pk = value; }
    public string Pick_up_date { get => pick_up_date; set => pick_up_date = value; }
    public string Devlivery_date { get => devlivery_date; set => devlivery_date = value; }
    public int Vehicle_id_fk { get => vehicle_id_fk; set => vehicle_id_fk = value; }
    public string Vehicle_name { get => vehicle_name; set => vehicle_name = value; }
    public string Vehicle_type { get => vehicle_type; set => vehicle_type = value; }
    public string Vehicle_number { get => vehicle_number; set => vehicle_number = value; }
    
    public int Fromwarehouse_fk { get => fromwarehouse_fk; set => fromwarehouse_fk = value; }
    public int Towarehouse_fk { get => towarehouse_fk; set => towarehouse_fk = value; }
    public int Isactive { get => isactive; set => isactive = value; }
    public int Added_by { get => added_by; set => added_by = value; }
    public string Type { get => type; set => type = value; }
    public string Cargo_type { get => cargo_type; set => cargo_type = value; }
}

   

