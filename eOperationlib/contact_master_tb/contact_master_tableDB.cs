using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class contact_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "contact_master";
  

    public contact_master_tableDB()
    {
    }

    public int OnInsert(contact_master_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [contactus_master]
                                   ([contact_name],[contact_email],[contact_subject],[contact_message])
                             VALUES
                                   (@contact_name,@contact_email,@contact_subject,@contact_message)";

            OnClearParameter();
            AddParameter("@contact_name", SqlDbType.VarChar, 500, obj.Contact_name, ParameterDirection.Input);
            AddParameter("@contact_email", SqlDbType.VarChar, 500, obj.Contact_email, ParameterDirection.Input);
            AddParameter("@contact_subject", SqlDbType.VarChar, 500, obj.Contact_subject, ParameterDirection.Input);
            AddParameter("@contact_message", SqlDbType.VarChar, 500, obj.Contact_message, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(contact_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [contactus_master]
                             SET    [contact_name]=@contact_name,
                                    [contact_email]=@contact_email,
                                    [contact_subject]=@contact_subject,
                                    [contact_message]=@contact_message,
                                    [isactive]=1                                
                           WHERE [contact_id_pk]=@contact_id_pk";
            OnClearParameter();
            AddParameter("@contact_name", SqlDbType.VarChar, 500, obj.Contact_name, ParameterDirection.Input);
            AddParameter("@contact_email", SqlDbType.VarChar, 500, obj.Contact_email, ParameterDirection.Input);
            AddParameter("@contact_subject", SqlDbType.VarChar, 500, obj.Contact_subject, ParameterDirection.Input);
            AddParameter("@contact_message)", SqlDbType.VarChar, 500, obj.Contact_message, ParameterDirection.Input);


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
            strQ += @"update  [contactus_master]                              
                           set [isactive]=0
                           WHERE [contact_id_pk]=@contact_id_pk";

            OnClearParameter();
            AddParameter("@contact_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private contact_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            contact_master_tableEntities obj = new contact_master_tableEntities();

            obj.Contact_id_pk = (drRow["contact_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["contact_id_pk"];
            obj.Contact_name = (drRow["contact_name"].Equals(DBNull.Value)) ? "" : (string)drRow["contact_name"];
            obj.Contact_email = (drRow["contact_email"].Equals(DBNull.Value)) ? "" : (string)drRow["contact_email"]; 
            obj.Contact_subject = (drRow["contact_subject"].Equals(DBNull.Value)) ? "" : (string)drRow["contact_subject"];
            obj.Contact_message= (drRow["contact_message"].Equals(DBNull.Value)) ? "" : (string)drRow["contact_message"];


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

    public contact_master_tableEntities OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        contact_master_tableEntities obj = new contact_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('contactus_master') ";

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

    public contact_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        contact_master_tableEntities obj = new contact_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @" SELECT contact_name, contact_email, contact_subject, contact_message FROM [contact_master]
                      WHERE [contact_id_pk] = @contact_id_pk and [isactive]=1";
                        

            OnClearParameter();
            AddParameter("@contact_id_pk",SqlDbType.Int, 50, ID, ParameterDirection.Input);

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

    public List<contact_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<contact_master_tableEntities> oList = new List<contact_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @" SELECT * FROM [contactus_master]";
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
            strQ = @"SELECT contact_id_pk, contact_name  FROM [contact_master] ";

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
                objData.ID = dtTable.Rows[intRow]["contact_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["contact_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["contact_name"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["contact_name"];
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
