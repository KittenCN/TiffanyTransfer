using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XLuSharpLibrary.DbAccess;
using System.Data.OleDb; 

namespace BHair.Business.BaseData
{
    /// <summary>设置。</summary>
    public class SetupConfig
    {
        #region 构造函数...

        /// <summary>设置。</summary>
        public SetupConfig()
        { }


        #endregion

        #region 属性...

        //Email账号
        private string _emailID;
        public string EmailID
        {
            get { return _emailID; }
            set { _emailID = value; }
        }
        //Email密码
        private string _emailPwd;
        public string EmailPwd
        {
            get { return _emailPwd; }
            set { _emailPwd = value; }
        }
        //Email地址
        private string _emailAddress;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }
        //Email的STMP
        private string _emailSMTP;
        public string EmailSMTP
        {
            get { return _emailSMTP; }
            set { _emailSMTP = value; }
        }
        //金额上限
        private double _upperLimit;
        public double UpperLimit
        {
            get { return _upperLimit; }
            set { _upperLimit = value; }
        }
        #endregion

        #region 自定义函数...

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable GetConfig()
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from [SetupConfig]");
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 修改配置
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateConfig()
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                string sql = string.Format("Update [SetupConfig] Set [EmailID]='{0}', [EmailPwd]='{1}' , [EmailAddress]='{2}' ,[EmailSMTP]='{3}',[UpperLimit]={4}",EmailID,EmailPwd,EmailAddress,EmailSMTP,UpperLimit);
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
