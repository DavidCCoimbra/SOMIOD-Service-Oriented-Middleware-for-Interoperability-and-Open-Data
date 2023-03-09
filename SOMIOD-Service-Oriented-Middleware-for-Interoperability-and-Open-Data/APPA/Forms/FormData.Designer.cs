namespace APPA.Forms
{
    partial class FormData
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
            this.label4 = new System.Windows.Forms.Label();
            this.textData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textApplicationModule = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGetApplication = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textApplication = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textDataID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "[POST] Content";
            // 
            // textData
            // 
            this.textData.Location = new System.Drawing.Point(31, 112);
            this.textData.Margin = new System.Windows.Forms.Padding(4);
            this.textData.Name = "textData";
            this.textData.Size = new System.Drawing.Size(420, 22);
            this.textData.TabIndex = 31;
            this.textData.TextChanged += new System.EventHandler(this.textData_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "[ALL] Module name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textApplicationModule
            // 
            this.textApplicationModule.Location = new System.Drawing.Point(503, 48);
            this.textApplicationModule.Margin = new System.Windows.Forms.Padding(4);
            this.textApplicationModule.Name = "textApplicationModule";
            this.textApplicationModule.Size = new System.Drawing.Size(420, 22);
            this.textApplicationModule.TabIndex = 29;
            this.textApplicationModule.TextChanged += new System.EventHandler(this.textApplicationPut_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(231, 487);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(192, 39);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete Data";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGetApplication
            // 
            this.btnGetApplication.Location = new System.Drawing.Point(31, 487);
            this.btnGetApplication.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetApplication.Name = "btnGetApplication";
            this.btnGetApplication.Size = new System.Drawing.Size(192, 39);
            this.btnGetApplication.TabIndex = 25;
            this.btnGetApplication.Text = "Post Data";
            this.btnGetApplication.UseVisualStyleBackColor = true;
            this.btnGetApplication.Click += new System.EventHandler(this.btnGetApplication_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 176);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1011, 285);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textApplication
            // 
            this.textApplication.Location = new System.Drawing.Point(31, 48);
            this.textApplication.Margin = new System.Windows.Forms.Padding(4);
            this.textApplication.Name = "textApplication";
            this.textApplication.Size = new System.Drawing.Size(420, 22);
            this.textApplication.TabIndex = 23;
            this.textApplication.TextChanged += new System.EventHandler(this.textApplication_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "[ALL] Application name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "[DELETE] Data id ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textDataID
            // 
            this.textDataID.Location = new System.Drawing.Point(503, 112);
            this.textDataID.Margin = new System.Windows.Forms.Padding(4);
            this.textDataID.Name = "textDataID";
            this.textDataID.Size = new System.Drawing.Size(420, 22);
            this.textDataID.TabIndex = 33;
            this.textDataID.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDataID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textApplicationModule);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnGetApplication);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textApplication);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormData";
            this.Text = "Data";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textApplicationModule;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnGetApplication;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textApplication;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDataID;
    }
}
