using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsUI.Docking;
using BHair.Base;
using BHair.Business;
using BHair.SystemSet;
using BHair.Business.Table;

namespace BHair
{

    public partial class frmMain : Form
    {
        ApplicationInfo applicationInfo = new ApplicationInfo();
        public frmMain()
        {
            InitializeComponent();
            this.Text = "内部转货系统 " + " V " + Application.ProductVersion + " 最后编译时间 " + System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location);

            this.tssrMain_Timer.Text = DateTime.Now.ToString();
            this.dPanelMain_AutoSize();

            //toolStripButton4.Visible = false;
            //toolStripButton5.Visible = false;
            //toolStripSeparator2.Visible = false;

            menuMain_Table.Visible = false;

            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.InitMenu();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //frmPays_List objfrmPaysList = new frmPays_List();
            //this.ShowWindows_Click(objfrmPaysList);
            if (Login.LoginUser.Character == 1)
            {
                timer1.Enabled = true;
                timer1.Interval = 43200000;
            }
            else
            {
                timer1.Enabled = false;
            }
            //this.TopMost = false;

        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            this.dPanelMain_AutoSize();
        }

        private void dPanelMain_AutoSize()
        {
            this.dPanelMain.Width = this.ClientSize.Width;
            this.dPanelMain.Height = this.ClientSize.Height - 45;
        }

        #region 检查选项卡是否存在...

        /// <summary>检查选项卡是否存在。</summary>
        /// <param name="text">选项卡名称</param>
        /// <returns></returns>
        private IDockContent FindTab(string text)
        {
            if (this.dPanelMain.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                {
                    if (form.Text == text)
                    {
                        return form as IDockContent;
                    }
                }
            }
            else
            {
                foreach (IDockContent content in this.dPanelMain.Documents)
                {
                    if (content.DockHandler.TabText == text)
                    {
                        return content;
                    }
                }
            }
            return null;
        }

        #endregion

        #region 打开选项卡窗体..

        /// <summary>打开窗体</summary>
        /// <param name="form">窗体实例</param>
        private void ShowWindows_Click(DockContent form)
        {
            string strText = form.Text;
            if (this.FindTab(strText) == null)
            {
                form.Show(this.dPanelMain);
            }
            else
            {
                this.FindTab(strText).DockHandler.Show();
            }
        }

