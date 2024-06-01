using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class driver_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "driver_master_tableDB";

    public driver_master_tableDB()
        
    {
    }

   public int OnInsert(driver_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [driver_master]
                                   ([driver_name],[driver_licence],[driver_contactno],[address],[vehicle_id_fk])
                             VALUES
                                   (@driver_name,@driver_licence,@driver_contactno,@address,@vehicle_id_fk)";

            OnClearParameter();
            AddParameter("@driver_name", SqlDbType.VarChar, 500, obj.Driver_name, ParameterDirection.Input);
            AddParameter("@driver_licence", SqlDbType.VarChar, 500, obj.Driver_licence, ParameterDirection.Input);
            AddParameter("@driver_contactno", SqlDbType.VarChar, 500, obj.Driver_contactno, ParameterDirection.Input);
            AddParameter("@address", SqlDbType.VarChar, 500, obj.Address, ParameterDirection.Input);
            AddParameter("@vehicle_id_fk", SqlDbType.Int, 500, obj.Vehicle_id_fk, ParameterDirection.Input);

            // AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive1, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(driver_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [driver_master]
                             SET    [driver_name]=@driver_name,
                                    [driver_licence]=@driver_licence,
                                    [driver_contactno]=@driver_contactno,
                                    [address]=@address,
                                    [vehicle_id_fk]=@vehicle_id_fk,
                                    [isactive]=1                                
                           WHERE [driver_id_pk]=@driver_id_pk";
            OnClearParameter();
            AddParameter("@driver_id_pk", SqlDbType.Int, 50, obj.Driver_id_pk, ParameterDirection.Input);
            AddParameter("@driver_name", SqlDbType.VarChar, 50, obj.Driver_name, ParameterDirection.Input);
            AddParameter("@driver_licence", SqlDbType.VarChar, 50, obj.Driver_licence, ParameterDirection.Input);
            AddParameter("@driver_contactno", SqlDbType.VarChar, 50, obj.Driver_contactno, ParameterDirection.Input);
            AddParameter("@address", SqlDbType.VarChar, 50, obj.Address, ParameterDirection.Input);
            AddParameter("@vehicle_id_fk", SqlDbType.Int, 50, obj.Vehicle_id_fk, ParameterDirection.Input);
            AddParameter("@isactive", SqlDbType.Int, 50, obj.Isactive, ParameterDirection.Input);

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
            strQ += @"update  [driver_master]                              
                           set [isactive]=0
                           WHERE [driver_id_pk]=@driver_id_pk";

            OnClearParameter();
            AddParameter("@driver_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private driver_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            driver_master_tableEntities obj = new driver_master_tableEntities();

            obj.Driver_id_pk = (drRow["driver_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["driver_id_pk"];
            obj.Driver_name = (drRow["driver_name"].Equals(DBNull.Value)) ? "" : (string)drRow["driver_name"];
            obj.Driver_licence = (drRow["driver_licence"].Equals(DBNull.Value)) ? "" : (string)drRow["driver_licence"];
            obj.Driver_contactno = (drRow["driver_contactno"].Equals(DBNull.Value)) ? "" : (string)drRow["driver_contactno"];
            obj.Address = (drRow["address"].Equals(DBNull.Value)) ? "" : (string)drRow["address"];
            obj.Vehicle_id_fk = (drRow["vehicle_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["vehicle_id_fk"];
            obj.Vehicle_name = (drRow["vehicle_name"].Equals(DBNull.Value)) ? "" : (string)drRow["vehicle_name"];
            obj.Vehicle_number = (drRow["vehicle_number"].Equals(DBNull.Value)) ? "" : (string)drRow["vehicle_number"];
          
            obj.Isactive = (drRow["isactive"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["isactive"].ToString());
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
    public driver_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        driver_master_tableEntities obj = new driver_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT d.*,v.vehicle_name,v.vehicle_number FROM [driver_master] d 
                               JOIN [vehicle_master] v ON d.[vehicle_id_fk] = v.[vehicle_id_pk] 
                               WHERE [driver_id_pk] = @driver_id_pk and d.[isactive]=1";

            OnClearParameter();
            AddParameter("@driver_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
    public List<int> OnGetTableCount()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<int> oList = new List<int>();
        string strQ = "";
        try
        {
            strQ = @"SELECT count(driver_id_pk) from [driver_master] where [isactive] = 1";
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
        List<driver_master_tableEntities> oList = new List<driver_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [driver_master]  where [isactive]= 1";
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

    public List<driver_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<driver_master_tableEntities> oList = new List<driver_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT d.*,v.vehicle_name,v.vehicle_number FROM [driver_master] d 
                            JOIN [vehicle_master] v ON d.[vehicle_id_fk] = v.[vehicle_id_pk] where  d.[isactive] = 1";
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
            strQ = @"SELECT driver_id_pk,driver_name FROM [ driver_master] 
                                where isactive = 1 ";

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
                objData.ID = dtTable.Rows[intRow]["driver_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["driver_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["driver_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["driver_name"];
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
