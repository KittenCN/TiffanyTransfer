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
    public partial class frmAddApplication : WinFormsUI.Docking.DockContent
    {
        DataTable AddApplicationDT;
        ApplicationInfo applicationInfo = new ApplicationInfo();
        ApplicationDetail applicationDetail = new ApplicationDetail();
        /// <summary>申请转货单</summary>
        public frmAddApplication()
        {
            InitializeComponent();
            GetDataTable();
            txtApplicant.Text = Login.LoginUser.UserName;
            txtApplicantPos.Text = Login.LoginUser.Position;
            dtAppDate.Value = DateTime.Now;
            LoadComBox();
            txtCtrlID.Text = "ZH" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Login.LoginUser.UID.Substring(0, 1);

            if (Login.LoginUser.IsAdmin == 1)
            {
                cbDeliverStore.Enabled = true;
                cbRecieveStore.Enabled = true; 
            }
        }

        void GetDataTable()
        {
            AddApplicationDT = applicationDetail.SelectAppDetailByCtrlID("0");
            dgvApplyProducts.AutoGenerateColumns = false;
            dgvApplyProducts.DataSource = AddApplicationDT;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (!Regex.IsMatch(txtCount4.Text, "^[0-9]*$") || txtCount4.Text == "")
            //{
            //    MessageBox.Show("请输入数字");
            //}
            //else
            //{
            //    BaseData.Items items = new BaseData.Items();
            //    DataTable ItemDT = items.SelectItemByItemID(txtItemID.Text);
            //    if (ItemDT.Rows.Count > 0)
            //    {
            //        bool Repeated =false;
            //        foreach(DataRow dr in AddApplicationDT.Rows)
            //        {
            //            if (dr.RowState == DataRowState.Deleted) dr.Delete();
            //            else
            //            {
            //                if (dr["ItemID"].ToString() == txtItemID.Text || dr["ItemID2"].ToString() == txtItemID.Text)
            //                {
            //                    dr["App_Count"] = (int)dr["App_Count"] + (int)numCount.Value;
            //                    Repeated = true;
            //                }
            //            }
            //        }

            //        if (!Repeated)
            //        {
            //            DataRow dr = AddApplicationDT.NewRow();
            //            dr["Department"] = txtDepartment4.Text;
            //            dr["App_Level"] = txtLevel4.Text;
            //            dr["ItemID"] = ItemDT.Rows[0]["ItemID"];
            //            dr["ItemID2"] = ItemDT.Rows[0]["ItemID2"];
            //            dr["Detail"] = ItemDT.Rows[0]["Detail"];
            //            dr["Price"] = ItemDT.Rows[0]["Price"];
            //            dr["App_Count"] = int.Parse(this.numCount.Value.ToString());
            //            dr["IsDelete"] = 0;
            //            AddApplicationDT.Rows.Add(dr);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("货号错误");
            //    }
            //}
            if (txtItemID.Text == "")
            {
                MessageBox.Show("请填写货号");
            }
            else
            {
                BaseData.Items items = new BaseData.Items();
                DataTable ItemDT = items.SelectItemByItemID(txtItemID.Text);
                if (ItemDT.Rows.Count > 0)
                {
                    bool Repeated = false;
                    foreach (DataRow dr in AddApplicationDT.Rows)
                    {
                        if (dr.RowState == DataRowState.Deleted) dr.Delete();
                        else
                        {
                            if (dr["ItemID"].ToString() == txtItemID.Text && dr["ItemHighlight"].ToString() == "1")
                            {
                                dr["App_Count"] = (int)dr["App_Count"] + (int)numCount.Value;
                                Repeated = true;
                            }
                            if (dr["ItemID2"].ToString() == txtItemID.Text && dr["ItemHighlight"].ToString() == "2")
                            {
                                dr["App_Count"] = (int)dr["App_Count"] + (int)numCount.Value;
                                Repeated = true;
                            }
                        }
                    }

                    if (!Repeated)
                    {
                        if(AddApplicationDT.Rows.Count<20)
                        {
                            DataRow dr = AddApplicationDT.NewRow();
                            dr["CtrlID"] = txtCtrlID.Text;
                            //dr["Department"] = txtDepartment4.Text;
                            //dr["App_Level"] = txtLevel4.Text;
                            dr["ItemID"] = ItemDT.Rows[0]["ItemID"];
                            dr["ItemID2"] = ItemDT.Rows[0]["ItemID2"];
                            dr["Detail"] = ItemDT.Rows[0]["Detail"];
                            dr["Price"] = ItemDT.Rows[0]["Price"];
                            dr["Department"] = ItemDT.Rows[0]["Department"];
                            dr["App_Level"] = ItemDT.Rows[0]["Class"];
                            dr["App_Count"] = int.Parse(this.numCount.Value.ToString());
                            dr["IsDelete"] = 0;
                            if (dr["ItemID"].ToString() == txtItemID.Text) dr["ItemHighlight"] = 1;
                            else if (dr["ItemID2"].ToString() == txtItemID.Text) dr["ItemHighlight"] = 2;
                            AddApplicationDT.Rows.Add(dr);
                            HighlightItemID();
                        }
                        else
                        {
                            MessageBox.Show("添加失败,每张转货单,只允许20条记录!");
                        }
                    }
                    txtItemID.Text = "";
                    txtItemID.Focus();
                }
                else
                {
                    MessageBox.Show("货号错误");
                    txtItemID.Text = "";
                    txtItemID.Focus();
                }
            }
        }

        private void BtnSubmitAddApp_Click(object sender, EventArgs e)
        {
            BaseData.Store store = new BaseData.Store();
            //if (store.SelectStoreInfoByStoreName(txtDeliverStore4.Text).Rows.Count == 0 || store.SelectStoreInfoByStoreName(txtReceiptStore4.Text).Rows.Count == 0)
            //{
            //    MessageBox.Show("收发店铺名错误");
            //}
            if (AddApplicationDT.Rows.Count == 0)
            {
                MessageBox.Show("申请表中未添加转货内容");
            }
            else if (txtCtrlID.Text == null || txtCtrlID.Text.Length == 0)
            {
                MessageBox.Show("请填写控制单号");
            }
            else if (cbDeliverStore.SelectedItem.ToString() == cbRecieveStore.SelectedItem.ToString())
            {
                MessageBox.Show("收发店面相同，无法添加");
            }
            else
            {
                int TotalCount = 0;
                double TotalPrice = 0;
                DataTable AddAppInfoDT = applicationInfo.SelectApplicationByCtrlID("0");
                DataRow dr = AddAppInfoDT.NewRow();
                dr["CtrlID"] = txtCtrlID.Text;
                dr["DeliverStore"] = cbDeliverStore.SelectedItem.ToString();
                dr["ReceiptStore"] = cbRecieveStore.SelectedItem.ToString();
                dr["ApplicantsDate"] = DateTime.Now;
                dr["ApplicantsName"] = txtApplicant.Text;
                dr["ApplicantsPos"] = txtApplicantPos.Text;
                dr["Applicants"] = Login.LoginUser.UID;
                dr["Alert_Approval"] = 0;
                dr["Alert_Deliver"] = 0;
                dr["Alert_Receipt"] = 0;
                dr["ExchangeType"] = cboExchangeType.SelectedItem.ToString();
                foreach (DataRow addDr in AddApplicationDT.Rows)
                {
                    addDr["CtrlID"] = dr["CtrlID"];
                    TotalCount += (int)addDr["App_Count"];
                    TotalPrice += ((int)addDr["App_Count"]) * ((double.Parse(addDr["Price"].ToString())));
                }
                dr["TotalCount"] = TotalCount;
                dr["TotalPrice"] = TotalPrice;
                AddAppInfoDT.Rows.Add(dr);

                if (TotalPrice > EmailControl.config.UpperLimit)
                {
                    DialogResult dres = MessageBox.Show("超出限额，是否继续提交？", "消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dres == DialogResult.OK)
                    {
                        try
                        {
                            applicationInfo.SubmitApplicationInfo(AddAppInfoDT);
                            applicationDetail.SubmitApplicationDetail(AddApplicationDT);
                            Thread thread = new Thread(new ThreadStart(SendEmail));
                            thread.Start();
                            MessageBox.Show("提交成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("提交失败，错误信息：" + ex.Message);
                        }
                    }
                }
                else
                {
                    try
                    {
                        applicationInfo.SubmitApplicationInfo(AddAppInfoDT);
                        applicationDetail.SubmitApplicationDetail(AddApplicationDT);
                        Thread thread = new Thread(new ThreadStart(SendEmail));
                        thread.Start();
                        MessageBox.Show("提交成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("提交失败，错误信息：" + ex.Message);
                    }
                }

            }
        }

        void SendEmail()
        {
            EmailControl.ToApplicantSubmit(txtCtrlID.Text, Login.LoginUser.UserName, dtAppDate.Value.ToString());
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvApplyProducts.SelectedRows.Count > 0)
            {
                dgvApplyProducts.Rows.Remove(dgvApplyProducts.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("请选中整行数据", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void LoadComBox()
        {

            BaseData.Store store = new BaseData.Store();
            store.StoreDT = store.SelectAllStoreInfo();
            foreach (DataRow dr in store.StoreDT.Rows)
            {
                cbDeliverStore.Items.Add(dr["StoreName"].ToString());
            }
            if (cbDeliverStore.Items.Count > 0)
            {
                //cbDeliverStore.SelectedItem = Login.LoginUser.Store;
                cbDeliverStore.SelectedIndex = 0;
            }
            //foreach (DataRow dr in store.StoreDT.Rows)
            //{
            //    cbRecieveStore.Items.Add(dr["StoreName"].ToString());
            //}
            //if (cbRecieveStore.Items.Count > 0)
            //{
            //    //cbRecieveStore.SelectedIndex = 0;
            //    cbRecieveStore.SelectedItem = Login.LoginUser.Store;
            //}
            string[] strStoreTemp =Login.LoginUser.Store.ToString().Split(',');
            if(strStoreTemp[0]!="" && strStoreTemp[0]!=null && strStoreTemp.Length>1)
            {
                for (int i = 0; i < strStoreTemp.Length; i++)
                {
                    if (strStoreTemp[i].ToString() != null && strStoreTemp[i].ToString() != "")
                    {
                        cbRecieveStore.Items.Add(strStoreTemp[i].ToString());
                    }
                        
                }
            }
            else
            {
                cbRecieveStore.Items.Add(strStoreTemp[0]);
            }
            if(cbRecieveStore.Items.Count>0)
            {
                cbRecieveStore.SelectedIndex = 0;
            }
            cboExchangeType.Items.Add("N/A");
            cboExchangeType.Items.Add("新店预留");
            cboExchangeType.Items.Add("Pull Back");
            cboExchangeType.SelectedIndex = 0;
        }

        private void cbRecieveStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDeliverStore.SelectedItem != null && cbRecieveStore.SelectedItem!=null && cbDeliverStore.SelectedItem.ToString() == cbRecieveStore.SelectedItem.ToString())
            {
                //MessageBox.Show("收发店铺相同，请重新选择", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (object obj in cbRecieveStore.Items)
                {
                    if (obj.ToString() != cbRecieveStore.SelectedItem.ToString())
                    {
                        cbDeliverStore.SelectedItem = obj;
                    }
                }
            }
        }

        void HighlightItemID()
        {
            foreach (DataGridViewRow dgvr in dgvApplyProducts.Rows)
            {
                if (dgvr.Cells["ItemHighlight"].Value.ToString() == "1")
                {
                    dgvr.Cells["number"].Style.ForeColor = Color.Red;
                }
                if (dgvr.Cells["ItemHighlight"].Value.ToString() == "2")
                {
                    dgvr.Cells["doubleNumber"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void txtItemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                
            }
        }

        private void frmAddApplication_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
