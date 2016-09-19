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
    public partial class frmStoreAppDetail : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationDetailTable;
        public DataTable DeliverDetailTable;
        public DataTable ReceiptDetailTable;
        public DataRow ApplicationDetailRow;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        public string CtrlID = "";
        string ctrlType = "正在审核"; 
        /// <summary>店面转货单详情</summary>
        public frmStoreAppDetail(ApplicationInfo ParentAppInfo, string CtrlType)
        {
            InitializeComponent();
            btnExcel.Visible = true;
            btnOutDetail.Visible = true;
            btnDeliver.Visible = false;
            btnReceipt.Visible = false;
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
            applicationInfo = ParentAppInfo;
            this.Text = string.Format("店面订单详细信息:控制号：{0}", applicationInfo.CtrlID);
            GetApplicationDetail();
            InitButton(CtrlType);
            ctrlType = CtrlType;
            if (ctrlType == "待发货") { BtnConfirm.Text = "待发货"; tabControl1.TabPages.Remove(tabPage3); }
            else if (ctrlType == "待收货") BtnConfirm.Text = "待收货";
            else if (ctrlType == "正在审核") { tabControl1.TabPages.Remove(tabPage3); tabControl1.TabPages.Remove(tabPage2); }
            else if (ctrlType == "历史申请单") { BtnConfirm.Visible = false; }
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

            txtApplyUser.Text = applicationInfo.ApplicantsName;
            txtPosition.Text = applicationInfo.ApplicantsPos;
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
        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void InitButton(string CtrlType)
        {
            switch (CtrlType)
            {
                case "正在审核": break;
                case "待发货": ConfirmPanel.Visible = true; txtBeforeChecked.ReadOnly = false; BtnConfirm.Visible = true; txtBeforeUser.Text = Login.LoginUser.UserName; break;
                case "待收货": ConfirmPanel.Visible = true; txtAfterChecked.ReadOnly = false; BtnConfirm.Visible = true; txtAfterUser.Text = Login.LoginUser.UserName; break;
                default: break;
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            frmAddStoreApplication fasa = new frmAddStoreApplication(applicationInfo, ctrlType);
            if (fasa.ShowDialog() == DialogResult.OK)
            {
                this.GetApplicationDetail();
                BtnConfirm.Visible = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            //try
            //{
            //    switch(ctrlType)
            //    {
            //        case "正在审核": break;
            //        case "待发货": applicationInfo.DeliverConfirm(applicationInfo.CtrlID,txtBeforeChecked.Text,Login.LoginUser,1); break;
            //        case "待收货": applicationInfo.ReceiptConfirm(applicationInfo.CtrlID, txtAfterChecked.Text, Login.LoginUser,1); break;
            //        default: break;
            //    }

            //    MessageBox.Show("确认成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("确认失败，错误信息：" + ex.Message);
            //}
        }

        private void BtnConfirmPart_Click(object sender, EventArgs e)
        {
            try
            {
                switch (ctrlType)
                {
                    case "正在审核": break;
                    case "待发货": break;
                    case "待收货": applicationInfo.ReceiptConfirm(applicationInfo.CtrlID, txtAfterChecked.Text, Login.LoginUser, 2); break;
                    default: break;
                }

                MessageBox.Show("确认成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("确认失败，错误信息：" + ex.Message);
            }
        }

        private void BtnConfirmNot_Click(object sender, EventArgs e)
        {
            try
            {
                switch (ctrlType)
                {
                    case "正在审核": break;
                    case "待发货": applicationInfo.DeliverConfirm(applicationInfo.CtrlID, txtBeforeChecked.Text, Login.LoginUser, 2); break;
                    case "待收货": applicationInfo.ReceiptConfirm(applicationInfo.CtrlID, txtAfterChecked.Text, Login.LoginUser, 3); break;
                    default: break;
                }

                MessageBox.Show("确认成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("确认失败，错误信息：" + ex.Message);
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

        private void dgvDevilerDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
        }

        private void dgvReceiptDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            //点了保存按钮进入
            if (result == DialogResult.OK)
            {
                //获得文件路径
                string localFilePath = saveFileDialog.FileName.ToString();
                PrintExcel pe = new PrintExcel();
                try
                {
                    DataTable appDT = applicationInfo.SelectApplicationByCtrlID(applicationInfo.CtrlID);
                    pe.OutPutXLS(appDT, ApplicationDetailTable, localFilePath);
                    MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvApplyDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
        }

        private void btnDeliver_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            //点了保存按钮进入
            if (result == DialogResult.OK)
            {
                //获得文件路径
                string localFilePath = saveFileDialog.FileName.ToString();
                PrintExcel pe = new PrintExcel();
                try
                {
                    DataTable appDT = applicationInfo.SelectApplicationByCtrlID(applicationInfo.CtrlID);
                    pe.OutPutXLS(appDT, DeliverDetailTable, localFilePath);
                    MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            //点了保存按钮进入
            if (result == DialogResult.OK)
            {
                //获得文件路径
                string localFilePath = saveFileDialog.FileName.ToString();
                PrintExcel pe = new PrintExcel();
                try
                {
                    DataTable appDT = applicationInfo.SelectApplicationByCtrlID(applicationInfo.CtrlID);
                    pe.OutPutXLS(appDT, ReceiptDetailTable, localFilePath);
                    MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmStoreAppDetail_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    btnExcel.Visible = true;
                    btnOutDetail.Visible = true;
                    btnDeliver.Visible = false;
                    btnReceipt.Visible = false;
                    break;
                case 1:
                    btnExcel.Visible = false;
                    btnOutDetail.Visible = false;
                    btnDeliver.Visible = true;
                    btnReceipt.Visible = false;
                    break;
                case 2:
                    btnExcel.Visible = false;
                    btnOutDetail.Visible = false;
                    btnDeliver.Visible = false;
                    btnReceipt.Visible = true;
                    break;
            }
        }

        private void btnOutDetail_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            //点了保存按钮进入
            if (result == DialogResult.OK)
            {
                //获得文件路径
                string localFilePath = saveFileDialog.FileName.ToString();
                PrintExcel pe = new PrintExcel();
                try
                {
                    DataTable appDT = applicationInfo.SelectApplicationByCtrlID(applicationInfo.CtrlID);
                    pe.WriteToExcelReport(pe.exporeDataToTable(dgvApplyDetails), localFilePath, "Sheet1");
                    MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
