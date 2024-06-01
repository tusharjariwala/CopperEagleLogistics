using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class city_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "city_master";

    public city_master_tableDB()
    {
    }

    public int OnInsert(city_master_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [city_master]
                                   ([city_name])
                             VALUES
                                   (@city_name)";

            OnClearParameter();
            AddParameter("@city_name", SqlDbType.VarChar, 50, obj.City_name, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(city_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [city_master]
                          SET  [city_name]=@city_name
                         WHERE [city_id_pk]=@city_id_pk";
            OnClearParameter();
            AddParameter("@city_id_pk", SqlDbType.Int, 50, obj.City_id_pk, ParameterDirection.Input);
            AddParameter("@city_name", SqlDbType.VarChar, 50, obj.City_name, ParameterDirection.Input);


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
            strQ += @"DELETE FROM city_master 
                         WHERE [city_id_pk]=@city_id_pk";

            OnClearParameter();
            AddParameter("@city_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private city_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            city_master_tableEntities obj = new city_master_tableEntities();

            obj.City_id_pk = (drRow["city_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["city_id_pk"];
            obj.City_name = (drRow["city_name"].Equals(DBNull.Value)) ? "" : (string)drRow["city_name"];
            obj.State_id_fk = (drRow["state_id_fk"].Equals(DBNull.Value)) ? 0 : (int)drRow["state_id_fk"];
            obj.State_name = (drRow["state_name"].Equals(DBNull.Value)) ? "" : (string)drRow["state_name"];



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
            return null;
        }
    }

    public city_master_tableEntities OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        city_master_tableEntities obj = new city_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('city_master') ";

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
                obj = BuildEntities(dtTable.Rows[0]);
            }

            return obj;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public city_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        city_master_tableEntities obj = new city_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT c.*, 
                        s.state_name FROM [city_master] c
                        JOIN [state_master] s 
                        ON c.[state_id_fk] = s.[state_id_pk] 
                        WHERE [city_id_pk] = @city_id_pk ";

            OnClearParameter();
            AddParameter("@city_id_pk", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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
            return obj;
        }
    }

    public List<city_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<city_master_tableEntities> oList = new List<city_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT c.*, 
                        s.state_name FROM [city_master] c 
                        JOIN [state_master] s 
                        ON c.[state_id_fk] = s.[state_id_pk] ";
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
            return null;
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
            strQ = @"SELECT city_id_pk, city_name  FROM [city_master] ";

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
                objData.ID = dtTable.Rows[intRow]["city_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["city_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["city_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["city_name"];
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
