using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.Table;
using System.Text.RegularExpressions;
using System.Threading; 

namespace BHair.Business
{
    public partial class frmAppApprovalDetail : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationDetailTable;
        public DataTable DeliverDetailTable;
        public DataTable ReceiptDetailTable;
        public DataRow ApplicationDetailRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
         ApplicationDetail applicationDetail = new ApplicationDetail();
        public string CtrlID = "";
        string ctrlType = "未审核";
        DataTable applicationInfoDT = new DataTable();
        /// <summary>商品部审批转货单详情</summary>
        public frmAppApprovalDetail(ApplicationInfo ParentAppInfo, string CtrlType)
        {
            InitializeComponent();
            applicationInfo = ParentAppInfo;
            this.Text = string.Format("订单详细信息:控制号：{0}", applicationInfo.CtrlID);
            InitComboBox();
            GetApplicationDetail();
            InitButton(CtrlType);
            //txtApproval.Text = Login.LoginUser.UserName;
            if(Login.LoginUser.Character==4)
            {
                BtnApprovalOK.Visible = false;
                btnDiffApp.Visible = false;
                btnDiffItem.Visible = false;
                btnEdit.Visible = false;
                btnFinalConfirm.Visible = false;
            }
        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetApplicationDetail();
        }

        public void GetApplicationDetail()
        {
            dgvApplyDetails.AutoGenerateColumns = false;
            dgvDevilerDetails.AutoGenerateColumns = false;
            dgvReceiptDetails.AutoGenerateColumns = false; 
            ApplicationDetailTable = applicationDetail.SelectAppDetailByCtrlID(applicationInfo.CtrlID);
            dgvApplyDetails.DataSource = ApplicationDetailTable;
            DeliverDetailTable = applicationDetail.SelectDeliverDetailByCtrlID(applicationInfo.CtrlID);
            dgvDevilerDetails.DataSource = DeliverDetailTable;
            ReceiptDetailTable = applicationDetail.SelectReceiptDetailByCtrlID(applicationInfo.CtrlID);
            dgvReceiptDetails.DataSource = ReceiptDetailTable;
            


            txtApplyUser.Text=applicationInfo.ApplicantsName;
            txtPosition.Text=applicationInfo.ApplicantsPos;
            txtDate.Text = applicationInfo.ApplicantsDate;
            txtSendShopName.Text = applicationInfo.DeliverStore;
            txtAcceptShopName.Text = applicationInfo.ReceiptStore;
            txtApproval.Text = applicationInfo.ApprovalName;
            dtApprovalTime.Value = DateTime.Now;
            txtApproval2.Text = applicationInfo.ApprovalName2;
            txtApprovalTime2.Text = applicationInfo.ApprovalDate2;
            txtBeforeChecked.Text = applicationInfo.DeliverCheck;
            txtBeforeUser.Text = applicationInfo.DeliverCheckerName;
            txtAfterChecked.Text = applicationInfo.ReceiptCheck;
            txtAfterUser.Text = applicationInfo.ReceiptCheckerName;
            txtS_O.SelectedItem = applicationInfo.S_O;
            txtO_O.SelectedItem = applicationInfo.O_O;
            txtBatch_Num1.SelectedText = applicationInfo.Batch_Num1;
            txtBatch_Num2.SelectedText = applicationInfo.Batch_Num2;
            txtDeliverDate.Text = applicationInfo.DeliverDate;
            txtReceiptDate.Text = applicationInfo.ReceiptDate;
            txtS_O_Str.Text = applicationInfo.S_O_Str;
            txtO_O_Str.Text = applicationInfo.O_O_Str;
            txtWuliuDate.Text = applicationInfo.WuliuDate;
        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void InitButton(string CtrlType)
        {
            switch(CtrlType)
            {
                case "未审核": ApprovalPanel.Visible = true; panel2.Visible = false; break;
                case "最终确认": ConfirmPanel.Visible = true; panel2.Visible = true; panel5.Visible = true; break;
                case "全部":  panel5.Visible = true; break;
                default: break;
            }
        }

        private void BtnApprovalOK_Click(object sender, EventArgs e)
        {
            try
            {
                applicationInfo.ApprovalApplication(applicationInfo.CtrlID, Login.LoginUser, 1, dtApprovalTime.Value);
                Thread thread = new Thread(new ThreadStart(SendEmail));
                thread.Start();
                MessageBox.Show("审核完毕", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("审核失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void SendEmail()
        {
            EmailControl.ToApplicantSubmit2(applicationInfo);
        }

        private void BtnApprovalNot_Click(object sender, EventArgs e)
        {
            applicationInfo.ApprovalApplication(applicationInfo.CtrlID, Login.LoginUser, 2, dtApprovalTime.Value);
            MessageBox.Show("审核完毕", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        private void btnFinalConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                applicationInfo.FinalConfirm(applicationInfo.CtrlID);
                MessageBox.Show("确认完毕", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("确认失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex==0)
            {
                frmAlterApplication faa = new frmAlterApplication(applicationInfo);
                if (faa.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
            else if(tabControl1.SelectedIndex==1)
            {
                frmAlterStoreApplication fasa = new frmAlterStoreApplication(applicationInfo,"Deliver");
                if (fasa.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
            else if(tabControl1.SelectedIndex==2)
            {
                frmAlterStoreApplication fasa = new frmAlterStoreApplication(applicationInfo, "Receipt");
                if (fasa.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
        }

        private void dgvApplyDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                frmAlterApplication faa = new frmAlterApplication(applicationInfo);
                if (faa.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                frmAlterStoreApplication fasa = new frmAlterStoreApplication(applicationInfo, "Deliver");
                if (fasa.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                frmAlterStoreApplication fasa = new frmAlterStoreApplication(applicationInfo, "Receipt");
                if (fasa.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
        }

        void HighlightItemID()
        {
            foreach (DataGridViewRow dgvr in dgvApplyDetails.Rows)
            {
                if (dgvr.Cells["ItemHighlight"].Value.ToString() == "1")
                {
                    dgvr.Cells["ItemID"].Style.ForeColor = Color.Red;
                }
                if (dgvr.Cells["ItemHighlight"].Value.ToString() == "2")
                {
                    dgvr.Cells["ItemID2"].Style.ForeColor = Color.Red;
                }
            }
            foreach (DataGridViewRow dgvr in dgvDevilerDetails.Rows)
            {
                if (dgvr.Cells["ItemHighlightf"].Value.ToString() == "1")
                {
                    dgvr.Cells["ItemIDf"].Style.ForeColor = Color.Red;
                }
                if (dgvr.Cells["ItemHighlightf"].Value.ToString() == "2")
                {
                    dgvr.Cells["ItemIDf2"].Style.ForeColor = Color.Red;
                }
            }
            foreach (DataGridViewRow dgvr in dgvReceiptDetails.Rows)
            {
                if (dgvr.Cells["ItemHighlights"].Value.ToString() == "1")
                {
                    dgvr.Cells["ItemIDs"].Style.ForeColor = Color.Red;
                }
                if (dgvr.Cells["ItemHighlights"].Value.ToString() == "2")
                {
                    dgvr.Cells["ItemIDs2"].Style.ForeColor = Color.Red;
                }
            }
        }

        void InitComboBox()
        {
            txtS_O.Items.Add("s6");
            txtS_O.Items.Add("s7");
            txtS_O.Items.Add("sf");
            txtS_O.SelectedIndex = 0;

            txtO_O.Items.Add("o6");
            txtO_O.Items.Add("o7");
            txtO_O.Items.Add("of");
            txtO_O.SelectedIndex = 0;
        }

        private void dgvDevilerDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
        }

        private void dgvReceiptDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
        }

        private void btnDiffItem_Click(object sender, EventArgs e)
        {
            frmSelectItems fsi = new frmSelectItems(applicationInfo.CtrlID);
            fsi.Show();
        }

        private void dgvApplyDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
        }

        private void btnDiffApp_Click(object sender, EventArgs e)
        {
            frmSelectItems_App fsi = new frmSelectItems_App(applicationInfo.CtrlID);
            fsi.Show();
        }

        private void frmAppApprovalDetail_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void btnEditWuliu_Click(object sender, EventArgs e)
        {
            if(btnEditWuliu.Text=="修改物流信息")
            {
                btnEditWuliu.Text = "保存修改";
                txtS_O.Enabled = true;
                txtS_O_Str.Enabled = true;
                txtO_O.Enabled = true;
                txtO_O_Str.Enabled = true;
                txtBatch_Num1.Enabled = true;
                txtBatch_Num2.Enabled = true;
            }
            else
            {
                btnEditWuliu.Text = "修改物流信息";
                txtS_O.Enabled = false;
                txtS_O_Str.Enabled = false;
                txtO_O.Enabled = false;
                txtO_O_Str.Enabled = false;
                txtBatch_Num1.Enabled = false;
                txtBatch_Num2.Enabled = false;

                if (applicationInfo.CtrlID != null && txtS_O_Str.Text != "" && txtO_O_Str.Text != "" && txtBatch_Num1.Text != "" && txtBatch_Num2.Text != "")
                {
                    try
                    {
                        ApplicationInfo applicationInfo = new ApplicationInfo();
                        GetData();
                        applicationInfo.UpdateApplicationInfo(applicationInfoDT);
                        GetApplicationDetail();
                        this.Close(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("确认失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("有必填项目为空!确认失败!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        void GetData()
        {
            applicationInfoDT = applicationInfo.SelectApplicationByCtrlID(applicationInfo.CtrlID);
            applicationInfoDT.Rows[0]["S_O"] = txtS_O.SelectedItem.ToString();
            applicationInfoDT.Rows[0]["O_O"] = txtO_O.SelectedItem.ToString();
            applicationInfoDT.Rows[0]["Batch_Num1"] = txtBatch_Num1.Text;
            applicationInfoDT.Rows[0]["Batch_Num2"] = txtBatch_Num2.Text;

            applicationInfoDT.Rows[0]["S_O_Str"] = txtS_O_Str.Text;
            applicationInfoDT.Rows[0]["O_O_Str"] = txtO_O_Str.Text;
            //applicationInfoDT.Rows[0]["WuliuDate"] = txtWuliuDate.Value;
        }
    }
}
