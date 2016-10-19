using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XLuSharpLibrary.CommonFunction;
using BHair.Business.BaseData;
using BHair.Business.Table;

namespace BHair.Business
{
    public partial class frmSelectItems : Form
    {
        private string _ctrlID = "";
        public DataTable DeliverDetailTable;
        public DataTable ReceiptDetailTable;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        public DataTable DiffDeliverDT;
        public DataTable DiffReceiptDT;

        private string _store = "";

        ApplicationDetail CurrentItems = new ApplicationDetail();   //当前订单详情

        private bool bRun = false;

        public frmSelectItems()
        {
            InitializeComponent();
            GetApplicationDetail();
        }

        public frmSelectItems(string CtrlID)
        {
            InitializeComponent();
            this._ctrlID = CtrlID;
            GetApplicationDetail();
        }



        #region 加载商品信息列表...
        public void GetApplicationDetail()
        {
            dgvDevilerDetails.AutoGenerateColumns = false;
            dgvReceiptDetails.AutoGenerateColumns = false;
            DeliverDetailTable = applicationDetail.SelectDeliverDetailByCtrlID(_ctrlID);
            ReceiptDetailTable = applicationDetail.SelectReceiptDetailByCtrlID(_ctrlID);
            DiffDeliverDT = DeliverDetailTable.Clone();
            DiffReceiptDT = ReceiptDetailTable.Clone();
            dgvDevilerDetails.DataSource = DiffDeliverDT;
            dgvReceiptDetails.DataSource = DiffReceiptDT;

            foreach (DataRow deldr in DeliverDetailTable.Rows)
            {
                bool isDiff = false;
                foreach (DataRow recdr in ReceiptDetailTable.Rows)
                {
                    if (deldr["ItemID2"].ToString() == recdr["ItemID2"].ToString() && deldr["ItemID"].ToString() == recdr["ItemID"].ToString() && deldr["App_Count"].ToString() == recdr["App_Count"].ToString() && deldr["ItemHighlight"].ToString() == recdr["ItemHighlight"].ToString())
                    {
                        isDiff = false;
                        goto done;
                    }
                    else
                    {
                        isDiff = true;
                    }
                }
            done:
                if (isDiff)
                {
                    DiffDeliverDT.Rows.Add(deldr.ItemArray);
                }
            }
            foreach (DataRow recdr in ReceiptDetailTable.Rows)
            {
                bool isDiff = false;
                foreach (DataRow deldr in DeliverDetailTable.Rows)
                {
                    if (deldr["ItemID2"].ToString() == recdr["ItemID2"].ToString() && deldr["ItemID"].ToString() == recdr["ItemID"].ToString() && deldr["App_Count"].ToString() == recdr["App_Count"].ToString() && deldr["ItemHighlight"].ToString() == recdr["ItemHighlight"].ToString())
                    {
                        isDiff = false;
                        goto done2;
                    }
                    else
                    {
                        isDiff = true;
                    }
                }
            done2:
                if (isDiff)
                {
                    DiffReceiptDT.Rows.Add(recdr.ItemArray);
                }
            }
        }

        void HighlightItemID()
        {
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
        #endregion

        private void dgvDevilerDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
        }

        private void dgvReceiptDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HighlightItemID();
        }

        private void frmSelectItems_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
