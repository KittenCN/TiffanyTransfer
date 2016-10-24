using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BHair.Business.Table;
using BHair.Business.BaseData;
using System.Security.Cryptography;

namespace BHair.Business
{
    public partial class frmApplicationReport : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationReport;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        string sqlStr="";

        public frmApplicationReport()
        {
            InitializeComponent();
            //GetApplicationDetail();
            InitComboBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sqlStr = "";
            if (txtItemID.Text != "")
                sqlStr += string.Format(" and (ApplicationDetail.ItemID='{0}' or ApplicationDetail.ItemID2='{0}' )", txtItemID.Text);

            sqlStr += string.Format(" and ApplicationInfo.ApplicantsDate>#{0}# and ApplicationInfo.ApplicantsDate<#{1}#", txtSDate.Value.AddDays(-1).ToShortDateString(), txtEDate.Value.ToShortDateString());
            if (txtDeliverStore.SelectedItem.ToString() != "全部")
                sqlStr += string.Format(" and ApplicationInfo.DeliverStore='{0}'", txtDeliverStore.SelectedItem.ToString());
            if (txtReceiptStore.SelectedItem.ToString() != "全部")
                sqlStr += string.Format(" and ApplicationInfo.ReceiptStore='{0}'", txtReceiptStore.SelectedItem.ToString());
            if (txtS_O.SelectedItem.ToString() != "全部")
                sqlStr += string.Format(" and S_O='{0}'", txtS_O.SelectedItem.ToString());
            if (txtS_O_Str.Text != "")
                sqlStr += string.Format(" and S_O_Str='{0}'", txtS_O_Str.Text);
            if (txtO_O.SelectedItem.ToString() != "全部")
                sqlStr += string.Format(" and O_O='{0}'", txtO_O.SelectedItem.ToString());
            if (txtO_O_Str.Text != "")
                sqlStr += string.Format(" and O_O_Str='{0}'", txtO_O_Str.Text);
            if (txtBatch_Num1.Text != "")
                sqlStr += string.Format(" and Batch_Num1='{0}'", txtBatch_Num1.Text);
            if (txtBatch_Num2.Text != "")
                sqlStr += string.Format(" and Batch_Num2='{0}'", txtBatch_Num2.Text);
            GetApplicationDetail();
        }


        public void GetApplicationDetail()
        {
            ApplicationReport = applicationInfo.SelectAppReport(sqlStr);
            dgvAppDetail.AutoGenerateColumns = false;
            dgvAppDetail.DataSource = ApplicationReport;
        }

        private void InitComboBox()
        {
            Store store = new Store();
            store.StoreDT = store.SelectAllStoreInfo();
            txtDeliverStore.Items.Add("全部");
            txtReceiptStore.Items.Add("全部");
            foreach (DataRow dr in store.StoreDT.Rows)
            {
                txtDeliverStore.Items.Add(dr["StoreName"].ToString());
                if(Login.LoginUser.Character!=3)
                {
                    txtReceiptStore.Items.Add(dr["StoreName"].ToString());
                }               
            }
            if (Login.LoginUser.Character == 3)
            {
                string[] strStoreTemp = Login.LoginUser.Store.ToString().Split(',');
                if (strStoreTemp[0] != "" && strStoreTemp[0] != null && strStoreTemp.Length > 1)
                {
                    for (int i = 0; i < strStoreTemp.Length; i++)
                    {
                        if(strStoreTemp[i].ToString()!=null && strStoreTemp[i].ToString()!="")
                        {
                            txtReceiptStore.Items.Add(strStoreTemp[i].ToString());
                        }                   
                    }
                }
                else
                {
                    txtReceiptStore.Items.Add(strStoreTemp[0]);
                }
                if (txtReceiptStore.Items.Count > 0)
                {
                    txtReceiptStore.SelectedIndex = 0;
                }
            }
            txtDeliverStore.SelectedIndex = 0;
            txtReceiptStore.SelectedIndex = 0;

            txtS_O.Items.Add("全部");
            txtS_O.Items.Add("s6");
            txtS_O.Items.Add("s7");
            txtS_O.Items.Add("sf");
            txtS_O.SelectedIndex = 0;

            txtO_O.Items.Add("全部");
            txtO_O.Items.Add("o6");
            txtO_O.Items.Add("o7");
            txtO_O.Items.Add("of");
            txtO_O.SelectedIndex = 0;
        }

