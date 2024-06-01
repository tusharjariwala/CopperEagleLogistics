using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class consignmentproduct_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "consignmentproduct_master_tableDB";

    public consignmentproduct_master_tableDB()
        
    {
    }

   public int OnInsert(consignmentproduct_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [consignmentproduct_master]
                                   ([isfargile],[name],[consignment_id_fk])
                             VALUES
                                   (@isfargile,@name,@consignment_id_fk)";

            OnClearParameter();
            AddParameter("@isfargile", SqlDbType.Int, 500, obj.Isfargile, ParameterDirection.Input);
          
            AddParameter("@name", SqlDbType.VarChar, 500, obj.Name, ParameterDirection.Input);
            AddParameter("@consignment_id_fk", SqlDbType.Int, 50, obj.Consignment_id_fk, ParameterDirection.Input);
            // AddParameter("@isactive", SqlDbType.Int, 500, obj.Isactive, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(consignmentproduct_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [consignmentproduct_master]
                             SET    [isfargile]=@isfargile,
                                    [name]=@name,
                                    [consignment_id_fk]=@consignment_id_fk,
                                    [isactive]=1
                             WHERE [consignmentproduct_id_pk]=@consignmentproduct_id_pk";
            OnClearParameter();
            AddParameter("@consignmentproduct_id_pk", SqlDbType.Int, 50, obj.Consignmentproduct_id_pk, ParameterDirection.Input);
            AddParameter("@isfargile", SqlDbType.Int, 50, obj.Isfargile, ParameterDirection.Input);
            AddParameter("@name", SqlDbType.VarChar, 50, obj.Name, ParameterDirection.Input);
            AddParameter("@consignment_id_fk", SqlDbType.Int, 50, obj.Consignment_id_fk, ParameterDirection.Input);
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
            strQ += @"update  [consignmentproduct_master]    
                         set [isactive]=0
                         WHERE [consignmentproduct_id_pk]=@consignmentproduct_id_pk";

            OnClearParameter();
            AddParameter("@consignmentproduct_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private consignmentproduct_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            consignmentproduct_master_tableEntities obj = new consignmentproduct_master_tableEntities();

            obj.Consignmentproduct_id_pk = (drRow["consignmentproduct_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["consignmentproduct_id_pk"];
            obj.Isfargile = (drRow["isfargile"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["isfargile"].ToString());
            obj.Name = (drRow["name"].Equals(DBNull.Value)) ? "" : (string)drRow["name"];
            obj.Isactive = (drRow["isactive"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["isactive"].ToString());

            obj.Consignment_id_fk = (drRow["consignment_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["consignment_id_fk"];
            obj.Consignment_number = (drRow["consignment_number"].Equals(DBNull.Value)) ? "" : (string)drRow["consignment_number"];
            obj.Package_type = (drRow["package_type"].Equals(DBNull.Value)) ? 0 : (int)drRow["package_type"];
            obj.Deliver_date = (drRow["deliver_date"].Equals(DBNull.Value)) ? "" : (string)drRow["deliver_date"];
            obj.Booking_date = (drRow["booking_date"].Equals(DBNull.Value)) ? "" : (string)drRow["booking_date"];
            obj.Sender_address = (drRow["sender_address"].Equals(DBNull.Value)) ? "" : (string)drRow["sender_address"];
            obj.Receiver_address = (drRow["receiver_address"].Equals(DBNull.Value)) ? "" : (string)drRow["receiver_address"];
            obj.Receiver_person = (drRow["receiver_person"].Equals(DBNull.Value)) ? "" : (string)drRow["receiver_person"];

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
    public consignmentproduct_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        consignmentproduct_master_tableEntities obj = new consignmentproduct_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT cp.*,c.consignment_number,c.package_type,c.deliver_date,c.booking_date,c.sender_address,c.receiver_address,c.receiver_person
                                   From [consignmentproduct_master]  cp 
                                JOIN [consignment_master] c ON cp.[consignment_id_fk]=c.[consignment_id_pk]
                        WHERE [consignmentproduct_id_pk] = @consignmentproduct_id_pk and cp.[isactive]=1";

            OnClearParameter();
            AddParameter("@consignmentproduct_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
        List<consignmentproduct_master_tableEntities> oList = new List<consignmentproduct_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [consignmentproduct_master] 
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

    public List<consignmentproduct_master_tableEntities> OnGetListdt(int ID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<consignmentproduct_master_tableEntities> oList = new List<consignmentproduct_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT cp.*, c.consignment_number,c.package_type,c.deliver_date,c.booking_date,c.sender_address,c.receiver_address,c.receiver_person
                                   From [consignmentproduct_master]  cp 
                                JOIN [consignment_master] c ON cp.[consignment_id_fk]=c.[consignment_id_pk]
                            where cp.[isactive]= 1 and cp.[consignment_id_fk]=@consignment_id_fk";
            OnClearParameter();
            AddParameter("@consignment_id_fk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
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
            strQ = @"SELECT consignmentproduct_id_pk ,name FROM [consignmentproduct_master] where [isactive]=1 ";

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
                objData.ID = dtTable.Rows[intRow]["consignmentproduct_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["consignmentproduct_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["name"];
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
