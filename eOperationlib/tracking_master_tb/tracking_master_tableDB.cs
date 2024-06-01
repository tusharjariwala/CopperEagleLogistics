using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class tracking_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "tracking_master_tableDB";

    public tracking_master_tableDB()
        
    {
    }

   public int OnInsert(tracking_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [tracking_master]
                                   ([tracking_date_and_time],[consignment_id_fk],[remark],[warehouse_id_fk],[status],[tracking_number])
                             VALUES
                                   (@tracking_date_and_time,@consignment_id_fk,@remark,@warehouse_id_fk,@status,@tracking_number)";

            OnClearParameter();
            AddParameter("@tracking_date_and_time", SqlDbType.VarChar, 50, obj.Tracking_date_and_time, ParameterDirection.Input);
            AddParameter("@consignment_id_fk", SqlDbType.Int, 50, obj.Consignment_id_fk, ParameterDirection.Input);
            AddParameter("@remark", SqlDbType.VarChar, 50, obj.Remark, ParameterDirection.Input);
            AddParameter("@warehouse_id_fk", SqlDbType.Int, 50, obj.Warehouse_id_fk1, ParameterDirection.Input);
            AddParameter("@status", SqlDbType.Int, 50, obj.Status, ParameterDirection.Input);
            AddParameter("@tracking_number", SqlDbType.VarChar, 50, obj.Tracking_number, ParameterDirection.Input);

            // AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive1, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(tracking_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [tracking_master]
                             SET    [tracking_date_and_time]=@tracking_date_and_time,
                                    [consignment_id_fk]=@consignment_id_fk,
                                    [remark]=@remark,
                                    [warehouse_id_fk]=@warehouse_id_fk,
                                    [tracking_number]=@tracking_number,
                                    [status]=1 
                         WHERE [tracking_id_pk]=@tracking_id_pk";
            OnClearParameter();
            AddParameter("@tracking_id_pk", SqlDbType.Int, 50, obj.Tracking_id_pk, ParameterDirection.Input);
            AddParameter("@tracking_date_and_time", SqlDbType.VarChar, 50, obj.Tracking_date_and_time, ParameterDirection.Input);
            AddParameter("@consignment_id_fk", SqlDbType.Int, 50, obj.Consignment_id_fk, ParameterDirection.Input);
            AddParameter("@remark", SqlDbType.VarChar, 50, obj.Remark, ParameterDirection.Input);
            AddParameter("@tracking_number", SqlDbType.VarChar, 50, obj.Tracking_number, ParameterDirection.Input);
            AddParameter("@warehouse_id_fk", SqlDbType.Int, 50, obj.Warehouse_id_fk1, ParameterDirection.Input);
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
            strQ += @"update  [tracking_master]
                           set [status]=0
                           WHERE [tracking_id_pk]=@tracking_id_pk";

            OnClearParameter();
            AddParameter("@tracking_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private tracking_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            tracking_master_tableEntities obj = new tracking_master_tableEntities();

            obj.Tracking_id_pk = (drRow["tracking_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["tracking_id_pk"];
            obj.Tracking_date_and_time = (drRow["tracking_date_and_time"].Equals(DBNull.Value)) ? "" : (string)drRow["tracking_date_and_time"];
            obj.Tracking_number = (drRow["tracking_number"].Equals(DBNull.Value)) ? "" : (string)drRow["tracking_number"];

            obj.Consignment_id_fk = (drRow["consignment_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["consignment_id_fk"];
            obj.Consignment_number = (drRow["consignment_number"].Equals(DBNull.Value)) ? "" : (string)drRow["consignment_number"];
            obj.Deliver_date = (drRow["deliver_date"].Equals(DBNull.Value)) ? "" : (string)drRow["deliver_date"];
            obj.Sender_address = (drRow["sender_address"].Equals(DBNull.Value)) ? "" : (string)drRow["sender_address"];
            obj.Receiver_address = (drRow["receiver_address"].Equals(DBNull.Value)) ? "" : (string)drRow["receiver_address"];
            obj.Receiver_person = (drRow["receiver_person"].Equals(DBNull.Value)) ? "" : (string)drRow["receiver_person"];

            obj.Remark = (drRow["remark"].Equals(DBNull.Value)) ? "" : (string)drRow["remark"];
            obj.Warehouse_id_fk1 = (drRow["warehouse_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["warehouse_id_fk"];
            obj.Warehouse_name1 = (drRow["warehouse_name"].Equals(DBNull.Value)) ? "" : (string)drRow["warehouse_name"];
            obj.Address1 = (drRow["address"].Equals(DBNull.Value)) ? "" : (string)drRow["address"];
            obj.Contactperson_name = (drRow["contactperson_name"].Equals(DBNull.Value)) ? "" : (string)drRow["contactperson_name"];
            obj.Contactperson_number = (drRow["contactperson_number"].Equals(DBNull.Value)) ? "" : (string)drRow["contactperson_number"];
            obj.Status = (drRow["status"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["status"].ToString());

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
    public tracking_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        tracking_master_tableEntities obj = new tracking_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT t.*,c.consignment_number,c.deliver_date,c.sender_address,c.receiver_address,c.receiver_person,w.warehouse_name,w.address,w.contactperson_name,w.contactperson_number FROM [tracking_master] t
                        JOIN [consignment_master] c ON t.[consignment_id_fk] = c.[consignment_id_pk]  
                        JOIN [warehouse_master] w ON t.[warehouse_id_fk]=w.[warehouse_id_pk]
                        WHERE [tracking_id_pk] = @tracking_id_pk  
                        and t.[status] = 1";

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
        List<tracking_master_tableEntities> oList = new List<tracking_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [tracking_master] 
                            where [status] = 1 ";
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

    public List<tracking_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<tracking_master_tableEntities> oList = new List<tracking_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT t.*,c.consignment_number,c.deliver_date,c.sender_address,c.receiver_address,c.receiver_person,w.warehouse_name,w.address,w.contactperson_name,w.contactperson_number FROM [tracking_master] t 
                        JOIN [consignment_master] c ON t.[consignment_id_fk] = c.[consignment_id_pk]  
                        JOIN [warehouse_master] w ON t.[warehouse_id_fk]=w.[warehouse_id_pk]  
                        WHERE  t.[status] = 1";
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

    public List<tracking_master_tableEntities> OnGetTrackingList(string tracking_number)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<tracking_master_tableEntities> oList = new List<tracking_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT t.*,c.consignment_number,c.deliver_date,c.sender_address,c.receiver_address,c.receiver_person,w.warehouse_name,w.address,w.contactperson_name,w.contactperson_number FROM [tracking_master] t 
                        JOIN [consignment_master] c ON t.[consignment_id_fk] = c.[consignment_id_pk]  
                        JOIN [warehouse_master] w ON t.[warehouse_id_fk]=w.[warehouse_id_pk]  
                        WHERE t.[tracking_number]=@tracking_number and t.[status] = 1";
            OnClearParameter();
            AddParameter("@tracking_number", SqlDbType.VarChar, 50, tracking_number, ParameterDirection.Input);


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
            strQ = @"SELECT tracking_id_pk,tracking_date_and_time FROM [tracking_master] where [status]=1 ";

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
                objData.ID = dtTable.Rows[intRow]["tracking_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["tracking_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["tracking_date_and_time"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["tracking_date_and_time"];
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
