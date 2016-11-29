using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XLuSharpLibrary.DbAccess;
using System.Data.OleDb; 

namespace BHair.Business.BaseData
{
    /// <summary>商品。</summary>
    public class Items
    {
        #region 构造函数...

        /// <summary>商品。</summary>
        public Items()
        { 
        }


        #endregion

        #region 属性...

        public DataTable ItemsDT = new DataTable();

        #endregion

        #region 自定义函数...

        /// <summary>
        /// 查询所有商品Item表
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllItem()
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Items where IsDelete=0 ");
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 通过货号或双货号查询Item表
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public DataTable SelectItemByItemID(string ItemID)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Items where (ItemID='{0}' or ItemID2='{0}') and IsDelete=0 ", ItemID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }


        /// <summary>
        /// 添加/修改商品表数据Items
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateItems(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Items", ah.Conn);
                OleDbCommandBuilder odcb = new OleDbCommandBuilder(adapt);
                odcb.QuotePrefix = "[";
                odcb.QuoteSuffix = "]";
                rows += adapt.Update(dt);
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
        /// 删除
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public int DeleteItem(string ID)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                string sql = string.Format("Update Items Set [IsDelete] =1 Where [ID]={0}", ID);
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

        /// <summary>
        /// 备份货物表
        /// </summary>
        /// <returns></returns>
        public bool BackupItem()
        {
            bool Result = true;
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("Select * into   Items_bak{0}   FROM   Items", DateTime.Now.ToString("yyyyMMddHHmmss"));
            Result= ah.ExecuteSQLNonquery(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 清空货物表
        /// </summary>
        /// <returns></returns>
        public bool ClearItem()
        {
            bool Result = true;
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("Delete from  Items");
            Result = ah.ExecuteSQLNonquery(sqlString);
            ah.Close();
            return Result;
        }


        #endregion
    }
}
