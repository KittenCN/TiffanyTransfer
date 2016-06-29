using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.BaseData;
using BHair.Business;
using BHair.Business.Table;
using System.IO;
using System.Drawing.Printing;
using System.Security.Cryptography;

namespace BHair.Base
{
    public partial class frmMember_Import : WinFormsUI.Docking.DockContent
    {
        Users users = new Users();
        Store store = new Store();
        DataTable memberDT = new DataTable();
        DataTable MemberDT = new DataTable();
        string sha1pwd;
        string filePath;
        public frmMember_Import()
        {
            InitializeComponent();
        }

        private void frmMember_List_Load(object sender, EventArgs e)
        {
            //this.LoadMemberList();
        }

        /// <summary>加载用户信息列表。</summary>
        public void LoadMemberList()
        {
            //user.UsersDT=user.SelectAllUsers("");
            //dgvMember.AutoGenerateColumns = false;
            //dgvMember.DataSource = user.UsersDT;
            //string strMember = this.txtMember.Text;
            //bool bEnabled = false;
            //List<Member> lstMember = new Member().SelectList(strMember, bEnabled);
            //this.dgvMember.AutoGenerateColumns = false;
            //this.dgvMember.Rows.Clear();
            //decimal dSum = 0;//合计余额
            //foreach (Member objMember in lstMember)
            //{
            //    dSum += objMember.Balance;
            //    this.dgvMember.Rows.Add(new object[] { objMember.ID, objMember.Card.CardName, objMember.Name, objMember.SexText, objMember.Birthday, objMember.Balance, objMember.Point, objMember.Phone, objMember.LastTime, objMember.StatusText, objMember.Other, objMember.Remark });
            //}


        }





       



        private void dgvMember_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            StaticValue.ShowRows_DataGridView_RowPostPaint(this.dgvMember, sender, e);
        }

        private void dgvMember_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMember.Columns[e.ColumnIndex].Name == "Character")
            {
                string str = e.Value.ToString();
                switch (str)
                {
                    case "1": e.Value = "商品部"; break;
                    case "2": e.Value = "财务部"; break;
                    case "3": e.Value = "店面员工"; break;
                    case "4": e.Value = "物流部"; break;
                    default:
                        e.Value = "无";
                        break;
                }
            }
        }



        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text == "")
            {
                MessageBox.Show("请填写用户默认密码", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel文件|*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sha1pwd = GetSHA1(txtPwd.Text.Trim());
                        label1.Text = "正在导入Excel数据....";
                        filePath = openFileDialog.FileName;
                        DataTable resultDT = users.SelectUsersByUID("");
                        store.StoreDT = store.SelectAllStoreInfo();
                        resultDT.Clear();
                        PrintExcel pe = new PrintExcel();
                        memberDT = pe.ExcelToDataTable_Member(filePath, resultDT,sha1pwd);
                        MemberDT = resultDT.Clone();
                        foreach (DataRow dr in memberDT.Rows)
                        {
                            if (dr["Character"].ToString() == "3")
                            {
                                foreach (DataRow drStore in store.StoreDT.Rows)
                                {
                                    if (dr["Store"].ToString() == drStore["StoreName"].ToString() && dr["UID"].ToString() != "Administrator")
                                    {
                                        MemberDT.Rows.Add(dr.ItemArray);
                                    }
                                }
                            }
                            else
                            {
                                if ( dr["UID"].ToString() != "Administrator")
                                {
                                    MemberDT.Rows.Add(dr.ItemArray);
                                }
                            }
                        }
                        dgvMember.AutoGenerateColumns = false;
                        dgvMember.DataSource = MemberDT;
                        label1.Text = "Excel数据导入完成";
                    }
                    catch(Exception ex)
                    {
                        label1.Text = "Excel数据导入失败:" + ex.ToString();
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            label1.Text = "正在导入到数据库....";
            try
            {

                //清空表
                users.ClearUsers();
                //插入新datatable表
                users.ImportUsers(MemberDT);
                label1.Text = "数据库导入完成";
                DialogResult = DialogResult.OK;
            }
            catch
            {
                label1.Text = "数据库导入失败";
            }
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
    }
}
