using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class state_master_tableEntities
{

    private int state_id_pk = 0;
    private string state_name = "";
    private int country_id_fk =0;
    private string country_name = "";

    public int State_id_pk { get => state_id_pk; set => state_id_pk = value; }
    public string State_name { get => state_name; set => state_name = value; }

    public string Country_name { get => country_name; set => country_name = value; }
    public int Country_id_fk { get => country_id_fk; set => country_id_fk = value; }
}

