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
    /// <summary>转货表信息。</summary>
    public class ApplicationInfo
    {
        #region 构造函数...

        /// <summary>转货表</summary>
        public ApplicationInfo()
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
        //申请人姓名
        private string _applicantsName;
        public string ApplicantsName
        {
            get { return _applicantsName; }
            set { _applicantsName = value; }
        }
        //申请人职位
        private string _applicantsPos;
        public string ApplicantsPos
        {
            get { return _applicantsPos; }
            set { _applicantsPos = value; }
        }
        //申请日期
        private string _applicantsDate;
        public string ApplicantsDate
        {
            get { return _applicantsDate; }
            set { _applicantsDate = value; }
        }
        //发货店铺名
        private string _deliverStore;
        public string DeliverStore
        {
            get { return _deliverStore; }
            set { _deliverStore = value; }
        }
        //收货店铺名
        private string _receiptStore;
        public string ReceiptStore
        {
            get { return _receiptStore; }
            set { _receiptStore = value; }
        }
        //审批人（商品部
        private string _approvalName;
        public string ApprovalName
        {
            get { return _approvalName; }
            set { _approvalName = value; }
        }
        //审批时间（商品部
        private string _approvalDate;
        public string ApprovalDate
        {
            get { return _approvalDate; }
            set { _approvalDate = value; }
        }
        //审批人（财务部
        private string _approvalName2;
        public string ApprovalName2
        {
            get { return _approvalName2; }
            set { _approvalName2 = value; }
        }
        //审批时间（财务部
        private string _approvalDate2;
        public string ApprovalDate2
        {
            get { return _approvalDate2; }
            set { _approvalDate2 = value; }
        }
        //发货前检查
        private string _deliverCheck;
        public string DeliverCheck
        {
            get { return _deliverCheck; }
            set { _deliverCheck = value; }
        }
        //发货前检查人
        private string _deliverCheckerName;
        public string DeliverCheckerName
        {
            get { return _deliverCheckerName; }
            set { _deliverCheckerName = value; }
        }
        //发货前检查状态
        private int _deliverState;
        public int DeliverState
        {
            get { return _deliverState; }
            set { _deliverState = value; }
        }
        //发货时间
        private string _deliverDate;
        public string DeliverDate
        {
            get { return _deliverDate; }
            set { _deliverDate = value; }
        }
        //收货前检查
        private string _receiptCheck;
        public string ReceiptCheck
        {
            get { return _receiptCheck; }
            set { _receiptCheck = value; }
        }
        //收货前检查人
        private string _receiptCheckerName;
        public string ReceiptCheckerName
        {
            get { return _receiptCheckerName; }
            set { _receiptCheckerName = value; }
        }
        //收货前检查状态
        private int _receiptState;
        public int ReceiptState
        {
            get { return _receiptState; }
            set { _receiptState = value; }
        }
        //收货时间
        private string _receiptDate;
        public string ReceiptDate
        {
            get { return _receiptDate; }
            set { _receiptDate = value; }
        }
        //S_O
        private string _S_O;
        public string S_O
        {
            get { return _S_O; }
            set { _S_O = value; }
        }
        //O_O
        private string _O_O;
        public string O_O
        {
            get { return _O_O; }
            set { _O_O = value; }
        }
        //S/O内容
        private string _S_O_Str;
        public string S_O_Str
        {
            get { return _S_O_Str; }
            set { _S_O_Str = value; }
        }
        //O_O内容
        private string _O_O_Str;
        public string O_O_Str
        {
            get { return _O_O_Str; }
            set { _O_O_Str = value; }
        }
        //Batch_Num1
        private string _batch_Num1;
        public string Batch_Num1
        {
            get { return _batch_Num1; }
            set { _batch_Num1 = value; }
        }
        //Batch_Num2
        private string _batch_Num2;
        public string Batch_Num2
        {
            get { return _batch_Num2; }
            set { _batch_Num2 = value; }
        }
        //Batch_Num2
        private string _wuliuID;
        public string WuliuID
        {
            get { return _wuliuID; }
            set { _wuliuID = value; }
        }
        //物流时间
        private string _wuliuDate;
        public string WuliuDate
        {
            get { return _wuliuDate; }
            set { _wuliuDate = value; }
        }

        //修改原因
        private string _editReason;
        public string EditReason
        {
            get { return _editReason; }
            set { _editReason = value; }
        }

        //转货类型
        private string _exchangeType;
        public string ExchangeType
        {
            get { return _exchangeType; }
            set { _exchangeType = value; }
        }

        //订单状态
        private int _appState;
        public int AppState
        {
            get { return _appState; }
            set { _appState = value; }
        }
        #endregion

        #region 自定义函数...

        /// <summary>
        /// 根据申请人ID查询订单ApplicationInfo表
        /// </summary>
        /// <param name="Applicants">申请人ID</param>
        /// <returns>Application表</returns>
        public DataTable SelectApplicationByApplicants(string[] Applicants,string sql)
        {
            DataTable Result = null;
            Boolean boolFlag = false;
            for (int i = 0; i < Applicants.Length; i++)
            {
                if (Applicants[i].ToString() != null && Applicants[i].ToString() != "")
                {
                    AccessHelper ah = new AccessHelper();
                    string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState<9 and ( DeliverStore='{0}' or ReceiptStore='{0}') {1} order by [ApplicantsDate] desc", Applicants[i].ToString(), sql);
                    DataTable tempResult = ah.SelectToDataTable(sqlString);
                    if (boolFlag == false)
                    {
                        Result = tempResult;
                        boolFlag = true;
                    }
                    else
                    {
                        foreach (DataRow dr in tempResult.Rows)
                        {
                            Result.Rows.Add(dr.ItemArray);
                        }
                    }
                    ah.Close();
                }
            }

            return Result;
        }

        /// <summary>
        /// 根据申请人ID查询历史订单ApplicationInfo表
        /// </summary>
        /// <param name="Applicants">申请人ID</param>
        /// <returns>Application表</returns>
        public DataTable SelectHistoryApplicationByApplicants(string[] Applicants, string sql)
        {
            DataTable Result = null;
            Boolean boolFlag = false;
            for (int i = 0; i < Applicants.Length; i++)
            {
                if (Applicants[i].ToString() != null && Applicants[i].ToString() != "")
                {
                    AccessHelper ah = new AccessHelper();
                    string sqlString = string.Format("select * from ApplicationInfo where IsDelete=0 and AppState=9 and ( DeliverStore='{0}' or ReceiptStore='{0}') {1} order by [ApplicantsDate] desc", Applicants[i].ToString(), sql);
                    DataTable tempResult = ah.SelectToDataTable(sqlString);
                    if (boolFlag == false)
                    {
                        Result = tempResult;
                        boolFlag = true;
                    }
                    else
                    {
                        foreach (DataRow dr in tempResult.Rows)
                        {
                            Result.Rows.Add(dr.ItemArray);
                        }
                    }
                    ah.Close();
                }
            }

            return Result;
        }

        /// <summary>
        /// 根据控制ID查询订单ApplicationInfo表
        /// </summary>
        /// <param name="Applicants">申请人ID</param>
        /// <returns>Application表</returns>
        public DataTable SelectApplicationByCtrlID(string CtrlID)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and  CtrlID = '{0}' order by [ApplicantsDate] desc ", CtrlID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 商品部查询ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectApplicationByApproval(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState=0 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 商品部查询待修改AppInfo
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable SelectAlterAppByApproval(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState = 5 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 商品部查询Finished AppInfo
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable SelectFinishAppByApproval(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState = 9 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 商品部查询已审批ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectHistoryApplicationByApproval(string sql,Users users)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState>0 and Approval='{1}' {0} order by [ApplicantsDate] desc", sql, users.UID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 商品部查询未通过ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectNotPassedApplication(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState<9 and ( ApprovalState=2 or ApprovalState2=2 or DeliverState=2 or ReceiptState=3) {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 商品部查询全部ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllApplication(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
        public DataTable SelectAllDetail(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select a.CtrlID,b.ItemID,b.ItemID2,a.DeliverStore,a.ReceiptStore,a.ApplicantsDate,a.ApplicantsName,a.TotalPrice,a.AppState,a.IsDelete from ApplicationInfo a left join ApplicationDetail b on  a.CtrlID=b.CtrlID where a.IsDelete=0 and b.IsDelete=0 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
        /// <summary>
        /// 财务部查询ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectApplicationByApproval2(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState=1 and ApprovalState =1 and ApprovalState2 = 0 and DeliverState = 0 and ReceiptState = 0 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 财务部查询已审核ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectHistoryApplicationByApproval2(string sql,Users users)
        {
            AccessHelper ah = new AccessHelper();
            //string sqlString = string.Format("select * from ApplicationInfo where  AppState>1 and Approval2='{1}'  {0} order by [ApplicantsDate] desc", sql, users.UID);
            string sqlString = string.Format("select * from ApplicationInfo where  AppState>1 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
        public DataTable SelectHistoryApplicationByApproval2(string sql, Users users,string strSort)
        {
            AccessHelper ah = new AccessHelper();
            //string sqlString = string.Format("select * from ApplicationInfo where  AppState>1 and Approval2='{1}'  {0} order by [ApplicantsDate] desc", sql, users.UID);
            string sqlString = string.Format("select * from ApplicationInfo where  AppState>1 {0} order by {1} ", sql,strSort);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 发货店面查询ApplicationInfo
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        public DataTable SelectApplicationByDeliver(string[] Store,string sql)
        {
            DataTable Result = null;
            Boolean boolFlag = false;
            for (int i = 0; i < Store.Length; i++)
            {
                if(Store[i].ToString()!=null && Store[i].ToString()!="")
                {
                    AccessHelper ah = new AccessHelper();
                    string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState=2  and DeliverStore = '{0}' {1} order by [ApplicantsDate] desc", Store[i].ToString(), sql);
                    DataTable tempResult = ah.SelectToDataTable(sqlString);
                    if (boolFlag == false)
                    {
                        Result = tempResult;
                        boolFlag = true;
                    }
                    else
                    {
                        foreach (DataRow dr in tempResult.Rows)
                        {
                            Result.Rows.Add(dr.ItemArray);
                        }
                    }
                    ah.Close();
                }
            }

            return Result;
        }

        /// <summary>
        /// 收货店面查询ApplicationInfo
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        public DataTable SelectApplicationByReceipt(string[] Store,string sql)
        {
            DataTable Result = null;
            Boolean boolFlag = false;
            for (int i = 0; i < Store.Length; i++)
            {
                if (Store[i].ToString() != null && Store[i].ToString() != "")
                {
                    AccessHelper ah = new AccessHelper();
                    string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState=3 and ApprovalState =1 and ApprovalState2 = 1 and DeliverState = 1 and ReceiptState = 0 and ReceiptStore = '{0}' {1} order by [ApplicantsDate] desc", Store[i].ToString(), sql);
                    DataTable tempResult = ah.SelectToDataTable(sqlString);
                    if (boolFlag == false)
                    {
                        Result = tempResult;
                        boolFlag = true;
                    }
                    else
                    {
                        foreach (DataRow dr in tempResult.Rows)
                        {
                            Result.Rows.Add(dr.ItemArray);
                        }
                    }
                    ah.Close();
                }
            }

            return Result;
        }

        /// <summary>
        /// 物流确认查询ApplicationInfo
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        public DataTable SelectFinalApplication( string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState=4   {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 物流未确认查询ApplicationInfo
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        public DataTable SelectUNApplication(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select a.DeliverStore as 发货店铺,ReceiptStore as 收货店铺,a.receiptdate as 收货日期,b.ctrlid as 控制号,b.department as 部门,b.app_level as 级别,b.itemid as 货号,b.itemid2 as 双货号,b.price as 单价,b.app_count as 数量,b.ItemHighlight from applicationinfo a inner join ReceiptDetail b on a.ctrlid=b.ctrlid where a.AppState=4 and b.isdelete=0 {0} order by a.receiptdate,b.ctrlid,b.department,b.app_level,b.itemid,b.itemid2,b.price,b.app_count", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }


        /// <summary>
        /// 物流已确认查询ApplicationInfo
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        public DataTable SelectApplication(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select a.DeliverStore as 发货店铺,ReceiptStore as 收货店铺,a.receiptdate as 收货日期,b.ctrlid as 控制号,b.department as 部门,b.app_level as 级别,b.itemid as 货号,b.itemid2 as 双货号,a.S_O,a.S_O_Str,a.O_O,a.O_O_Str,a.Batch_Num1,a.Batch_Num2,b.price as 单价,b.app_count as 数量,b.ItemHighlight from applicationinfo a inner join ReceiptDetail b on a.ctrlid=b.ctrlid where a.AppState>4 and b.isdelete=0 {0} order by a.receiptdate,b.ctrlid,b.department,b.app_level,b.itemid,b.itemid2,b.price,b.app_count", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 物流确认查询历史ApplicationInfo
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        public DataTable SelectHistoryFinalApplication(string sql,string WuliuUser)
        {
            AccessHelper ah = new AccessHelper();
            //string sqlString = string.Format("select * from ApplicationInfo where AppState>4  and [WuliuUser]='{1}' {0} order by [ApplicantsDate] desc", sql, WuliuUser);
            string sqlString = string.Format("select * from ApplicationInfo where AppState>4  {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 查询历史订单ApplicationInfo表
        /// </summary>
        /// <returns>Application表</returns>
        public DataTable SelectHistoryApplication(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where IsDelete = 0 and AppState = 9 and ApprovalState=1 and ApprovalState2=1 and DeliverState=1 and ReceiptState =1 {0} order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 将提交的申请表Info插入数据库ApplicationInfo，添加申请表数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int SubmitApplicationInfo(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (SelectApplicationByCtrlID(dr["CtrlID"].ToString()).Rows.Count == 0)
                    {
                        OleDbDataAdapter adapt = new OleDbDataAdapter("select * from ApplicationInfo", ah.Conn);
                        var cmd = new OleDbCommand("insert into ApplicationInfo (CtrlID,Applicants,ApplicantsName,ApplicantsPos,ApplicantsDate,DeliverStore,ReceiptStore,Approval,ApprovalPos,TotalCount,TotalPrice,ExchangeType) values(@CtrlID,@Applicants,@ApplicantsName,@ApplicantsPos,@ApplicantsDate,@DeliverStore,@ReceiptStore,@Approval,@ApprovalPos,@TotalCount,@TotalPrice,@ExchangeType) ", ah.Conn);
                        cmd.Parameters.Add("@CtrlID", OleDbType.VarChar, 20, "CtrlID");
                        cmd.Parameters.Add("@Applicants", OleDbType.VarChar, 40, "Applicants");
                        cmd.Parameters.Add("@ApplicantsName", OleDbType.VarChar, 40, "ApplicantsName");
                        cmd.Parameters.Add("@ApplicantsPos", OleDbType.VarChar, 20, "ApplicantsPos");
                        cmd.Parameters.Add("@ApplicantsDate", OleDbType.Date, 20, "ApplicantsDate");
                        cmd.Parameters.Add("@DeliverStore", OleDbType.VarChar, 20, "DeliverStore");
                        cmd.Parameters.Add("@ReceiptStore", OleDbType.VarChar, 20, "ReceiptStore");
                        cmd.Parameters.Add("@Approval", OleDbType.VarChar, 20, "Approval");
                        cmd.Parameters.Add("@ApprovalPos", OleDbType.VarChar, 20, "ApprovalPos");
                        cmd.Parameters.Add("@TotalCount", OleDbType.Numeric, 20, "TotalCount");
                        cmd.Parameters.Add("@TotalPrice", OleDbType.Numeric, 20, "TotalPrice");
                        cmd.Parameters.Add("@ExchangeType", OleDbType.VarChar, 40, "ExchangeType");
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
        /// 修改申请表数据ApplicationInfo
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateApplicationInfo(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from ApplicationInfo", ah.Conn);
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
        /// 修改申请详情表Detail
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

        /// <summary>
        /// 商品部审批
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int ApprovalApplication(string CtrlID,Users users,int ApprovalState,DateTime dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            string sql;
            if(ApprovalState==2)  sql = string.Format("Update ApplicationInfo Set ApprovalDate = '{5}', AppState = 0,ApprovalState = {1} ,Approval='{2}' , ApprovalName='{3}' , ApprovalPos='{4}' where  ApprovalState = 0 and AppState=0 and IsDelete = 0 and CtrlID='{0}'", CtrlID, ApprovalState, users.UID, users.UserName, users.Position, dt);
            else  sql = string.Format("Update ApplicationInfo Set ApprovalDate = '{5}', AppState = 1,ApprovalState = {1} ,Approval='{2}' , ApprovalName='{3}' , ApprovalPos='{4}' where  ApprovalState = 0 and AppState=0 and IsDelete = 0 and CtrlID='{0}'", CtrlID, ApprovalState, users.UID, users.UserName, users.Position, dt);
            try
            {
                OleDbCommand comm = new OleDbCommand(sql, ah.Conn);
                rows = comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ah.Close();
                return 0;
            }
            ah.Close();
            return rows;
        }

        /// <summary>
        /// 财务部审批
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int ApprovalApplication2(string CtrlID,Users users,int ApprovalState,DateTime dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            string sql;
            if(ApprovalState==2)  sql  = string.Format("Update ApplicationInfo Set ApprovalDate2='{5}', ApprovalState2 = {4} ,AppState=1 , Approval2='{1}' , ApprovalName2='{2}' , ApprovalPos2='{3}' where  ApprovalState = 1 and ApprovalState2 = 0 and  AppState =1 and IsDelete = 0 and CtrlID='{0}'", CtrlID, users.UID, users.UserName, users.Position, ApprovalState, dt);
                else sql  = string.Format("Update ApplicationInfo Set ApprovalDate2='{5}', ApprovalState2 = {4} ,AppState=2 , Approval2='{1}' , ApprovalName2='{2}' , ApprovalPos2='{3}' where  ApprovalState = 1 and ApprovalState2 = 0 and  AppState =1 and IsDelete = 0 and CtrlID='{0}'", CtrlID, users.UID, users.UserName, users.Position, ApprovalState, dt);
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

        /// <summary>
        /// 转出店面确认
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int DeliverConfirm(string CtrlID, string check, Users user,int DeliverState)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            string sql ;
            if (DeliverState == 2) sql = string.Format("Update ApplicationInfo Set DeliverState = {4} , DeliverCheck='{1}' , DeliverChecker='{2}' , DeliverCheckerName='{3}' , AppState=2 where DeliverState = 0 and  ApprovalState2 = 1 and ApprovalState = 1 and  AppState =2 and IsDelete = 0 and CtrlID='{0}'", CtrlID, check, user.UID, user.UserName, DeliverState);
           else sql = string.Format("Update ApplicationInfo Set DeliverState = {4} , DeliverCheck='{1}' , DeliverChecker='{2}' , DeliverCheckerName='{3}' , AppState=3 where DeliverState = 0 and  ApprovalState2 = 1 and ApprovalState = 1 and  AppState =2 and IsDelete = 0 and CtrlID='{0}'", CtrlID,check,user.UID,user.UserName,DeliverState);
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

        /// <summary>
        /// 收货店面确认
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int ReceiptConfirm(string CtrlID, string check, Users user,int ReceiptState)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            string sql;
                if(ReceiptState==2||ReceiptState==3) sql= string.Format("Update ApplicationInfo Set ReceiptState = {4} ,ReceiptCheck='{1}' , ReceiptChecker='{2}' , ReceiptCheckerName='{3}'  ,  AppState=3 where ReceiptState = 0 and  DeliverState = 1 and  ApprovalState2 = 1 and  ApprovalState = 1 and  AppState =3 and IsDelete = 0 and CtrlID='{0}'", CtrlID, check, user.UID, user.UserName, ReceiptState);
                else sql= string.Format("Update ApplicationInfo Set ReceiptState = {4} ,ReceiptCheck='{1}' , ReceiptChecker='{2}' , ReceiptCheckerName='{3}'  ,  AppState=4 where ReceiptState = 0 and  DeliverState = 1 and  ApprovalState2 = 1 and  ApprovalState = 1 and  AppState =3 and IsDelete = 0 and CtrlID='{0}'", CtrlID, check, user.UID, user.UserName, ReceiptState);
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

        /// <summary>
        /// 物流确认
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int WLConfirm(string CtrlID,string WuliuID)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            string sql = string.Format("Update ApplicationInfo Set AppState=9,[WuliuUser]='{1}' where IsDelete = 0 and CtrlID='{0}'", CtrlID,WuliuID);
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

        /// <summary>
        /// 商品部最终确认
        /// </summary>
        /// <param name="CtrlID">控制号</param>
        /// <returns></returns>
        public int FinalConfirm(string CtrlID)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            string sql = string.Format("Update ApplicationInfo Set AppState=9 where IsDelete = 0 and CtrlID='{0}'", CtrlID);
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

        /// <summary>
        /// 删除订单表数据
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public int DeleteApplicaionInfo(string CtrlID)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            string sql = string.Format("Update ApplicationInfo Set IsDelete = 1  where  IsDelete = 0 and CtrlID='{0}'", CtrlID);
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








        /// <summary>
        /// 报表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable SelectAppReport(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationDetail left join ApplicationInfo on ApplicationDetail.CtrlID=ApplicationInfo.CtrlID where ApplicationInfo.AppState=9 and ApplicationInfo.IsDelete=0 {0}", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }



        /// <summary>
        /// 获取申请批准后超时提醒
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataTable SelectAlertApproval(string DeliverStore)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where [IsDelete]=0 and [Alert_Approval]=0 and  [DeliverStore]='{0}' and [AppState]>0 and [AppState]<3 and [ApplicantsDate]<#{1}# ", DeliverStore, DateTime.Now.AddHours(-72));
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
        /// <summary>
        /// 完成超时提醒
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public int FinishAlertApproval(string CtrlID)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            string sql = string.Format("Update ApplicationInfo Set Alert_Approval=1 where  CtrlID='{0}'", CtrlID);
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


        /// <summary>
        /// 获取发货后超时提醒
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataTable SelectAlertDeliver(string DeliverStore)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where [IsDelete]=0 and  [Alert_Deliver]=0 and [DeliverStore]='{0}' and [AppState]>=3 and [AppState]<4 and [DeliverDate]<#{1}# ", DeliverStore, DateTime.Now.AddHours(-72));
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
        /// <summary>
        /// 完成超时提醒
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public int FinishAlertDeliver(string CtrlID)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            string sql = string.Format("Update ApplicationInfo Set Alert_Deliver=1 where  CtrlID='{0}'", CtrlID);
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

        /// <summary>
        /// 获取收货后超时提醒
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataTable SelectAlertReceipt(string ReceiptStore)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo where [IsDelete]=0 and [Alert_Receipt]=0 and [ReceiptStore]='{0}' and [AppState]>=4 and [AppState]<5 and [ReceiptDate]<#{1}# ", ReceiptStore, DateTime.Now.AddHours(-48));
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
        /// <summary>
        /// 完成超时提醒
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public int FinishAlertReceipt(string CtrlID)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            string sql = string.Format("Update ApplicationInfo Set Alert_Receipt=1 where  CtrlID='{0}'", CtrlID);
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

        /// <summary>
        /// 查询全部ApplicationInfo
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllApplicationInfo(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from ApplicationInfo  order by [ApplicantsDate] desc", sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
    }
}
