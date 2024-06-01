using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class contact_master_tableEntities
{
    private int contact_id_pk = 0;
    private string contact_name = "";
    private string contact_email = "";
    private string contact_subject = "";
    private string contact_message = "";
    private int isactive = 0;

    public int Contact_id_pk { get => contact_id_pk; set => contact_id_pk = value; }
    public string Contact_name { get => contact_name; set => contact_name = value; }
    public string Contact_email { get => contact_email; set => contact_email = value; }
    public string Contact_subject { get => contact_subject; set => contact_subject = value; }
    public string Contact_message { get => contact_message; set => contact_message = value; }
    public int Isactive { get => isactive; set => isactive = value; }
}

