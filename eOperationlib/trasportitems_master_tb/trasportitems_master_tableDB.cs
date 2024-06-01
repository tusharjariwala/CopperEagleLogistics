using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class trasportitems_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "trasportitems_master_tableDB";

    public trasportitems_master_tableDB()
        
    {
    }

   public int OnInsert(trasportitems_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [trasportitems_master]
                                   ([transport_id_fk],[container_id_fk],[consignment_id_fk])
                             VALUES
                                   (@transport_id_fk,@container_id_fk,@consignment_id_fk)";
            OnClearParameter();
         
          
            AddParameter("@transport_id_fk", SqlDbType.Int, 50, obj.Transport_id_fk, ParameterDirection.Input);
            AddParameter("@container_id_fk", SqlDbType.Int, 50, obj.Container_id_fk, ParameterDirection.Input);
            AddParameter("@consignment_id_fk", SqlDbType.Int, 50, obj.Consignment_id_fk, ParameterDirection.Input);

         
            // AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive1, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(trasportitems_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [trasportitems_master]
                             SET    [transport_id_fk]=@transport_id_fk,
                                    [container_id_fk]=@container_id_fk,
                                    [consignment_id_fk]=@consignment_id_fk
                                  
                                  
                         WHERE [trasportitems_id_pk]=@trasportitems_id_pk";
            OnClearParameter();
            AddParameter("@trasportitems_id_pk", SqlDbType.Int, 50, obj.Trasportitems_id_pk, ParameterDirection.Input);
        

        
            AddParameter("@transport_id_fk", SqlDbType.Int, 50, obj.Transport_id_fk, ParameterDirection.Input);
            AddParameter("@container_id_fk", SqlDbType.Int, 50, obj.Container_id_fk, ParameterDirection.Input);
            AddParameter("@consignment_id_fk", SqlDbType.Int, 50, obj.Consignment_id_fk, ParameterDirection.Input);
      

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
            strQ += @"DELETE FROM trasportitems_master 
                         WHERE [trasportitems_id_pk]=@trasportitems_id_pk";

            OnClearParameter();
            AddParameter("@trasportitems_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private trasportitems_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            trasportitems_master_tableEntities obj = new trasportitems_master_tableEntities();

            obj.Trasportitems_id_pk = (drRow["trasportitems_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["trasportitems_id_pk"];
          
            obj.Transport_id_fk = (drRow["transport_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["transport_id_fk"];
            obj.Pick_up_date = (drRow["pick_up_date"].Equals(DBNull.Value)) ? "" : (string)drRow["pick_up_date"];
            obj.Devlivery_date = (drRow["devlivery_date"].Equals(DBNull.Value)) ? "" : (string)drRow["devlivery_date"];
            obj.Type = (drRow["type"].Equals(DBNull.Value)) ? "" : (string)drRow["type"];
            obj.Cargo_type = (drRow["cargo_type"].Equals(DBNull.Value)) ? "" : (string)drRow["cargo_type"];


            obj.Container_id_fk = (drRow["container_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["container_id_fk"];
            obj.Container_name = (drRow["container_name"].Equals(DBNull.Value)) ? "" : (string)drRow["container_name"];
            obj.Container_number = (drRow["container_number"].Equals(DBNull.Value)) ? "" : (string)drRow["container_number"];
            obj.Delivery_days = (drRow["delivery_days"].Equals(DBNull.Value)) ? "" : (string)drRow["delivery_days"];
            obj.Departed_date = (drRow["departed_date"].Equals(DBNull.Value)) ? "" : (string)drRow["departed_date"];
            obj.Expected_date = (drRow["expected_date"].Equals(DBNull.Value)) ? "" : (string)drRow["expected_date"];
             obj.Status = (drRow["status"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["status"].ToString());
            obj.Tracking_id = (drRow["tracking_id"].Equals(DBNull.Value)) ? 0 : (int)drRow["tracking_id"];

            obj.Consignment_id_fk = (drRow["consignment_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["consignment_id_fk"];
            obj.Consignment_number = (drRow["consignment_number"].Equals(DBNull.Value)) ? "" : (string)drRow["consignment_number"];
            obj.Package_type = (drRow["package_type"].Equals(DBNull.Value)) ? 0 : (int)drRow["package_type"];
            obj.Deliver_date = (drRow["deliver_date"].Equals(DBNull.Value)) ? "" : (string)drRow["deliver_date"];
            obj.Booking_date = (drRow["booking_date"].Equals(DBNull.Value)) ? "" : (string)drRow["booking_date"];
            obj.Sender_address = (drRow["sender_address"].Equals(DBNull.Value)) ? "" : (string)drRow["sender_address"];
            obj.Receiver_address = (drRow["receiver_address"].Equals(DBNull.Value)) ? "" : (string)drRow["receiver_address"];
            obj.Receiver_person = (drRow["receiver_person"].Equals(DBNull.Value)) ? "" : (string)drRow["receiver_person"];
            obj.Weight = (drRow["weight"].Equals(DBNull.Value)) ? "" : (string)drRow["weight"];




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
    public trasportitems_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        trasportitems_master_tableEntities obj = new trasportitems_master_tableEntities();

        string strQ = "";

        try
        {

            strQ = @"SELECT ti.*,c.consignment_number,c.deliver_date,c.sender_address,c.package_type,c.booking_date,c.receiver_address,c.receiver_person,c.weight,
                              con.container_name,con.container_number,con.delivery_days,con.departed_date,con.expected_date,con.status,con.tracking_id,
                              tr.pick_up_date,tr.devlivery_date,tr.type,tr.cargo_type 
                           FROM [trasportitems_master] ti
                        JOIN [consignment_master] c ON ti.[consignment_id_fk] = c.[consignment_id_pk]  
                        JOIN [container_master] con ON ti.[container_id_fk]=con.[container_id_pk]
                         JOIN [transport_master] tr ON ti.[transport_id_fk]=tr.[transport_id_pk] 
                        WHERE [trasportitems_id_pk] = @trasportitems_id_pk";



            OnClearParameter();
            AddParameter("@trasportitems_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
            strQ = @"SELECT IDENT_CURRENT('trasportitems_master') ";

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

    public List<trasportitems_master_tableEntities> OnGetListdt()
    {
        throw new NotImplementedException();
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
            strQ = @"SELECT count(trasportitems_id_pk) from [trasportitems_master] ";
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
        List<trasportitems_master_tableEntities> oList = new List<trasportitems_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [trasportitems_master]  ";
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

    public List<trasportitems_master_tableEntities> OnGetListdt(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<trasportitems_master_tableEntities> oList = new List<trasportitems_master_tableEntities>();
        string strQ = "";

        try
        {

            strQ = @"SELECT ti.*,c.consignment_number,c.deliver_date,c.sender_address,c.package_type,c.booking_date,c.receiver_address,c.receiver_person,c.weight,
                              con.container_name,con.container_number,con.delivery_days,con.departed_date,con.expected_date,con.status,con.tracking_id,
                              tr.pick_up_date,tr.devlivery_date,tr.type,tr.cargo_type 
                           FROM [trasportitems_master] ti
                        JOIN [consignment_master] c ON ti.[consignment_id_fk] = c.[consignment_id_pk]  
                        JOIN [container_master] con ON ti.[container_id_fk]=con.[container_id_pk]
                         JOIN [transport_master] tr ON ti.[transport_id_fk]=tr.[transport_id_pk] 
                       where ti.[transport_id_fk]=@transport_id_fk ";

            OnClearParameter();
            AddParameter("@transport_id_fk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
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
            strQ = @"SELECT container_id_fk,consignment_id_fk  FROM [trasportitems_master] ";

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
                objData.ID = dtTable.Rows[intRow]["container_id_fk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["container_id_fk"];
                objData.ID = dtTable.Rows[intRow]["consignment_id_fk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["consignment_id_fk"];
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