        #endregion

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            this.tssrMain_Timer.Text = DateTime.Now.ToString();
        }

        #region 日常操作...


        private void menuMain_System_Member_Click(object sender, EventArgs e)
        {
            frmMember_List objfrmMemberList = new frmMember_List();
            this.ShowWindows_Click(objfrmMemberList);
        }


        #endregion



        #region 转货流程

        /// <summary>
        /// 申请转货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Flow_add_Click(object sender, EventArgs e)
        {
            frmAddApplication objfrmAddApp = new frmAddApplication();
            objfrmAddApp.Show();
        }

        /// <summary>
        /// 店面申请单状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Manage_StoreApp_Click(object sender, EventArgs e)
        {
            frmStoreApp objfrmStoreApp = new frmStoreApp();
            this.ShowWindows_Click(objfrmStoreApp);
        }

        /// <summary>
        /// 财务部审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Manage_Approval2App_Click(object sender, EventArgs e)
        {
            frmAppAproval2 objfrmAppAproval2 = new frmAppAproval2();
            this.ShowWindows_Click(objfrmAppAproval2);
        }

        /// <summary>
        /// 商品部审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Manage_ApprovalApp_Click(object sender, EventArgs e)
        {
            frmAppAproval objfrmAppAproval = new frmAppAproval();
            this.ShowWindows_Click(objfrmAppAproval);
        }

        private void 物流确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppDone objfrmAppDone = new frmAppDone();
            this.ShowWindows_Click(objfrmAppDone);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 历史查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Manage_History_Click(object sender, EventArgs e)
        {
            frmHistoryInfo objfrmHisApp = new frmHistoryInfo();
            this.ShowWindows_Click(objfrmHisApp);
        }

        /// <summary>
        /// 转货报表查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmApplicationReport objfrmApplicationReport = new frmApplicationReport();
            this.ShowWindows_Click(objfrmApplicationReport);
        }

        #endregion




        #region 统计报表...



        /// <summary>员工工资统计</summary>
        private void menuMain_Table_Salary_Click(object sender, EventArgs e)
        {
            //frmSalary objfrmSalary = new frmSalary();
            //this.ShowWindows_Click(objfrmSalary);
        }



        #endregion

        #region 系统维护...

        /// <summary>商品信息管理</summary>
        private void menuMain_System_Item_Click(object sender, EventArgs e)
        {
            frmItem_List objfrmItemsList = new frmItem_List();
            this.ShowWindows_Click(objfrmItemsList);
        }

        /// <summary>
        /// 店面管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_Manage_Store_Click(object sender, EventArgs e)
        {
            frmStore_List objfrmStoreList = new frmStore_List();
            this.ShowWindows_Click(objfrmStoreList);
        }




        /// <summary>系统设置</summary>
        private void menuMain_System_Config_Click(object sender, EventArgs e)
        {
            Login objfrmLogin = new Login();
            CloseAllTab();
            if (objfrmLogin.ShowDialog() == DialogResult.OK)
            {
                this.InitMenu();
            }
        }

        private void menuMain_System_Log_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMain_System_Pwd_Click(object sender, EventArgs e)
        {
            frmMember objfrmMember = new frmMember(Login.LoginUser.UID);
            objfrmMember.Show();
        }

        /// <summary>退出</summary>
        private void menuMain_System_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            menuMain_System_Member_Click(null, null);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            menuMain_Manage_History_Click(null, null);
        }

        /// <summary>
        /// 申请转货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            menuMain_Flow_add_Click(null, null);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            menuMain_Table_Salary_Click(null, null);
        }



        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            menuMain_System_Item_Click(null, null);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            menuMain_System_Config_Click(null, null);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            menuMain_Manage_StoreApp_Click(null, null);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            物流确认ToolStripMenuItem_Click(null, null);
        }
        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            menuMain_Manage_ApprovalApp_Click(null, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            menuMain_Manage_Approval2App_Click(null, null);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            toolStripMenuItem3_Click(null, null);
        }

        private void 登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            CloseAllTab();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.InitMenu();
            }
        }

        private void menuMain_System_SetupConfig_Click(object sender, EventArgs e)
        {
            frmConfig fc = new frmConfig();
            fc.Show();
        }

        bool IsLogin()
        {
            if (Login.LoginUser.UID != null && Login.LoginUser.UID != "")
            {

                return true;
            }
            else
            {
                MessageBox.Show("请先登录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        #region
        /// <summary>
        /// 权限按钮
        /// </summary>
        void InitMenu()
        {
            if (Login.LoginUser.UID == null || Login.LoginUser.UID == "")
            {
                menuMain_Flow_add.Visible = false;
                menuMain_Manage_StoreApp.Visible = false;
                menuMain_Manage_Approval2App.Visible = false;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = false;
                menuMain_System_SetupConfig.Visible = false;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                物流确认ToolStripMenuItem.Visible = false;
                toolStripMenuItem3.Visible = false;

                toolStripButton4.Visible = false;
                toolStripButton12.Visible = false;
                toolStripButton1.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton13.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = false;
                tsBTNDataProcessing.Visible = false;
            }
            else if (Login.LoginUser.Character == 1)    //商品部
            {
                menuMain_Flow_add.Visible = true;
                menuMain_Manage_StoreApp.Visible = true;
                menuMain_Manage_Approval2App.Visible = true;
                menuMain_Manage_ApprovalApp.Visible = true;
                menuMain_Manage_History.Visible = true;
                toolStripMenuItem3.Visible = true;

                if (Login.LoginUser.IsAdmin == 1)
                {
                    menuMain_System_Member.Visible = true;
                    menuMain_Manage_Store.Visible = true;
                    menuMain_System_SetupConfig.Visible = true;
                    menuMain_System_Item.Visible = true;
                    menuMain_System_Log.Visible = false;
                    //toolStripButton8.Visible = true;
                    toolStripButton2.Visible = true;
                    物流确认ToolStripMenuItem.Visible = true;
                    toolStripButton13.Visible = true;
                }
                else
                {
                    menuMain_System_Member.Visible = false;
                    menuMain_Manage_Store.Visible = false;
                    menuMain_System_Item.Visible = false;
                    menuMain_System_Log.Visible = false;
                    //toolStripButton8.Visible = false;
                    toolStripButton2.Visible = false;
                    tsBTNDataProcessing.Visible = false;
                }

                toolStripButton4.Visible = true;
                toolStripButton12.Visible = true;
                toolStripButton1.Visible = true;
                toolStripButton3.Visible = true;
                toolStripButton5.Visible = true;
                toolStripButton6.Visible = true;
                toolStripButton8.Visible = true;
                tsBTNDataProcessing.Visible = false;

                menuMain_Manage_ApprovalApp_Click(null, null);//商品部审核窗口
            }
            else if (Login.LoginUser.Character == 2)
            {
                menuMain_Flow_add.Visible = false;
                menuMain_Manage_StoreApp.Visible = false;
                menuMain_Manage_Approval2App.Visible = true;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = false;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                物流确认ToolStripMenuItem.Visible = false;
                toolStripMenuItem3.Visible = false;
                menuMain_System_SetupConfig.Visible = false;

                toolStripButton4.Visible = false;
                toolStripButton12.Visible = false;
                toolStripButton1.Visible = true;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton13.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = false;
                tsBTNDataProcessing.Visible = false;

                menuMain_Manage_Approval2App_Click(null, null);//财务审核窗口
            }
            else if (Login.LoginUser.Character == 3)
            {
                menuMain_Flow_add.Visible = true;
                menuMain_Manage_StoreApp.Visible = true;
                menuMain_Manage_Approval2App.Visible = false;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = false;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                物流确认ToolStripMenuItem.Visible = false;
                toolStripMenuItem3.Visible = false;
                menuMain_System_SetupConfig.Visible = false;

                toolStripButton4.Visible = true;
                toolStripButton12.Visible = true;
                toolStripButton1.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton13.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = true;
                tsBTNDataProcessing.Visible = false;

                menuMain_Manage_StoreApp_Click(null, null);//打开店面申请状态窗口
            }
            else if (Login.LoginUser.Character == 4)
            {
                toolStripButton5.Text = "单据修改";
                toolStripButton5.ToolTipText = "单据修改";

                menuMain_Flow_add.Visible = false;
                menuMain_Manage_StoreApp.Visible = false;
                menuMain_Manage_Approval2App.Visible = false;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = false;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                物流确认ToolStripMenuItem.Visible = true;
                toolStripMenuItem3.Visible = false;
                menuMain_System_SetupConfig.Visible = false;

                toolStripButton4.Visible = false;
                toolStripButton12.Visible = false;
                toolStripButton1.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton13.Visible = true;
                toolStripButton5.Visible = true;    //物流部能修改单据 2016.8.29
                toolStripButton6.Visible = false;
                tsBTNDataProcessing.Visible = false;

                物流确认ToolStripMenuItem_Click(null, null);//物流确认窗口
            }
            else
            {
                menuMain_Flow_add.Visible = false;
                menuMain_Manage_StoreApp.Visible = false;
                menuMain_Manage_Approval2App.Visible = false;
                menuMain_Manage_ApprovalApp.Visible = false;
                menuMain_Manage_History.Visible = false;
                menuMain_System_Member.Visible = false;
                menuMain_Manage_Store.Visible = false;
                menuMain_System_Item.Visible = false;
                menuMain_System_Log.Visible = false;
                物流确认ToolStripMenuItem.Visible = false;
                toolStripMenuItem3.Visible = false;
                menuMain_System_SetupConfig.Visible = false;

                toolStripButton4.Visible = false;
                toolStripButton12.Visible = false;
                toolStripButton1.Visible = false;
                toolStripButton13.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton8.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = false;
                tsBTNDataProcessing.Visible = false;
            }
            if (Login.LoginUser.UID == "Administrator")
            {
                menuMain_Flow_add.Visible = true;
                menuMain_Manage_StoreApp.Visible = true;
                menuMain_Manage_Approval2App.Visible = true;
                menuMain_Manage_ApprovalApp.Visible = true;
                menuMain_Manage_History.Visible = true;
                toolStripMenuItem3.Visible = true;
                menuMain_System_Member.Visible = true;
                menuMain_Manage_Store.Visible = true;
                menuMain_System_SetupConfig.Visible = true;
                menuMain_System_Item.Visible = true;
                menuMain_System_Log.Visible = false;
                //toolStripButton8.Visible = true;
                toolStripButton2.Visible = true;
                物流确认ToolStripMenuItem.Visible = true;
                toolStripButton13.Visible = true;
                toolStripButton4.Visible = true;
                toolStripButton12.Visible = true;
                toolStripButton1.Visible = true;
                toolStripButton3.Visible = true;
                toolStripButton5.Visible = true;
                toolStripButton6.Visible = true;
                toolStripButton8.Visible = true;
                tsBTNDataProcessing.Visible = true;
            }
        }
        #endregion

        void CloseAllTab()
        {
            IDockContent[] documents = this.dPanelMain.DocumentsToArray();
            foreach (IDockContent content in documents)
            {
                content.DockHandler.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //申请批准后超时提醒
            DataTable alertApprovalDT = applicationInfo.SelectAlertApproval(Login.LoginUser.Store);
            if (alertApprovalDT.Rows.Count > 0)
            {
                foreach (DataRow dr in alertApprovalDT.Rows)
                {
                    try
                    {
                        EmailControl.ToAlertApproval(dr["CtrlID"].ToString(), dr["ApplicantsName"].ToString(), dr["ApplicantsDate"].ToString(), dr["DeliverStore"].ToString());
                        applicationInfo.FinishAlertApproval(dr["CtrlID"].ToString());
                    }
                    catch
                    {

                    }
                }
            }
            //发货后超时提醒
            DataTable alertDeliverDT = applicationInfo.SelectAlertApproval(Login.LoginUser.Store);
            if (alertApprovalDT.Rows.Count > 0)
            {
                foreach (DataRow dr in alertApprovalDT.Rows)
                {
                    try
                    {
                        EmailControl.ToAlertDeliver(dr["CtrlID"].ToString(), dr["ApplicantsName"].ToString(), dr["ApplicantsDate"].ToString(), dr["DeliverStore"].ToString(), dr["ReceiptStore"].ToString());
                        applicationInfo.FinishAlertDeliver(dr["CtrlID"].ToString());
                    }
                    catch
                    {

                    }
                }
            }

            //收货后超时提醒
            DataTable alertReceiptDT = applicationInfo.SelectAlertReceipt(Login.LoginUser.Store);
            if (alertApprovalDT.Rows.Count > 0)
            {
                foreach (DataRow dr in alertApprovalDT.Rows)
                {
                    try
                    {
                        EmailControl.ToAlertReceipt(dr["CtrlID"].ToString(), dr["ApplicantsName"].ToString(), dr["ApplicantsDate"].ToString(), dr["DeliverStore"].ToString(), dr["ReceiptStore"].ToString());
                        applicationInfo.FinishAlertReceipt(dr["CtrlID"].ToString());
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void tsBTNDataProcessing_Click(object sender, EventArgs e)
        {
            //frmAddApplication objfrmAddApp = new frmAddApplication();
            //objfrmAddApp.Show();
            frmDataProcessing objfrmDP = new Business.frmDataProcessing();
            objfrmDP.Show();
        }
    }
}
