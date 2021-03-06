﻿using System;
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
    public partial class frmSelectItems_App : Form
    {
        private string _ctrlID = "";
        public DataTable DeliverDetailTable;
        public DataTable AppDetailTable;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        public DataTable DiffDeliverDT;
        public DataTable DiffAppDT;

        private string _store = "";

        ApplicationDetail CurrentItems = new ApplicationDetail();   //当前订单详情

        private bool bRun = false;

        public frmSelectItems_App()
        {
            InitializeComponent();
            GetApplicationDetail();
        }

        public frmSelectItems_App(string CtrlID)
        {
            InitializeComponent();
            this._ctrlID = CtrlID;
            GetApplicationDetail();
        }



        #region 加载商品信息列表...
        public void GetApplicationDetail()
        {
            dgvDevilerDetails.AutoGenerateColumns = false;
            dgvAppDetails.AutoGenerateColumns = false;
            DeliverDetailTable = applicationDetail.SelectDeliverDetailByCtrlID(_ctrlID);
            AppDetailTable = applicationDetail.SelectAppDetailByCtrlID(_ctrlID);
            DiffDeliverDT = DeliverDetailTable.Clone();
            DiffAppDT = AppDetailTable.Clone();
            dgvDevilerDetails.DataSource = DiffDeliverDT;
            dgvAppDetails.DataSource = DiffAppDT;
            string[] strIDs = new string[50];
            int i = 0;

            foreach (DataRow deldr in DeliverDetailTable.Rows)
            {
                bool isDiff = false;
                if (AppDetailTable.Rows.Count != 0)
                {
                    foreach (DataRow recdr in AppDetailTable.Rows)
                    {
                        if (deldr["ItemID2"].ToString() == recdr["ItemID2"].ToString() && deldr["ItemID"].ToString() == recdr["ItemID"].ToString() && deldr["App_Count"].ToString() == recdr["App_Count"].ToString() && deldr["ItemHighlight"].ToString() == recdr["ItemHighlight"].ToString())
                        {
                            if (Array.IndexOf<string>(strIDs, recdr["ID"].ToString()) == -1)
                            {
                                i++;
                                strIDs[i] = recdr["ID"].ToString();
                                isDiff = false;
                                goto done;
                            }
                            else
                            {
                                isDiff = true;
                            }
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
                else
                {
                    isDiff = true;
                    DiffDeliverDT.Rows.Add(deldr.ItemArray);
                }
            }
            strIDs = new string[50];
            i = 0;
            foreach (DataRow recdr in AppDetailTable.Rows)
            {
                bool isDiff = false;
                if (DeliverDetailTable.Rows.Count != 0)
                {
                    foreach (DataRow deldr in DeliverDetailTable.Rows)
                    {
                        if (deldr["ItemID2"].ToString() == recdr["ItemID2"].ToString() && deldr["ItemID"].ToString() == recdr["ItemID"].ToString() && deldr["App_Count"].ToString() == recdr["App_Count"].ToString() && deldr["ItemHighlight"].ToString() == recdr["ItemHighlight"].ToString())
                        {
                            if (Array.IndexOf<string>(strIDs, deldr["ID"].ToString()) == -1)
                            {
                                i++;
                                strIDs[i] = deldr["ID"].ToString();
                                isDiff = false;
                                goto done2;
                            }
                            else
                            {
                                isDiff = true;
                            }
                        }
                        else
                        {
                            isDiff = true;
                        }
                    }
                done2:
                    if (isDiff)
                    {
                        DiffAppDT.Rows.Add(recdr.ItemArray);
                    }
                }
                else
                {
                    isDiff = true;
                    DiffAppDT.Rows.Add(recdr.ItemArray);
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
            foreach (DataGridViewRow dgvr in dgvAppDetails.Rows)
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

        private void frmSelectItems_App_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
