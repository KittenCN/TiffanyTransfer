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

namespace BHair.Base
{
    public partial class frmMember_List : WinFormsUI.Docking.DockContent
    {
        Users user = new Users();
        public frmMember_List()
        {
            InitializeComponent();
        }

        private void frmMember_List_Load(object sender, EventArgs e)
        {
            this.LoadMemberList();
        }

        /// <summary>加载用户信息列表。</summary>
        public void LoadMemberList()
        {
            user.UsersDT=user.SelectAllUsers("");
            dgvMember.AutoGenerateColumns = false;
            dgvMember.DataSource = user.UsersDT;
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

        



        private void txtMember_TextChanged(object sender, EventArgs e)
        {
            string sql = string.Format(" and ([UserName] like '%{0}%' or [UID] like '%{0}%')",txtMember.Text);
            user.UsersDT = user.SelectAllUsers(sql);
            dgvMember.DataSource = user.UsersDT;
            //this.LoadMemberList();
        }

        /// <summary>新增用户</summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMember objfrmMember = new frmMember();
            if (objfrmMember.ShowDialog() == DialogResult.OK)
            {
                this.LoadMemberList();
            }
        }

        #region 编辑用户信息...

        /// <summary>编辑用户</summary>
        private void btnModify_Click(object sender, EventArgs e)
        {
            this.ShowMember();
        }

        /// <summary>双击编辑用户信息</summary>
        private void dgvMember_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.ShowMember();
            }
        }

        private void ShowMember()
        {
            if (this.dgvMember.CurrentRow != null)
            {
                string strMemberId = this.dgvMember.CurrentRow.Cells["UID"].Value.ToString();
                frmMember objfrmMember = new frmMember(strMemberId);
                if (objfrmMember.ShowDialog() == DialogResult.OK)
                {
                    this.LoadMemberList();
                }
            }
        }

        #endregion


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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("是否删除该用户", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (this.dgvMember.CurrentRow != null)
            {
                string CurrentUID = dgvMember.CurrentRow.Cells["UID"].Value.ToString();
                try
                {
                    user.DeleteUser(CurrentUID);
                    MessageBox.Show("已删除该用户", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMemberList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("删除失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            frmMember_Import objfrmMember_Import = new frmMember_Import();
            if (objfrmMember_Import.ShowDialog() == DialogResult.OK)
            {
                this.LoadMemberList();
            }
        }


    }
}
