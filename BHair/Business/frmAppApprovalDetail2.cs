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
    public partial class frmAppApprovalDetail2 : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationDetailTable;
        public DataRow ApplicationDetailRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
         ApplicationDetail applicationDetail = new ApplicationDetail();
        public string CtrlID = "";
        string ctrlType = "未审核";
        /// <summary>财务部审批转货单详情</summary>
        public frmAppApprovalDetail2(ApplicationInfo ParentAppInfo, string CtrlType)
        {
            InitializeComponent();
            applicationInfo = ParentAppInfo;
            this.Text = string.Format("订单详细信息:控制号：{0}", applicationInfo.CtrlID);
            GetApplicationDetail();
            InitButton(CtrlType);
            //txtApproval.Text = Login.LoginUser.UserName;
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

            txtApplyUser.Text=applicationInfo.ApplicantsName;
            txtPosition.Text=applicationInfo.ApplicantsPos;
            txtDate.Text = applicationInfo.ApplicantsDate;
            txtSendShopName.Text = applicationInfo.DeliverStore;
            txtAcceptShopName.Text = applicationInfo.ReceiptStore;
            txtApproval.Text = applicationInfo.ApprovalName;
            txtApprovalTime.Text = applicationInfo.ApprovalDate;
            txtApproval2.Text = applicationInfo.ApprovalName2;
            dtApprovalTime2.Value = DateTime.Now;
            txtBeforeChecked.Text = applicationInfo.DeliverCheck;
            txtBeforeUser.Text = applicationInfo.DeliverCheckerName;
            txtAfterChecked.Text = applicationInfo.ReceiptCheck;
            txtAfterUser.Text = applicationInfo.ReceiptCheckerName;
            txtDeliverDate.Text = applicationInfo.DeliverDate;
            txtReceiptDate.Text = applicationInfo.DeliverDate;
        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void InitButton(string CtrlType)
        {
            switch(CtrlType)
            {
                case "未审核": ApprovalPanel.Visible = true; break;
                case "历史审核": break;
                default: break;
            }
        }

        private void BtnApprovalOK_Click(object sender, EventArgs e)
        {
            try
            {
                applicationInfo.ApprovalApplication2(applicationInfo.CtrlID, Login.LoginUser, 1, dtApprovalTime2.Value);
                //EmailControl.ToDeliverConfirm(applicationInfo);
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
            EmailControl.ToDeliverConfirm(applicationInfo);
        }

        private void BtnApprovalNot_Click(object sender, EventArgs e)
        {
            applicationInfo.ApprovalApplication2(applicationInfo.CtrlID, Login.LoginUser, 2, dtApprovalTime2.Value);
            MessageBox.Show("审核完毕", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
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
          
        }

        private void dgvApplyDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
        }

        private void frmAppApprovalDetail2_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
