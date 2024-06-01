using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class customer_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "customer_master_tableDB";

    public customer_master_tableDB()
        
    {
    }

   public int OnInsert(customer_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [customer_master]
                                   ([customer_name],[company_name],[company_contact],[phonenumber],[email],[address1],[city_id_fk])
                             VALUES
                                   (@customer_name,@company_name,@company_contact,@phonenumber,@email,@address1,@city_id_fk)";

            OnClearParameter();
            AddParameter("@customer_name", SqlDbType.VarChar, 500, obj.Customer_name, ParameterDirection.Input);
            AddParameter("@company_name", SqlDbType.VarChar, 500, obj.Company_name, ParameterDirection.Input);
            AddParameter("@company_contact", SqlDbType.VarChar, 500, obj.Company_contact, ParameterDirection.Input);
            AddParameter("@phonenumber", SqlDbType.VarChar, 500, obj.Phonenumber, ParameterDirection.Input);
            AddParameter("@email", SqlDbType.VarChar, 500, obj.Email, ParameterDirection.Input);
            AddParameter("@address1", SqlDbType.VarChar, 500, obj.Address1, ParameterDirection.Input);
            AddParameter("@city_id_fk", SqlDbType.Int, 500, obj.City_id_fk, ParameterDirection.Input);

           // AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive1, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(customer_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [customer_master]
                             SET    [customer_name]=@customer_name,
                                    [company_name]=@company_name,      
                                    [company_contact]=@company_contact,
                                    [phonenumber]=@phonenumber,
                                    [email]=@email,
                                    [address1]=@address1,
                                    [city_id_fk]=@city_id_fk,
                                    [isactive]=1     
                         WHERE [customer_id_pk]=@customer_id_pk";
            OnClearParameter();
            AddParameter("@customer_id_pk", SqlDbType.Int, 50, obj.Customer_id_pk, ParameterDirection.Input);
            AddParameter("@customer_name", SqlDbType.VarChar, 50, obj.Customer_name, ParameterDirection.Input);
            AddParameter("@company_name", SqlDbType.VarChar, 50, obj.Company_name, ParameterDirection.Input);
            AddParameter("@company_contact", SqlDbType.VarChar, 50, obj.Company_contact, ParameterDirection.Input);
            AddParameter("@phonenumber", SqlDbType.VarChar, 50, obj.Phonenumber, ParameterDirection.Input);
            AddParameter("@email", SqlDbType.VarChar, 50, obj.Email, ParameterDirection.Input);
            AddParameter("@address1", SqlDbType.VarChar, 50, obj.Address1, ParameterDirection.Input);
            AddParameter("@city_id_fk", SqlDbType.Int, 50, obj.City_id_fk, ParameterDirection.Input);
            AddParameter("@isactive", SqlDbType.Int, 50, obj.IsActive, ParameterDirection.Input);

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
            strQ += @"update  [customer_master] 
                           set [isactive]=0
                           WHERE [customer_id_pk]=@customer_id_pk";

            OnClearParameter();
            AddParameter("@customer_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private customer_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            customer_master_tableEntities obj = new customer_master_tableEntities();

            obj.Customer_id_pk = (drRow["customer_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["customer_id_pk"];
            obj.Customer_name = (drRow["customer_name"].Equals(DBNull.Value)) ? "" : (string)drRow["customer_name"];
            obj.Company_name = (drRow["company_name"].Equals(DBNull.Value)) ? "" : (string)drRow["company_name"];
            obj.Company_contact = (drRow["company_contact"].Equals(DBNull.Value)) ? "" : (string)drRow["company_contact"];
            obj.Phonenumber = (drRow["phonenumber"].Equals(DBNull.Value)) ? "" : (string)drRow["phonenumber"];
            obj.Email = (drRow["email"].Equals(DBNull.Value)) ? "" : (string)drRow["email"];
            obj.Address1 = (drRow["address1"].Equals(DBNull.Value)) ? "" : (string)drRow["address1"];
            obj.City_id_fk = (drRow["city_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["city_id_fk"];
            obj.City_name = (drRow["city_name"].Equals(DBNull.Value)) ? "" : (string)drRow["city_name"];

            obj.IsActive = (drRow["isActive"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["isActive"].ToString());
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

    public int OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        int lastId = 0;

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('customer_master') ";

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
            strQ = @"SELECT count(customer_id_pk) from [customer_master] where [isActive] = 1";
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

    public customer_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        customer_master_tableEntities obj = new customer_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,ci.city_name  from [customer_master] c 
                                JOIN [city_master] ci ON c.[city_id_fk] = ci.[city_id_pk]
                                WHERE [customer_id_pk] = @customer_id_pk
                                and c.[isactive] = 1";


            OnClearParameter();
            AddParameter("@customer_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
        List<customer_master_tableEntities> oList = new List<customer_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [customer_master]  where [isactive]= 1";
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

    public List<customer_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<customer_master_tableEntities> oList = new List<customer_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT c.* , ci.city_name from [customer_master] c 
                            JOIN [city_master] ci ON c.[city_id_fk] = ci.[city_id_pk]
                            WHERE c.[isactive] = 1 ";
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
            strQ = @"SELECT [customer_master].customer_id_pk,[customer_master].customer_name FROM [customer_master] 
                                WHERE c.[isactive] = 1 ";

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
                objData.ID = dtTable.Rows[intRow]["customer_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["customer_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["customer_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["customer_name"];
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
