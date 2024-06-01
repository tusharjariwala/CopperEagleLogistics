using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class vehicle_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "vehicle_master_tableDB";

    public vehicle_master_tableDB()
        
    {
    }

   public int OnInsert(vehicle_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [vehicle_master]
                                   ([vehicle_name],[vehicle_type],[vehicle_number],[vehicle_loadamount],[warehouse_id_fk])
                             VALUES
                                   (@vehicle_name,@vehicle_type,@vehicle_number,@vehicle_loadamount,@warehouse_id_fk)";

            OnClearParameter();
            AddParameter("@vehicle_name", SqlDbType.VarChar, 500, obj.Vehicle_name, ParameterDirection.Input);
            AddParameter("@vehicle_type", SqlDbType.VarChar, 500, obj.Vehicle_type, ParameterDirection.Input);
            AddParameter("@vehicle_number", SqlDbType.VarChar, 500, obj.Vehicle_number, ParameterDirection.Input);
            AddParameter("@vehicle_loadamount", SqlDbType.VarChar, 500, obj.Vehicle_loadamount, ParameterDirection.Input);
            AddParameter("@warehouse_id_fk", SqlDbType.Int, 500, obj.Warehouse_id_fk, ParameterDirection.Input);

            // AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive1, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(vehicle_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [vehicle_master]
                             SET    [vehicle_name]=@vehicle_name,
                                    [vehicle_type]=@vehicle_type,
                                    [vehicle_number]=@vehicle_number,
                                    [vehicle_loadamount]=@vehicle_loadamount,
                                    [warehouse_id_fk]=@warehouse_id_fk
                         WHERE [vehicle_id_pk]=@vehicle_id_pk";
            OnClearParameter();
            AddParameter("@vehicle_id_pk", SqlDbType.Int, 50, obj.Vehicle_id_pk, ParameterDirection.Input);
            AddParameter("@vehicle_name", SqlDbType.VarChar, 50, obj.Vehicle_name, ParameterDirection.Input);
            AddParameter("@vehicle_type", SqlDbType.VarChar, 50, obj.Type, ParameterDirection.Input);
            AddParameter("@vehicle_number", SqlDbType.VarChar, 50, obj.Vehicle_number, ParameterDirection.Input);
            AddParameter("@vehicle_loadamount", SqlDbType.VarChar, 50, obj.Vehicle_loadamount, ParameterDirection.Input);
            AddParameter("@warehouse_id_fk", SqlDbType.Int, 50, obj.Warehouse_id_fk, ParameterDirection.Input);
      

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
            strQ += @"update  [vehicle_master]                             
                           set [isactive]=0
                         WHERE [vehicle_id_pk]=@vehicle_id_pk";

            OnClearParameter();
            AddParameter("@vehicle_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private vehicle_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            vehicle_master_tableEntities obj = new vehicle_master_tableEntities();

            obj.Vehicle_id_pk = (drRow["vehicle_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["vehicle_id_pk"];
            obj.Vehicle_name = (drRow["vehicle_name"].Equals(DBNull.Value)) ? "" : (string)drRow["vehicle_name"];
            obj.Vehicle_type = (drRow["vehicle_type"].Equals(DBNull.Value)) ? "" : (string)drRow["vehicle_type"];
            obj.Vehicle_number = (drRow["vehicle_number"].Equals(DBNull.Value)) ? "" : (string)drRow["vehicle_number"];
            obj.Vehicle_loadamount = (drRow["vehicle_loadamount"].Equals(DBNull.Value)) ? "" : (string)drRow["vehicle_loadamount"];
            obj.Warehouse_id_fk = (drRow["warehouse_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["warehouse_id_fk"];
            obj.Warehouse_name = (drRow["warehouse_name"].Equals(DBNull.Value)) ? "" : (string)drRow["warehouse_name"];
            obj.Address = (drRow["address"].Equals(DBNull.Value)) ? "" : (string)drRow["address"];
            obj.Type = (drRow["type"].Equals(DBNull.Value)) ? "" : (string)drRow["type"];
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
    public vehicle_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        vehicle_master_tableEntities obj = new vehicle_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT v.*,w.warehouse_name,w.address,w.type FROM [vehicle_master] v 
                        JOIN [warehouse_master] w ON v.[warehouse_id_fk] = w.[warehouse_id_pk]
                        WHERE [vehicle_id_pk] = @vehicle_id_pk and v.[isactive] = 1 ";

            OnClearParameter();
            AddParameter("@vehicle_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
            strQ = @"SELECT count(vehicle_id_pk) from [vehicle_master] where [isactive] = 1";
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
        List<vehicle_master_tableEntities> oList = new List<vehicle_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [vehicle_master]  where [isactive]= 1 ";
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

    public List<vehicle_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<vehicle_master_tableEntities> oList = new List<vehicle_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT v.*,w.warehouse_name,w.address,w.type FROM [vehicle_master] v
                            JOIN [warehouse_master] w ON v.[warehouse_id_fk] = w.[warehouse_id_pk]  
                            where v.[isactive]= 1  ";
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
            strQ = @"SELECT vehicle_id_pk,vehicle_name FROM [ vehicle_master]   where [isactive]= 1  ";

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
                objData.ID = dtTable.Rows[intRow]["vehicle_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["vehicle_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["vehicle_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["vehicle_name"];
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
