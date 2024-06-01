using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class reverselogistics_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "reverselogistics_master_tableDB";

    public reverselogistics_master_tableDB()
        
    {
    }

   public int OnInsert(reverselogistics_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [reverselogistics_master]
                                   ([reason],[consignment_id_fk],[return_status])
                             VALUES
                                   (@reason,@consignment_id_fk,@return_status)";

            OnClearParameter();
          
           // AddParameter("@datetime", SqlDbType.VarChar, 50, obj.Datetime, ParameterDirection.Input);
            AddParameter("@reason", SqlDbType.VarChar, 50, obj.Reason, ParameterDirection.Input);
            AddParameter("@consignment_id_fk", SqlDbType.Int, 50, obj.Consignment_id_fk, ParameterDirection.Input);
            AddParameter("@return_status", SqlDbType.Int, 50, obj.Return_status, ParameterDirection.Input);

            // AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive1, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(reverselogistics_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [reverselogistics_master]
                             SET 
                                    [reason]=@reason,
                                    [consignment_id_fk]=@consignment_id_fk,
                                    [return_status]=1              
                         WHERE [reverselogistics_id_pk]=@reverselogistics_id_pk";
            OnClearParameter();
            AddParameter("@reverselogistics_id_pk", SqlDbType.Int, 50, obj.Reverselogistics_id_pk, ParameterDirection.Input);
            //AddParameter("@datetime", SqlDbType.VarChar, 50, obj.Datetime, ParameterDirection.Input);
            AddParameter("@reason", SqlDbType.VarChar, 50, obj.Reason, ParameterDirection.Input);
            AddParameter("@consignment_id_fk", SqlDbType.Int, 50, obj.Consignment_id_fk, ParameterDirection.Input);
            AddParameter("@return_status", SqlDbType.Int, 50, obj.Return_status, ParameterDirection.Input);
      

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
            strQ += @"update  [reverselogistics_master]                            
                           set [return_status]=0
                           WHERE [reverselogistics_id_pk]=@reverselogistics_id_pk";

            OnClearParameter();
            AddParameter("@reverselogistics_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private reverselogistics_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            reverselogistics_master_tableEntities obj = new reverselogistics_master_tableEntities();

            obj.Reverselogistics_id_pk = (drRow["reverselogistics_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["reverselogistics_id_pk"];
            obj.Datetime = (drRow["datetime"].Equals(DBNull.Value)) ? "" : (string)drRow["datetime"].ToString();

            obj.Consignment_id_fk = (drRow["consignment_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["consignment_id_fk"];
            obj.Consignment_number = (drRow["consignment_number"].Equals(DBNull.Value)) ? "" : (string)drRow["consignment_number"];
            obj.Deliver_date = (drRow["deliver_date"].Equals(DBNull.Value)) ? "" : (string)drRow["deliver_date"];
            obj.Sender_address = (drRow["sender_address"].Equals(DBNull.Value)) ? "" : (string)drRow["sender_address"];
            obj.Receiver_address = (drRow["receiver_address"].Equals(DBNull.Value)) ? "" : (string)drRow["receiver_address"];
            obj.Receiver_person = (drRow["receiver_person"].Equals(DBNull.Value)) ? "" : (string)drRow["receiver_person"];

            obj.Reason = (drRow["reason"].Equals(DBNull.Value)) ? "" : (string)drRow["reason"];

            obj.Return_status = (drRow["return_status"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["return_status"].ToString());
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
    public reverselogistics_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        reverselogistics_master_tableEntities obj = new reverselogistics_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT r.*,c.consignment_number,c.deliver_date,c.sender_address,c.receiver_address,c.receiver_person FROM [reverselogistics_master] r 
                               JOIN [consignment_master] c ON r.[consignment_id_fk] = c.[consignment_id_pk]  
                               WHERE [reverselogistics_id_pk] = @reverselogistics_id_pk   
                               and r.[return_status] = 1";

            OnClearParameter();
            AddParameter("@reverselogistics_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
        List<reverselogistics_master_tableEntities> oList = new List<reverselogistics_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [reverselogistics_master] 
                            where [return_status] = 1 ";
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

    public List<reverselogistics_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<reverselogistics_master_tableEntities> oList = new List<reverselogistics_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT r.*,c.consignment_number,c.deliver_date,c.sender_address,c.receiver_address,c.receiver_person  FROM [reverselogistics_master] r 
                                JOIN [consignment_master] c ON r.[consignment_id_fk] = c.[consignment_id_pk]  
                                WHERE  r.[return_status] = 1";
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
            strQ = @"SELECT reverselogistics_id_pk,datetime FROM [reverselogistics_master]  WHERE  [return_status] = 1  ";

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
                objData.ID = dtTable.Rows[intRow]["reverselogistics_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["reverselogistics_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["datetime"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["datetime"];
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
