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
    public partial class frmAppApprovalAlter : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationDetailTable;
        public DataRow ApplicationDetailRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
         ApplicationDetail applicationDetail = new ApplicationDetail();
        public string CtrlID = "";
        string ctrlType = "未审核";
        /// <summary>商品部转货单修改</summary>
        public frmAppApprovalAlter(ApplicationInfo ParentAppInfo, string CtrlType)
        {
            InitializeComponent();
            applicationInfo = ParentAppInfo;
            this.Text = string.Format("订单详细信息:控制号：{0}", applicationInfo.CtrlID);
            GetApplicationDetail();
        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetApplicationDetail();
        }

        public void GetApplicationDetail()
        {
            ApplicationDetailTable = applicationDetail.SelectAppDetailByCtrlID(applicationInfo.CtrlID);
            dgvApplyDetails.DataSource = ApplicationDetailTable;

            txtApplyUser.Text=applicationInfo.ApplicantsName;
            txtPosition.Text=applicationInfo.ApplicantsPos;
            txtDate.Text = applicationInfo.ApplicantsDate;
            //txtSendShopName.Text = applicationInfo.DeliverStore;
            //txtAcceptShopName.Text = applicationInfo.ReceiptStore;
            txtApproval.Text = applicationInfo.ApprovalName;
            txtApprovalTime.Text = applicationInfo.ApprovalDate;
            txtApproval2.Text = applicationInfo.ApprovalName2;
            txtApprovalTime2.Text = applicationInfo.ApprovalDate2;
            txtBeforeChecked.Text = applicationInfo.DeliverCheck;
            txtBeforeUser.Text = applicationInfo.DeliverCheckerName;
            txtAfterChecked.Text = applicationInfo.ReceiptCheck;
            txtAfterUser.Text = applicationInfo.ReceiptCheckerName;

        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void btnAlter_Click(object sender, EventArgs e)
        {

        }

        private void frmAppApprovalAlter_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void dgvApplyDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
