using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class freight_master_tableEntities
{

    private int freight_id_pk = 0;
    private string freight_type = "";

    private int departure_id = 0;
    private int deliverCity_id = 0;

    private string departureCity_name = "";   
    private string deliverCity_name = "";

    private string total_gross_weight = "";
    private string dimention = "";
    private string email = "";
    private string message = "";
    private int isactive = 0;
 
    public int Freight_id_pk { get => freight_id_pk; set => freight_id_pk = value; }
    public string Freight_type { get => freight_type; set => freight_type = value; }
    public string DepartureCity_name { get => departureCity_name; set => departureCity_name = value; }
    public string DeliverCity_name { get => deliverCity_name; set => deliverCity_name = value; }
    public string Total_gross_weight { get => total_gross_weight; set => total_gross_weight = value; }
    public string Dimention { get => dimention; set => dimention = value; }
    public string Email { get => email; set => email = value; }
    public string Message { get => message; set => message = value; }
    public int Isactive { get => isactive; set => isactive = value; }
    public int Departure_id { get => departure_id; set => departure_id = value; }
    public int DeliverCity_id { get => deliverCity_id; set => deliverCity_id = value; }
}

   

