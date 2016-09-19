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
    public partial class frmAppDoneDetail : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationDetailTable;
        public DataRow ApplicationDetailRow;
        public DataTable DeliverDetailTable;
        public DataTable ReceiptDetailTable;
         ApplicationInfo applicationInfo = new ApplicationInfo();
         ApplicationDetail applicationDetail = new ApplicationDetail();
         DataTable applicationInfoDT = new DataTable();
        public string CtrlID = "";
        string CtrlType = "未确认";
        /// <summary>物流确认单详情</summary>
        public frmAppDoneDetail(ApplicationInfo ParentAppInfo, string ctrlType)
        {
            InitializeComponent();
            applicationInfo = ParentAppInfo;
            this.Text = string.Format("物流确认详细信息:控制号：{0}", applicationInfo.CtrlID);
            CtrlType = ctrlType;
            if(CtrlType!="未确认")
            {
                txtS_O.SelectedText = applicationInfo.S_O;
                txtO_O.SelectedText = applicationInfo.O_O;
                txtBatch_Num1.Text = applicationInfo.Batch_Num1;
                txtBatch_Num2.Text = applicationInfo.Batch_Num2;
                txtS_O.Enabled = false;
                txtO_O.Enabled = false;
                txtBatch_Num1.Enabled=false;
                txtBatch_Num2.Enabled = false;
                btnConfirm.Visible = false;
            }
            InitComboBox();
            GetApplicationDetail();
            txtS_O_Str.Focus();
        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetApplicationDetail();
        }

        public void GetApplicationDetail()
        {
            ApplicationDetailTable = applicationDetail.SelectAppDetailByCtrlID(applicationInfo.CtrlID);
            dgvApplyDetails.AutoGenerateColumns = false; 
            dgvApplyDetails.DataSource = ApplicationDetailTable;
            dgvDevilerDetails.AutoGenerateColumns = false;
            dgvReceiptDetails.AutoGenerateColumns = false;
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
            txtApprovalTime.Text = applicationInfo.ApprovalDate;
            txtApproval2.Text = applicationInfo.ApprovalName2;
            txtApprovalTime2.Text = applicationInfo.ApprovalDate2;
            txtBeforeChecked.Text = applicationInfo.DeliverCheck;
            txtBeforeUser.Text = applicationInfo.DeliverCheckerName;
            txtAfterChecked.Text = applicationInfo.ReceiptCheck;
            txtAfterUser.Text = applicationInfo.ReceiptCheckerName;
            txtDeliverDate.Text = applicationInfo.DeliverDate;
            txtReceiptDate.Text = applicationInfo.DeliverDate;
            txtS_O.SelectedItem = applicationInfo.S_O;
            txtO_O.SelectedItem = applicationInfo.O_O;
            txtS_O_Str.Text = applicationInfo.S_O_Str;
            txtO_O_Str.Text = applicationInfo.O_O_Str;
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

        void SendEmail()
        {
            EmailControl.ToApplicantFinal(applicationInfo);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (applicationInfo.CtrlID != null && txtS_O_Str.Text!="" && txtO_O_Str.Text!="" && txtBatch_Num1.Text!="" && txtBatch_Num2.Text!="")
            {
                try
                {
                    GetData();
                    applicationInfo.UpdateApplicationInfo(applicationInfoDT);
                    applicationInfo.WLConfirm(applicationInfo.CtrlID,Login.LoginUser.UID);
                    GetApplicationDetail();
                    //EmailControl.ToApplicantFinal(applicationInfo);
                    Thread thread = new Thread(new ThreadStart(SendEmail));
                    thread.Start();
                    MessageBox.Show("确认成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(DialogResult == DialogResult.OK)
                    {
                        this.Close();
                    }             
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

        void GetData()
        {
            applicationInfoDT = applicationInfo.SelectApplicationByCtrlID(applicationInfo.CtrlID);
            applicationInfoDT.Rows[0]["S_O"] = txtS_O.SelectedItem.ToString();
            applicationInfoDT.Rows[0]["O_O"] = txtO_O.SelectedItem.ToString();
            applicationInfoDT.Rows[0]["Batch_Num1"] = txtBatch_Num1.Text;
            applicationInfoDT.Rows[0]["Batch_Num2"] = txtBatch_Num2.Text;

            applicationInfoDT.Rows[0]["S_O_Str"] = txtS_O_Str.Text;
            applicationInfoDT.Rows[0]["O_O_Str"] = txtO_O_Str.Text;
            applicationInfoDT.Rows[0]["WuliuDate"] = txtWuliuDate.Value;
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

        private void frmAppDoneDetail_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
