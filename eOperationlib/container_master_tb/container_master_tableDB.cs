using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class container_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "container_master_tableDB";

    public container_master_tableDB()
        
    {
    }

   public int OnInsert(container_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [container_master]
                                   ([container_name],[container_number],[delivery_days],[departed_date],[expected_date],[employee_id_fk],[status],[tracking_id])
                             VALUES
                                   (@container_name,@container_number,@delivery_days,@departed_date,@expected_date,@employee_id_fk,@status,@tracking_id)";

            OnClearParameter();
            AddParameter("@container_name", SqlDbType.VarChar, 50, obj.Container_name, ParameterDirection.Input);
            AddParameter("@container_number", SqlDbType.VarChar, 50, obj.Container_number1, ParameterDirection.Input);
            AddParameter("@delivery_days", SqlDbType.VarChar, 50, obj.Delivery_days, ParameterDirection.Input);
            AddParameter("@departed_date", SqlDbType.VarChar, 50, obj.Departed_date, ParameterDirection.Input);
            AddParameter("@expected_date", SqlDbType.VarChar, 50, obj.Expected_date, ParameterDirection.Input);
            AddParameter("@employee_id_fk", SqlDbType.Int, 50, obj.Employee_id_fk, ParameterDirection.Input);
            AddParameter("@status", SqlDbType.Int, 50, obj.Status1, ParameterDirection.Input);
            AddParameter("@tracking_id", SqlDbType.Int, 50, obj.Tracking_id, ParameterDirection.Input);
            // AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive1, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(container_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [container_master]
                             SET    [container_name]=@container_name,
                                    [container_number]=@container_number,
                                    [delivery_days]=@delivery_days,
                                    [departed_date]=@departed_date,
                                    [expected_date]=@expected_date,
                                    [employee_id_fk]=@employee_id_fk,
                                    [status]=1                           
                         WHERE [container_id_pk]=@container_id_pk";
            OnClearParameter();
            AddParameter("@container_id_pk", SqlDbType.Int, 50, obj.Container_id_pk, ParameterDirection.Input);
            AddParameter("@container_name", SqlDbType.VarChar, 50, obj.Container_name, ParameterDirection.Input);
            AddParameter("@container_number", SqlDbType.VarChar, 50, obj.Container_number1, ParameterDirection.Input);
            AddParameter("@delivery_days", SqlDbType.VarChar, 50, obj.Delivery_days, ParameterDirection.Input);
            AddParameter("@departed_date", SqlDbType.VarChar, 50, obj.Departed_date, ParameterDirection.Input);
            AddParameter("@expected_date", SqlDbType.VarChar, 50, obj.Expected_date, ParameterDirection.Input);
            AddParameter("@employee_id_fk", SqlDbType.Int, 50, obj.Employee_id_fk, ParameterDirection.Input);
            AddParameter("@status", SqlDbType.Int, 50, obj.Status1, ParameterDirection.Input);
      

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
            strQ += @"update  [container_master] 
                         set [isactive]=0,  
                              [status]=0
                         WHERE [container_id_pk]=@container_id_pk";

            OnClearParameter();
            AddParameter("@container_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private container_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            container_master_tableEntities obj = new container_master_tableEntities();

            obj.Container_id_pk = (drRow["container_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["container_id_pk"];
            obj.Container_name = (drRow["container_name"].Equals(DBNull.Value)) ? "" : (string)drRow["container_name"];

         
            obj.Container_number1 = (drRow["container_number"].Equals(DBNull.Value)) ? "" : (string)drRow["container_number"];
            obj.Delivery_days = (drRow["delivery_days"].Equals(DBNull.Value)) ? "" : (string)drRow["delivery_days"];
            obj.Departed_date = (drRow["departed_date"].Equals(DBNull.Value)) ? "" : (string)drRow["departed_date"];
            obj.Expected_date = (drRow["expected_date"].Equals(DBNull.Value)) ? "" : (string)drRow["expected_date"];

           
            obj.Employee_id_fk = (drRow["employee_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["employee_id_fk"];
            obj.Employee_name = (drRow["employee_name"].Equals(DBNull.Value)) ? "" : (string)drRow["employee_name"];
            obj.Employee_email = (drRow["employee_email"].Equals(DBNull.Value)) ? "" : (string)drRow["employee_email"];
            obj.Employee_contactno = (drRow["employee_contactno"].Equals(DBNull.Value)) ? "" : (string)drRow["employee_contactno"];

            obj.Status1 = (drRow["status"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["status"].ToString());
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
    public container_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        container_master_tableEntities obj = new container_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,e.employee_name,e.employee_email,e.employee_contactno  From [container_master] c 
                            JOIN [employee_master] e ON c.[employee_id_fk] =e.[employee_id_pk]
                            WHERE [container_id_pk] = @container_id_pk   
                            and c.[status] = 1 and c.[isactive]=1";

            OnClearParameter();
            AddParameter("@container_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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

    public container_master_tableEntities OnGetDataByTracking(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        container_master_tableEntities obj = new container_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,e.employee_name,e.employee_email,e.employee_contactno  From [container_master] c 
                            JOIN [employee_master] e ON c.[employee_id_fk] =e.[employee_id_pk]
                            WHERE c.[tracking_id] = @tracking_id_pk   
                            and c.[status] = 1 ";

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

    public int OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        int lastId = 0;

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('container_master') ";

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
            strQ = @"SELECT count(container_id_pk) from [container_master] where [isactive] = 1";
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

    public DataTable OnGetCategory()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<container_master_tableEntities> oList = new List<container_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [container_master] where [status] = 1 and [isactive]=1 ";
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

    public List<container_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<container_master_tableEntities> oList = new List<container_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT c.*,e.employee_name,e.employee_email,e.employee_contactno  From [container_master] c 
                            JOIN [employee_master] e ON c.[employee_id_fk] =e.[employee_id_pk]
                            WHERE  c.[status] = 1 and c.[isactive]=1 ";
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
            strQ = @"SELECT container_id_pk,container_name FROM [container_master] where [status] = 1 and [isactive]=1  ";

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
                objData.ID = dtTable.Rows[intRow]["container_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["container_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["container_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["container_name"];
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
