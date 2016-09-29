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
    public partial class frmStoreApp : WinFormsUI.Docking.DockContent
    {
        public DataTable ApplicationInfoTable;
        public DataRow ApplicationInfoRow;
         ApplicationInfo applicationInfo = new ApplicationInfo();
        public string CtrlID = "";
        string SelectStr = "and 1=1";
        string CtrlType="正在审核";
        /// <summary>店面转货单状态</summary>
        public frmStoreApp()
        {
            InitializeComponent();
            GetApplicationDetail();
            cbCtrlType.Items.Add("正在审核");
            cbCtrlType.Items.Add("待发货");
            cbCtrlType.Items.Add("待收货");
            cbCtrlType.Items.Add("历史申请单");
            cbCtrlType.SelectedIndex = 0;
        }



        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetApplicationDetail();
        }

        public void GetApplicationDetail()
        {
            ApplicationInfoTable = new DataTable();
            string[] strStoreTemp = Login.LoginUser.Store.ToString().Split(',');
            switch (CtrlType)
            {
                case "正在审核": ApplicationInfoTable = applicationInfo.SelectApplicationByApplicants(strStoreTemp, ""); break;
                case "待发货": ApplicationInfoTable = applicationInfo.SelectApplicationByDeliver(strStoreTemp, ""); break;
                case "待收货": ApplicationInfoTable = applicationInfo.SelectApplicationByReceipt(strStoreTemp, ""); break;
                case "历史申请单": ApplicationInfoTable = applicationInfo.SelectHistoryApplicationByApplicants(strStoreTemp, ""); break;
                default: ApplicationInfoTable = applicationInfo.SelectApplicationByApplicants(strStoreTemp, ""); break;
            }

            dgvApplyInfo.AutoGenerateColumns = false; 
            dgvApplyInfo.DataSource = ApplicationInfoTable;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (applicationInfo.CtrlID!=null)
            {
                frmStoreAppDetail fsad =new frmStoreAppDetail(applicationInfo,CtrlType);
                if (fsad.ShowDialog() == DialogResult.OK)
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
        }

        private void dgvApplyInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvApplyInfo.RowCount > 0)
            {
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
                applicationInfo.DeliverDate = dgvApplyInfo.SelectedRows[0].Cells["DeliverDate"].Value.ToString();
                applicationInfo.ReceiptDate = dgvApplyInfo.SelectedRows[0].Cells["ReceiptDate"].Value.ToString();
                applicationInfo.S_O_Str = dgvApplyInfo.SelectedRows[0].Cells["S_O_Str"].Value.ToString();
                applicationInfo.O_O_Str = dgvApplyInfo.SelectedRows[0].Cells["O_O_Str"].Value.ToString();
                applicationInfo.WuliuDate = dgvApplyInfo.SelectedRows[0].Cells["WuliuDate"].Value.ToString();
                applicationInfo.WuliuID = dgvApplyInfo.SelectedRows[0].Cells["WuliuID"].Value.ToString();
            }
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            string[] strStoreTemp = Login.LoginUser.Store.ToString().Split(',');
            switch (CtrlType)
            {
                case "正在审核": ApplicationInfoTable = applicationInfo.SelectApplicationByApplicants(strStoreTemp, SelectStr); break;
                case "待发货": ApplicationInfoTable = applicationInfo.SelectApplicationByDeliver(strStoreTemp, SelectStr);  break;
                case "待收货": ApplicationInfoTable = applicationInfo.SelectApplicationByReceipt(strStoreTemp, SelectStr);  break;
                case "历史申请单": ApplicationInfoTable = applicationInfo.SelectHistoryApplicationByApplicants(strStoreTemp, ""); break;
                default: ApplicationInfoTable = applicationInfo.SelectApplicationByApplicants(strStoreTemp, SelectStr); break;
            }
            dgvApplyInfo.DataSource = ApplicationInfoTable;
        }

        private void cbCtrlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlType = cbCtrlType.SelectedItem.ToString();
            GetApplicationDetail();
            btnOneceRecive.Visible = false;
            if (CtrlType == "正在审核") { btnAdd.Visible = true; btnAlter.Visible = false; btnDelete.Visible = false; }
            if (CtrlType == "待发货") {btnAdd.Visible = false; btnAlter.Visible = false; btnDelete.Visible = false;}
            if (CtrlType == "待收货")
            {
                btnAdd.Visible = false;
                btnAlter.Visible = false;
                btnDelete.Visible = false;
                if (Login.LoginUser.UID == "Administrator" || Login.LoginUser.Character==1 || Login.LoginUser.Character==4)
                {
                    btnOneceRecive.Visible = true;
                }
            }
            if (CtrlType == "历史申请单") { btnAdd.Visible = false; btnAlter.Visible = false; btnDelete.Visible = false; }

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddApplication faa = new frmAddApplication();
            if (faa.ShowDialog() == DialogResult.OK)
            {
                this.GetApplicationDetail();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column27"].Value > 0)
            {
                MessageBox.Show("已进入审批状态，无法撤销", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    applicationInfo.DeleteApplicaionInfo(dgvApplyInfo.SelectedRows[0].Cells["Column1"].Value.ToString());
                    MessageBox.Show("撤销成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GetApplicationDetail();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("撤销失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            if ((int)dgvApplyInfo.SelectedRows[0].Cells["Column27"].Value > 0)
            {
                MessageBox.Show("已进入审批状态，无法修改", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (applicationInfo.CtrlID != null)
                {
                    frmAlterApplication objfrmAlter = new frmAlterApplication(applicationInfo);
                    if (objfrmAlter.ShowDialog() == DialogResult.OK)
                    {
                        this.GetApplicationDetail();
                    }
                }
                else
                {
                    MessageBox.Show("请选择一行记录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvApplyInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvApplyInfo.Rows)
            {
                if ((int)dgvr.Cells["Column27"].Value== 0)
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

        private void dgvApplyInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (applicationInfo.CtrlID != null)
            {
                frmStoreAppDetail objfrmDetail = new frmStoreAppDetail(applicationInfo,CtrlType);
                if (objfrmDetail.ShowDialog() == DialogResult.OK)
                {
                    this.GetApplicationDetail();
                }
            }
        }

        private void frmStoreApp_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void btnOneceRecive_Click(object sender, EventArgs e)
        {
            if(applicationInfo.CtrlID!=null)
            {
                ApplicationDetail applicationDetail = new ApplicationDetail();
                DataTable AddApplicationDT = applicationDetail.SelectDeliverDetailByCtrlID(applicationInfo.CtrlID);
                DataTable AddAppInfoDT = applicationInfo.SelectApplicationByCtrlID(applicationInfo.CtrlID);
                applicationDetail.UpdateReceiptDetail(AddApplicationDT);
                applicationInfo.UpdateApplicationInfo(AddAppInfoDT);
                applicationInfo.ReceiptConfirm(applicationInfo.CtrlID, "一键自动收货!", Login.LoginUser, 1);
                SendEmailtoWuliu();
            }
        }
        void SendEmailtoWuliu()
        {
            EmailControl.ToApplicantWLSubmit(applicationInfo);
            //EmailControl.ToReceiptConfirm(applicationInfo);
        }
    }
}
