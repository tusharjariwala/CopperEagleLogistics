using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class consignment_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "consignment_master_tableDB";

    public consignment_master_tableDB()
        
    {
    }

   public int OnInsert(consignment_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [consignment_master]
                                   ([employee_id_fk],[customer_id_fk],[consignment_number],[package_type],[deliver_date],[booking_date],[sender_address],[receiver_address],[receiver_person],[packagetype_id_fk],[description],[status],[weight],[tracking_id])
                             VALUES
                                   (@employee_id_fk,@customer_id_fk,@consignment_number,@package_type,@deliver_date,@booking_date,@sender_address,@receiver_address,@receiver_person,@packagetype_id_fk,@description,@status,@weight,@tracking_id)";

            OnClearParameter();
 
            AddParameter("@employee_id_fk", SqlDbType.Int, 50, obj.Employee_id_fk, ParameterDirection.Input);
            AddParameter("@customer_id_fk", SqlDbType.Int, 50, obj.Customer_id_fk, ParameterDirection.Input);
            AddParameter("@consignment_number", SqlDbType.VarChar, 50, obj.Consignment_number, ParameterDirection.Input);
            AddParameter("@package_type", SqlDbType.Int, 50, obj.Package_type, ParameterDirection.Input);
            AddParameter("@deliver_date", SqlDbType.VarChar, 50, obj.Deliver_date, ParameterDirection.Input);
            AddParameter("@booking_date", SqlDbType.VarChar, 50, obj.Booking_date, ParameterDirection.Input);
            AddParameter("@sender_address", SqlDbType.VarChar, 50, obj.Sender_address, ParameterDirection.Input);
            AddParameter("@receiver_address", SqlDbType.VarChar, 50, obj.Receiver_address, ParameterDirection.Input);
            AddParameter("@receiver_person", SqlDbType.VarChar, 50, obj.Receiver_person, ParameterDirection.Input);
            AddParameter("@packagetype_id_fk", SqlDbType.Int, 50, obj.Packagetype_id_fk, ParameterDirection.Input);
            AddParameter("@description", SqlDbType.VarChar, 50, obj.Description, ParameterDirection.Input);
            AddParameter("@weight", SqlDbType.VarChar, 50, obj.Weight, ParameterDirection.Input);
            AddParameter("@status", SqlDbType.Int, 50, obj.Status, ParameterDirection.Input);
            AddParameter("@tracking_id", SqlDbType.Int, 50, obj.Tracking_id, ParameterDirection.Input);
            // AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive1, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(consignment_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [consignment_master]
                             SET    [employee_id_fk]=@employee_id_fk,
                                    [customer_id_fk]=@customer_id_fk,
                                    [consignment_number]=@consignment_number,
                                    [package_type]=@package_type,
                                    [deliver_date]=@deliver_date,
                                    [booking_date]=@booking_date,
                                    [sender_address]=@sender_address,
                                    [receiver_address]=@receiver_address,
                                    [receiver_person]=@receiver_person,
                                    [packagetype_id_fk]=@packagetype_id_fk,
                                    [description]=@description,
                                    [weight]=@weight,
                                    [status]=1        
                         WHERE [consignment_id_pk]=@consignment_id_pk";
            OnClearParameter();
            AddParameter("@consignment_id_pk", SqlDbType.Int, 50, obj.Consignment_id_pk, ParameterDirection.Input);
            AddParameter("@employee_id_fk", SqlDbType.Int, 50, obj.Employee_id_fk, ParameterDirection.Input);
            AddParameter("@customer_id_fk", SqlDbType.Int, 50, obj.Customer_id_fk, ParameterDirection.Input);
            AddParameter("@consignment_number", SqlDbType.VarChar, 50, obj.Consignment_number, ParameterDirection.Input);
            AddParameter("@package_type", SqlDbType.Int, 50, obj.Package_type, ParameterDirection.Input);
            AddParameter("@deliver_date", SqlDbType.VarChar, 50, obj.Deliver_date, ParameterDirection.Input);
            AddParameter("@booking_date", SqlDbType.VarChar, 50, obj.Booking_date, ParameterDirection.Input);
            AddParameter("@sender_address", SqlDbType.VarChar, 50, obj.Sender_address, ParameterDirection.Input);
            AddParameter("@receiver_address", SqlDbType.VarChar, 50, obj.Receiver_address, ParameterDirection.Input);
            AddParameter("@receiver_person", SqlDbType.VarChar, 50, obj.Receiver_person, ParameterDirection.Input);
            AddParameter("@packagetype_id_fk", SqlDbType.Int, 50, obj.Packagetype_id_fk, ParameterDirection.Input);
            AddParameter("@description", SqlDbType.VarChar, 50, obj.Description, ParameterDirection.Input);
            AddParameter("@weight", SqlDbType.VarChar, 50, obj.Weight, ParameterDirection.Input);
            AddParameter("@status", SqlDbType.Int, 50, obj.Status, ParameterDirection.Input);
           
            return OnExecNonQuery(strQ);


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnDelete(int ID)
    {
        string strQ = "";
      
        try
        {
            strQ += @"update  [consignment_master]     
                           set [status]=0,
                                [isactive]=0
                           WHERE [consignment_id_pk]=@consignment_id_pk";

            OnClearParameter();
            AddParameter("@consignment_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private consignment_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            consignment_master_tableEntities obj = new consignment_master_tableEntities();

            obj.Consignment_id_pk = (drRow["consignment_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["consignment_id_pk"];

            obj.Employee_id_fk = (drRow["employee_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["employee_id_fk"];
            obj.Employee_name = (drRow["employee_name"].Equals(DBNull.Value)) ? "" : (string)drRow["employee_name"];
            obj.Employee_email = (drRow["employee_email"].Equals(DBNull.Value)) ? "" : (string)drRow["employee_email"];
            obj.Employee_contactno = (drRow["employee_contactno"].Equals(DBNull.Value)) ? "" : (string)drRow["employee_contactno"];

            obj.Customer_id_fk = (drRow["customer_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["customer_id_fk"];
            obj.Customer_name = (drRow["customer_name"].Equals(DBNull.Value)) ? "" : (string)drRow["customer_name"];
            obj.Company_name = (drRow["company_name"].Equals(DBNull.Value)) ? "" : (string)drRow["company_name"];
            obj.Company_contact = (drRow["company_contact"].Equals(DBNull.Value)) ? "" : (string)drRow["company_contact"];
            obj.Phonenumber = (drRow["phonenumber"].Equals(DBNull.Value)) ? "" : (string)drRow["phonenumber"];

            obj.Packagetype_id_fk = (drRow["packagetype_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["packagetype_id_fk"];
            obj.Code = (drRow["code"].Equals(DBNull.Value)) ? "" : (string)drRow["code"];
            obj.Name = (drRow["name"].Equals(DBNull.Value)) ? "" : (string)drRow["name"];

            obj.Package_type = (drRow["package_type"].Equals(DBNull.Value)) ? 0 : (int)drRow["package_type"];
            obj.Consignment_number = (drRow["consignment_number"].Equals(DBNull.Value)) ? "" : (string)drRow["consignment_number"];
            obj.Deliver_date = (drRow["deliver_date"].Equals(DBNull.Value)) ? "" : (string)drRow["deliver_date"];
            obj.Booking_date = (drRow["booking_date"].Equals(DBNull.Value)) ? "" : (string)drRow["booking_date"];

            obj.Sender_address = (drRow["sender_address"].Equals(DBNull.Value)) ? "" : (string)drRow["sender_address"];
            obj.Receiver_address = (drRow["receiver_address"].Equals(DBNull.Value)) ? "" : (string)drRow["receiver_address"];
            obj.Receiver_person = (drRow["receiver_person"].Equals(DBNull.Value)) ? "" : (string)drRow["receiver_person"];
            obj.Description = (drRow["description"].Equals(DBNull.Value)) ? "" : (string)drRow["description"];
            obj.Status = (drRow["status"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["status"].ToString());
            obj.Weight = (drRow["weight"].Equals(DBNull.Value)) ? "" : (string)drRow["weight"];
            obj.Isactive = (drRow["isactive"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["isactive"].ToString());
            obj.Tracking_id = (drRow["tracking_id"].Equals(DBNull.Value)) ? 0 : (int)drRow["tracking_id"];


            //if (DateTime.TryParseExact((string)drRow["addon"], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtdata))
            //{
            //    obj.Addon = dtdata;
            //}

            //if (DateTime.TryParseExact((string)drRow["modifyon"], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtdata))
            //{
            //    obj.Modifyon = dtdata;
            //}

            return obj;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        int lastId = 0;

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('consignment_master') ";

            OnClearParameter();

            //DB_Config.OnStartConnection();
            dtTable = OnExecQuery(strQ, "list").Tables[0];


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }


            if (dtTable.Rows.Count != 0)
            {
                lastId = Int32.Parse(dtTable.Rows[0].ItemArray[0].ToString());
            }

            return lastId;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<int> OnGetTableCount()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<int> oList = new List<int>();
        string strQ = "";
        try
        {
            strQ = @"SELECT count(consignment_id_pk) from [consignment_master] where [isactive] = 1";
            OnClearParameter();

            dtTable = OnExecQuery(strQ, "list").Tables[0];
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }
            int intRow = 0;
            int count = (int)dtTable.Rows[0][0];
            oList.Add(count);
            intRow = intRow + 1;
            return oList;
        }
        catch (Exception ex)
        {
            throw ex;
            // return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }
    public int OnGetTableStatus(int ID)
    {
       
       
        string strQ = "";
        try
        {
           strQ = @"Update [consignment_master]  set  [status] =2 where [consignment_id_pk]=@consignment_id_pk";
            
            OnClearParameter();
            AddParameter("@consignment_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
          

            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
            // return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }
    public consignment_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        consignment_master_tableEntities obj = new consignment_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,e.employee_name,e.employee_email,e.employee_contactno,cu.customer_name,
                   cu.company_name,cu.company_contact,cu.phonenumber, p.code, p.name FROM [consignment_master] c 
                         JOIN [employee_master] e ON c.[employee_id_fk] = e.[employee_id_pk] 
                         JOIN [customer_master] cu ON c.[customer_id_fk]=cu.[customer_id_pk] 
                         JOIN [packagetype_master] p ON c.[packagetype_id_fk]=p.[packagetype_id_pk] 
                         where [consignment_id_pk]=@consignment_id_pk and c.[status]=1 and c.[isactive]=1 ";


            OnClearParameter();
            AddParameter("@consignment_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

            //DB_Config.OnStartConnection();
            dtTable = OnExecQuery(strQ, "list").Tables[0];


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }


            if (dtTable.Rows.Count != 0)
            {
                obj = BuildEntities(dtTable.Rows[0]);
            }

            return obj;

        }
        catch (Exception ex)
        {
            throw ex;
           // return obj;
        }
    }

    public consignment_master_tableEntities OnGetDataByTracking(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        consignment_master_tableEntities obj = new consignment_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,e.employee_name,e.employee_email,e.employee_contactno,cu.customer_name,
                   cu.company_name,cu.company_contact,cu.phonenumber, p.code, p.name FROM [consignment_master] c 
                         JOIN [employee_master] e ON c.[employee_id_fk] = e.[employee_id_pk] 
                         JOIN [customer_master] cu ON c.[customer_id_fk]=cu.[customer_id_pk] 
                         JOIN [packagetype_master] p ON c.[packagetype_id_fk]=p.[packagetype_id_pk] 
                         where c.[tracking_id] = @tracking_id_pk  and c.[status]=1 ";


            OnClearParameter();
            AddParameter("@tracking_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

            //DB_Config.OnStartConnection();
            dtTable = OnExecQuery(strQ, "list").Tables[0];


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }


            if (dtTable.Rows.Count != 0)
            {
                obj = BuildEntities(dtTable.Rows[0]);
            }

            return obj;

        }
        catch (Exception ex)
        {
            throw ex;
            // return obj;
        }
    }

    public DataTable OnGetCategory()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<consignment_master_tableEntities> oList = new List<consignment_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [consignment_master]  where [status]= 1 and [isactive]=1";
            OnClearParameter();
            dtTable = OnExecQuery(strQ, "list").Tables[0];



            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }
            return dtTable;
        }
        catch (Exception ex)
        {
            throw ex;
            return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }

    public List<consignment_master_tableEntities> OnGetListdtByID(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<consignment_master_tableEntities> oList = new List<consignment_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,e.employee_name,e.employee_email,e.employee_contactno,cu.customer_name,
                   cu.company_name,cu.company_contact,cu.phonenumber, p.code, p.name FROM [consignment_master] c 
                         JOIN [employee_master] e ON c.[employee_id_fk] = e.[employee_id_pk] 
                         JOIN [customer_master] cu ON c.[customer_id_fk]=cu.[customer_id_pk] 
                         JOIN [packagetype_master] p ON c.[packagetype_id_fk]=p.[packagetype_id_pk] 
                         where [customer_id_fk]=@customer_id_fk ";


            OnClearParameter();
            AddParameter("@customer_id_fk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            dtTable = OnExecQuery(strQ, "list").Tables[0];



            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }
            int intRow = 0;
            while (intRow < dtTable.Rows.Count)
            {
                oList.Add(BuildEntities(dtTable.Rows[intRow]));
                intRow = intRow + 1;
            }
            return oList;
        }
        catch (Exception ex)
        {
            throw ex;
            // return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }

    public List<consignment_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<consignment_master_tableEntities> oList = new List<consignment_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,e.employee_name,e.employee_email,e.employee_contactno,cu.customer_name,
                   cu.company_name,cu.company_contact,cu.phonenumber, p.code,p.name FROM [consignment_master] c 
                         JOIN [employee_master] e ON c.[employee_id_fk] = e.[employee_id_pk] 
                         JOIN [customer_master] cu ON c.[customer_id_fk]=cu.[customer_id_pk] JOIN [packagetype_master] p ON c.[packagetype_id_fk]=p.[packagetype_id_pk] 
                         where  c.[status]=1 and c.[isactive] = 1";
            OnClearParameter();

            dtTable = OnExecQuery(strQ, "list").Tables[0];



            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }
            int intRow = 0;
            while (intRow < dtTable.Rows.Count)
            {
                oList.Add(BuildEntities(dtTable.Rows[intRow]));
                intRow = intRow + 1;
            }
            return oList;
        }
        catch (Exception ex)
        {
            throw ex;
           // return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }
    public List<ComboboxItem> OnGetListForCombo()
    {
        Exception exForce;
        DataTable dtTable;

        List<ComboboxItem> oList = new List<ComboboxItem>();

        string strQ = "";

        try
        {

            OnClearParameter();
            strQ = @"SELECT consignment_id_pk,consignment_number FROM [consignment_master] 
                            where status=1 and [isactive]=1";

            dtTable = OnExecQuery(strQ, "list").Tables[0];

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }

            int intRow = 0;
            while (intRow < dtTable.Rows.Count)
            {
                ComboboxItem objData = new ComboboxItem();
                objData.ID = dtTable.Rows[intRow]["consignment_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["consignment_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["consignment_number"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["consignment_number"];
                oList.Add(objData);

                intRow = intRow + 1;
            }
            return oList;
        }
        catch (Exception ex)
        {
            throw ex;
          return oList;
        }
    }
}
