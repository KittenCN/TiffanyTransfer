using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BHair.Base;
using BHair.Business;
using BHair.SystemSet;
using BHair.Business.Table;

namespace BHair.Business
{
    public partial class frmDataProcessing : Form
    {
        public DataTable dtStaDetail;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        public frmDataProcessing()
        {
            InitializeComponent();
        }

        private void frmDataProcessing_Load(object sender, EventArgs e)
        {
            AccessHelper ah = new AccessHelper();
            string strSQL = "select * from (select CtrlID,count(CtrlID) as num from applicationdetail where isdelete=0 group by CtrlID) a where a.num>20";
            dtStaDetail = ah.SelectToDataTable(strSQL);
            ah.Close();
            if (dtStaDetail.Rows.Count > 0)
            {
                labDataCount.Text = dtStaDetail.Rows.Count.ToString();
                btnDataProcess.Enabled = true;
            }
            else
            {
                labDataCount.Text = "0";
                btnDataProcess.Enabled = false;
            }
        }

        private void btnDataProcess_Click(object sender, EventArgs e)
        {
            AccessHelper ah = new AccessHelper();
            foreach (DataRow dr in dtStaDetail.Rows)
            {
                string strCtrlID = "";
                int intNum = int.Parse(dr["num"].ToString());
                int intCI = 1;
                int intCurrentNum = 1;
                int intTotalCount = 0;
                double douTotalPrice = 0.00;
                string strSQL = "select * from applicationdetail where CtrlID='" + dr["CtrlID"].ToString() + "' ";
                DataTable dtDataDetail = ah.SelectToDataTable(strSQL);
                strSQL= "select * from ApplicationInfo where CtrlID='" + dr["CtrlID"].ToString() + "' ";
                DataTable dtDataInfo = ah.SelectToDataTable(strSQL);
                string strOriCtrlID = "Auto" + DateTime.Now.ToString("HHmmssfff") + dtDataInfo.Rows[0]["Applicants"].ToString().Substring(0, 1);
                strCtrlID = strOriCtrlID;
                DataTable AddAppInfoDT = applicationInfo.SelectApplicationByCtrlID("0");
                DataTable AddAppDetailDT = applicationDetail.SelectAppDetailByCtrlID("0");
                DataRow drInfo = AddAppInfoDT.NewRow();
                DataRow drDetail = AddAppDetailDT.NewRow();
                drInfo = dtDataInfo.Rows[0];
                
                foreach (DataRow drIN in dtDataDetail.Rows)
                {
                    drDetail = drIN;
                    if(intCurrentNum<=20)
                    {
                        intCurrentNum++;                       
                        drInfo["CtrlID"] = strCtrlID;
                        drDetail["CtrlID"] = strCtrlID;
                        intTotalCount += (int)drDetail["App_Count"];
                        douTotalPrice += ((int)drDetail["App_Count"]) * ((double.Parse(drDetail["Price"].ToString())));
                        AddAppDetailDT.Rows.Add(drDetail.ItemArray);
                    }
                    else
                    {
                        drInfo["TotalCount"] = intTotalCount;
                        drInfo["TotalPrice"] = douTotalPrice;
                        AddAppInfoDT.Rows.Add(drInfo.ItemArray);
                        applicationInfo.SubmitApplicationInfo(AddAppInfoDT);
                        applicationDetail.SubmitApplicationDetail(AddAppDetailDT);

                        intCurrentNum = 1;
                        intTotalCount = 0;
                        douTotalPrice = 0.00;
                        strCtrlID = strOriCtrlID + intCI.ToString();
                        intCI++;
                        AddAppInfoDT.Clear();
                        AddAppDetailDT.Clear();
                        //drInfo = AddAppInfoDT.NewRow();
                        //drDetail = AddAppDetailDT.NewRow();
                        //drInfo = dtDataInfo.Rows[0];

                        intCurrentNum++;
                        drInfo["CtrlID"] = strCtrlID;
                        drDetail["CtrlID"] = strCtrlID;
                        intTotalCount += (int)drDetail["App_Count"];
                        douTotalPrice += ((int)drDetail["App_Count"]) * ((double.Parse(drDetail["Price"].ToString())));
                        AddAppDetailDT.Rows.Add(drDetail.ItemArray);
                    }
                }
                if(AddAppDetailDT.Rows.Count>0)
                {
                    drInfo["TotalCount"] = intTotalCount;
                    drInfo["TotalPrice"] = douTotalPrice;
                    AddAppInfoDT.Rows.Add(drInfo.ItemArray);
                    applicationInfo.SubmitApplicationInfo(AddAppInfoDT);
                    applicationDetail.SubmitApplicationDetail(AddAppDetailDT);

                    intCurrentNum = 1;
                    intTotalCount = 0;
                    douTotalPrice = 0.00;
                    //strCtrlID = strOriCtrlID + intCI.ToString();
                    //intCI++;
                    AddAppInfoDT.Clear();
                    AddAppDetailDT.Clear();
                }
                strSQL= "update applicationdetail set isdelete=1 where CtrlID='" + dr["CtrlID"].ToString() + "' ";
                ah.ExecuteSQLNonquery(strSQL);
                strSQL= "update ApplicationInfo set isdelete=1 where CtrlID='" + dr["CtrlID"].ToString() + "' ";
                ah.ExecuteSQLNonquery(strSQL);
            }
            ah.Close();
            MessageBox.Show("处理完成!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            frmDataProcessing_Load(null,null);
        }
    }
}
