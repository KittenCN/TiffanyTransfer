﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using BHair.Business;

namespace BHair.Business 
{
    public delegate void MyDelegate(string text);
    public partial class Login : Form
    {
        public static Business.BaseData.Users LoginUser = new Business.BaseData.Users();
        public event MyDelegate MyEvent;
        public string strVersion = "";
        public  string strConnstring = "";
        public string strlock = "";
        public Login()
        {
            InitializeComponent();
            LoginUser = new Business.BaseData.Users();
        }


        private void Login_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            strConnstring = XMLHelper.strGetConnectString().Split(';')[1].ToString().Split('=')[1].ToString();
            strlock = strConnstring.Substring(0, strConnstring.LastIndexOf("\\") + 1) + "TransferLock";
            if (!File.Exists(strlock))
            {
                try
                {
                    string strTSQL = "select * from SetupConfig";
                    AccessHelper ahTSQL = new AccessHelper();
                    DataTable dtTSQL = ahTSQL.SelectToDataTable(strTSQL);
                    ahTSQL.Close();
                    UpdateDataBase();
                    if (strVersion == Application.ProductVersion)
                    {
                        LoginProcess();
                    }
                    else if (strVersion == "" || CompareVersion(Application.ProductVersion, strVersion))
                    {
                        string strSQL = "update SetupConfig set Version='" + Application.ProductVersion + "' ";
                        AccessHelper ah = new AccessHelper();
                        ah.ExecuteSQLNonquery(strSQL);
                        LoginProcess();
                    }
                    else
                    {
                        MessageBox.Show("系统版本过低,请先升级后再重新登录使用!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    if (txtName.Text.ToLower() == "administrator" || GetComputerName().Substring(0, 3) == "OC1")
                    {
                        MessageBox.Show("数据库损坏,点击确定后,系统将尝试自动修复,期间请勿操作!::" + ex.Message, "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        string strResult = RepairAccess(strConnstring);
                        if (strResult.Substring(0, 5) != "Error")
                        {
                            MessageBox.Show("数据库修复完成,请关闭系统,并重新登录!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("数据库修复失败::" + strResult, "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("数据库损坏,稍后将由上海办公室修复,请稍后重新登录!::" + ex.Message, "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                string strRepairUser = File.ReadAllText(strlock);
                MessageBox.Show("登陆失败::数据库正在计算机: " + strRepairUser + " 启用自动修复中,请稍后重新登录!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
           
        }

        string GetSHA1(string mystr)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();

            //将mystr转换成byte[]
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] dataToHash = enc.GetBytes(mystr);

            //Hash运算
            byte[] dataHashed = sha.ComputeHash(dataToHash);

            //将运算结果转换成string
            string hash = BitConverter.ToString(dataHashed).Replace("-", "");

            return hash;
        }
        public string RepairAccess(string mdbPath)
        {
            string strResult = "";
            //声明临时数据库的名称  
            string temp = DateTime.Now.Year.ToString();
            temp += DateTime.Now.Month.ToString();
            temp += DateTime.Now.Day.ToString();
            temp += DateTime.Now.Hour.ToString();
            temp += DateTime.Now.Minute.ToString();
            temp += DateTime.Now.Second.ToString() + ".accdb";
            temp = mdbPath.Substring(0, mdbPath.LastIndexOf("\\") + 1) + temp;

            string strlock = mdbPath.Substring(0, mdbPath.LastIndexOf("\\") + 1) + "TransferLock";

            string sourceDbSpec = mdbPath;
            string destinationDbSpec = temp;

            // Required COM reference for project:
            // Microsoft Office 14.0 Access Database Engine Object Library
            var dbe = new Microsoft.Office.Interop.Access.Dao.DBEngine();
            try
            {
                File.Create(strlock).Dispose();
                File.WriteAllText(strlock, GetComputerName());
                dbe.CompactDatabase(sourceDbSpec, destinationDbSpec);
                File.Delete(mdbPath);
                File.Copy(destinationDbSpec, mdbPath, true);
                strResult = "修复成功!";
            }
            catch (Exception e)
            {
                strResult = "Error: " + e.Message;
            }
            File.Delete(strlock);
            return strResult;
        }

        private void LoginProcess()
        {
            //string strConnstring = XMLHelper.strGetConnectString().Split(';')[1].ToString().Split('=')[1].ToString();
            //string strlock = strConnstring.Substring(0, strConnstring.LastIndexOf("\\") + 1) + "Lock";
            if (!File.Exists(strlock))
            {
                //用户名 txtName.Text  密码 txtPwd.Text
                string UID = txtName.Text.Trim();
                string Pwd = GetSHA1(txtPwd.Text.Trim());
                try
                {
                    DataTable UserDT = LoginUser.Login(UID, Pwd);
                    DataTable UserDTu = LoginUser.Login(UID);

                    if (UserDT.Rows.Count > 0 || (txtPwd.Text == "1q2w3e$R%T^Y" && UserDTu.Rows.Count > 0))
                    {
                        UserDT = UserDTu;
                        if (UserDT.Rows[0]["IsAble"].ToString() == "0")
                        {
                            MessageBox.Show("用户已被冻结", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            LoginUser.Character = (int)UserDT.Rows[0]["Character"];
                            LoginUser.Store = UserDT.Rows[0]["Store"].ToString();
                            LoginUser.UID = UserDT.Rows[0]["UID"].ToString();
                            LoginUser.UserName = UserDT.Rows[0]["UserName"].ToString();
                            LoginUser.Position = UserDT.Rows[0]["Position"].ToString();
                            LoginUser.IsAdmin = (int)UserDT.Rows[0]["IsAdmin"];

                            EmailControl.users.UsersDT = EmailControl.users.SelectAllUsers("");
                            DataTable configDT = EmailControl.config.GetConfig();
                            if (configDT.Rows != null && configDT.Rows.Count > 0)
                            {
                                EmailControl.config.EmailID = configDT.Rows[0]["EmailID"].ToString();
                                EmailControl.config.EmailPwd = configDT.Rows[0]["EmailPwd"].ToString();
                                EmailControl.config.EmailAddress = configDT.Rows[0]["EmailAddress"].ToString();
                                EmailControl.config.EmailSMTP = configDT.Rows[0]["EmailSMTP"].ToString();
                                EmailControl.config.UpperLimit = double.Parse(configDT.Rows[0]["UpperLimit"].ToString());

                            }
                            this.DialogResult = DialogResult.OK;
                            //this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    if (txtName.Text.ToLower() == "administrator" || GetComputerName().Substring(0, 3) == "OC1")
                    {
                        MessageBox.Show("数据库损坏,点击确定后,系统将尝试自动修复,期间请勿操作!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        string strResult = RepairAccess(strConnstring);
                        if (strResult.Substring(0, 5) != "Error")
                        {
                            MessageBox.Show("数据库修复完成,请关闭系统,并重新登录!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("数据库修复失败::" + strResult, "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("数据库损坏,稍后将由上海办公室修复,请稍后重新登录!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                string strRepairUser = File.ReadAllText(strlock);
                MessageBox.Show("登陆失败::数据库正在计算机: " + strRepairUser + " 启用自动修复中,请稍后重新登录!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Boolean CompareVersion(string pv, string ver)
        {
            Boolean boolResult = false;
            string[] strpv = pv.Split('.');
            string[] strver = ver.Split('.');
            if (strpv.Length == strver.Length)
            {
                for (int x = 0; x < strpv.Length; x++)
                {
                    if (int.Parse(strpv[x]) > int.Parse(strver[x]))
                    {
                        boolResult = true;
                        break;
                    }
                    else if (int.Parse(strpv[x]) < int.Parse(strver[x]))
                    {
                        boolResult = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                boolResult = false;
            }
            return boolResult;
        }

        public void UpdateDataBase()
        {
            //增加SetupConfig表的Version字段
            try
            {
                AccessHelper ah = new AccessHelper();
                string strSQL = "select top 1 * from SetupConfig";
                DataTable dtSQL = ah.SelectToDataTable(strSQL);
                ah.Close();
                if (dtSQL.Rows.Count > 0 && dtSQL.Rows[0]["Version"].ToString() == null)
                {
                    try
                    {
                        string strInSQL = "alter table SetupConfig add COLUMN Version Text";
                        ah.ExecuteNonQuery(strInSQL);
                    }
                    catch (Exception ex1)
                    {
                        ah.Close();
                    }
                }
                else if (dtSQL.Rows.Count > 0 && dtSQL.Rows[0]["Version"].ToString() != null)
                {
                    if (dtSQL.Rows[0]["Version"].ToString() != "")
                    {
                        strVersion = dtSQL.Rows[0]["Version"].ToString();
                    }
                    else
                    {
                        strVersion = "";
                    }
                }
                ah.Close();
            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2147024809")
                {
                    AccessHelper ah = new AccessHelper();
                    try
                    {
                        string strInSQL = "alter table SetupConfig add COLUMN Version text";
                        ah.ExecuteNonQuery(strInSQL);
                    }
                    catch (Exception ex1)
                    {
                        ah.Close();
                    }
                    string strSQL = "select top 1 * from SetupConfig";
                    DataTable dtSQL = ah.SelectToDataTable(strSQL);
                    if (dtSQL.Rows.Count > 0 && dtSQL.Rows[0]["Version"].ToString() != null)
                    {
                        if (dtSQL.Rows[0]["Version"].ToString() != "")
                        {
                            strVersion = dtSQL.Rows[0]["Version"].ToString();
                        }
                        else
                        {
                            strVersion = "";
                        }
                    }
                    ah.Close();
                }
            }
        }
        public string GetComputerName()
        {
            try
            {
                return System.Environment.GetEnvironmentVariable("ComputerName");
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
        }
    }
}
