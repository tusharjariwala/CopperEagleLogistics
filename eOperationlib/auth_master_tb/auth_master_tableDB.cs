using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class auth_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "auth_master_tableDB";

    public auth_master_tableDB()
        
    {

    }

   public int OnInsert(auth_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [auth_master]
                                   ([employee_email],[password],[user_id_fk],[user_type])
                             VALUES
                                   (@employee_email,@password,@user_id_fk,@user_type)";

            OnClearParameter();
          
            AddParameter("@employee_email", SqlDbType.VarChar, 500, obj.Employee_email, ParameterDirection.Input);
            AddParameter("@password", SqlDbType.VarChar, 500, obj.Password, ParameterDirection.Input);
            AddParameter("@user_id_fk", SqlDbType.Int, 50, obj.User_id_fk, ParameterDirection.Input);
            AddParameter("@user_type", SqlDbType.VarChar, 500, obj.User_type, ParameterDirection.Input);
           
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(auth_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [auth_master]
                             SET    [employee_email]=@employee_email,
                                    [password]=@password,
                                    [user_type]=@user_type,
                                   [user_id_fk]=@ususer_id_fk,
                                                                  
                         WHERE [auth_id_pk]=@auth_id_pk";
            OnClearParameter();
            AddParameter("@auth_id_pk", SqlDbType.Int, 50, obj.Auth_id_pk, ParameterDirection.Input);
            AddParameter("@employee_email", SqlDbType.VarChar, 50, obj.Employee_email, ParameterDirection.Input);
            AddParameter("@password", SqlDbType.VarChar, 50, obj.Password, ParameterDirection.Input);
            AddParameter("@user_id_fk", SqlDbType.Int, 50, obj.User_id_fk, ParameterDirection.Input);
            AddParameter("@user_type", SqlDbType.VarChar, 50, obj.User_type, ParameterDirection.Input);
            
           

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
            strQ += @"update  [auth_master]                           
                           
                           WHERE [auth_id_pk]=@auth_id_pk";

            OnClearParameter();
            AddParameter("@auth_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private auth_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            auth_master_tableEntities obj = new auth_master_tableEntities();

            obj.Auth_id_pk = (drRow["auth_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["auth_id_pk"];
            obj.Employee_email = (drRow["employee_email"].Equals(DBNull.Value)) ? "" : (string)drRow["employee_email"];
            obj.Password = (drRow["password"].Equals(DBNull.Value)) ? "" : (string)drRow["password"];
            obj.User_type = (drRow["user_type"].Equals(DBNull.Value)) ? "" : (string)drRow["user_type"];
            obj.User_id_fk = (drRow["user_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["user_id_fk"];



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
    public auth_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        auth_master_tableEntities obj = new auth_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [auth_master] WHERE [auth_id_pk] = @auth_id_pk ";

            OnClearParameter();
            AddParameter("@auth_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
    public auth_master_tableEntities OnLoginData(string email,string password)
    {
        Exception exForce;
        DataTable dtTable;

        auth_master_tableEntities obj = new auth_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [auth_master] WHERE [employee_email] = @employee_email and [Password]=@password ";

            OnClearParameter();
            AddParameter("@employee_email", SqlDbType.VarChar, 50,email, ParameterDirection.Input);
            AddParameter("@password", SqlDbType.VarChar, 50, password, ParameterDirection.Input);

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
        List<auth_master_tableEntities> oList = new List<auth_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [auth_master]  ";
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

    public List<auth_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<auth_master_tableEntities> oList = new List<auth_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from auth_master";
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
            strQ = @"SELECT auth_id_pk,employee_email FROM [auth_master] ";

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
                objData.ID = dtTable.Rows[intRow]["auth_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["auth_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["employee_email"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["employee_email"];
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
