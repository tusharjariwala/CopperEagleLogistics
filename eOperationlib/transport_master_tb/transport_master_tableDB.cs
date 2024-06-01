using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class transport_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "transport_master_tableDB";

    public transport_master_tableDB()
        
    {
    }

   public int OnInsert(transport_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [transport_master]
                                   ([pick_up_date],[devlivery_date],[vehicle_id_fk],[fromwarehouse_fk],[towarehouse_fk],[type],[cargo_type])
                             VALUES
                                   (@pick_up_date,@devlivery_date,@vehicle_id_fk,@fromwarehouse_fk,@towarehouse_fk,@type,@cargo_type)";
            OnClearParameter();
            AddParameter("@pick_up_date", SqlDbType.VarChar, 50, obj.Pick_up_date, ParameterDirection.Input);
            AddParameter("@devlivery_date", SqlDbType.VarChar, 50, obj.Devlivery_date, ParameterDirection.Input);
          
            AddParameter("@vehicle_id_fk", SqlDbType.Int, 50, obj.Vehicle_id_fk, ParameterDirection.Input);
            AddParameter("@fromwarehouse_fk", SqlDbType.Int, 50, obj.Fromwarehouse_fk, ParameterDirection.Input);
            AddParameter("@towarehouse_fk", SqlDbType.Int, 50, obj.Towarehouse_fk, ParameterDirection.Input);

            AddParameter("@type", SqlDbType.VarChar, 50, obj.Type, ParameterDirection.Input);
            AddParameter("@cargo_type", SqlDbType.VarChar, 50, obj.Cargo_type, ParameterDirection.Input);

            // AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive1, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(transport_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [transport_master]
                             SET    [pick_up_date]=@pick_up_date,
                                    [devlivery_date]=@devlivery_date,
                                    [vehicle_id_fk]=@vehicle_id_fk,
                                  
                                    [fromwarehouse_fk]=@fromwarehouse_fk,
                                    [towarehouse_fk]=@towarehouse_fk
                         WHERE [transport_id_pk]=@transport_id_pk";
            OnClearParameter();
            AddParameter("@transport_id_pk", SqlDbType.Int, 50, obj.Transport_id_pk, ParameterDirection.Input);
            AddParameter("@pick_up_date", SqlDbType.VarChar, 50, obj.Pick_up_date, ParameterDirection.Input);
            AddParameter("@devlivery_date", SqlDbType.VarChar, 50, obj.Devlivery_date, ParameterDirection.Input);

        
            AddParameter("@vehicle_id_fk", SqlDbType.Int, 50, obj.Vehicle_id_fk, ParameterDirection.Input);
            AddParameter("@fromwarehouse_fk", SqlDbType.Int, 50, obj.Fromwarehouse_fk, ParameterDirection.Input);
            AddParameter("@towarehouse_fk", SqlDbType.Int, 50, obj.Towarehouse_fk, ParameterDirection.Input);
      

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
            strQ += @"update  [transport_master]
                           set [isactive]=0
                           WHERE [transport_id_pk]=@transport_id_pk";

            OnClearParameter();
            AddParameter("@transport_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private transport_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            transport_master_tableEntities obj = new transport_master_tableEntities();

            obj.Transport_id_pk = (drRow["transport_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["transport_id_pk"];
            obj.Pick_up_date = (drRow["pick_up_date"].Equals(DBNull.Value)) ? "" : (string)drRow["pick_up_date"];
            obj.Devlivery_date = (drRow["devlivery_date"].Equals(DBNull.Value)) ? "" : (string)drRow["devlivery_date"];

         

          
            obj.Vehicle_id_fk = (drRow["vehicle_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["vehicle_id_fk"];
            obj.Vehicle_name = (drRow["vehicle_name"].Equals(DBNull.Value)) ? "" : (string)drRow["vehicle_name"];
            obj.Vehicle_type = (drRow["vehicle_type"].Equals(DBNull.Value)) ? "" : (string)drRow["vehicle_type"];
            obj.Vehicle_number = (drRow["vehicle_number"].Equals(DBNull.Value)) ? "" : (string)drRow["vehicle_number"];

         
            obj.Fromwarehouse_fk = (drRow["fromwarehouse_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["fromwarehouse_fk"];
            obj.Towarehouse_fk = (drRow["towarehouse_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["towarehouse_fk"];

            obj.Type = (drRow["type"].Equals(DBNull.Value)) ? "" : (string)drRow["type"];
            obj.Cargo_type = (drRow["cargo_type"].Equals(DBNull.Value)) ? "" : (string)drRow["cargo_type"];

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
    public transport_master_tableEntities OnGetData(int ID1, int ID2)
    {
        Exception exForce;
        DataTable dtTable;

        transport_master_tableEntities obj = new transport_master_tableEntities();

        string strQ = "";

        try
        {

            strQ = @"SELECT t.*,co.consignment_number,cn.container_number,fwh.warehouse_name as fromwarehouse_fk,twh.warehouse_name as towarehouse_fk,v.vehicle_name,v.vehicle_type,v.vehicle_number FROM [transport_master] t 
                       
                        JOIN [vehicle_master] v ON t.[vehicle_id_fk]=v.[vehicle_id_pk]  
                        JOIN [warehouse_master] fwh ON t.[fromwarehouse_fk]=fwh.[warehouse_id_pk]
                        JOIN [warehouse_master] twh ON t.[towarehouse_fk]=twh.[warehouse_id_pk]
                        JOIN [container_master] cn on t.[container_id_fk]=cn.[container_id_pk]
                        JOIN [consignment_master] co on t.[consignment_id_fk]=co.[consignment_id_pk]
                        WHERE t.[container_id_fk]=@container_id_pk and  t.[isactive]=1 OR t.[consignment_id_fk]=@consignment_id_pk and  t.[isactive]=1 ";


            OnClearParameter();
            AddParameter("@container_id_fk", SqlDbType.Int, 50, ID1, ParameterDirection.Input);
            AddParameter("@consignment_id_fk", SqlDbType.Int, 50,ID2, ParameterDirection.Input);


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
            strQ = @"SELECT IDENT_CURRENT('transport_master') ";

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
            strQ = @"SELECT count(transport_id_pk) from [transport_master] where [isactive] = 1";
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
        List<transport_master_tableEntities> oList = new List<transport_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [transport_master] where [isactive]=1 ";
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

    public List<transport_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<transport_master_tableEntities> oList = new List<transport_master_tableEntities>();
        string strQ = "";

        try
        {

            strQ = @"SELECT t.*,fwh.warehouse_name as fromwarehouse_fk,twh.warehouse_name as towarehouse_fk,v.vehicle_name,v.vehicle_type,v.vehicle_number FROM [transport_master] t 
                    
                        JOIN [vehicle_master] v ON t.[vehicle_id_fk]=v.[vehicle_id_pk]  
                        JOIN [warehouse_master] fwh ON t.[fromwarehouse_fk]=fwh.[warehouse_id_pk]
                        JOIN [warehouse_master] twh ON t.[towarehouse_fk]=twh.[warehouse_id_pk] where t.[isactive]=1 ";

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
            strQ = @"SELECT transport_id_pk,devlivery_date FROM [transport_master] where [isactive]=1  ";

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
                objData.ID = dtTable.Rows[intRow]["transport_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["transport_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["devlivery_date"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["devlivery_date"];
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
