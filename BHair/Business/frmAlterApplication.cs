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
    public partial class frmAlterApplication : WinFormsUI.Docking.DockContent
    {
        DataTable AddApplicationDT;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        string CtrlID = "";
        /// <summary>申请转货单</summary>
        public frmAlterApplication(ApplicationInfo ai)
        {
            InitializeComponent();
            applicationInfo = ai;
            GetDataTable();
            LoadComBox();
            LoadAppData();

            if(Login.LoginUser.Character==1)
            {
                txtApplicant.ReadOnly = false;
                txtApplicantPos.ReadOnly = false;
            }
        }

        void GetDataTable()
        {
            AddApplicationDT = applicationDetail.SelectAppDetailByCtrlID(applicationInfo.CtrlID);
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
                        if (AddApplicationDT.Rows.Count < 20)
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
                        else
                        {
                            MessageBox.Show("添加失败,每张转货单,只允许20条记录!");
                        }
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
                MessageBox.Show("申请表中未添加转货内容");
            }
            else if (txtCtrlID.Text == null || txtCtrlID.Text.Length == 0)
            {
                MessageBox.Show("请填写控制单号");
            }
            else
            {
                frmEditReason fer = new frmEditReason(applicationInfo.EditReason);
                if (fer.ShowDialog() == DialogResult.OK)
                {
                    int TotalCount = 0;
                    double TotalPrice = 0;
                    DataTable AddAppInfoDT = applicationInfo.SelectApplicationByCtrlID(applicationInfo.CtrlID);
                    AddAppInfoDT.Rows[0]["EditReason"] = fer.EditReasonString;
                    AddAppInfoDT.Rows[0]["CtrlID"] = txtCtrlID.Text;
                    AddAppInfoDT.Rows[0]["DeliverStore"] = cbDeliverStore.SelectedItem.ToString();
                    AddAppInfoDT.Rows[0]["ReceiptStore"] = cbRecieveStore.SelectedItem.ToString();
                    AddAppInfoDT.Rows[0]["ApplicantsDate"] = dtAppDate.Value;
                    AddAppInfoDT.Rows[0]["ApplicantsName"] = txtApplicant.Text;
                    AddAppInfoDT.Rows[0]["ApplicantsPos"] = txtApplicantPos.Text;
                    AddAppInfoDT.Rows[0]["Applicants"] = Login.LoginUser.UID;
                    AddAppInfoDT.Rows[0]["ExchangeType"] = cboExchangeType.SelectedItem.ToString();

                    foreach (DataGridViewRow addDr in dgvApplyProducts.Rows)
                    {
                        //addDr["CtrlID"] = AddAppInfoDT.Rows[0]["CtrlID"];
                        TotalCount += (int)addDr.Cells["numbers"].Value;
                        TotalPrice += ((int)addDr.Cells["numbers"].Value) * ((double.Parse(addDr.Cells["price"].Value.ToString())));
                    }
                    AddAppInfoDT.Rows[0]["TotalCount"] = TotalCount;
                    AddAppInfoDT.Rows[0]["TotalPrice"] = TotalPrice;

                    //foreach(DataRow dr in AddApplicationDT.Rows)
                    //{
                    //    dr["CtrlID"] = txtCtrlID.Text;
                    //}

                    if (Login.LoginUser.Character == 1)
                    {
                        if ((int)AddAppInfoDT.Rows[0]["ApprovalState"] != 1) AddAppInfoDT.Rows[0]["ApprovalState"] = 0;
                        if ((int)AddAppInfoDT.Rows[0]["ApprovalState2"] != 1) AddAppInfoDT.Rows[0]["ApprovalState2"] = 0;
                        if ((int)AddAppInfoDT.Rows[0]["DeliverState"] != 1) AddAppInfoDT.Rows[0]["DeliverState"] = 0;
                        if ((int)AddAppInfoDT.Rows[0]["ReceiptState"] != 1) AddAppInfoDT.Rows[0]["ReceiptState"] = 0;
                    }
                    if (TotalPrice > EmailControl.config.UpperLimit)
                    {
                        DialogResult dres = MessageBox.Show("超出限额，是否继续提交？", "消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dres == DialogResult.OK)
                        {
                            try
                            {
                                applicationInfo.UpdateApplicationInfo(AddAppInfoDT);
                                applicationDetail.UpdateApplicationDetail(AddApplicationDT);
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
                    else
                    {
                        try
                        {
                            applicationInfo.UpdateApplicationInfo(AddAppInfoDT);
                            applicationDetail.UpdateApplicationDetail(AddApplicationDT);
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
            cboExchangeType.Items.Add("N/A");
            cboExchangeType.Items.Add("新店预留");
            cboExchangeType.Items.Add("Pull Back");
            cboExchangeType.SelectedIndex = 0;
        }

        void LoadAppData()
        {
            txtApplicant.Text = applicationInfo.ApplicantsName;
            txtApplicantPos.Text = applicationInfo.ApplicantsPos;
            txtCtrlID.Text = applicationInfo.CtrlID;
            cbDeliverStore.SelectedItem = applicationInfo.DeliverStore;
            cbRecieveStore.SelectedItem = applicationInfo.ReceiptStore;
            cboExchangeType.SelectedItem = applicationInfo.ExchangeType;   
            dtAppDate.Value = DateTime.Parse(applicationInfo.ApplicantsDate);
            tbEditReason.Text = applicationInfo.EditReason;
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

        private void frmAlterApplication_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
