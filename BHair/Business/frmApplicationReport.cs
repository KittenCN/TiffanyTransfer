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

            sqlStr += string.Format(" and ApplicationInfo.ApplicantsDate>#{0}# and ApplicationInfo.ApplicantsDate<#{1}#", txtSDate.Value.AddDays(-1), txtEDate.Value);
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
                txtReceiptStore.Items.Add(dr["StoreName"].ToString());
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
            this.TopMost = true;
        }
    }
}
