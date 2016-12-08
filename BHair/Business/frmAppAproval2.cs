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
    public partial class frmAppAproval2 : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationInfoTable;
        public DataRow ApplicationInfoRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
        public string CtrlID = "";
        string SelectStr = "and 1=1";
        string CtrlType="未审核";
        public int intSelectRowIndex = 0;
        /// <summary>财务部转货单状态</summary>
        public frmAppAproval2()
        {
            InitializeComponent();
            GetApplicationDetail();
            cbCtrlType.Items.Add("未审核");
            cbCtrlType.Items.Add("历史审核");
            cbCtrlType.SelectedIndex = 0;
            //dgvApplyInfo.SortCompare += new DataGridViewSortCompareEventHandler(
            //              this.dgvApplyInfo_SortCompare);
        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetApplicationDetail();
        }

        public void GetApplicationDetail()
        {
            ApplicationInfoTable = new DataTable();
            switch(CtrlType)
            {
                case "未审核": ApplicationInfoTable = applicationInfo.SelectApplicationByApproval2(SelectStr); btn_SortByString.Enabled = false; break;
                case "历史审核": ApplicationInfoTable = applicationInfo.SelectHistoryApplicationByApproval2(SelectStr, Login.LoginUser); btn_SortByString.Enabled = true; break;
                default: ApplicationInfoTable = applicationInfo.SelectApplicationByApproval2(SelectStr); break;
            }

            dgvApplyInfo.AutoGenerateColumns = false; 
            dgvApplyInfo.DataSource = ApplicationInfoTable;

            try
            {
                if (dgvApplyInfo.Rows.Count > 0 && intSelectRowIndex > 0)
                {
                    dgvApplyInfo.Rows[intSelectRowIndex].Selected = true;
                    dgvApplyInfo.CurrentCell = dgvApplyInfo.Rows[intSelectRowIndex].Cells[1];
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {            
            if (applicationInfo.CtrlID!=null && dgvApplyInfo.CurrentRow!=null)
            {
                intSelectRowIndex = dgvApplyInfo.CurrentRow.Index;
                frmAppApprovalDetail2 faad = new frmAppApprovalDetail2(applicationInfo, CtrlType);
                if (faad.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
            else
            {
                MessageBox.Show("请选择一行记录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtChoose_TextChanged(object sender, EventArgs e)
        {
            if (TxtChoose.Text != "")
            {
                SelectStr = string.Format("and 1=1 and( CtrlID='{0}' or DeliverStore='{0}' or ReceiptStore='{0}' or ApplicantsName='{0}')", TxtChoose.Text);
            }
            else
            {
                SelectStr = "";
            }
        }

        private void dgvApplyInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvApplyInfo.RowCount > 0)
            {
                intSelectRowIndex = dgvApplyInfo.CurrentRow.Index;

                if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column18"].Value == 1) txtApproval.Text = "通过"; else if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column18"].Value == 2) txtApproval.Text = "不通过"; else txtApproval.Text = "未审批";
                if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column20"].Value == 1) txtApproval2.Text = "通过"; else if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column20"].Value == 2) txtApproval2.Text = "不通过"; else txtApproval2.Text = "未审批";
                if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column22"].Value == 1) txtDeliverConfirm.Text = "通过"; else if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column22"].Value == 2) txtDeliverConfirm.Text = "不确认"; else txtDeliverConfirm.Text = "未确认";
                if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column24"].Value == 1) txtReceiptConfirm.Text = "通过"; else if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column24"].Value == 2) txtReceiptConfirm.Text = "部分确认"; else if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column24"].Value == 3) txtReceiptConfirm.Text = "不确认"; else txtReceiptConfirm.Text = "未确认";
                if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column27"].Value == 9) txtIsDone.Text = "已完成"; else txtIsDone.Text = "未完成";

                applicationInfo.CtrlID = dgvApplyInfo.SelectedRows[0].Cells["Column1"].Value.ToString();
                applicationInfo.ApplicantsName = dgvApplyInfo.SelectedRows[0].Cells["Column5"].Value.ToString();
                applicationInfo.ApplicantsPos = dgvApplyInfo.SelectedRows[0].Cells["Column8"].Value.ToString();
                applicationInfo.ApplicantsDate = dgvApplyInfo.SelectedRows[0].Cells["Column4"].Value.ToString();
                applicationInfo.DeliverStore = dgvApplyInfo.SelectedRows[0].Cells["Column2"].Value.ToString();
                applicationInfo.ReceiptStore = dgvApplyInfo.SelectedRows[0].Cells["Column3"].Value.ToString();
                applicationInfo.ApprovalName = dgvApplyInfo.SelectedRows[0].Cells["Column10"].Value.ToString();
                applicationInfo.ApprovalDate = dgvApplyInfo.SelectedRows[0].Cells["Column19"].Value.ToString();
                applicationInfo.ApprovalName2 = dgvApplyInfo.SelectedRows[0].Cells["Column30"].Value.ToString();
                applicationInfo.ApprovalDate2 = dgvApplyInfo.SelectedRows[0].Cells["Column21"].Value.ToString();
                applicationInfo.DeliverCheck = dgvApplyInfo.SelectedRows[0].Cells["Column12"].Value.ToString();
                applicationInfo.DeliverCheckerName = dgvApplyInfo.SelectedRows[0].Cells["Column14"].Value.ToString();
                applicationInfo.ReceiptCheck = dgvApplyInfo.SelectedRows[0].Cells["Column15"].Value.ToString();
                applicationInfo.ReceiptCheckerName = dgvApplyInfo.SelectedRows[0].Cells["Column17"].Value.ToString();

                applicationInfo.DeliverDate = dgvApplyInfo.SelectedRows[0].Cells["DeliverDate"].Value.ToString();
                applicationInfo.ReceiptDate = dgvApplyInfo.SelectedRows[0].Cells["ReceiptDate"].Value.ToString();
                applicationInfo.S_O_Str = dgvApplyInfo.SelectedRows[0].Cells["S_O_Str"].Value.ToString();
                applicationInfo.O_O_Str = dgvApplyInfo.SelectedRows[0].Cells["O_O_Str"].Value.ToString();
                applicationInfo.WuliuDate = dgvApplyInfo.SelectedRows[0].Cells["WuliuDate"].Value.ToString();
            }
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            switch (CtrlType)
            {
                case "未审核": ApplicationInfoTable = applicationInfo.SelectApplicationByApproval2(SelectStr); break;
                case "历史审核": ApplicationInfoTable = applicationInfo.SelectHistoryApplicationByApproval2(SelectStr, Login.LoginUser); break;
                default: ApplicationInfoTable = applicationInfo.SelectApplicationByApproval2(SelectStr); break;
            }
            dgvApplyInfo.DataSource = ApplicationInfoTable;
        }

        private void BtnQueue_Click(object sender, EventArgs e)
        {
            CtrlType = "未审核";
            GetApplicationDetail();
        }

        private void BtnDeliver_Click(object sender, EventArgs e)
        {
            CtrlType = "历史审核";
            GetApplicationDetail();
        }

        private void cbCtrlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlType = cbCtrlType.SelectedItem.ToString();
            GetApplicationDetail();
        }

        private void dgvApplyInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvApplyInfo.Rows)
            {
                if ((int)dgvr.Cells["Column27"].Value == 0)
                    dgvr.Cells["App_State"].Value = "未审核";
                else if ((int)dgvr.Cells["Column27"].Value == 1)
                    dgvr.Cells["App_State"].Value = "商品部审核通过";
                else if ((int)dgvr.Cells["Column27"].Value == 2)
                    dgvr.Cells["App_State"].Value = "财务部审核通过";
                else if ((int)dgvr.Cells["Column27"].Value == 3)
                    dgvr.Cells["App_State"].Value = "转出店面确认通过";
                else if ((int)dgvr.Cells["Column27"].Value == 4)
                    dgvr.Cells["App_State"].Value = "转入店面确认通过";
                else if ((int)dgvr.Cells["Column27"].Value == 5)
                    dgvr.Cells["App_State"].Value = "物流确认通过";
                else if ((int)dgvr.Cells["Column27"].Value == 9)
                    dgvr.Cells["App_State"].Value = "已完成";
                else
                    dgvr.Cells["App_State"].Value = "无";

                if((int)dgvr.Cells["Column26"].Value==1)
                    dgvr.Cells["App_State"].Value = "已撤销";
            }
        }

        private void dgvApplyInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (applicationInfo.CtrlID != null)
            {
                frmAppApprovalDetail2 faad = new frmAppApprovalDetail2(applicationInfo, CtrlType);
                if (faad.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < dgvApplyInfo.Rows.Count; x++)
            {
                if (dgvApplyInfo.Rows[x].Cells["dgChecked"].Value != null && dgvApplyInfo.Rows[x].Cells["dgChecked"].Value.ToString() == "True")
                {
                    dgvApplyInfo.Rows[x].Cells["dgChecked"].Value = null;
                }
                else
                {
                    dgvApplyInfo.Rows[x].Cells["dgChecked"].Value = "True";
                }
            }
        }

        private void btnApprovalAll_Click(object sender, EventArgs e)
        {
            int successRows = 0;
            if (CtrlType == "未审核")
            {
                //foreach (DataRow dr in ApplicationInfoTable.Rows)
                //{
                //    if (dr["ApprovalState"].ToString() == "1")
                //    {
                //        successRows += applicationInfo.ApprovalApplication2(dr["CtrlID"].ToString(), Login.LoginUser, 1, DateTime.Now);
                //        //EmailControl.ToDeliverConfirm(applicationInfo);
                //        Thread thread = new Thread(new ThreadStart(SendEmail));
                //        thread.Start();
                //    }
                //}
                for (int x = 0; x < dgvApplyInfo.Rows.Count; x++)
                {
                    if (dgvApplyInfo.Rows[x].Cells["dgChecked"].Value != null && dgvApplyInfo.Rows[x].Cells["dgChecked"].Value.ToString() == "True")
                    {
                        successRows += applicationInfo.ApprovalApplication2(dgvApplyInfo.Rows[x].Cells["Column1"].Value.ToString(), Login.LoginUser, 1, DateTime.Now);
                        applicationInfo.CtrlID = dgvApplyInfo.Rows[x].Cells["Column1"].Value.ToString();
                        applicationInfo.ApplicantsName = dgvApplyInfo.Rows[x].Cells["Column5"].Value.ToString();
                        applicationInfo.ApplicantsPos = dgvApplyInfo.Rows[x].Cells["Column8"].Value.ToString();
                        applicationInfo.ApplicantsDate = dgvApplyInfo.Rows[x].Cells["Column4"].Value.ToString();
                        applicationInfo.DeliverStore = dgvApplyInfo.Rows[x].Cells["Column2"].Value.ToString();
                        applicationInfo.ReceiptStore = dgvApplyInfo.Rows[x].Cells["Column3"].Value.ToString();
                        applicationInfo.ApprovalName = dgvApplyInfo.Rows[x].Cells["Column10"].Value.ToString();
                        applicationInfo.ApprovalDate = dgvApplyInfo.Rows[x].Cells["Column19"].Value.ToString();
                        applicationInfo.ApprovalName2 = dgvApplyInfo.Rows[x].Cells["Column30"].Value.ToString();
                        applicationInfo.ApprovalDate2 = dgvApplyInfo.Rows[x].Cells["Column21"].Value.ToString();
                        applicationInfo.DeliverCheck = dgvApplyInfo.Rows[x].Cells["Column12"].Value.ToString();
                        applicationInfo.DeliverCheckerName = dgvApplyInfo.Rows[x].Cells["Column14"].Value.ToString();
                        applicationInfo.ReceiptCheck = dgvApplyInfo.Rows[x].Cells["Column15"].Value.ToString();
                        applicationInfo.ReceiptCheckerName = dgvApplyInfo.Rows[x].Cells["Column17"].Value.ToString();

                        applicationInfo.DeliverDate = dgvApplyInfo.Rows[x].Cells["DeliverDate"].Value.ToString();
                        applicationInfo.ReceiptDate = dgvApplyInfo.Rows[x].Cells["ReceiptDate"].Value.ToString();
                        applicationInfo.S_O_Str = dgvApplyInfo.Rows[x].Cells["S_O_Str"].Value.ToString();
                        applicationInfo.O_O_Str = dgvApplyInfo.Rows[x].Cells["O_O_Str"].Value.ToString();
                        applicationInfo.WuliuDate = dgvApplyInfo.Rows[x].Cells["WuliuDate"].Value.ToString();
                        SendEmail();
                    }
                }
                MessageBox.Show("审批通过" + successRows + "条", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetApplicationDetail();
            }
            else
            {
                MessageBox.Show("非未审核订单,不得再次审核");
            }
            //if (CtrlType == "最终确认")
            //{
            //    foreach (DataRow dr in ApplicationInfoTable.Rows)
            //    {
            //        if (dr["FinalState"].ToString() == "1")
            //        {
            //            successRows += applicationInfo.FinalConfirm(dr["TransNo"].ToString());
            //        }
            //    }
            //    MessageBox.Show("最终确认通过" + successRows + "条", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        void SendEmail()
        {
            EmailControl.ToDeliverConfirm(applicationInfo);
        }

        private void frmAppAproval2_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void btn_SortByString_Click(object sender, EventArgs e)
        {
            ApplicationInfoTable = applicationInfo.SelectHistoryApplicationByApproval2(SelectStr, Login.LoginUser, " IsDelete,AppState ");
            dgvApplyInfo.DataSource = ApplicationInfoTable;
        }
        //private void dgvApplyInfo_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        //{
        //    if (e.Column.Name == "流程状态")
        //    {
        //        e.SortResult = System.String.Compare(Convert.ToString(e.CellValue1), Convert.ToString(e.CellValue2));
        //    }
        //    e.Handled = true;
        //}
    }
}
