using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class warehouse_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "warehouse_master_tableDB";

    public warehouse_master_tableDB()
        
    {
    }

   public int OnInsert(warehouse_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [warehouse_master]
                                   ([warehouse_name],[address],[type],[contactperson_name],[contactperson_number],[capacity])
                             VALUES
                                   (@warehouse_name,@address,@type,@contactperson_name,@contactperson_number,@capacity)";

            OnClearParameter();
            AddParameter("@warehouse_name", SqlDbType.VarChar, 500, obj.Warehouse_name, ParameterDirection.Input);
            AddParameter("@address", SqlDbType.VarChar, 500, obj.Address, ParameterDirection.Input);
            AddParameter("@type", SqlDbType.VarChar, 500, obj.Type1, ParameterDirection.Input);
            AddParameter("@contactperson_name", SqlDbType.VarChar, 500, obj.Contactperson_name, ParameterDirection.Input);
            AddParameter("@contactperson_number", SqlDbType.VarChar, 500, obj.Contactperson_number, ParameterDirection.Input);
            AddParameter("@capacity", SqlDbType.VarChar, 500, obj.Capacity, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(warehouse_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [warehouse_master]
                             SET    [warehouse_name]=@warehouse_name,
                                    [address]=@address,
                                    [type]=@type,
                                    [contactperson_name]=@contactperson_name,
                                    [contactperson_number]=@contactperson_number,
                                   [capacity]=@capacity                          
                         WHERE [warehouse_id_pk]=@warehouse_id_pk";
            OnClearParameter();
            AddParameter("@warehouse_id_pk", SqlDbType.Int, 50, obj.Warehouse_id_pk, ParameterDirection.Input);
            AddParameter("@warehouse_name", SqlDbType.VarChar, 50, obj.Warehouse_name, ParameterDirection.Input);
            AddParameter("@address", SqlDbType.VarChar, 50, obj.Address, ParameterDirection.Input);
            AddParameter("@type", SqlDbType.VarChar, 50, obj.Type1, ParameterDirection.Input);
            AddParameter("@contactperson_name", SqlDbType.VarChar, 50, obj.Contactperson_name, ParameterDirection.Input);
            AddParameter("@contactperson_number", SqlDbType.VarChar, 50, obj.Contactperson_number, ParameterDirection.Input);
            AddParameter("@capacity", SqlDbType.VarChar, 50, obj.Capacity, ParameterDirection.Input);

          

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
            strQ += @"update  [warehouse_master]                              
                           set  [isactive]=0
                         WHERE [warehouse_id_pk]=@warehouse_id_pk";

            OnClearParameter();
            AddParameter("@warehouse_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private warehouse_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            warehouse_master_tableEntities obj = new warehouse_master_tableEntities();

            obj.Warehouse_id_pk = (drRow["warehouse_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["warehouse_id_pk"];
            obj.Warehouse_name = (drRow["warehouse_name"].Equals(DBNull.Value)) ? "" : (string)drRow["warehouse_name"];
            obj.Address = (drRow["address"].Equals(DBNull.Value)) ? "" : (string)drRow["address"];
            obj.Type1 = (drRow["type"].Equals(DBNull.Value)) ? "" : (string)drRow["type"];
            obj.Contactperson_name = (drRow["contactperson_name"].Equals(DBNull.Value)) ? "" : (string)drRow["contactperson_name"];
            obj.Contactperson_number = (drRow["contactperson_number"].Equals(DBNull.Value)) ? "" : (string)drRow["contactperson_number"];
            obj.Capacity = (drRow["capacity"].Equals(DBNull.Value)) ? "" : (string)drRow["capacity"];
            obj.Isactive= (drRow["isactive"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["isactive"].ToString());

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
    public warehouse_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        warehouse_master_tableEntities obj = new warehouse_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [warehouse_master] WHERE [warehouse_id_pk] = @warehouse_id_pk and [isactive] = 1 ";

            OnClearParameter();
            AddParameter("@warehouse_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
            strQ = @"SELECT count(warehouse_id_pk) from [warehouse_master] where [isactive] = 1";
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
        List<warehouse_master_tableEntities> oList = new List<warehouse_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [warehouse_master] where [isactive]= 1 ";
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

    public List<warehouse_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<warehouse_master_tableEntities> oList = new List<warehouse_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from   warehouse_master where [isactive]= 1 ";
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
            strQ = @"SELECT warehouse_id_pk,warehouse_name FROM [warehouse_master] where [isactive]= 1 ";

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
                objData.ID = dtTable.Rows[intRow]["warehouse_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["warehouse_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["warehouse_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["warehouse_name"];
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