        private void dgvAppDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            applicationInfo.CtrlID = dgvAppDetail.SelectedRows[0].Cells["CtrlID"].Value.ToString();
            applicationInfo.ApplicantsName = dgvAppDetail.SelectedRows[0].Cells["ApplicantsName"].Value.ToString();
            applicationInfo.ApplicantsPos = dgvAppDetail.SelectedRows[0].Cells["ApplicantsPos"].Value.ToString();
            applicationInfo.ApplicantsDate = dgvAppDetail.SelectedRows[0].Cells["ApplicantsDate"].Value.ToString();
            applicationInfo.DeliverStore = dgvAppDetail.SelectedRows[0].Cells["DeliverStore"].Value.ToString();
            applicationInfo.ReceiptStore = dgvAppDetail.SelectedRows[0].Cells["ReceiptStore"].Value.ToString();
            applicationInfo.ApprovalName = dgvAppDetail.SelectedRows[0].Cells["ApprovalName"].Value.ToString();
            applicationInfo.ApprovalDate = dgvAppDetail.SelectedRows[0].Cells["ApprovalDate"].Value.ToString();
            applicationInfo.ApprovalName2 = dgvAppDetail.SelectedRows[0].Cells["ApprovalName2"].Value.ToString();
            applicationInfo.ApprovalDate2 = dgvAppDetail.SelectedRows[0].Cells["ApprovalDate2"].Value.ToString();
            applicationInfo.DeliverCheckerName = dgvAppDetail.SelectedRows[0].Cells["DeliverCheckerName"].Value.ToString();
            applicationInfo.ReceiptCheckerName = dgvAppDetail.SelectedRows[0].Cells["ReceiptCheckerName"].Value.ToString();
            applicationInfo.S_O = dgvAppDetail.SelectedRows[0].Cells["S_O"].Value.ToString();
            applicationInfo.O_O = dgvAppDetail.SelectedRows[0].Cells["O_O"].Value.ToString();
            applicationInfo.Batch_Num1 = dgvAppDetail.SelectedRows[0].Cells["Batch_Num1"].Value.ToString();
            applicationInfo.Batch_Num2 = dgvAppDetail.SelectedRows[0].Cells["Batch_Num2"].Value.ToString();
            applicationInfo.DeliverDate= dgvAppDetail.SelectedRows[0].Cells["DeliverDate"].Value.ToString();
            applicationInfo.ReceiptDate = dgvAppDetail.SelectedRows[0].Cells["ReceiptDate"].Value.ToString();
        }

        private void dgvAppDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(applicationInfo.CtrlID!=null)
            {
                frmHistoryDetail fhd = new frmHistoryDetail(applicationInfo);
                fhd.Show();
            }
        }

        private void frmApplicationReport_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //PrintExcel pe = new PrintExcel();
            //pe.OutputAsExcelFile(dgvAppDetail);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF文件(*.pdf)|*.pdf";
            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string strRandom = getRandomString(12);
                    string tempFilePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\" + strRandom + ".xls";
                    PrintExcel pe = new PrintExcel();
                    pe.WriteToExcelReport(pe.exporeDataToTable(dgvAppDetail), tempFilePath, "Sheet1");
                    string localFilePath = saveFileDialog.FileName.ToString();
                    PrintPDF pp = new PrintPDF();
                    pp.XLSConvertToPDF(tempFilePath, localFilePath);
                    MessageBox.Show("保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        Random m_rnd = new Random();
        public char getRandomChar()
        {
            int ret = m_rnd.Next(122);
            while (ret < 48 || (ret > 57 && ret < 65) || (ret > 90 && ret < 97))
            {
                ret = m_rnd.Next(122);
            }
            return (char)ret;
        }
        public string getRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(getRandomChar());
            }
            return sb.ToString();
        }

        private void btnOutExcel_Click(object sender, EventArgs e)
        {
            PrintExcel pe = new PrintExcel();
            pe.OutputAsExcelFile(dgvAppDetail);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "EXCEL文件(*.xls)|*.xls";
            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    //string strRandom = getRandomString(12);
                    //string tempFilePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\" + strRandom + ".xls";
                    string tempFilePath = saveFileDialog.FileName.ToString();
                    //PrintExcel pe = new PrintExcel();
                    pe.WriteToExcelReport(pe.exporeDataToTable(dgvAppDetail), tempFilePath, "Sheet1");
                    //string localFilePath = saveFileDialog.FileName.ToString();
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
    }
}
