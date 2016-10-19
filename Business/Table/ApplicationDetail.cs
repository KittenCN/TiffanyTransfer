using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BHair.Business.BaseData;
using XLuSharpLibrary.DbAccess;
using System.Data.OleDb; 

namespace BHair.Business.Table
{
    /// <summary>转货详情表信息。</summary>
    public class ApplicationDetail
    {
        #region 构造函数...

        /// <summary>转货详情表</summary>
        public ApplicationDetail()
        { }



        #endregion

        #region 属性...

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //控制号
        private string _ctrlID;
        public string CtrlID
        {
            get { return _ctrlID; }
            set { _ctrlID = value; }
        }
        //部门
        private string _department;
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        //级别
        private string _level;
        public string Level
        {
            get { return _level; }
            set { _level = value; }
        }
        //货号
        private string _itemID;
        public string ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }
        //双货号
        private string _itemID2;
        public string ItemID2
        {
            get { return _itemID2; }
            set { _itemID2 = value; }
        }
        //产品描述
        private string _detail;
        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }
        //单价
        private int _price;
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        //数量
        private int _count;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        //假删
        private int _isDelete;
        public int IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }

        public DataTable dataTable = new DataTable();

        #endregion

        #region 自定义函数...

        /// <summary>
        /// 根据控制号查询订单详情ApplicationDetail表
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectAppDetailByCtrlID(string CtrlID)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationDetail where IsDelete = 0 and CtrlID = '{0}'", CtrlID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 根据控制号查询发货单详情ApplicationDetail表
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectDeliverDetailByCtrlID(string CtrlID)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from DeliverDetail where IsDelete = 0 and CtrlID = '{0}' order by ItemID,ItemID2", CtrlID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 根据控制号查询收货单详情ApplicationDetail表
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectReceiptDetailByCtrlID(string CtrlID)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ReceiptDetail where IsDelete = 0 and CtrlID = '{0}' order by ItemID,ItemID2", CtrlID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 添加ApplicationDetail数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int SubmitApplicationDetail(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    OleDbDataAdapter adapt = new OleDbDataAdapter("select * from ApplicationDetail", ah.Conn);
                    //var cmd = new OleDbCommand("insert into ApplicationDetail (CtrlID,[Department],[App_Level],ItemID,ItemID2,[Detail],[Price],[App_Count]) values (@CtrlID,@Department,@App_Level,@ItemID,@ItemID2,@Detail,@Price,@App_Count) ", ah.Conn);
                    //cmd.Parameters.Add("@CtrlID", OleDbType.VarChar, 20, "CtrlID");
                    //cmd.Parameters.Add("@Department", OleDbType.VarChar, 20, "Department");
                    //cmd.Parameters.Add("@App_Level", OleDbType.VarChar, 20, "App_Level");
                    //cmd.Parameters.Add("@ItemID", OleDbType.VarChar, 20, "ItemID");
                    //cmd.Parameters.Add("@ItemID2", OleDbType.VarChar, 20, "ItemID2");
                    //cmd.Parameters.Add("@Detail", OleDbType.VarChar, 20, "Detail");
                    //cmd.Parameters.Add("@Price", OleDbType.Numeric, 20, "Price");
                    //cmd.Parameters.Add("@App_Count", OleDbType.Numeric, 20, "App_Count");
                    //cmd.Parameters.Add("@App_Count", OleDbType.Numeric, 20, "App_Count");
                    //adapt.InsertCommand = cmd;
                    OleDbCommandBuilder odcb = new OleDbCommandBuilder(adapt);
                    odcb.QuotePrefix = "[";
                    odcb.QuoteSuffix = "]";
                    rows += adapt.Update(dt);
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
        /// 修改申请表详情数据ApplicationDetail
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateApplicationDetail(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from ApplicationDetail", ah.Conn);
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

        public int UpdateDeliverDetail(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from DeliverDetail", ah.Conn);
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

        public int UpdateReceiptDetail(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from ReceiptDetail", ah.Conn);
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

        public void InsertReceiptDetail(DataTable dt)
        {
            if(dt!=null && dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    AccessHelper ah = new AccessHelper();
                    string sql = "insert into ReceiptDetail(CtrlID,Department,App_Level,ItemID,ItemID2,Detail,Price,App_Count,IsDelete,ItemHighlight) ";
                    sql = sql + " values('" + dr["CtrlID"] + "','" + dr["Department"] + "','" + dr["App_Level"] + "','" + dr["ItemID"] + "','" + dr["ItemID2"] + "','" + dr["Detail"] + "'," + dr["Price"] + "," + dr["App_Count"] + "," + dr["IsDelete"] + "," + dr["ItemHighlight"] + ") ";
                    ah.ExecuteSQLNonquery(sql);
                    ah.Close();
                }
            }
        }

        public void DeleteReceiptDetail(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AccessHelper ah = new AccessHelper();
                    string sql = "delete from ReceiptDetail where CtrlID='" + dr["CtrlID"].ToString() + "' ";
                    ah.ExecuteSQLNonquery(sql);
                    ah.Close();
                }
            }
        }

        /// <summary>
        /// 删除订单详情表数据
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public int DeleteApplicaionDetail(string CtrlID)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            string sql = string.Format("Update ApplicationDetail Set IsDelete = 1  where  IsDelete = 0 and CtrlID={0}", CtrlID);
            try
            {
                OleDbCommand comm = new OleDbCommand(sql, ah.Conn);
                rows = comm.ExecuteNonQuery();
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
