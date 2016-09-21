using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XLuSharpLibrary.DbAccess;
using System.Data.OleDb; 

namespace BHair.Business.BaseData
{
    /// <summary>用户。</summary>
    public class Users
    {
        #region 构造函数...

        /// <summary>用户。</summary>
        public Users()
        { }


        #endregion

        #region 属性...

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //用户账号
        private string _UID;
        public string UID
        {
            get { return _UID; }
            set { _UID = value; }
        }
        //用户姓名
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        //用户密码
        private string _userPwd;
        public string UserPwd
        {
            get { return _userPwd; }
            set { _userPwd = value; }
        }
        //电话
        private string _tel;
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        //Email
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        //职位
        private string _position;
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        //部门
        private string _department;
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        //所属店面
        private string _store;
        public string Store
        {
            get { return _store; }
            set { _store = value; }
        }
        //用户信息描述
        private string _detail;
        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }
        //创建时间
        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        //登陆时间
        private DateTime _loginTime;
        public DateTime LoginTime
        {
            get { return _loginTime; }
            set { _loginTime = value; }
        }
        //上次登录时间
        private DateTime _lastLoginTime;
        public DateTime LastLoginTime
        {
            get { return _lastLoginTime; }
            set { _lastLoginTime = value; }
        }
        //是否为管理员
        private int _isAdmin;
        public int IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }
        //所属角色 1=商品部（可审批可修改）；2=财务部（只可审批）；3=店面用户（提交申请和确认申请）
        private int _character;
        public int Character
        {
            get { return _character; }
            set { _character = value; }
        }
        //是否被删除 1=被删除
        private int _isDelete;
        public int IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }
        //是否被冻结 0=被冻结
        private int _isAble;
        public int IsAble
        {
            get { return _isAble; }
            set { _isAble = value; }
        }

        public DataTable UsersDT = new DataTable();

        #endregion

        #region 自定义函数...

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectAllUsers(string sql)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from [Users] where IsDelete = 0 {0}",sql);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 通过账户查询用户
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable SelectUsersByUID(string UID)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Users where IsDelete = 0 and UID='{0}'", UID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="CtrlID"></param>
        /// <returns></returns>
        public DataTable Login(string UID, string UserPwd)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Users where IsDelete = 0 and UID = '{0}' and UserPwd='{1}'", UID, UserPwd);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
        public DataTable Login(string UID)
        {
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("select * from Users where IsDelete = 0 and UID = '{0}'", UID);
            DataTable Result = ah.SelectToDataTable(sqlString);
            ah.Close();
            return Result;
        }
        /// <summary>
        /// 添加用户Users
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int InsertUser(Users user)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                //OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Users", ah.Conn);
                //OleDbCommandBuilder odcb = new OleDbCommandBuilder(adapt);
                //rows += adapt.Update(dt);
                string sql = string.Format("Insert Into [Users] ([UID],[UserName],[UserPwd],[Tel],[Email],[Position],[Department],[Store],[Detail],[IsAdmin],[Character],[IsDelete],[IsAble]) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12})", user.UID, user.UserName, user.UserPwd, user.Tel, user.Email, user.Position, user.Department, user.Store, user.Detail, user.IsAdmin, user.Character, user.IsDelete,user.IsAble);
                OleDbCommand comm = new OleDbCommand(sql, ah.Conn);
                rows += comm.ExecuteNonQuery();
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
        /// 修改用户信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int UpdateUser(Users user)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                string sql = string.Format("Update [Users] Set [UserName]='{0}' , [UserPwd]='{1}' , [Tel]='{2}' , [Email]='{3}' , [Position] ='{4}' , [Department]='{5}' , [Store]='{6}' , [Detail] = '{7}' , [IsAdmin] ={8} , [Character]={9} , [IsDelete] ={10},[IsAble]={11} Where [UID]='{12}'", user.UserName, user.UserPwd, user.Tel, user.Email, user.Position, user.Department, user.Store, user.Detail, user.IsAdmin, user.Character, user.IsDelete, user.IsAble,user.UID);
                    OleDbCommand comm = new OleDbCommand(sql, ah.Conn);
                    rows += comm.ExecuteNonQuery();
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
        /// 删除
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public int DeleteUser(string UID)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                    string sql = string.Format("Update Users Set IsDelete =1 Where UID='{0}'", UID);
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
        /// 清空用户表
        /// </summary>
        /// <returns></returns>
        public bool ClearUsers()
        {
            bool Result = true;
            AccessHelper ah = new AccessHelper();
            string sqlString = string.Format("Delete from  Users Where [UID]<>'Administrator'");
            Result = ah.ExecuteSQLNonquery(sqlString);
            ah.Close();
            return Result;
        }

        /// <summary>
        /// 导入用户表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int ImportUsers(DataTable dt)
        {
            int rows = 0;
            AccessHelper ah = new AccessHelper();
            try
            {
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Users", ah.Conn);
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

        public bool ResetPwd(string UserID)
        {
            bool Result = false;
            AccessHelper ah = new AccessHelper();
            try
            {
                string sql = string.Format("Update Users Set [UserPwd]='05B530AD0FB56286FE051D5F8BE5B8453F1CD93F' where [UID]='{0}'", UserID);
                Result = ah.ExecuteSQLNonquery(sql);
            }
            catch (Exception ex)
            {
                ah.Close();
                return false;
            }
            ah.Close();
            return Result;
        }

        #endregion
    }
}
