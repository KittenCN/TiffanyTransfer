using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XLuSharpLibrary.DbAccess;
using System.Data.OleDb; 

namespace BHair.Business.BaseData
{
    /// <summary>店面。</summary>
    public class Store
    {
        #region 构造函数...

        /// <summary>店面。</summary>
        public Store()
        { }


        #endregion

        #region 属性...

        public DataTable StoreDT = new DataTable();

        #endregion

        #region 自定义函数...

        /// <summary>
        /// 添加店面信息表StoreInfo
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int InsertStoreInfo(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (SelectStoreInfoByStoreName(dr["StoreName"].ToString()).Rows.Count == 0)
                    {
                        OleDbDataAdapter adapt = new OleDbDataAdapter("select * from StoreInfo", ah.Conn);
                        var cmd = new OleDbCommand("insert into StoreInfo (StoreName,Address,Contact,Tel) values(@StoreName,@Address,@Contact,@Tel) ", ah.Conn);
                        cmd.Parameters.Add("@StoreName", OleDbType.VarChar, 20, "StoreName");
                        cmd.Parameters.Add("@Address", OleDbType.VarChar, 40, "Address");
                        cmd.Parameters.Add("@Contact", OleDbType.VarChar, 20, "Contact");
                        cmd.Parameters.Add("@Tel", OleDbType.VarChar, 20, "Tel");
                        adapt.InsertCommand = cmd;
                        rows += adapt.Update(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                ah.Close();
                return 0;
            }
            ah.Close();
            return rows;
        }

        /// <summary>
        /// 修改店面信息表StoreInfo
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateStoreInfo(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    OleDbDataAdapter adapt = new OleDbDataAdapter("select * from StoreInfo", ah.Conn);
                    OleDbCommandBuilder odcb = new OleDbCommandBuilder(adapt);
                    rows += adapt.Update(dt);
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                ah.Close();
                return 0;
            }
            ah.Close();
            return rows;
        }

        /// <summary>
        /// 根据店名查询店面信息StoreInfo
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectStoreInfoByStoreName(string StoreName)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from StoreInfo where IsDelete = 0 and StoreName='{0}'", StoreName);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 查询所有店面信息StoreInfo
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectAllStoreInfo()
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from StoreInfo where IsDelete = 0 ");
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public int DeleteStore(string ID)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                string sql = string.Format("Update StoreInfo Set IsDelete =1 Where ID='{0}'", ID);
                OleDbCommand comm = new OleDbCommand(sql, ah.Conn);
                rows += comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw ex;
                ah.Close();
                return 0;
            }
            ah.Close();
            return rows;
        }
        #endregion
    }
}
