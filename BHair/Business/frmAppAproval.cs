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
    public partial class frmAppAproval : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationInfoTable;
        public DataRow ApplicationInfoRow;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        public string CtrlID = "";
        string SelectStr = "and 1=1";
        string CtrlType = "未审核";
        public DataTable dtResult = null;
        public int intSelectRowIndex = 0;
        /// <summary>商品部转货单状态</summary>
        public frmAppAproval()
        {
            InitializeComponent();
            GetApplicationDetail();
            if (Login.LoginUser.Character == 4)
            {
                cbCtrlType.Items.Add("物流部历史");
                btnApprovalAll.Visible = false;
                btnDelete.Visible = false;
                btnFinishState.Visible = false;
                btnOuttoExcel.Visible = false;
                btnImportApp.Visible = false;
                btnSelectAll.Visible = false;
            }
            else
            {
                cbCtrlType.Items.Add("未审核");
                cbCtrlType.Items.Add("已完成");
                cbCtrlType.Items.Add("财务待完成");
                cbCtrlType.Items.Add("全部");
            }

            cbCtrlType.SelectedIndex = 0;
        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetApplicationDetail();
        }

        public void GetApplicationDetail()
        {
            ApplicationInfoTable = new DataTable();
            switch (CtrlType)
            {
                case "物流部历史": ApplicationInfoTable = applicationInfo.SelectHistoryFinalApplication(SelectStr, Login.LoginUser.UID); break;
                case "未审核": ApplicationInfoTable = applicationInfo.SelectApplicationByApproval(SelectStr); break;
                case "最终确认": ApplicationInfoTable = applicationInfo.SelectAlterAppByApproval(SelectStr); break;
                case "已完成": ApplicationInfoTable = applicationInfo.SelectFinishAppByApproval(SelectStr); break;
                case "财务待完成": ApplicationInfoTable = applicationInfo.SelectApplicationByApproval2(SelectStr); break;
                case "全部": ApplicationInfoTable = applicationInfo.SelectAllApplication(SelectStr); break;
                default: ApplicationInfoTable = applicationInfo.SelectApplicationByApproval(SelectStr); break;
            }
            dtResult = ApplicationInfoTable;
            ApplicationInfoTable.Columns.Add("FinishState", typeof(string));
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
            //if(CtrlType== "已完成")
            //{
            //    BaseProcess bp = new BaseProcess();
            //    for (int i = 0; i < ApplicationInfoTable.Rows.Count; i++)
            //    {
            //        if (ApplicationInfoTable.Rows[i]["AppState"].ToString() == "9")
            //        {
            //            if (bp.boolCampareOrder(ApplicationInfoTable.Rows[i]["CtrlID"].ToString()))
            //            {
            //                ApplicationInfoTable.Rows[i]["FinishState"] = "异常";
            //            }
            //            else
            //            {
            //                ApplicationInfoTable.Rows[i]["FinishState"] = "正常";
            //            }
            //        }
            //        else
            //        {
            //            ApplicationInfoTable.Rows[i]["FinishState"] = "-";
            //        }
            //    }
            //    for (int i = 0; i < dgvApplyInfo.Rows.Count; i++)
            //    {
            //        if (dgvApplyInfo.Rows[i].Cells["完成状态"].Value.ToString() == "异常")
            //        {
            //            dgvApplyInfo.Rows[i].Cells["完成状态"].Style.ForeColor = Color.Red;
            //        }
            //    }
            //}
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            
            if (applicationInfo.CtrlID != null && dgvApplyInfo.CurrentRow != null)
            {
                intSelectRowIndex = dgvApplyInfo.CurrentRow.Index;
                frmAppApprovalDetail faad = new frmAppApprovalDetail(applicationInfo, CtrlType);
                if (faad.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
                this.GetApplicationDetail();
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
                txtWuliuID.Text = dgvApplyInfo.SelectedRows[0].Cells["WuliuID"].Value.ToString();

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
                applicationInfo.S_O = dgvApplyInfo.SelectedRows[0].Cells["S_O"].Value.ToString();
                applicationInfo.O_O = dgvApplyInfo.SelectedRows[0].Cells["O_O"].Value.ToString();
                applicationInfo.Batch_Num1 = dgvApplyInfo.SelectedRows[0].Cells["Batch_Num1"].Value.ToString();
                applicationInfo.Batch_Num2 = dgvApplyInfo.SelectedRows[0].Cells["Batch_Num2"].Value.ToString();
                applicationInfo.WuliuID = dgvApplyInfo.SelectedRows[0].Cells["WuliuID"].Value.ToString();
                applicationInfo.EditReason = dgvApplyInfo.SelectedRows[0].Cells["EditReason"].Value.ToString();
                applicationInfo.DeliverDate = dgvApplyInfo.SelectedRows[0].Cells["DeliverDate"].Value.ToString();
                applicationInfo.ReceiptDate = dgvApplyInfo.SelectedRows[0].Cells["ReceiptDate"].Value.ToString();
                applicationInfo.S_O_Str = dgvApplyInfo.SelectedRows[0].Cells["S_O_Str"].Value.ToString();
                applicationInfo.O_O_Str = dgvApplyInfo.SelectedRows[0].Cells["O_O_Str"].Value.ToString();
                applicationInfo.WuliuDate = dgvApplyInfo.SelectedRows[0].Cells["WuliuDate"].Value.ToString();
                applicationInfo.ExchangeType = dgvApplyInfo.SelectedRows[0].Cells["ExchangeType"].Value.ToString();
                applicationInfo.AppState = (int)dgvApplyInfo.SelectedRows[0].Cells["Column27"].Value;
            }
            if (CtrlType == "未审核")
            {
                txtApproval.Text = "未审批";
                txtApproval2.Text = "未审批";
                txtDeliverConfirm.Text = "未确认";
                txtReceiptConfirm.Text = "未确认";
                txtIsDone.Text = "未完成";
            }
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            switch (CtrlType)
            {
                case "物流部历史": ApplicationInfoTable = applicationInfo.SelectHistoryFinalApplication(SelectStr, Login.LoginUser.UID); break;
                case "未审核": ApplicationInfoTable = applicationInfo.SelectApplicationByApproval(SelectStr); break;
                case "最终确认": ApplicationInfoTable = applicationInfo.SelectAlterAppByApproval(SelectStr); break;
                case "已完成": ApplicationInfoTable = applicationInfo.SelectFinishAppByApproval(SelectStr); break;
                case "财务待完成": ApplicationInfoTable = applicationInfo.SelectApplicationByApproval2(SelectStr); break;
                case "全部": ApplicationInfoTable = applicationInfo.SelectAllApplication(SelectStr); break;
                default: ApplicationInfoTable = applicationInfo.SelectApplicationByApproval(SelectStr); break;
            }
            dtResult = ApplicationInfoTable;
            ApplicationInfoTable.Columns.Add("FinishState", typeof(string));
            dgvApplyInfo.AutoGenerateColumns = false;
            dgvApplyInfo.DataSource = ApplicationInfoTable;
            //if(CtrlType== "已完成")
            //{
            //    BaseProcess bp = new BaseProcess();
            //    for (int i = 0; i < ApplicationInfoTable.Rows.Count; i++)
            //    {
            //        if (ApplicationInfoTable.Rows[i]["AppState"].ToString() == "9")
            //        {
            //            if (bp.boolCampareOrder(ApplicationInfoTable.Rows[i]["CtrlID"].ToString()))
            //            {
            //                ApplicationInfoTable.Rows[i]["FinishState"] = "异常";
            //            }
            //            else
            //            {
            //                ApplicationInfoTable.Rows[i]["FinishState"] = "正常";
            //            }
            //        }
            //        else
            //        {
            //            ApplicationInfoTable.Rows[i]["FinishState"] = "-";
            //        }
            //    }
            //    for (int i = 0; i < dgvApplyInfo.Rows.Count; i++)
            //    {
            //        if (dgvApplyInfo.Rows[i].Cells["完成状态"].Value.ToString() == "异常")
            //        {
            //            dgvApplyInfo.Rows[i].Cells["完成状态"].Style.ForeColor = Color.Red;
            //        }
            //    }
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int successRows = 0;
            if (applicationInfo.CtrlID != null)
            {
                try
                {
                    //applicationInfo.DeleteApplicaionInfo(applicationInfo.CtrlID);
                    //MessageBox.Show("撤销成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //GetApplicationDetail();
                    //foreach (DataRow dr in ApplicationInfoTable.Rows)
                    //{
                    //    //if (dr["ApprovalState"].ToString() == "1")
                    //    if (dr["dgChecked"].ToString() == "1")
                    //    {
                    //        successRows += applicationInfo.DeleteApplicaionInfo(dr["CtrlID"].ToString());
                    //        MessageBox.Show("撤销成功" + successRows + "条", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        GetApplicationDetail();
                    //    }
                    //}
                    for (int x = 0; x < dgvApplyInfo.Rows.Count; x++)
                    {
                        if (dgvApplyInfo.Rows[x].Cells["dgChecked"].Value != null && dgvApplyInfo.Rows[x].Cells["dgChecked"].Value.ToString() == "True")
                        {
                            successRows += applicationInfo.DeleteApplicaionInfo(dgvApplyInfo.Rows[x].Cells["Column1"].Value.ToString());
                        }
                    }
                    MessageBox.Show("撤销成功" + successRows + "条", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GetApplicationDetail();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("撤销失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请至少选择一行记录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            if (applicationInfo.CtrlID != null)
            {
                frmAlterApplication faa = new frmAlterApplication(applicationInfo);
                if (faa.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
            else
            {
                MessageBox.Show("请选择一行记录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

                if ((int)dgvr.Cells["Column26"].Value == 1)
                    dgvr.Cells["App_State"].Value = "已撤销";

            }
        }

        private void cbCtrlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlType = cbCtrlType.SelectedItem.ToString();
            GetApplicationDetail();
        }

        private void dgvApplyInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (applicationInfo.CtrlID != null)
            {
                frmAlterApplication faa = new frmAlterApplication(applicationInfo);
                if (faa.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
        }

        private void dgvApplyInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (applicationInfo.CtrlID != null)
            {
                frmAppApprovalDetail faad = new frmAppApprovalDetail(applicationInfo, CtrlType);
                if (faad.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
                this.GetApplicationDetail();
            }
        }

        private void frmAppAproval_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void btnImportApp_Click(object sender, EventArgs e)
        {
            frmImportApplication fia = new frmImportApplication();
            fia.Show();
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
                //    //if (dr["ApprovalState"].ToString() == "1")
                //    if (dr["dgChecked"].ToString() == "1")
                //    {
                //        successRows += applicationInfo.ApprovalApplication(dr["CtrlID"].ToString(), Login.LoginUser, 1, DateTime.Now);
                //        //EmailControl.ToDeliverConfirm(applicationInfo);
                //        Thread thread = new Thread(new ThreadStart(SendEmail));
                //        thread.Start();
                //    }
                //}
                for (int x = 0; x < dgvApplyInfo.Rows.Count; x++)
                {

                    if (dgvApplyInfo.Rows[x].Cells["dgChecked"].Value != null && dgvApplyInfo.Rows[x].Cells["dgChecked"].Value.ToString() == "True")
                    {
                        successRows += applicationInfo.ApprovalApplication(dgvApplyInfo.Rows[x].Cells["Column1"].Value.ToString(), Login.LoginUser, 1, DateTime.Now);
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
                        applicationInfo.S_O = dgvApplyInfo.Rows[x].Cells["S_O"].Value.ToString();
                        applicationInfo.O_O = dgvApplyInfo.Rows[x].Cells["O_O"].Value.ToString();
                        applicationInfo.Batch_Num1 = dgvApplyInfo.Rows[x].Cells["Batch_Num1"].Value.ToString();
                        applicationInfo.Batch_Num2 = dgvApplyInfo.Rows[x].Cells["Batch_Num2"].Value.ToString();
                        applicationInfo.WuliuID = dgvApplyInfo.Rows[x].Cells["WuliuID"].Value.ToString();
                        applicationInfo.EditReason = dgvApplyInfo.Rows[x].Cells["EditReason"].Value.ToString();
                        applicationInfo.DeliverDate = dgvApplyInfo.Rows[x].Cells["DeliverDate"].Value.ToString();
                        applicationInfo.ReceiptDate = dgvApplyInfo.Rows[x].Cells["ReceiptDate"].Value.ToString();
                        applicationInfo.S_O_Str = dgvApplyInfo.Rows[x].Cells["S_O_Str"].Value.ToString();
                        applicationInfo.O_O_Str = dgvApplyInfo.Rows[x].Cells["O_O_Str"].Value.ToString();
                        applicationInfo.WuliuDate = dgvApplyInfo.Rows[x].Cells["WuliuDate"].Value.ToString();
                        applicationInfo.ExchangeType = dgvApplyInfo.Rows[x].Cells["ExchangeType"].Value.ToString();

                        SendEmail();
                    }
                }
                MessageBox.Show("审批通过" + successRows + "条", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetApplicationDetail();
            }
        }
        void SendEmail()
        {
            EmailControl.ToApplicantSubmit2(applicationInfo);
        }

        private void dgvApplyInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOuttoExcel_Click(object sender, EventArgs e)
        {
            if(CtrlType == "全部")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        string localFilePath = saveFileDialog.FileName.ToString();
                        //string tempFilePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\" + strRandom + ".xls";
                        dtResult = applicationInfo.SelectAllDetail(" and a.ApplicantsDate >= dateadd(\"d\",0,\"" + dTPBegin.Value.Date + "\") and a.ApplicantsDate < dateadd(\"d\",1,\"" + dTPEnd.Value.Date + "\") ");
                        PrintExcel pe = new PrintExcel();
                        pe.WriteToExcelSPB(dtResult, localFilePath, "Sheet1");
                        //PrintPDF pp = new PrintPDF();
                        //pp.XLSConvertToPDF(tempFilePath, localFilePath);
                        MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("保存失败,仅全部选择项且无搜索项的条件下,可导出明细EXCEL", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFinishState_Click(object sender, EventArgs e)
        {
            BaseProcess bp = new BaseProcess();
            for (int i = 0; i < ApplicationInfoTable.Rows.Count; i++)
            {
                if (ApplicationInfoTable.Rows[i]["AppState"].ToString() == "9")
                {
                    if (bp.boolCampareOrder(ApplicationInfoTable.Rows[i]["CtrlID"].ToString()))
                    {
                        ApplicationInfoTable.Rows[i]["FinishState"] = "异常";
                    }
                    else
                    {
                        ApplicationInfoTable.Rows[i]["FinishState"] = "正常";
                    }
                }
                else
                {
                    ApplicationInfoTable.Rows[i]["FinishState"] = "-";
                }
            }
            for (int i = 0; i < dgvApplyInfo.Rows.Count; i++)
            {
                if (dgvApplyInfo.Rows[i].Cells["完成状态"].Value.ToString() == "异常")
                {
                    dgvApplyInfo.Rows[i].Cells["完成状态"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void btnOneceRecive_Click(object sender, EventArgs e)
        {
            if (applicationInfo.CtrlID != null && (applicationInfo.AppState==3 || applicationInfo.AppState==4))
            {
                ApplicationDetail applicationDetail = new ApplicationDetail();
                DataTable AddApplicationDT = applicationDetail.SelectDeliverDetailByCtrlID(applicationInfo.CtrlID);
                DataTable AddAppInfoDT = applicationInfo.SelectApplicationByCtrlID(applicationInfo.CtrlID);
                applicationDetail.DeleteReceiptDetail(AddApplicationDT);
                applicationDetail.InsertReceiptDetail(AddApplicationDT);
                applicationInfo.UpdateApplicationInfo(AddAppInfoDT);
                applicationInfo.ReceiptConfirm(applicationInfo.CtrlID, "一键自动收货!", Login.LoginUser, 1);
                SendEmailtoWuliu();
                MessageBox.Show("订单号:" + applicationInfo.CtrlID + "一键自动收货成功!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("订单号错误,或订单状态错误!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void SendEmailtoWuliu()
        {
            EmailControl.ToApplicantWLSubmit(applicationInfo);
            //EmailControl.ToReceiptConfirm(applicationInfo);
        }
    }
}
