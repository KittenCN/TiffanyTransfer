using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.BaseData;
using BHair.Business;
using XLuSharpLibrary.CommonFunction;
using System.Security.Cryptography;

namespace BHair.Base
{
    public partial class frmMember : Form
    {
        private string UID = "";
        Users user = new Users();
        private static string[] strStore;

        /// <summary>新增用户信息。</summary>
        public frmMember()
        {
            InitializeComponent();
            this.Text = "新增用户信息";
            LoadComBox();
            if (Login.LoginUser.IsAdmin == 1)
            {
                cboCharacter.Enabled = true;
                //cboStore.Enabled = true;
                txtUID.ReadOnly = false;
                txtUserName.ReadOnly = false;
                cbIsAdmin.Visible = true;
                cbIsAble.Visible = true;
                cbcbStroe.Enabled = true;
            }
        }

        /// <summary>编辑用户信息。</summary>
        /// <param name="memberid">用户编号(ID)</param>
        public frmMember(string memberid)
        {
            InitializeComponent();
            this.Text = "编辑用户信息";
            this.UID = memberid;
            LoadComBox();
            LoadData();
            if (Login.LoginUser.IsAdmin == 1)
            {
                cboCharacter.Enabled = true;
                //cboStore.Enabled = true;
                cbIsAdmin.Visible = true;
                cbIsAble.Visible = true;
                cbcbStroe.Enabled = true;
            }
            else
            {
                cboCharacter.Enabled = false;
                //cboStore.Enabled = false;
                cbIsAdmin.Visible = false;
                cbIsAble.Visible = false;
                cbcbStroe.Enabled = false;
            }
        }

        #region 初化基础数据。

