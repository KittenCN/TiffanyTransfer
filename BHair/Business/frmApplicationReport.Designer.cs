namespace BHair.Business
{
    partial class frmApplicationReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAppDetail = new System.Windows.Forms.DataGridView();
            this.CtrlID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicantsDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliverStore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptStore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.App_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliverDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicantsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicantsPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApprovalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApprovalName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliverChecker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliverCheckerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptChecker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptCheckerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApprovalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApprovalDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_O = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_O = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_Num1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_Num2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtO_O_Str = new System.Windows.Forms.TextBox();
            this.txtO_O = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtS_O_Str = new System.Windows.Forms.TextBox();
            this.txtS_O = new System.Windows.Forms.ComboBox();
            this.txtReceiptStore = new System.Windows.Forms.ComboBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeliverStore = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBatch_Num2 = new System.Windows.Forms.TextBox();
            this.txtBatch_Num1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOutExcel = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvAppDetail);
            this.panel1.Location = new System.Drawing.Point(12, 197);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 232);
            this.panel1.TabIndex = 0;
            // 
            // dgvAppDetail
            // 
            this.dgvAppDetail.AllowUserToAddRows = false;
            this.dgvAppDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CtrlID,
            this.ApplicantsDate,
            this.DeliverStore,
            this.ReceiptStore,
            this.ItemID,
            this.ItemID2,
            this.Detail,
            this.Price,
            this.App_Count,
            this.TotalPrice,
            this.ReceiptDate,
            this.DeliverDate,
            this.ApplicantsName,
            this.ApplicantsPos,
            this.ApprovalName,
            this.ApprovalName2,
            this.DeliverChecker,
            this.DeliverCheckerName,
            this.ReceiptChecker,
            this.ReceiptCheckerName,
            this.ApprovalDate,
            this.ApprovalDate2,
            this.S_O,
            this.O_O,
            this.Batch_Num1,
            this.Batch_Num2});
            this.dgvAppDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAppDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvAppDetail.Name = "dgvAppDetail";
            this.dgvAppDetail.RowTemplate.Height = 23;
            this.dgvAppDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppDetail.Size = new System.Drawing.Size(832, 232);
            this.dgvAppDetail.TabIndex = 0;
            this.dgvAppDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppDetail_CellClick);
            this.dgvAppDetail.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAppDetail_CellMouseDoubleClick);
            // 
            // CtrlID
            // 
            this.CtrlID.DataPropertyName = "ApplicationDetail.CtrlID";
            this.CtrlID.HeaderText = "控制号";
            this.CtrlID.Name = "CtrlID";
            this.CtrlID.ReadOnly = true;
            // 
            // ApplicantsDate
            // 
            this.ApplicantsDate.DataPropertyName = "ApplicantsDate";
            this.ApplicantsDate.HeaderText = "申请日期";
            this.ApplicantsDate.Name = "ApplicantsDate";
            this.ApplicantsDate.ReadOnly = true;
            // 
            // DeliverStore
            // 
            this.DeliverStore.DataPropertyName = "DeliverStore";
            this.DeliverStore.HeaderText = "发货店铺";
            this.DeliverStore.Name = "DeliverStore";
            this.DeliverStore.ReadOnly = true;
            // 
            // ReceiptStore
            // 
            this.ReceiptStore.DataPropertyName = "ReceiptStore";
            this.ReceiptStore.HeaderText = "收货店铺";
            this.ReceiptStore.Name = "ReceiptStore";
            this.ReceiptStore.ReadOnly = true;
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "ItemID";
            this.ItemID.HeaderText = "货号";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            // 
            // ItemID2
            // 
            this.ItemID2.DataPropertyName = "ItemID2";
            this.ItemID2.HeaderText = "双货号";
            this.ItemID2.Name = "ItemID2";
            this.ItemID2.ReadOnly = true;
            // 
            // Detail
            // 
            this.Detail.DataPropertyName = "Detail";
            this.Detail.HeaderText = "产品描述";
            this.Detail.Name = "Detail";
            this.Detail.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // App_Count
            // 
            this.App_Count.DataPropertyName = "App_Count";
            this.App_Count.HeaderText = "数量";
            this.App_Count.Name = "App_Count";
            this.App_Count.ReadOnly = true;
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "总价";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            // 
            // ReceiptDate
            // 
            this.ReceiptDate.DataPropertyName = "ReceiptDate";
            this.ReceiptDate.HeaderText = "ReceiptDate";
            this.ReceiptDate.Name = "ReceiptDate";
            this.ReceiptDate.ReadOnly = true;
            this.ReceiptDate.Visible = false;
            // 
            // DeliverDate
            // 
            this.DeliverDate.DataPropertyName = "DeliverDate";
            this.DeliverDate.HeaderText = "DeliverDate";
            this.DeliverDate.Name = "DeliverDate";
            this.DeliverDate.ReadOnly = true;
            this.DeliverDate.Visible = false;
            // 
            // ApplicantsName
            // 
            this.ApplicantsName.DataPropertyName = "ApplicantsName";
            this.ApplicantsName.HeaderText = "ApplicantsName";
            this.ApplicantsName.Name = "ApplicantsName";
            this.ApplicantsName.ReadOnly = true;
            this.ApplicantsName.Visible = false;
            // 
            // ApplicantsPos
            // 
            this.ApplicantsPos.DataPropertyName = "ApplicantsPos";
            this.ApplicantsPos.HeaderText = "ApplicantsPos";
            this.ApplicantsPos.Name = "ApplicantsPos";
            this.ApplicantsPos.ReadOnly = true;
            this.ApplicantsPos.Visible = false;
            // 
            // ApprovalName
            // 
            this.ApprovalName.DataPropertyName = "ApprovalName";
            this.ApprovalName.HeaderText = "ApprovalName";
            this.ApprovalName.Name = "ApprovalName";
            this.ApprovalName.ReadOnly = true;
            this.ApprovalName.Visible = false;
            // 
            // ApprovalName2
            // 
            this.ApprovalName2.DataPropertyName = "ApprovalName2";
            this.ApprovalName2.HeaderText = "ApprovalName2";
            this.ApprovalName2.Name = "ApprovalName2";
            this.ApprovalName2.ReadOnly = true;
            this.ApprovalName2.Visible = false;
            // 
            // DeliverChecker
            // 
            this.DeliverChecker.DataPropertyName = "DeliverChecker";
            this.DeliverChecker.HeaderText = "DeliverChecker";
            this.DeliverChecker.Name = "DeliverChecker";
            this.DeliverChecker.ReadOnly = true;
            this.DeliverChecker.Visible = false;
            // 
            // DeliverCheckerName
            // 
            this.DeliverCheckerName.DataPropertyName = "DeliverCheckerName";
            this.DeliverCheckerName.HeaderText = "DeliverCheckerName";
            this.DeliverCheckerName.Name = "DeliverCheckerName";
            this.DeliverCheckerName.ReadOnly = true;
            this.DeliverCheckerName.Visible = false;
            // 
            // ReceiptChecker
            // 
            this.ReceiptChecker.DataPropertyName = "ReceiptChecker";
            this.ReceiptChecker.HeaderText = "ReceiptChecker";
            this.ReceiptChecker.Name = "ReceiptChecker";
            this.ReceiptChecker.ReadOnly = true;
            this.ReceiptChecker.Visible = false;
            // 
            // ReceiptCheckerName
            // 
            this.ReceiptCheckerName.DataPropertyName = "ReceiptCheckerName";
            this.ReceiptCheckerName.HeaderText = "ReceiptCheckerName";
            this.ReceiptCheckerName.Name = "ReceiptCheckerName";
            this.ReceiptCheckerName.ReadOnly = true;
            this.ReceiptCheckerName.Visible = false;
            // 
            // ApprovalDate
            // 
            this.ApprovalDate.DataPropertyName = "ApprovalDate";
            this.ApprovalDate.HeaderText = "ApprovalDate";
            this.ApprovalDate.Name = "ApprovalDate";
            this.ApprovalDate.ReadOnly = true;
            this.ApprovalDate.Visible = false;
            // 
            // ApprovalDate2
            // 
            this.ApprovalDate2.DataPropertyName = "ApprovalDate2";
            this.ApprovalDate2.HeaderText = "ApprovalDate2";
            this.ApprovalDate2.Name = "ApprovalDate2";
            this.ApprovalDate2.ReadOnly = true;
            this.ApprovalDate2.Visible = false;
            // 
            // S_O
            // 
            this.S_O.DataPropertyName = "S_O";
            this.S_O.HeaderText = "S_O";
            this.S_O.Name = "S_O";
            this.S_O.ReadOnly = true;
            this.S_O.Visible = false;
            // 
            // O_O
            // 
            this.O_O.DataPropertyName = "O_O";
            this.O_O.HeaderText = "O_O";
            this.O_O.Name = "O_O";
            this.O_O.ReadOnly = true;
            this.O_O.Visible = false;
            // 
            // Batch_Num1
            // 
            this.Batch_Num1.DataPropertyName = "Batch_Num1";
            this.Batch_Num1.HeaderText = "Batch_Num1";
            this.Batch_Num1.Name = "Batch_Num1";
            this.Batch_Num1.ReadOnly = true;
            this.Batch_Num1.Visible = false;
            // 
            // Batch_Num2
            // 
            this.Batch_Num2.DataPropertyName = "Batch_Num2";
            this.Batch_Num2.HeaderText = "Batch_Num2";
            this.Batch_Num2.Name = "Batch_Num2";
            this.Batch_Num2.ReadOnly = true;
            this.Batch_Num2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtReceiptStore, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtItemID, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDeliverStore, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtBatch_Num2, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtBatch_Num1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(819, 124);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtO_O_Str);
            this.panel5.Controls.Add(this.txtO_O);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(512, 65);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(304, 25);
            this.panel5.TabIndex = 3;
            // 
            // txtO_O_Str
            // 
            this.txtO_O_Str.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtO_O_Str.Location = new System.Drawing.Point(63, 2);
            this.txtO_O_Str.Name = "txtO_O_Str";
            this.txtO_O_Str.Size = new System.Drawing.Size(241, 21);
            this.txtO_O_Str.TabIndex = 17;
            // 
            // txtO_O
            // 
            this.txtO_O.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtO_O.FormattingEnabled = true;
            this.txtO_O.Location = new System.Drawing.Point(3, 3);
            this.txtO_O.Name = "txtO_O";
            this.txtO_O.Size = new System.Drawing.Size(58, 20);
            this.txtO_O.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtS_O_Str);
            this.panel4.Controls.Add(this.txtS_O);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(103, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(303, 25);
            this.panel4.TabIndex = 3;
            // 
            // txtS_O_Str
            // 
            this.txtS_O_Str.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtS_O_Str.Location = new System.Drawing.Point(59, 3);
            this.txtS_O_Str.Name = "txtS_O_Str";
            this.txtS_O_Str.Size = new System.Drawing.Size(241, 21);
            this.txtS_O_Str.TabIndex = 16;
            // 
            // txtS_O
            // 
            this.txtS_O.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtS_O.FormattingEnabled = true;
            this.txtS_O.Location = new System.Drawing.Point(0, 3);
            this.txtS_O.Name = "txtS_O";
            this.txtS_O.Size = new System.Drawing.Size(58, 20);
            this.txtS_O.TabIndex = 13;
            // 
            // txtReceiptStore
            // 
            this.txtReceiptStore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceiptStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtReceiptStore.FormattingEnabled = true;
            this.txtReceiptStore.Location = new System.Drawing.Point(512, 34);
            this.txtReceiptStore.Name = "txtReceiptStore";
            this.txtReceiptStore.Size = new System.Drawing.Size(304, 20);
            this.txtReceiptStore.TabIndex = 8;
            // 
            // txtItemID
            // 
            this.txtItemID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemID.Location = new System.Drawing.Point(512, 3);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(304, 21);
            this.txtItemID.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "出货店铺";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "货号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtEDate);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtSDate);
            this.panel2.Location = new System.Drawing.Point(103, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 25);
            this.panel2.TabIndex = 0;
            // 
            // txtEDate
            // 
            this.txtEDate.Location = new System.Drawing.Point(144, 6);
            this.txtEDate.Name = "txtEDate";
            this.txtEDate.Size = new System.Drawing.Size(112, 21);
            this.txtEDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "至";
            // 
            // txtSDate
            // 
            this.txtSDate.Location = new System.Drawing.Point(4, 5);
            this.txtSDate.Name = "txtSDate";
            this.txtSDate.Size = new System.Drawing.Size(115, 21);
            this.txtSDate.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "进货店铺";
            // 
            // txtDeliverStore
            // 
            this.txtDeliverStore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliverStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDeliverStore.FormattingEnabled = true;
            this.txtDeliverStore.Location = new System.Drawing.Point(103, 34);
            this.txtDeliverStore.Name = "txtDeliverStore";
            this.txtDeliverStore.Size = new System.Drawing.Size(303, 20);
            this.txtDeliverStore.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "S/O";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "O/O";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(412, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Batch_Num2";
            // 
            // txtBatch_Num2
            // 
            this.txtBatch_Num2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatch_Num2.Location = new System.Drawing.Point(512, 96);
            this.txtBatch_Num2.Name = "txtBatch_Num2";
            this.txtBatch_Num2.Size = new System.Drawing.Size(304, 21);
            this.txtBatch_Num2.TabIndex = 16;
            // 
            // txtBatch_Num1
            // 
            this.txtBatch_Num1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatch_Num1.Location = new System.Drawing.Point(103, 96);
            this.txtBatch_Num1.Name = "txtBatch_Num1";
            this.txtBatch_Num1.Size = new System.Drawing.Size(303, 21);
            this.txtBatch_Num1.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "Batch_Num1";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnOutExcel);
            this.panel3.Controls.Add(this.btnExcel);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(13, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(831, 179);
            this.panel3.TabIndex = 2;
            // 
            // btnOutExcel
            // 
            this.btnOutExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutExcel.Location = new System.Drawing.Point(585, 153);
            this.btnOutExcel.Name = "btnOutExcel";
            this.btnOutExcel.Size = new System.Drawing.Size(75, 23);
            this.btnOutExcel.TabIndex = 4;
            this.btnOutExcel.Text = "转存Excel";
            this.btnOutExcel.UseVisualStyleBackColor = true;
            this.btnOutExcel.Click += new System.EventHandler(this.btnOutExcel_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(666, 153);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Text = "转存PDF";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(747, 153);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmApplicationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 441);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmApplicationReport";
            this.TabText = "转货报表";
            this.Text = "转货报表";
            this.Load += new System.EventHandler(this.frmApplicationReport_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker txtEDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtSDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.DataGridView dgvAppDetail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox txtDeliverStore;
        private System.Windows.Forms.ComboBox txtReceiptStore;
        private System.Windows.Forms.ComboBox txtS_O;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtO_O;
        private System.Windows.Forms.TextBox txtBatch_Num1;
        private System.Windows.Forms.TextBox txtBatch_Num2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtO_O_Str;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtS_O_Str;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CtrlID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicantsDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliverStore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptStore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn App_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliverDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicantsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicantsPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovalName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliverChecker;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliverCheckerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptChecker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptCheckerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovalDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovalDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_O;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_O;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_Num1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_Num2;
        private System.Windows.Forms.Button btnOutExcel;
    }
}