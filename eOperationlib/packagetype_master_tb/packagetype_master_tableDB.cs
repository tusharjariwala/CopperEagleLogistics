using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class packagetype_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "packagetype_master_tableDB";

    public packagetype_master_tableDB()
        
    {
    }

   public int OnInsert(packagetype_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [packagetype_master]
                                   ([code],[name])
                             VALUES
                                   (@code,@name)";

            OnClearParameter();
            AddParameter("@code", SqlDbType.VarChar, 500, obj.Code, ParameterDirection.Input);
          
            AddParameter("@name", SqlDbType.VarChar, 500, obj.Name, ParameterDirection.Input);
        
          // AddParameter("@isactive", SqlDbType.Int, 500, obj.Isactive, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(packagetype_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [packagetype_master]
                             SET    [code]=@code,
                                    [name]=@name,
                                    [isactive]=1                                                               
                             WHERE [packagetype_id_pk]=@packagetype_id_pk";
            OnClearParameter();
            AddParameter("@packagetype_id_pk", SqlDbType.Int, 50, obj.Packagetype_id_pk, ParameterDirection.Input);
            AddParameter("@code", SqlDbType.VarChar, 50, obj.Code, ParameterDirection.Input);
           
            AddParameter("@name", SqlDbType.VarChar, 50, obj.Name, ParameterDirection.Input);
         
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
            strQ += @"update  [packagetype_master]                            
                           set [isactive]=0
                           WHERE [packagetype_id_pk]=@packagetype_id_pk";

            OnClearParameter();
            AddParameter("@packagetype_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private packagetype_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            packagetype_master_tableEntities obj = new packagetype_master_tableEntities();

            obj.Packagetype_id_pk = (drRow["packagetype_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["packagetype_id_pk"];
            obj.Code = (drRow["code"].Equals(DBNull.Value)) ? "" : (string)drRow["code"];
            obj.Name = (drRow["name"].Equals(DBNull.Value)) ? "" : (string)drRow["name"];
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
    public packagetype_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        packagetype_master_tableEntities obj = new packagetype_master_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [packagetype_master] 
                               WHERE [packagetype_id_pk] = @packagetype_id_pk   and [isactive] = 1 ";

            OnClearParameter();
            AddParameter("@packagetype_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
        List<packagetype_master_tableEntities> oList = new List<packagetype_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [ packagetype_master] 
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

    public List<packagetype_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<packagetype_master_tableEntities> oList = new List<packagetype_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * from packagetype_master 
                            where [isactive]= 1 ";
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
            strQ = @"SELECT packagetype_id_pk ,name FROM [packagetype_master]  WHERE [isactive] =1 ";

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
                objData.ID = dtTable.Rows[intRow]["packagetype_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["packagetype_id_pk"];
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
