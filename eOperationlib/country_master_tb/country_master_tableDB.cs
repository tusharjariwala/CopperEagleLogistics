using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class country_master_tableDB : clsDB_Operation
{ 

    private const string mstrModuleName = "country_master";

    public country_master_tableDB()
    {

    }

    public int OnInsert(country_master_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [country_master]
                                   ([country_name])
                             VALUES
                                   (@country_name)";

            OnClearParameter();
            AddParameter("@country_name", SqlDbType.VarChar, 500, obj.Country_name, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(country_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [country_master]
                             SET   [country_name]=@country_name
                             WHERE [country_id_pk]=@country_id_pk";
            OnClearParameter();
            AddParameter("@country_id_pk", SqlDbType.Int, 50, obj.Country_id_pk, ParameterDirection.Input);
            AddParameter("@country_name", SqlDbType.VarChar, 500, obj.Country_name, ParameterDirection.Input);


            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<country_master_tableEntities> OnInsert(List<country_master_tableEntities> departments)
    {
        throw new NotImplementedException();
    }

    public int OnDelete(int ID)
    {
        string strQ = "";
        try
        {
            strQ += @"update  country_master 
                         set   [country_name]=@country_name
                         WHERE [country_id_pk]=@country_id_pk";

            OnClearParameter();
            AddParameter("@country_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    private country_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            country_master_tableEntities obj = new country_master_tableEntities();

            obj.Country_id_pk = (drRow["country_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["country_id_pk"];
            obj.Country_name = (drRow["country_name"].Equals(DBNull.Value)) ? "" : (string)drRow["country_name"];
            



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
           // return null;
        }
    }

    public country_master_tableEntities OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        country_master_tableEntities obj = new country_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('country_master') ";

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

    public country_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        country_master_tableEntities obj = new country_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [country_master] 
                            WHERE [country_id_pk] = @country_id_pk ";

            OnClearParameter();
            AddParameter("@country_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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

    public List<country_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<country_master_tableEntities> oList = new List<country_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from [country_master] ";
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
            //return null;
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
            strQ = @"SELECT [country_master].country_id_pk ,[country_master].country_name
                                    FROM [country_master]";

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
                objData.ID = dtTable.Rows[intRow]["country_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["country_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["country_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["country_name"];
                oList.Add(objData);

                intRow = intRow + 1;
            }
            return oList;
        }
        catch (Exception ex)
        {
            throw ex;
           // return oList;
        }
    }
}
