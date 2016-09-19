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
    public partial class frmHistoryDetail : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationDetailTable;
        public DataRow ApplicationDetailRow;
        public DataTable DeliverDetailTable;
        public DataTable ReceiptDetailTable;
         ApplicationInfo applicationInfo = new ApplicationInfo();
         ApplicationDetail applicationDetail = new ApplicationDetail();
        public string CtrlID = "";
        /// <summary>历史转货单详情</summary>
        public frmHistoryDetail(ApplicationInfo ParentAppInfo)
        {
            InitializeComponent();
            applicationInfo = ParentAppInfo;
            this.Text = string.Format("历史转货记录详细信息:控制号：{0}", applicationInfo.CtrlID);
            InitComboBox();
            GetApplicationDetail();
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
            txtS_O.Text = applicationInfo.S_O;
            txtO_O.Text = applicationInfo.O_O;
            txtBatch_Num1.SelectedText = applicationInfo.Batch_Num1;
            txtBatch_Num2.SelectedText = applicationInfo.Batch_Num2;
            txtDeliverDate.Text = applicationInfo.DeliverDate;
            txtReceiptDate.Text = applicationInfo.ReceiptDate;
            txtS_O_Str.Text = applicationInfo.S_O_Str;
            txtO_O_Str.Text = applicationInfo.O_O_Str;
        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            if (Login.LoginUser.IsAdmin == 1)
            {
                frmAlterApplication faa = new frmAlterApplication(applicationInfo);
                if (faa.ShowDialog() == DialogResult.OK)
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

        private void dgvApplyDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
        }

        private void frmHistoryDetail_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
