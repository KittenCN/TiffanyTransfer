using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BHair.Business.Table;

namespace BHair.Business
{
    public class BaseProcess
    {
        public Boolean boolCampareOrder(string _ctrlID)
        {
            Boolean boolResult = false;
            DataTable DeliverDetailTable;
            DataTable ReceiptDetailTable;
            DataTable AppDetailTable;
            ApplicationInfo applicationInfo = new ApplicationInfo();
            ApplicationDetail applicationDetail = new ApplicationDetail();
            //dgvDevilerDetails.AutoGenerateColumns = false;
            //dgvReceiptDetails.AutoGenerateColumns = false;
            DeliverDetailTable = applicationDetail.SelectDeliverDetailByCtrlID(_ctrlID);
            ReceiptDetailTable = applicationDetail.SelectReceiptDetailByCtrlID(_ctrlID);
            AppDetailTable = applicationDetail.SelectAppDetailByCtrlID(_ctrlID);
            foreach (DataRow deldr in DeliverDetailTable.Rows)
            {
                foreach (DataRow recdr in ReceiptDetailTable.Rows)
                {
                    if (DeliverDetailTable.Rows.Count == ReceiptDetailTable.Rows.Count && deldr["ItemID2"].ToString() == recdr["ItemID2"].ToString() && deldr["ItemID"].ToString() == recdr["ItemID"].ToString() && deldr["App_Count"].ToString() == recdr["App_Count"].ToString() && deldr["ItemHighlight"].ToString() == recdr["ItemHighlight"].ToString())
                    {
                        boolResult = false;
                        goto done;
                    }
                    else
                    {
                        boolResult = true;
                    }
                }
            done:
                if (boolResult)
                {
                    goto Finish;
                }
            }
            foreach (DataRow recdr in ReceiptDetailTable.Rows)
            {
                foreach (DataRow deldr in DeliverDetailTable.Rows)
                {
                    if (DeliverDetailTable.Rows.Count == ReceiptDetailTable.Rows.Count && deldr["ItemID2"].ToString() == recdr["ItemID2"].ToString() && deldr["ItemID"].ToString() == recdr["ItemID"].ToString() && deldr["App_Count"].ToString() == recdr["App_Count"].ToString() && deldr["ItemHighlight"].ToString() == recdr["ItemHighlight"].ToString())
                    {
                        boolResult = false;
                        goto done2;
                    }
                    else
                    {
                        boolResult = true;
                    }
                }
            done2:
                if (boolResult)
                {
                    goto Finish;
                }
            }
            foreach (DataRow deldr in DeliverDetailTable.Rows)
            {
                foreach (DataRow recdr in AppDetailTable.Rows)
                {
                    if (DeliverDetailTable.Rows.Count == AppDetailTable.Rows.Count && deldr["ItemID2"].ToString() == recdr["ItemID2"].ToString() && deldr["ItemID"].ToString() == recdr["ItemID"].ToString() && deldr["App_Count"].ToString() == recdr["App_Count"].ToString() && deldr["ItemHighlight"].ToString() == recdr["ItemHighlight"].ToString())
                    {
                        boolResult = false;
                        goto done3;
                    }
                    else
                    {
                        boolResult = true;
                    }
                }
            done3:
                if (boolResult)
                {
                    goto Finish;
                }
            }
            foreach (DataRow recdr in AppDetailTable.Rows)
            {
                foreach (DataRow deldr in DeliverDetailTable.Rows)
                {
                    if (DeliverDetailTable.Rows.Count == AppDetailTable.Rows.Count && deldr["ItemID2"].ToString() == recdr["ItemID2"].ToString() && deldr["ItemID"].ToString() == recdr["ItemID"].ToString() && deldr["App_Count"].ToString() == recdr["App_Count"].ToString() && deldr["ItemHighlight"].ToString() == recdr["ItemHighlight"].ToString())
                    {
                        boolResult = false;
                        goto done4;
                    }
                    else
                    {
                        boolResult = true;
                    }
                }
            done4:
                if (boolResult)
                {
                    goto Finish;
                }
            }
        Finish:
            return boolResult;
        }
    }
}
