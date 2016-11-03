namespace BHair.Business
{
    partial class frmImportApplication
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
            this.btnExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvApplyInfo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.App_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WuliuID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_O = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_O = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_Num1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_Num2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliverDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_O_Str = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O_O_Str = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WuliuDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvApplyDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemHighlight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbErrorList = new System.Windows.Forms.GroupBox();
            this.dgvErrorList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eCtrlID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyDetails)).BeginInit();
            this.gbErrorList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(12, 10);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(117, 23);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "选择Excel文件";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 8;
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(781, 15);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 23);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "导入到数据库";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvApplyInfo);
            this.groupBox1.Location = new System.Drawing.Point(15, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(869, 179);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "申请单列表";
            // 
            // dgvApplyInfo
            // 
            this.dgvApplyInfo.AllowUserToAddRows = false;
            this.dgvApplyInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplyInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column7,
            this.Column5,
            this.Column8,
            this.Column6,
            this.Column28,
            this.Column29,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column32,
            this.Column30,
            this.Column31,
            this.App_State,
            this.WuliuID,
            this.S_O,
            this.O_O,
            this.Batch_Num1,
            this.Batch_Num2,
            this.DeliverDate,
            this.ReceiptDate,
            this.S_O_Str,
            this.O_O_Str,
            this.WuliuDate});
            this.dgvApplyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApplyInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvApplyInfo.MultiSelect = false;
            this.dgvApplyInfo.Name = "dgvApplyInfo";
            this.dgvApplyInfo.RowTemplate.Height = 23;
            this.dgvApplyInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplyInfo.Size = new System.Drawing.Size(863, 159);
            this.dgvApplyInfo.TabIndex = 128;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CtrlID";
            this.Column1.HeaderText = "控制号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DeliverStore";
            this.Column2.HeaderText = "发货店铺";
            this.Column2.MinimumWidth = 20;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ReceiptStore";
            this.Column3.HeaderText = "收货店铺";
            this.Column3.MinimumWidth = 20;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ApplicantsDate";
            this.Column4.HeaderText = "申请时间";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Applicants";
            this.Column7.HeaderText = "申请人ID";
            this.Column7.Name = "Column7";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ApplicantsName";
            this.Column5.HeaderText = "申请人";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "ApplicantsPos";
            this.Column8.HeaderText = "申请人职位";
            this.Column8.Name = "Column8";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "TotalPrice";
            this.Column6.HeaderText = "小计";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column28
            // 
            this.Column28.DataPropertyName = "ID";
            this.Column28.HeaderText = "ID";
            this.Column28.Name = "Column28";
            this.Column28.Visible = false;
            // 
            // Column29
            // 
            this.Column29.DataPropertyName = "TotalCount";
            this.Column29.HeaderText = "总数";
            this.Column29.Name = "Column29";
            this.Column29.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Approval";
            this.Column9.HeaderText = "批准人ID";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "ApprovalName";
            this.Column10.HeaderText = "批准人姓名";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "ApprovalPos";
            this.Column11.HeaderText = "批准人职位";
            this.Column11.Name = "Column11";
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "DeliverCheck";
            this.Column12.HeaderText = "发货前检查";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "DeliverChecker";
            this.Column13.HeaderText = "发货前检查人";
            this.Column13.Name = "Column13";
            this.Column13.Visible = false;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "DeliverCheckerName";
            this.Column14.HeaderText = "发货前检查人姓名";
            this.Column14.Name = "Column14";
            this.Column14.Visible = false;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "ReceiptCheck";
            this.Column15.HeaderText = "收货物后检查";
            this.Column15.Name = "Column15";
            this.Column15.Visible = false;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "ReceiptChecker";
            this.Column16.HeaderText = "收货物后检查人";
            this.Column16.Name = "Column16";
            this.Column16.Visible = false;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "ReceiptCheckerName";
            this.Column17.HeaderText = "收货物后检查人姓名";
            this.Column17.Name = "Column17";
            this.Column17.Visible = false;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "ApprovalState";
            this.Column18.HeaderText = "商品部审批 1=通过";
            this.Column18.Name = "Column18";
            this.Column18.Visible = false;
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "ApprovalDate";
            this.Column19.HeaderText = "商品部审批日期";
            this.Column19.Name = "Column19";
            this.Column19.Visible = false;
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "ApprovalState2";
            this.Column20.HeaderText = "财务部审批 1=通过";
            this.Column20.Name = "Column20";
            this.Column20.Visible = false;
            // 
            // Column21
            // 
            this.Column21.DataPropertyName = "ApprovalDate2";
            this.Column21.HeaderText = "财务部审批日期";
            this.Column21.Name = "Column21";
            this.Column21.Visible = false;
            // 
            // Column22
            // 
            this.Column22.DataPropertyName = "DeliverState";
            this.Column22.HeaderText = "转出店面确认 1=通过";
            this.Column22.Name = "Column22";
            this.Column22.Visible = false;
            // 
            // Column23
            // 
            this.Column23.DataPropertyName = "DeliverDate";
            this.Column23.HeaderText = "转出店面确认日期";
            this.Column23.Name = "Column23";
            this.Column23.Visible = false;
            // 
            // Column24
            // 
            this.Column24.DataPropertyName = "ReceiptState";
            this.Column24.HeaderText = "收货店面确认 1=通过 2=部分通过";
            this.Column24.Name = "Column24";
            this.Column24.Visible = false;
            // 
            // Column25
            // 
            this.Column25.DataPropertyName = "ReceiptDate";
            this.Column25.HeaderText = "收货店面确认日期";
            this.Column25.Name = "Column25";
            this.Column25.Visible = false;
            // 
            // Column26
            // 
            this.Column26.DataPropertyName = "IsDelete";
            this.Column26.HeaderText = "是否被删除 1=删除";
            this.Column26.Name = "Column26";
            this.Column26.Visible = false;
            // 
            // Column32
            // 
            this.Column32.DataPropertyName = "Approval2";
            this.Column32.HeaderText = "批准人（财务部";
            this.Column32.Name = "Column32";
            this.Column32.Visible = false;
            // 
            // Column30
            // 
            this.Column30.DataPropertyName = "ApprovalName2";
            this.Column30.HeaderText = "批准人姓名（财务部";
            this.Column30.Name = "Column30";
            this.Column30.Visible = false;
            // 
            // Column31
            // 
            this.Column31.DataPropertyName = "ApprovalPos2";
            this.Column31.HeaderText = "批准人职位（财务部";
            this.Column31.Name = "Column31";
            this.Column31.Visible = false;
            // 
            // App_State
            // 
            this.App_State.HeaderText = "流程状态";
            this.App_State.Name = "App_State";
            this.App_State.ReadOnly = true;
            this.App_State.Visible = false;
            // 
            // WuliuID
            // 
            this.WuliuID.DataPropertyName = "WuliuID";
            this.WuliuID.HeaderText = "WuliuID";
            this.WuliuID.Name = "WuliuID";
            this.WuliuID.ReadOnly = true;
            this.WuliuID.Visible = false;
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
            // DeliverDate
            // 
            this.DeliverDate.DataPropertyName = "DeliverDate";
            this.DeliverDate.HeaderText = "DeliverDate";
            this.DeliverDate.Name = "DeliverDate";
            this.DeliverDate.ReadOnly = true;
            this.DeliverDate.Visible = false;
            // 
            // ReceiptDate
            // 
            this.ReceiptDate.DataPropertyName = "ReceiptDate";
            this.ReceiptDate.HeaderText = "ReceiptDate";
            this.ReceiptDate.Name = "ReceiptDate";
            this.ReceiptDate.ReadOnly = true;
            this.ReceiptDate.Visible = false;
            // 
            // S_O_Str
            // 
            this.S_O_Str.DataPropertyName = "S_O_Str";
            this.S_O_Str.HeaderText = "S_O_Str";
            this.S_O_Str.Name = "S_O_Str";
            this.S_O_Str.ReadOnly = true;
            this.S_O_Str.Visible = false;
            // 
            // O_O_Str
            // 
            this.O_O_Str.DataPropertyName = "O_O_Str";
            this.O_O_Str.HeaderText = "O_O_Str";
            this.O_O_Str.Name = "O_O_Str";
            this.O_O_Str.ReadOnly = true;
            this.O_O_Str.Visible = false;
            // 
            // WuliuDate
            // 
            this.WuliuDate.DataPropertyName = "WuliuDate";
            this.WuliuDate.HeaderText = "WuliuDate";
            this.WuliuDate.Name = "WuliuDate";
            this.WuliuDate.ReadOnly = true;
            this.WuliuDate.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvApplyDetails);
            this.groupBox2.Location = new System.Drawing.Point(15, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(869, 175);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "货物列表";
            // 
            // dgvApplyDetails
            // 
            this.dgvApplyDetails.AllowUserToAddRows = false;
            this.dgvApplyDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplyDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.department,
            this.level,
            this.itemId,
            this.itemId2,
            this.detail,
            this.price,
            this.count,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.ItemHighlight});
            this.dgvApplyDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApplyDetails.Location = new System.Drawing.Point(3, 17);
            this.dgvApplyDetails.MultiSelect = false;
            this.dgvApplyDetails.Name = "dgvApplyDetails";
            this.dgvApplyDetails.RowTemplate.Height = 23;
            this.dgvApplyDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplyDetails.Size = new System.Drawing.Size(863, 155);
            this.dgvApplyDetails.TabIndex = 128;
            this.dgvApplyDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvApplyDetails_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CtrlID";
            this.dataGridViewTextBoxColumn3.HeaderText = "控制号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // department
            // 
            this.department.DataPropertyName = "Department";
            this.department.HeaderText = "部门";
            this.department.Name = "department";
            this.department.ReadOnly = true;
            // 
            // level
            // 
            this.level.DataPropertyName = "App_Level";
            this.level.HeaderText = "级别";
            this.level.Name = "level";
            this.level.ReadOnly = true;
            // 
            // itemId
            // 
            this.itemId.DataPropertyName = "ItemID";
            this.itemId.HeaderText = "货号";
            this.itemId.Name = "itemId";
            this.itemId.ReadOnly = true;
            // 
            // itemId2
            // 
            this.itemId2.DataPropertyName = "ItemID2";
            this.itemId2.HeaderText = "双货号";
            this.itemId2.Name = "itemId2";
            this.itemId2.ReadOnly = true;
            // 
            // detail
            // 
            this.detail.DataPropertyName = "Detail";
            this.detail.HeaderText = "产品描述";
            this.detail.MinimumWidth = 20;
            this.detail.Name = "detail";
            this.detail.ReadOnly = true;
            // 
            // price
            // 
            this.price.DataPropertyName = "Price";
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // count
            // 
            this.count.DataPropertyName = "App_Count";
            this.count.HeaderText = "数量";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "IsDelete";
            this.dataGridViewTextBoxColumn2.HeaderText = "IsDelete";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // ItemHighlight
            // 
            this.ItemHighlight.DataPropertyName = "ItemHighlight";
            this.ItemHighlight.HeaderText = "ItemHighlight";
            this.ItemHighlight.Name = "ItemHighlight";
            this.ItemHighlight.ReadOnly = true;
            this.ItemHighlight.Visible = false;
            // 
            // gbErrorList
            // 
            this.gbErrorList.Controls.Add(this.dgvErrorList);
            this.gbErrorList.Location = new System.Drawing.Point(18, 436);
            this.gbErrorList.Name = "gbErrorList";
            this.gbErrorList.Size = new System.Drawing.Size(863, 201);
            this.gbErrorList.TabIndex = 12;
            this.gbErrorList.TabStop = false;
            this.gbErrorList.Text = "错误列表";
            // 
            // dgvErrorList
            // 
            this.dgvErrorList.AllowUserToAddRows = false;
            this.dgvErrorList.AllowUserToDeleteRows = false;
            this.dgvErrorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.eCtrlID,
            this.eItemID,
            this.ErrorString});
            this.dgvErrorList.Location = new System.Drawing.Point(7, 20);
            this.dgvErrorList.Name = "dgvErrorList";
            this.dgvErrorList.ReadOnly = true;
            this.dgvErrorList.RowTemplate.Height = 23;
            this.dgvErrorList.Size = new System.Drawing.Size(855, 175);
            this.dgvErrorList.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // eCtrlID
            // 
            this.eCtrlID.DataPropertyName = "eCtrlID";
            this.eCtrlID.HeaderText = "控制号";
            this.eCtrlID.Name = "eCtrlID";
            this.eCtrlID.ReadOnly = true;
            this.eCtrlID.Width = 200;
            // 
            // eItemID
            // 
            this.eItemID.DataPropertyName = "eItemID";
            this.eItemID.HeaderText = "货号/双货号";
            this.eItemID.Name = "eItemID";
            this.eItemID.ReadOnly = true;
            // 
            // ErrorString
            // 
            this.ErrorString.DataPropertyName = "ErrorString";
            this.ErrorString.HeaderText = "错误信息";
            this.ErrorString.Name = "ErrorString";
            this.ErrorString.ReadOnly = true;
            this.ErrorString.Width = 300;
            // 
            // frmImportApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 649);
            this.Controls.Add(this.gbErrorList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportApplication";
            this.TabText = "申请单导入";
            this.Text = "申请单导入";
            this.Load += new System.EventHandler(this.frmMember_List_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyDetails)).EndInit();
            this.gbErrorList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvApplyInfo;
        private System.Windows.Forms.DataGridView dgvApplyDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewTextBoxColumn level;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemHighlight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column32;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column30;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column31;
        private System.Windows.Forms.DataGridViewTextBoxColumn App_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn WuliuID;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_O;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_O;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_Num1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_Num2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliverDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_O_Str;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_O_Str;
        private System.Windows.Forms.DataGridViewTextBoxColumn WuliuDate;
        private System.Windows.Forms.GroupBox gbErrorList;
        private System.Windows.Forms.DataGridView dgvErrorList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn eCtrlID;
        private System.Windows.Forms.DataGridViewTextBoxColumn eItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorString;
    }
}