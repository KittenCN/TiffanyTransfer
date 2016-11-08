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
    public partial class frmAlterStoreApplication : WinFormsUI.Docking.DockContent
    {
        DataTable AddApplicationDT;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        string CtrlID = "";
        string DeliverOrReceipt = "Deliver";
        /// <summary>申请转货单</summary>
        public frmAlterStoreApplication(ApplicationInfo ai,string DorR)
        {
            InitializeComponent();
            DeliverOrReceipt = DorR;
            applicationInfo = ai;
            GetDataTable();
            LoadComBox();
            LoadAppData();
            
            if (DeliverOrReceipt == "Deliver") { this.Name = "发货单修改"; label48.Text = "发货之前的检查，是否有损坏没有写无，有则写明货号"; }
            else { this.Text = "收货单修改"; label3.Text = "收货日期"; label48.Text = "收货之前的检查，是否有损坏.没有写无，有则写明货号"; }

            if(Login.LoginUser.Character==1)
            {
                txtApplicant.ReadOnly = false;
                txtApplicantPos.ReadOnly = false;
                if (DeliverOrReceipt == "Deliver") txtWuliuID.ReadOnly = false;
                dtAppDate.Enabled = true;
            }
            
        }

        void GetDataTable()
        {
            if (DeliverOrReceipt == "Deliver") AddApplicationDT = applicationDetail.SelectDeliverDetailByCtrlID(applicationInfo.CtrlID);
            else AddApplicationDT = applicationDetail.SelectReceiptDetailByCtrlID(applicationInfo.CtrlID);
            dgvApplyProducts.AutoGenerateColumns = false; 
            dgvApplyProducts.DataSource = AddApplicationDT;
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
                    bool Repeated = false;
                    foreach (DataRow dr in AddApplicationDT.Rows)
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
                        dr["Department"] = txtDepartment4.Text;
                        dr["App_Level"] = txtLevel4.Text;
                        dr["ItemID"] = ItemDT.Rows[0]["ItemID"];
                        dr["ItemID2"] = ItemDT.Rows[0]["ItemID2"];
                        dr["Detail"] = ItemDT.Rows[0]["Detail"];
                        dr["Price"] = ItemDT.Rows[0]["Price"];
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
            if (AddApplicationDT.Rows.Count == 0)
            {
                MessageBox.Show("表中未添加转货内容");
            }
            else if (txtCtrlID.Text == null || txtCtrlID.Text.Length == 0)
            {
                MessageBox.Show("请填写控制单号");
            }
            else
            {
                int TotalCount = 0;
                double TotalPrice = 0;
                DataTable AddAppInfoDT = applicationInfo.SelectApplicationByCtrlID(applicationInfo.CtrlID);

                AddAppInfoDT.Rows[0]["WuliuID"] = txtWuliuID.Text;
                if (DeliverOrReceipt == "Deliver") { AddAppInfoDT.Rows[0]["DeliverDate"] = dtAppDate.Value; AddAppInfoDT.Rows[0]["DeliverCheck"] = txtStoreCheck.Text; }
                else  { AddAppInfoDT.Rows[0]["ReceiptDate"] = dtAppDate.Value; AddAppInfoDT.Rows[0]["ReceiptCheck"] = txtStoreCheck.Text; }

                //foreach(DataRow dr in AddApplicationDT.Rows)
                //{
                //    dr["CtrlID"] = txtCtrlID.Text;
                //}



                try
                {
                    if (DeliverOrReceipt == "Deliver")
                    {
                        applicationDetail.UpdateDeliverDetail(AddApplicationDT);
                        applicationInfo.UpdateApplicationInfo(AddAppInfoDT);
                    }
                    else
                    {
                        applicationDetail.UpdateReceiptDetail(AddApplicationDT);
                        applicationInfo.UpdateApplicationInfo(AddAppInfoDT);
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

        void LoadAppData()
        {
            txtApplicant.Text = applicationInfo.ApplicantsName;
            txtApplicantPos.Text = applicationInfo.ApplicantsPos;
            txtCtrlID.Text = applicationInfo.CtrlID;
            cbDeliverStore.SelectedItem = applicationInfo.DeliverStore;
            cbRecieveStore.SelectedItem = applicationInfo.ReceiptStore;
            
            txtWuliuID.Text = applicationInfo.WuliuID;
            if (DeliverOrReceipt == "Deliver")
            {
                if(applicationInfo.DeliverDate!=null && applicationInfo.DeliverDate != "")
                {
                    dtAppDate.Value = DateTime.Parse(applicationInfo.DeliverDate);
                }               
                txtStoreCheck.Text = applicationInfo.DeliverCheck;
            }
            else
            {
                if(applicationInfo.ReceiptDate!=null && applicationInfo.ReceiptDate!="")
                {
                    dtAppDate.Value = DateTime.Parse(applicationInfo.ReceiptDate);
                }               
                txtStoreCheck.Text = applicationInfo.ReceiptCheck;
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

        private void dgvApplyProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
        }

        private void frmAlterStoreApplication_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
