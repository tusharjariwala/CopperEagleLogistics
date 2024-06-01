using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class packagetype_master_tableEntities
{

    private int packagetype_id_pk = 0;
    private string code = "";
    private string name = "";
    private int isactive = 0;
    private int added_by = 0;

    public int Packagetype_id_pk { get => packagetype_id_pk; set => packagetype_id_pk = value; }
    public string Code { get => code; set => code = value; }
    public string Name { get => name; set => name = value; }
    public int Isactive { get => isactive; set => isactive = value; }
    public int Added_by { get => added_by; set => added_by = value; }
}

   