        /// <summary>初始化基础数据。</summary>
        private void LoadData()
        {
            user.UsersDT = user.SelectUsersByUID(UID);
            if (user.UsersDT.Rows.Count > 0)
            {
                LoadMember();
            }
            else
            {
                MessageBox.Show("获取用户信息失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }






        #endregion



        /// <summary>加载用户信息。</summary>
        private void LoadMember()
        {
            user.UID = user.UsersDT.Rows[0]["UID"].ToString();
            user.UserPwd = user.UsersDT.Rows[0]["UserPwd"].ToString();
            user.UserName = user.UsersDT.Rows[0]["UserName"].ToString();
            user.Tel = user.UsersDT.Rows[0]["Tel"].ToString();
            user.Email = user.UsersDT.Rows[0]["Email"].ToString();
            user.Position = user.UsersDT.Rows[0]["Position"].ToString();
            user.Department = user.UsersDT.Rows[0]["Department"].ToString();
            user.Store = user.UsersDT.Rows[0]["Store"].ToString();
            user.Detail = user.UsersDT.Rows[0]["Detail"].ToString();
            user.IsAdmin = (int)user.UsersDT.Rows[0]["IsAdmin"];
            user.Character = (int)user.UsersDT.Rows[0]["Character"];

            txtUID.Text = user.UsersDT.Rows[0]["UID"].ToString();
            txtUserName.Text = user.UsersDT.Rows[0]["UserName"].ToString();
            txtTel.Text = user.UsersDT.Rows[0]["Tel"].ToString();
            txtEmail.Text = user.UsersDT.Rows[0]["Email"].ToString();
            txtPosition.Text = user.UsersDT.Rows[0]["Position"].ToString();
            txtDepartment.Text = user.UsersDT.Rows[0]["Department"].ToString();
            txtDetail.Text = user.UsersDT.Rows[0]["Detail"].ToString();

            if (user.UsersDT.Rows[0]["IsAdmin"].ToString() == "1")
            { cbIsAdmin.Checked = true; }
            if (user.UsersDT.Rows[0]["IsAble"].ToString() == "0")
            { cbIsAble.Checked = true; }

            if (user.UsersDT.Rows[0]["Character"].ToString() == "1") cboCharacter.SelectedIndex = 0;
            if (user.UsersDT.Rows[0]["Character"].ToString() == "2") cboCharacter.SelectedIndex = 1;
            if (user.UsersDT.Rows[0]["Character"].ToString() == "3") cboCharacter.SelectedIndex = 2;
            if (user.UsersDT.Rows[0]["Character"].ToString() == "4") cboCharacter.SelectedIndex = 3;

            //if(cboStore.Items.Contains(user.UsersDT.Rows[0]["Store"].ToString()))
            //{
            //    cboStore.SelectedIndex = cboStore.Items.IndexOf(user.UsersDT.Rows[0]["Store"].ToString());
            //}
            //if (cbcbStroe.Items.Contains(user.UsersDT.Rows[0]["Store"].ToString()))
            //{
            //    cbcbStroe.SelectedIndex = cbcbStroe.Items.IndexOf(user.UsersDT.Rows[0]["Store"].ToString());
            //}
            string[] strTemp = user.UsersDT.Rows[0]["Store"].ToString().Split(',');
            if (strTemp[0]!="" && strTemp[0]!=null)
            {
                for (int x = 0; x < strTemp.Length - 1 ; x++)
                {
                    for(int y=0; y< cbcbStroe.Items.Count + 1; y++)
                    {
                        if (strStore[y] == strTemp[x])
                        {
                            cbcbStroe.CheckBoxItems[y].Checked = true;
                            break;
                        }
                    }
                }
                if(strTemp.Length==1)
                {
                    for (int y = 0; y < cbcbStroe.Items.Count + 1; y++)
                    {
                        if (strStore[y] == strTemp[0])
                        {
                            cbcbStroe.CheckBoxItems[y].Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>保存用户信息</summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtAffirm.Text)
            {
                MessageBox.Show("两次密码不同", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtUID.Text == "")
            {
                MessageBox.Show("请输入用户名", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.Text == "编辑用户信息")
            {
                GetUserInfo();
                user.UpdateUser(user);
            }
            else
            {
                GetUserInfo();
                user.InsertUser(user);
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>取消</summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        void LoadComBox()
        {
            cboCharacter.Items.Add("商品部");
            cboCharacter.Items.Add("财务部");
            cboCharacter.Items.Add("店面员工");
            cboCharacter.Items.Add("物流部");
            cboCharacter.SelectedIndex = 2;

            Store store = new Store();
            store.StoreDT = store.SelectAllStoreInfo();
            //cboStore.Items.Add("");
            //foreach(DataRow dr in store.StoreDT.Rows)
            //{
            //    cboStore.Items.Add(dr["StoreName"].ToString());
            //}
            //if(cboStore.Items.Count>0)
            //{
            //    cboStore.SelectedIndex = 0;
            //}
            strStore = new string[store.StoreDT.Rows.Count + 1];
            cbcbStroe.Items.Add("");
            strStore[0] = "";
            int i = 1;
            foreach (DataRow dr in store.StoreDT.Rows)
            {
                cbcbStroe.Items.Add(dr["StoreName"].ToString());
                strStore[i] = dr["StoreName"].ToString();
                i++;
            }
            if (cbcbStroe.Items.Count > 0)
            {
                cbcbStroe.SelectedIndex = 0;
            }
        }

        private string GetcbcbString()
        {
            string strResult = "";
            //for(int i=0;i<cbcbStroe.Items.Count;i++)
            //{
            //    if(cbcbStroe.)
            //}
            foreach (var item in cbcbStroe.CheckBoxItems)
            {
                if (item.Checked == true)
                {
                    strResult = strResult + item.Text + ",";
                }
            }
            return strResult;
        }

        void GetUserInfo()
        {
            user.UID = txtUID.Text;
            user.UserName = txtUserName.Text;
            if (txtPassword.Text.Length > 0) user.UserPwd = GetSHA1(txtPassword.Text);
            user.Tel = txtTel.Text;
            user.Email = txtEmail.Text;
            user.Position = txtPosition.Text;
            user.Department = txtDepartment.Text;
            //user.Store = cboStore.SelectedItem.ToString();
            user.Detail = txtDetail.Text;
            user.Character = cboCharacter.SelectedIndex + 1;
            user.IsDelete = 0;
            user.Store = GetcbcbString();
            if (cbIsAble.Checked) user.IsAble = 0; else user.IsAble = 1;
            if (cbIsAdmin.Checked) user.IsAdmin = 1; else user.IsAdmin = 0;


            //user.UsersDT = user.SelectUsersByUID(UID);
            //if (this.Text == "编辑用户信息")
            //{
            //    user.UsersDT.Rows[0]["UID"] = txtUID.Text;
            //    user.UsersDT.Rows[0]["UserName"] = txtUserName.Text;
            //    user.UsersDT.Rows[0]["UserPwd"] = GetSHA1(txtPassword.Text);
            //    user.UsersDT.Rows[0]["Tel"] = txtTel.Text;
            //    user.UsersDT.Rows[0]["Email"] = txtEmail.Text;
            //    user.UsersDT.Rows[0]["Position"] = txtPosition.Text;
            //    user.UsersDT.Rows[0]["Department"] = txtDepartment.Text;
            //    user.UsersDT.Rows[0]["Store"] = cboStore.SelectedText;
            //    user.UsersDT.Rows[0]["Detail"] = txtDetail.Text;
            //    user.UsersDT.Rows[0]["Character"] = cboCharacter.SelectedIndex + 1;
            //    user.UsersDT.Rows[0]["IsDelete"] = 0;
            //    if (cbIsAdmin.Checked) user.UsersDT.Rows[0]["IsAdmin"] = 1; else user.UsersDT.Rows[0]["IsAdmin"] = 0;
            //}
            //else
            //{
            //    DataRow dr = user.UsersDT.NewRow();
            //    dr["UID"] = txtUID.Text;
            //    dr["UserName"] = txtUserName.Text;
            //    dr["UserPwd"] = GetSHA1(txtPassword.Text);
            //    dr["Tel"] = txtTel.Text;
            //    dr["Email"] = txtEmail.Text;
            //    dr["Position"] = txtPosition.Text;
            //    dr["Department"] = txtDepartment.Text;
            //    dr["Store"] = cboStore.SelectedText;
            //    dr["Detail"] = txtDetail.Text;
            //    dr["Character"] = cboCharacter.SelectedIndex + 1;
            //    dr["IsDelete"] = 0;
            //    if (cbIsAdmin.Checked) dr["IsAdmin"] = 1; else dr["IsAdmin"] = 0;
            //    user.UsersDT.Rows.Add(dr);
            //}
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                user.ResetPwd(txtUID.Text);
                MessageBox.Show("重置成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("重置密码失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
