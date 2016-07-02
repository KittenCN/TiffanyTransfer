using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.BaseData;
using BHair.Business.Table;
using System.IO;
using System.Drawing.Printing;
using System.Security.Cryptography;

namespace BHair.Business
{
    public partial class frmImportApplication : WinFormsUI.Docking.DockContent
    {
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        DataTable applicationInfoDT = new DataTable();
        DataTable applicationDetailDT = new DataTable();
        DataTable[] TempDT = new DataTable[2];

        string filePath;
        public frmImportApplication()
        {
            InitializeComponent();
        }

        private void frmMember_List_Load(object sender, EventArgs e)
        {
            //this.LoadMemberList();
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
            
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel文件|*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                      
                        label1.Text = "正在导入Excel数据....";
                        filePath = openFileDialog.FileName;


                        applicationInfoDT = applicationInfo.SelectApplicationByCtrlID("");
                        applicationInfoDT.Clear();
                        applicationDetailDT = applicationDetail.SelectAppDetailByCtrlID("");
                        applicationDetailDT.Clear();
                        TempDT[0] = applicationInfoDT;
                        TempDT[1] = applicationDetailDT;
                        PrintExcel pe = new PrintExcel();
                        TempDT = pe.ExcelToDataTable_Application(filePath, TempDT);

                        dgvApplyInfo.AutoGenerateColumns = false;
                        dgvApplyInfo.DataSource = TempDT[0];
                        dgvApplyDetails.AutoGenerateColumns = false;
                        dgvApplyDetails.DataSource = TempDT[1];
                        label1.Text = "Excel数据导入完成";
                    }
                    catch
                    {
                        label1.Text = "Excel数据导入失败";
                    }
                }
            }
        

        private void btnImport_Click(object sender, EventArgs e)
        {
            label1.Text = "正在导入到数据库....";
            try
            {


                //插入新datatable表
                //users.ImportUsers(MemberDT);
                applicationInfo.UpdateApplicationInfo(TempDT[0]);
                applicationDetail.UpdateApplicationDetail(TempDT[1]);
                label1.Text = "数据库导入完成";
                DialogResult = DialogResult.OK;
            }
            catch
            {
                label1.Text = "数据库导入失败";
            }
        }

        private void dgvApplyDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
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
    }
}
