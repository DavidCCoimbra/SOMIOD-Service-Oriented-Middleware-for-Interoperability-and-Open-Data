namespace APPA.Forms
{
    partial class FormApplication
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
            this.textApplication = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGetApplication = new System.Windows.Forms.Button();
            this.btnUpdateApplication = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAllApplications = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textApplicationPut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "[GET:POST] Application Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textApplication
            // 
            this.textApplication.Location = new System.Drawing.Point(40, 44);
            this.textApplication.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textApplication.Name = "textApplication";
            this.textApplication.Size = new System.Drawing.Size(420, 22);
            this.textApplication.TabIndex = 1;
            this.textApplication.TextChanged += new System.EventHandler(this.textApplication_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 187);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1011, 270);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnGetApplication
            // 
            this.btnGetApplication.Location = new System.Drawing.Point(40, 484);
            this.btnGetApplication.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetApplication.Name = "btnGetApplication";
            this.btnGetApplication.Size = new System.Drawing.Size(123, 39);
            this.btnGetApplication.TabIndex = 3;
            this.btnGetApplication.Text = "Get Application";
            this.btnGetApplication.UseVisualStyleBackColor = true;
            this.btnGetApplication.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdateApplication
            // 
            this.btnUpdateApplication.Location = new System.Drawing.Point(315, 484);
            this.btnUpdateApplication.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateApplication.Name = "btnUpdateApplication";
            this.btnUpdateApplication.Size = new System.Drawing.Size(143, 39);
            this.btnUpdateApplication.TabIndex = 4;
            this.btnUpdateApplication.Text = "Update Application";
            this.btnUpdateApplication.UseVisualStyleBackColor = true;
            this.btnUpdateApplication.Click += new System.EventHandler(this.btnUpdateApplication_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(171, 484);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 39);
            this.button3.TabIndex = 5;
            this.button3.Text = "Create Application";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAllApplications
            // 
            this.btnAllApplications.Location = new System.Drawing.Point(907, 132);
            this.btnAllApplications.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAllApplications.Name = "btnAllApplications";
            this.btnAllApplications.Size = new System.Drawing.Size(144, 39);
            this.btnAllApplications.TabIndex = 6;
            this.btnAllApplications.Text = "All Applications";
            this.btnAllApplications.UseVisualStyleBackColor = true;
            this.btnAllApplications.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Applications";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textApplicationPut
            // 
            this.textApplicationPut.Location = new System.Drawing.Point(40, 106);
            this.textApplicationPut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textApplicationPut.Name = "textApplicationPut";
            this.textApplicationPut.Size = new System.Drawing.Size(420, 22);
            this.textApplicationPut.TabIndex = 8;
            this.textApplicationPut.TextChanged += new System.EventHandler(this.textApplicationPut_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "[PUT] New Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(465, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 39);
            this.button1.TabIndex = 10;
            this.button1.Text = "Delete Application";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FormApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textApplicationPut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAllApplications);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnUpdateApplication);
            this.Controls.Add(this.btnGetApplication);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textApplication);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormApplication";
            this.Text = "FormApplication";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textApplication;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGetApplication;
        private System.Windows.Forms.Button btnUpdateApplication;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAllApplications;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textApplicationPut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}
