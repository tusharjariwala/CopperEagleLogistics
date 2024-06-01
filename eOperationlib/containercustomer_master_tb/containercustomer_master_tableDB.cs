using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class containercustomer_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "containercustomer_master_tableDB";

    public containercustomer_master_tableDB()
        
    {
    }

   public int OnInsert(containercustomer_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [containercustomer_master]
                                   ([container_id_fk],[customer_id_fk],[no_of_parcels])
                             VALUES
                                   (@container_id_fk,@customer_id_fk,@no_of_parcels)";
            OnClearParameter();
            AddParameter("@container_id_fk", SqlDbType.Int, 50, obj.Container_id_fk, ParameterDirection.Input);
            AddParameter("@customer_id_fk", SqlDbType.Int, 50, obj.Customer_id_fk, ParameterDirection.Input);
            AddParameter("@no_of_parcels", SqlDbType.VarChar, 50, obj.No_of_parcels, ParameterDirection.Input);


            
           

            // AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive1, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(containercustomer_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [containercustomer_master]
                             SET    [container_id_fk]=@container_id_fk,
                                    [customer_id_fk]=@customer_id_fk,
                                    [no_of_parcels]=@no_of_parcels
                             WHERE [container_customerid_pk]=@container_customerid_pk";
            OnClearParameter();
            AddParameter("@container_customerid_pk", SqlDbType.Int, 50, obj.Container_customerid_pk, ParameterDirection.Input);
            AddParameter("@container_id_fk", SqlDbType.Int, 50, obj.Container_id_fk, ParameterDirection.Input);
            AddParameter("@customer_id_fk", SqlDbType.Int, 50, obj.Customer_id_fk, ParameterDirection.Input);
            AddParameter("@no_of_parcels", SqlDbType.VarChar, 50, obj.No_of_parcels, ParameterDirection.Input);
            
      

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
            strQ += @"delete from  [containercustomer_master]
                          
                           WHERE [container_customerid_pk]=@container_customerid_pk";

            OnClearParameter();
            AddParameter("@container_customerid_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private containercustomer_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            containercustomer_master_tableEntities obj = new containercustomer_master_tableEntities();

            obj.Container_customerid_pk = (drRow["container_customerid_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["container_customerid_pk"];
        
            obj.Container_id_fk = (drRow["container_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["container_id_fk"];
            obj.Container_name = (drRow["container_name"].Equals(DBNull.Value)) ? "" : (string)drRow["container_name"];
            obj.Container_number = (drRow["container_number"].Equals(DBNull.Value)) ? "" : (string)drRow["container_number"];
            obj.Delivery_days = (drRow["delivery_days"].Equals(DBNull.Value)) ? "" : (string)drRow["delivery_days"];
            obj.Departed_date = (drRow["departed_date"].Equals(DBNull.Value)) ? "" : (string)drRow["departed_date"];
        
            obj.Customer_id_fk = (drRow["customer_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["customer_id_fk"];
            obj.Customer_name = (drRow["customer_name"].Equals(DBNull.Value)) ? "" : (string)drRow["customer_name"];
            obj.Company_name = (drRow["company_name"].Equals(DBNull.Value)) ? "" : (string)drRow["company_name"];
            obj.Company_contact = (drRow["company_contact"].Equals(DBNull.Value)) ? "" : (string)drRow["company_contact"];
            obj.Phonenumber = (drRow["phonenumber"].Equals(DBNull.Value)) ? "" : (string)drRow["phonenumber"];

            obj.No_of_parcels = (drRow["no_of_parcels"].Equals(DBNull.Value)) ? "" : (string)drRow["no_of_parcels"];
            obj.Added_by = (drRow["added_by"].Equals(DBNull.Value)) ? 0 : (int)drRow["added_by"];



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
    public containercustomer_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        containercustomer_master_tableEntities obj = new containercustomer_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,cu.customer_name,cu.company_name,cu.company_contact,cu.phonenumber,co.container_name,co.container_number,co.delivery_days,co.departed_date
                                 From [containercustomer_master] c 
                                 JOIN [customer_master] cu ON c.[customer_id_fk] =cu.[customer_id_pk]
                                 JOIN [container_master] co ON c.[container_id_fk] =co.[container_id_pk] 
                                 WHERE [container_customerid_pk] = @container_customerid_pk ";

            OnClearParameter();
            AddParameter("@container_customerid_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
        List<containercustomer_master_tableEntities> oList = new List<containercustomer_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [containercustomer_master]";
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

    public List<containercustomer_master_tableEntities> OnGetListdt(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<containercustomer_master_tableEntities> oList = new List<containercustomer_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,cu.customer_name,cu.company_name,cu.company_contact,cu.phonenumber,co.container_name,co.container_number,co.delivery_days,co.departed_date
                            From [containercustomer_master] c 
                            JOIN [customer_master] cu ON c.[customer_id_fk] =cu.[customer_id_pk]
                            JOIN [container_master] co ON c.[container_id_fk] =co.[container_id_pk] 
                            where c.[container_id_fk]=@container_id_fk";
            OnClearParameter();

            AddParameter("@container_id_fk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
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
            strQ = @"SELECT container_customerid_pk,no_of_parcels FROM [containercustomer_master]  ";

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
                objData.ID = dtTable.Rows[intRow]["container_customerid_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["container_customerid_pk"];
                objData.NAME = dtTable.Rows[intRow]["no_of_parcels"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["no_of_parcels"];
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
