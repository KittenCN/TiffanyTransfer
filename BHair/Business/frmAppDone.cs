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
    public partial class frmAppDone : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationInfoTable;
        public DataRow ApplicationInfoRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
        public string CtrlID = "";
        string SelectStr = "and 1=1";
        string CtrlType = "未确认";
        public int intSelectRowIndex = 0;
        /// <summary>历史转货单信息</summary>
        public frmAppDone()
        {
            InitializeComponent();
            GetApplicationDetail();
            cbCtrlType.Items.Add("未确认");
            cbCtrlType.Items.Add("历史确认");
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
                case "未确认": ApplicationInfoTable = applicationInfo.SelectFinalApplication(SelectStr); break;
                case "历史确认": ApplicationInfoTable = applicationInfo.SelectHistoryFinalApplication(SelectStr, Login.LoginUser.UID); break;
                default: ApplicationInfoTable = applicationInfo.SelectFinalApplication(SelectStr); break;
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
            catch(Exception ex)
            {

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

                applicationInfo.DeliverDate = dgvApplyInfo.SelectedRows[0].Cells["DeliverDate"].Value.ToString();
                applicationInfo.ReceiptDate = dgvApplyInfo.SelectedRows[0].Cells["ReceiptDate"].Value.ToString();
                applicationInfo.S_O_Str = dgvApplyInfo.SelectedRows[0].Cells["S_O_Str"].Value.ToString();
                applicationInfo.O_O_Str = dgvApplyInfo.SelectedRows[0].Cells["O_O_Str"].Value.ToString();
            }
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {

            switch (CtrlType)
            {
                case "未确认": ApplicationInfoTable = applicationInfo.SelectFinalApplication(SelectStr); break;
                case "历史确认": ApplicationInfoTable = applicationInfo.SelectHistoryFinalApplication(SelectStr, Login.LoginUser.UID); break;
                default: ApplicationInfoTable = applicationInfo.SelectFinalApplication(SelectStr); break;
            }
            dgvApplyInfo.AutoGenerateColumns = false;
            dgvApplyInfo.DataSource = ApplicationInfoTable;
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
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //if (applicationInfo.CtrlID != null)
            //{
            //    try
            //    {
            //        //applicationInfo.WLConfirm(applicationInfo.CtrlID);
            //        GetApplicationDetail();
            //        EmailControl.ToApplicantFinal(applicationInfo);
            //        MessageBox.Show("确认成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show("确认失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请选择一行记录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
           

            if (applicationInfo.CtrlID != null && dgvApplyInfo.CurrentRow != null)
            {
                intSelectRowIndex = dgvApplyInfo.CurrentRow.Index;
                frmAppDoneDetail fadd = new frmAppDoneDetail(applicationInfo, CtrlType);
                fadd.ShowDialog();
                this.GetApplicationDetail();
            }
            else
            {
                MessageBox.Show("请选择一行记录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbCtrlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlType = cbCtrlType.SelectedItem.ToString();
            GetApplicationDetail();
        }

        private void dgvApplyInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frmAppDoneDetail fadd = new frmAppDoneDetail(applicationInfo, CtrlType);
            fadd.ShowDialog();
            this.GetApplicationDetail();
        }

        private void frmAppDone_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
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
                    PrintExcel pe = new PrintExcel();
                    pe.WriteToExcel(applicationInfo.SelectUNApplication(""), localFilePath, "Sheet1");
                    PrintPDF pp = new PrintPDF();
                    //pp.XLSConvertToPDF(tempFilePath, localFilePath);
                    MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel文件|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    label7.Text = "正在导入Excel数据....";
                    string filePath = openFileDialog.FileName;

                    DataTable applicationInfoDT = applicationInfo.SelectFinalApplication("");
                    applicationInfoDT.Clear();
                    DataTable TempDT = applicationInfoDT;
                    PrintExcel pe = new PrintExcel();
                    pe.ExcelToDataTable_Wuliu(filePath, TempDT,Login.LoginUser.UserName);

                    //dgvApplyInfo.AutoGenerateColumns = false;
                    //dgvApplyInfo.DataSource = TempDT;
                    label7.Text = "";
                    MessageBox.Show("Excel数据导入完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetApplicationDetail();
                }
                catch
                {
                    label7.Text = "";
                    MessageBox.Show("Excel数据导入失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetApplicationDetail();
                }
            }
        }

        private void btnOutFinish_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string strBeginDate = dtWuliuBegin.Value.ToShortDateString().ToString();
                    string strEndDate = dtWuliuEnd.Value.AddDays(1).ToShortDateString().ToString();
                    string localFilePath = saveFileDialog.FileName.ToString();
                    //string tempFilePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\" + strRandom + ".xls";
                    PrintExcel pe = new PrintExcel();
                    pe.WriteToExcel(applicationInfo.SelectApplication(" and  a.WuliuDate>=#" + strBeginDate + "# and a.WuliuDate<#" + strEndDate + "# "), localFilePath, "Sheet1");
                    PrintPDF pp = new PrintPDF();
                    //pp.XLSConvertToPDF(tempFilePath, localFilePath);
                    MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
