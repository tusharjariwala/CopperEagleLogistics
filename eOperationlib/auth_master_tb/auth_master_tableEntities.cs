using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class auth_master_tableEntities
{

    private int auth_id_pk = 0;
    private string employee_email = "";
    private string password = "";
    private int user_id_fk = 0;
    private string user_type = "";


    public string Employee_email { get => employee_email; set => employee_email = value; }
    public string Password { get => password; set => password = value; }
    public int User_id_fk { get => user_id_fk; set => user_id_fk = value; }
    public string User_type { get => user_type; set => user_type = value; }
    public int Auth_id_pk { get => auth_id_pk; set => auth_id_pk = value; }
}

   

