using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class employee_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "employee_master_tableDB";

    public employee_master_tableDB()
        
    {

    }

   public int OnInsert(employee_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [employee_master]
                                   ([employee_name],[employee_email],[type],[employee_contactno],[isactive])
                             VALUES
                                   (@employee_name,@employee_email,@type,@employee_contactno,@isactive)";

            OnClearParameter();
            AddParameter("@employee_name", SqlDbType.VarChar, 500, obj.Employee_name, ParameterDirection.Input);
          
            AddParameter("@employee_email", SqlDbType.VarChar, 500, obj.Employee_email, ParameterDirection.Input);
            AddParameter("@type", SqlDbType.VarChar, 500, obj.Type, ParameterDirection.Input);
            AddParameter("@employee_contactno", SqlDbType.VarChar, 500, obj.Employee_contactno, ParameterDirection.Input);
            AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(employee_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [employee_master]
                             SET    [employee_name]=@employee_name,
                                    [employee_email]=@employee_email,
                                    [type]=@type,
                                    [employee_contactno]=@employee_contactno
                                                                  
                         WHERE [employee_id_pk]=@employee_id_pk";
            OnClearParameter();
            AddParameter("@employee_id_pk", SqlDbType.Int, 50, obj.Employee_id_pk, ParameterDirection.Input);
            AddParameter("@employee_name", SqlDbType.VarChar, 50, obj.Employee_name, ParameterDirection.Input);
           
            AddParameter("@employee_email", SqlDbType.VarChar, 50, obj.Employee_email, ParameterDirection.Input);
            AddParameter("@type", SqlDbType.VarChar, 50, obj.Type, ParameterDirection.Input);
            AddParameter("@employee_contactno", SqlDbType.VarChar, 50, obj.Employee_contactno, ParameterDirection.Input);
           

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
            strQ += @"update  [employee_master]                           
                           set [isactive]=0
                           WHERE [employee_id_pk]=@employee_id_pk";

            OnClearParameter();
            AddParameter("@employee_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private employee_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            employee_master_tableEntities obj = new employee_master_tableEntities();

            obj.Employee_id_pk = (drRow["employee_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["employee_id_pk"];
            obj.Employee_name = (drRow["employee_name"].Equals(DBNull.Value)) ? "" : (string)drRow["employee_name"];
            obj.Employee_email = (drRow["employee_email"].Equals(DBNull.Value)) ? "" : (string)drRow["employee_email"];
            obj.Type = (drRow["type"].Equals(DBNull.Value)) ? "" : (string)drRow["type"];
            obj.Employee_contactno = (drRow["employee_contactno"].Equals(DBNull.Value)) ? "" : (string)drRow["employee_contactno"];
            obj.IsActive = (drRow["isactive"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["isactive"].ToString());



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
            strQ = @"SELECT IDENT_CURRENT('employee_master') ";

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
            strQ = @"SELECT count(employee_id_pk) from [employee_master] where [isactive] = 1";
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
    public employee_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        employee_master_tableEntities obj = new employee_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [employee_master] WHERE [employee_id_pk] = @employee_id_pk and [isactive] = 1";

            OnClearParameter();
            AddParameter("@employee_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
        List<employee_master_tableEntities> oList = new List<employee_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [employee_master]  
                            where [isactive]= 1";
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

    public List<employee_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<employee_master_tableEntities> oList = new List<employee_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from employee_master 
                            where [isactive]= 1 ";
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
            strQ = @"SELECT employee_id_pk,employee_name FROM [ employee_master] where [isactive]= 1 ";

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
                objData.ID = dtTable.Rows[intRow]["employee_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["employee_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["employee_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["employee_name"];
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
