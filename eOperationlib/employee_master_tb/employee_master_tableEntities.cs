using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class employee_master_tableEntities
{

    private int employee_id_pk = 0;
    private string employee_name = "";
    private string employee_email = "";
    private string type = "";
    private string employee_contactno = "";
    private int isActive = 0;

  
    public int Employee_id_pk { get => employee_id_pk; set => employee_id_pk = value; }
    public string Employee_name { get => employee_name; set => employee_name = value; }
    public string Employee_email { get => employee_email; set => employee_email = value; }
    public string Type { get => type; set => type = value; }
    public string Employee_contactno { get => employee_contactno; set => employee_contactno = value; }
    public int IsActive { get => isActive; set => isActive = value; }
}

   

