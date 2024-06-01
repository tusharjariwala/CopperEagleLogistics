using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class freight_master_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "freight_master_tableDB";

    public freight_master_tableDB()
        
    {
    }

   public int OnInsert(freight_master_tableEntities obj)
    {
        
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [freight_master]
                                   ([freight_type],[departure_id],[deliverCity_id],[total_gross_weight],[dimention],[email],[message])
                             VALUES
                                   (@freight_type,@departure_id,@deliverCity_id,@total_gross_weight,@dimention,@email,@message)";
            OnClearParameter();
            AddParameter("@freight_type", SqlDbType.VarChar, 50, obj.Freight_type, ParameterDirection.Input);           
            AddParameter("@departure_id", SqlDbType.Int, 50, obj.Departure_id, ParameterDirection.Input);
            AddParameter("@deliverCity_id", SqlDbType.Int, 50, obj.DeliverCity_id, ParameterDirection.Input);
            AddParameter("@total_gross_weight", SqlDbType.VarChar, 50, obj.Total_gross_weight, ParameterDirection.Input);
            AddParameter("@dimention", SqlDbType.VarChar, 50, obj.Dimention, ParameterDirection.Input);
            AddParameter("@email", SqlDbType.VarChar, 50, obj.Email, ParameterDirection.Input);
            AddParameter("@message", SqlDbType.VarChar, 50, obj.Message, ParameterDirection.Input);




            // AddParameter("@isactive", SqlDbType.Int, 500, obj.IsActive1, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

     public int OnUpdate(freight_master_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [freight_master]
                             SET    [freight_type]=@freight_type,
                                    [departure_id]=@departure_id,
                                    [deliverCity_id]=@deliverCity_id,
                                    [total_gross_weight]=@total_gross_weight,
                                    [dimention]=@dimention,
                                    [email]=@email,
                                    [message]=@message
                         WHERE [freight_id_pk]=@freight_id_pk";
            OnClearParameter();
            AddParameter("@freight_id_pk", SqlDbType.Int, 50, obj.Freight_id_pk, ParameterDirection.Input);
            AddParameter("@freight_type", SqlDbType.VarChar, 50, obj.Freight_type, ParameterDirection.Input);
            AddParameter("@departure_id", SqlDbType.Int, 50, obj.Departure_id, ParameterDirection.Input);
            AddParameter("@deliverCity_id", SqlDbType.Int, 50, obj.DeliverCity_id, ParameterDirection.Input);
            AddParameter("@total_gross_weight", SqlDbType.VarChar, 50, obj.Total_gross_weight, ParameterDirection.Input);
            AddParameter("@dimention", SqlDbType.VarChar, 50, obj.Dimention, ParameterDirection.Input);
            AddParameter("@email", SqlDbType.VarChar, 50, obj.Email, ParameterDirection.Input);
            AddParameter("@message", SqlDbType.VarChar, 50, obj.Message, ParameterDirection.Input);






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
            strQ += @"update  [freight_master]
                           set [isactive]=0
                           WHERE [freight_id_pk]=@freight_id_pk";

            OnClearParameter();
            AddParameter("@freight_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private freight_master_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            freight_master_tableEntities obj = new freight_master_tableEntities();

            obj.Freight_id_pk = (drRow["freight_id_pk"].Equals(DBNull.Value)) ? 0 : (int)drRow["freight_id_pk"];
            obj.Freight_type = (drRow["freight_type"].Equals(DBNull.Value)) ? "" : (string)drRow["freight_type"];

            obj.Departure_id = (drRow["departure_id"].Equals(DBNull.Value)) ? 0 : (int)drRow["departure_id"];
            obj.DeliverCity_id = (drRow["deliverCity_id"].Equals(DBNull.Value)) ? 0 : (int)drRow["deliverCity_id"];

            obj.DepartureCity_name = (drRow["departureCity_name"].Equals(DBNull.Value)) ? "" : (string)drRow["departureCity_name"];
            obj.DeliverCity_name = (drRow["deliverCity_name"].Equals(DBNull.Value)) ? "" : (string)drRow["deliverCity_name"];

            obj.Total_gross_weight = (drRow["total_gross_weight"].Equals(DBNull.Value)) ? "" : (string)drRow["total_gross_weight"];
            obj.Dimention = (drRow["dimention"].Equals(DBNull.Value)) ? "" : (string)drRow["dimention"];
            obj.Email = (drRow["email"].Equals(DBNull.Value)) ? "" : (string)drRow["email"];
            obj.Message = (drRow["message"].Equals(DBNull.Value)) ? "" : (string)drRow["message"];
           
            obj.Isactive = (drRow["isactive"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["isactive"].ToString());

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
    public freight_master_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        freight_master_tableEntities obj = new freight_master_tableEntities();

        string strQ = "";

        try
        {

            strQ = @"SELECT f.*,dc.city_name as departureCity_name,dec.city_name as deliverCity_name FROM [freight_master] f 
                        JOIN [city_master] dc ON f.[departure_id]=dc.[city_id_pk]
                        JOIN [city_master] dec ON f.[deliverCity_id]=dec.[city_id_pk]
                        WHERE [freight_id_pk]=@freight_id_pk and f.[isactive]=1 ";


            OnClearParameter();
            AddParameter("@freight_id_pk", SqlDbType.Int, 50, ID, ParameterDirection.Input);

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
        List<freight_master_tableEntities> oList = new List<freight_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [freight_master] where [isactive]=1 ";
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

    public List<freight_master_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<freight_master_tableEntities> oList = new List<freight_master_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT f.*,dc.city_name as departureCity_name,dec.city_name as deliverCity_name FROM [freight_master] f 
                        JOIN [city_master] dc ON f.[departure_id]=dc.[city_id_pk]
                        JOIN [city_master] dec ON f.[deliverCity_id]=dec.[city_id_pk]
                        WHERE f.[isactive]=1 ";


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
            strQ = @"SELECT freight_id_pk,freight_type FROM [freight_master] where [isactive]=1  ";

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
                objData.ID = dtTable.Rows[intRow]["freight_id_pk"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["freight_id_pk"];
                objData.NAME = dtTable.Rows[intRow]["freight_type"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["freight_type"];
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
