using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.Table;
using System.Text.RegularExpressions;

namespace BHair.Business
{
    public partial class frmAddStoreApplication : WinFormsUI.Docking.DockContent
    {
        DataTable AddApplicationDT;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        string DeliverOrReceipt = "发货确认";
        /// <summary>申请转货单</summary>
        public frmAddStoreApplication(ApplicationInfo ai,string DorR)
        {
            InitializeComponent();
            GetDataTable();
            txtApplicant.Text = Login.LoginUser.UserName;
            txtApplicantPos.Text = Login.LoginUser.Position;
            dtAppDate.Value = DateTime.Now;
            applicationInfo = ai;
            txtCtrlID.Text = ai.CtrlID;
            LoadComBox();

            DeliverOrReceipt = DorR;
            if (DeliverOrReceipt == "发货确认") { this.Name = "发货单输入"; txtWuliuID.Visible = true; label5.Visible = true; label3.Text = "发货日期"; label48.Text = "发货之前的检查，是否有损坏没有写无，有则写明货号"; }
            else if (DeliverOrReceipt=="收货确认") { this.Name = "收货单输入"; label3.Text = "收货日期"; label48.Text = "收货之前的检查，是否有损坏.没有写无，有则写明货号"; }
        }

        void GetDataTable()
        {
            AddApplicationDT = applicationDetail.SelectAppDetailByCtrlID("0");
            dgvApplyProducts.AutoGenerateColumns = false; 
            dgvApplyProducts.DataSource = AddApplicationDT;

            HighlightItemID();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (!Regex.IsMatch(txtCount4.Text, "^[0-9]*$") || txtCount4.Text == "")
            //{
            //    MessageBox.Show("请输入数字");
            //}
            //else
            if (txtItemID.Text == "")
            {
                MessageBox.Show("请填写货号");
            }
            else
            {
                BaseData.Items items = new BaseData.Items();
                DataTable ItemDT = items.SelectItemByItemID(txtItemID.Text);
                if (ItemDT.Rows.Count > 0)
                {
                    bool Repeated =false;
                    foreach(DataRow dr in AddApplicationDT.Rows)
                    {
                        if (dr.RowState == DataRowState.Deleted) dr.Delete();
                        else
                        {
                            if (dr["ItemID"].ToString() == txtItemID.Text && dr["ItemHighlight"].ToString() == "1")
                            {
                                dr["App_Count"] = (int)dr["App_Count"] + (int)numCount.Value;
                                Repeated = true;
                            }
                            if (dr["ItemID2"].ToString() == txtItemID.Text && dr["ItemHighlight"].ToString() == "2")
                            {
                                dr["App_Count"] = (int)dr["App_Count"] + (int)numCount.Value;
                                Repeated = true;
                            }
                        }
                    }

                    if (!Repeated)
                    {
                        DataRow dr = AddApplicationDT.NewRow();
                        dr["CtrlID"] = txtCtrlID.Text;
                        //dr["Department"] = txtDepartment4.Text;
                        //dr["App_Level"] = txtLevel4.Text;
                        dr["ItemID"] = ItemDT.Rows[0]["ItemID"];
                        dr["ItemID2"] = ItemDT.Rows[0]["ItemID2"];
                        dr["Detail"] = ItemDT.Rows[0]["Detail"];
                        dr["Price"] = ItemDT.Rows[0]["Price"];
                        dr["Department"] = ItemDT.Rows[0]["Department"];
                        dr["App_Level"] = ItemDT.Rows[0]["Class"];
                        dr["App_Count"] = int.Parse(this.numCount.Value.ToString());
                        dr["IsDelete"] = 0;
                        if (dr["ItemID"].ToString() == txtItemID.Text) dr["ItemHighlight"] = 1;
                        else if (dr["ItemID2"].ToString() == txtItemID.Text) dr["ItemHighlight"] = 2;
                        AddApplicationDT.Rows.Add(dr);
                        HighlightItemID();
                    }
                    txtItemID.Text = "";
                    txtItemID.Focus();
                }
                else
                {
                    MessageBox.Show("货号错误");
                    txtItemID.Text = "";
                    txtItemID.Focus();
                }
            }
        }

