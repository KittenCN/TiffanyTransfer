namespace BHair.Business
{
    partial class frmDataProcessing
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
            this.label1 = new System.Windows.Forms.Label();
            this.labDataCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDataProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "共有超限记录:";
            // 
            // labDataCount
            // 
            this.labDataCount.AutoSize = true;
            this.labDataCount.Location = new System.Drawing.Point(159, 68);
            this.labDataCount.Name = "labDataCount";
            this.labDataCount.Size = new System.Drawing.Size(17, 12);
            this.labDataCount.TabIndex = 1;
            this.labDataCount.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "条";
            // 
            // btnDataProcess
            // 
            this.btnDataProcess.Enabled = false;
            this.btnDataProcess.Location = new System.Drawing.Point(101, 130);
            this.btnDataProcess.Name = "btnDataProcess";
            this.btnDataProcess.Size = new System.Drawing.Size(63, 40);
            this.btnDataProcess.TabIndex = 3;
            this.btnDataProcess.Text = "处理超限数据...";
            this.btnDataProcess.UseVisualStyleBackColor = true;
            this.btnDataProcess.Click += new System.EventHandler(this.btnDataProcess_Click);
            // 
            // frmDataProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnDataProcess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labDataCount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataProcessing";
            this.Text = "frmDataProcessing";
            this.Load += new System.EventHandler(this.frmDataProcessing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labDataCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDataProcess;
    }
}