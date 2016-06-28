using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BHair.Business.BaseData;
using BHair.Business;
namespace BHair.Base
{
    public partial class frmConfig : Form
    {
        SetupConfig setupConfig = new SetupConfig();
        /// <summary>系统设置</summary>
        public frmConfig()
        {
            InitializeComponent();
            btnOk.Text = "修改";
            EmailControl.config.GetConfig();

            txtEmailID.Text= EmailControl.config.EmailID;
            txtEmailPwd.Text = EmailControl.config.EmailPwd;
            txtEmailAddress.Text = EmailControl.config.EmailAddress;
            txtEmailSMTP.Text = EmailControl.config.EmailSMTP;
            txtUpperLimit.Value =(decimal)EmailControl.config.UpperLimit;
            
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                EmailControl.config.EmailID = txtEmailID.Text;
                EmailControl.config.EmailPwd = txtEmailPwd.Text;
                EmailControl.config.EmailAddress = txtEmailAddress.Text;
                EmailControl.config.EmailSMTP = txtEmailSMTP.Text;
                EmailControl.config.UpperLimit = (double)txtUpperLimit.Value;
                EmailControl.config.UpdateConfig();
                MessageBox.Show("修改成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
