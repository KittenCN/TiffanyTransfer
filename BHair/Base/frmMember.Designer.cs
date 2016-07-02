namespace BHair.Base
{
    partial class frmMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabMember = new System.Windows.Forms.TabControl();
            this.tabDetail = new System.Windows.Forms.TabPage();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.grpNotNull = new System.Windows.Forms.GroupBox();
            this.cboStore = new System.Windows.Forms.ComboBox();
            this.cbcbStroe = new PresentationControls.CheckBoxComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblAffirm = new System.Windows.Forms.Label();
            this.txtAffirm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.cboCharacter = new System.Windows.Forms.ComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.lblCard = new System.Windows.Forms.Label();
            this.cbIsAdmin = new System.Windows.Forms.CheckBox();
            this.cbIsAble = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabMember.SuspendLayout();
            this.tabDetail.SuspendLayout();
            this.grpNotNull.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(410, 329);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(318, 329);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabMember
            // 
            this.tabMember.Controls.Add(this.tabDetail);
            this.tabMember.Location = new System.Drawing.Point(12, 180);
            this.tabMember.Name = "tabMember";
            this.tabMember.SelectedIndex = 0;
            this.tabMember.Size = new System.Drawing.Size(477, 143);
            this.tabMember.TabIndex = 5;
            // 
            // tabDetail
            // 
            this.tabDetail.Controls.Add(this.txtDepartment);
            this.tabDetail.Controls.Add(this.label3);
            this.tabDetail.Controls.Add(this.txtPosition);
            this.tabDetail.Controls.Add(this.label1);
            this.tabDetail.Controls.Add(this.txtEmail);
            this.tabDetail.Controls.Add(this.lblAddress);
            this.tabDetail.Controls.Add(this.txtTel);
            this.tabDetail.Controls.Add(this.lblPhone);
            this.tabDetail.Location = new System.Drawing.Point(4, 22);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetail.Size = new System.Drawing.Size(469, 117);
            this.tabDetail.TabIndex = 0;
            this.tabDetail.Text = "详细信息(可选)";
            this.tabDetail.UseVisualStyleBackColor = true;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(77, 61);
            this.txtDepartment.MaxLength = 18;
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(151, 21);
            this.txtDepartment.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "部门：";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(77, 37);
            this.txtPosition.MaxLength = 18;
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(151, 21);
            this.txtPosition.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "职位：";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(77, 89);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(231, 21);
            this.txtEmail.TabIndex = 10;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(6, 92);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(71, 12);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Email地址：";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(77, 10);
            this.txtTel.MaxLength = 13;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(80, 21);
            this.txtTel.TabIndex = 8;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(6, 13);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(65, 12);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "联系电话：";
            // 
            // grpNotNull
            // 
            this.grpNotNull.Controls.Add(this.button1);
            this.grpNotNull.Controls.Add(this.cboStore);
            this.grpNotNull.Controls.Add(this.cbcbStroe);
            this.grpNotNull.Controls.Add(this.groupBox1);
            this.grpNotNull.Controls.Add(this.label2);
            this.grpNotNull.Controls.Add(this.txtDetail);
            this.grpNotNull.Controls.Add(this.lblRemark);
            this.grpNotNull.Controls.Add(this.cboCharacter);
            this.grpNotNull.Controls.Add(this.lblLevel);
            this.grpNotNull.Controls.Add(this.txtUserName);
            this.grpNotNull.Controls.Add(this.lblName);
            this.grpNotNull.Controls.Add(this.txtUID);
            this.grpNotNull.Controls.Add(this.lblCard);
            this.grpNotNull.Location = new System.Drawing.Point(12, 12);
            this.grpNotNull.Name = "grpNotNull";
            this.grpNotNull.Size = new System.Drawing.Size(477, 162);
            this.grpNotNull.TabIndex = 4;
            this.grpNotNull.TabStop = false;
            this.grpNotNull.Text = "用户信息(必填)";
            // 
            // cboStore
            // 
            this.cboStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStore.Enabled = false;
            this.cboStore.FormattingEnabled = true;
            this.cboStore.Location = new System.Drawing.Point(159, 74);
            this.cboStore.Name = "cboStore";
            this.cboStore.Size = new System.Drawing.Size(80, 20);
            this.cboStore.TabIndex = 19;
            this.cboStore.Visible = false;
            // 
            // cbcbStroe
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbcbStroe.CheckBoxProperties = checkBoxProperties1;
            this.cbcbStroe.DisplayMemberSingleItem = "";
            this.cbcbStroe.FormattingEnabled = true;
            this.cbcbStroe.Location = new System.Drawing.Point(220, 59);
            this.cbcbStroe.Name = "cbcbStroe";
            this.cbcbStroe.Size = new System.Drawing.Size(80, 20);
            this.cbcbStroe.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.lblAffirm);
            this.groupBox1.Controls.Add(this.txtAffirm);
            this.groupBox1.Location = new System.Drawing.Point(313, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 79);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改密码";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(2, 19);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 12);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "用户密码：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(71, 14);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(83, 21);
            this.txtPassword.TabIndex = 13;
            // 
            // lblAffirm
            // 
            this.lblAffirm.AutoSize = true;
            this.lblAffirm.Location = new System.Drawing.Point(2, 44);
            this.lblAffirm.Name = "lblAffirm";
            this.lblAffirm.Size = new System.Drawing.Size(65, 12);
            this.lblAffirm.TabIndex = 14;
            this.lblAffirm.Text = "确认密码：";
            // 
            // txtAffirm
            // 
            this.txtAffirm.Location = new System.Drawing.Point(71, 41);
            this.txtAffirm.MaxLength = 20;
            this.txtAffirm.Name = "txtAffirm";
            this.txtAffirm.PasswordChar = '*';
            this.txtAffirm.Size = new System.Drawing.Size(83, 21);
            this.txtAffirm.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "所属店面：";
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(73, 130);
            this.txtDetail.MaxLength = 400;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(400, 21);
            this.txtDetail.TabIndex = 17;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(8, 133);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(41, 12);
            this.lblRemark.TabIndex = 16;
            this.lblRemark.Text = "备注：";
            // 
            // cboCharacter
            // 
            this.cboCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCharacter.Enabled = false;
            this.cboCharacter.FormattingEnabled = true;
            this.cboCharacter.Location = new System.Drawing.Point(71, 56);
            this.cboCharacter.Name = "cboCharacter";
            this.cboCharacter.Size = new System.Drawing.Size(80, 20);
            this.cboCharacter.TabIndex = 7;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(6, 60);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(65, 12);
            this.lblLevel.TabIndex = 6;
            this.lblLevel.Text = "用户角色：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(220, 25);
            this.txtUserName.MaxLength = 255;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(80, 21);
            this.txtUserName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(157, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 12);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "用户姓名：";
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(71, 25);
            this.txtUID.MaxLength = 255;
            this.txtUID.Name = "txtUID";
            this.txtUID.ReadOnly = true;
            this.txtUID.Size = new System.Drawing.Size(80, 21);
            this.txtUID.TabIndex = 1;
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(6, 28);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(65, 12);
            this.lblCard.TabIndex = 0;
            this.lblCard.Text = "用户账号：";
            // 
            // cbIsAdmin
            // 
            this.cbIsAdmin.AutoSize = true;
            this.cbIsAdmin.Location = new System.Drawing.Point(20, 330);
            this.cbIsAdmin.Name = "cbIsAdmin";
            this.cbIsAdmin.Size = new System.Drawing.Size(120, 16);
            this.cbIsAdmin.TabIndex = 8;
            this.cbIsAdmin.Text = "是否为超级管理员";
            this.cbIsAdmin.UseVisualStyleBackColor = true;
            this.cbIsAdmin.Visible = false;
            // 
            // cbIsAble
            // 
            this.cbIsAble.AutoSize = true;
            this.cbIsAble.Location = new System.Drawing.Point(171, 330);
            this.cbIsAble.Name = "cbIsAble";
            this.cbIsAble.Size = new System.Drawing.Size(96, 16);
            this.cbIsAble.TabIndex = 9;
            this.cbIsAble.Text = "是否冻结用户";
            this.cbIsAble.UseVisualStyleBackColor = true;
            this.cbIsAble.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "重置密码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 361);
            this.Controls.Add(this.cbIsAble);
            this.Controls.Add(this.cbIsAdmin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabMember);
            this.Controls.Add(this.grpNotNull);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMember";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户信息";
            this.tabMember.ResumeLayout(false);
            this.tabDetail.ResumeLayout(false);
            this.tabDetail.PerformLayout();
            this.grpNotNull.ResumeLayout(false);
            this.grpNotNull.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabMember;
        private System.Windows.Forms.TabPage tabDetail;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.GroupBox grpNotNull;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtAffirm;
        private System.Windows.Forms.Label lblAffirm;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox cboCharacter;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.ComboBox cboStore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbIsAdmin;
        private System.Windows.Forms.CheckBox cbIsAble;
        private PresentationControls.CheckBoxComboBox cbcbStroe;
        private System.Windows.Forms.Button button1;
    }
}