        private void BtnSubmitAddApp_Click(object sender, EventArgs e)
        {
            BaseData.Store store = new BaseData.Store();
            //if (store.SelectStoreInfoByStoreName(txtDeliverStore4.Text).Rows.Count == 0 || store.SelectStoreInfoByStoreName(txtReceiptStore4.Text).Rows.Count == 0)
            //{
            //    MessageBox.Show("收发店铺名错误");
            //}
            if (txtWuliuID.Text.Length < 1 && DeliverOrReceipt == "发货确认")
            {
                MessageBox.Show("请填写物流单号");
            }
            else if (AddApplicationDT.Rows.Count == 0)
            {
                MessageBox.Show("申请表中未添加转货内容");
            }
            else if(txtCtrlID.Text==null||txtCtrlID.Text.Length==0)
            {
                MessageBox.Show("请填写控制单号");
            }
            else
            {
                DataTable AddAppInfoDT = applicationInfo.SelectApplicationByCtrlID(applicationInfo.CtrlID);
                if(AddAppInfoDT.Rows.Count>0)
                {
                    AddAppInfoDT.Rows[0]["WuliuID"] = txtWuliuID.Text;
                    if (DeliverOrReceipt == "发货确认") { AddAppInfoDT.Rows[0]["DeliverDate"] = dtAppDate.Value; AddAppInfoDT.Rows[0]["DeliverCheck"] = txtStoreCheck.Text; }
                    else if (DeliverOrReceipt == "收货确认") { AddAppInfoDT.Rows[0]["ReceiptDate"] = dtAppDate.Value; AddAppInfoDT.Rows[0]["ReceiptCheck"] = txtStoreCheck.Text; }
                }
                try
                {
                    if (DeliverOrReceipt == "发货确认")
                    {
                        applicationDetail.UpdateDeliverDetail(AddApplicationDT);
                        applicationInfo.UpdateApplicationInfo(AddAppInfoDT);
                        applicationInfo.DeliverConfirm(applicationInfo.CtrlID, "", Login.LoginUser, 1);
                        EmailControl.ToReceiptConfirm(applicationInfo);
                    }
                    else if (DeliverOrReceipt == "收货确认")
                    {
                        applicationDetail.UpdateReceiptDetail(AddApplicationDT);
                        applicationInfo.UpdateApplicationInfo(AddAppInfoDT);
                        applicationInfo.ReceiptConfirm(applicationInfo.CtrlID, "", Login.LoginUser, 1);
                        EmailControl.ToApplicantWLSubmit(applicationInfo);
                    }
                    MessageBox.Show("提交成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("提交失败，错误信息：" + ex.Message);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvApplyProducts.SelectedRows.Count > 0)
            {
                dgvApplyProducts.Rows.Remove(dgvApplyProducts.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("请选中整行数据", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void LoadComBox()
        {

            BaseData.Store store = new BaseData.Store();
            store.StoreDT = store.SelectAllStoreInfo();
            foreach (DataRow dr in store.StoreDT.Rows)
            {
                cbDeliverStore.Items.Add(dr["StoreName"].ToString());
            }
            if (cbDeliverStore.Items.Count > 0)
            {
                cbDeliverStore.SelectedIndex = 0;
            }
            foreach (DataRow dr in store.StoreDT.Rows)
            {
                cbRecieveStore.Items.Add(dr["StoreName"].ToString());
            }
            if (cbRecieveStore.Items.Count > 0)
            {
                cbRecieveStore.SelectedIndex = 0;
            }


        }

        void HighlightItemID()
        {
            foreach (DataGridViewRow dgvr in dgvApplyProducts.Rows)
            {
                if (dgvr.Cells["ItemHighlight"].Value.ToString() == "1")
                {
                    dgvr.Cells["number"].Style.ForeColor = Color.Red;
                }
                if (dgvr.Cells["ItemHighlight"].Value.ToString() == "2")
                {
                    dgvr.Cells["doubleNumber"].Style.ForeColor = Color.Red;
                }
            }
        }
    }
}
