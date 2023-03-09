namespace APPA.Forms
{
    partial class FormModules
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
            this.label3 = new System.Windows.Forms.Label();
            this.textApplicationPut = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAllApplications = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnUpdateApplication = new System.Windows.Forms.Button();
            this.btnGetApplication = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textApplication = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "[GET:POST] Module name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textApplicationPut
            // 
            this.textApplicationPut.Location = new System.Drawing.Point(31, 110);
            this.textApplicationPut.Margin = new System.Windows.Forms.Padding(4);
            this.textApplicationPut.Name = "textApplicationPut";
            this.textApplicationPut.Size = new System.Drawing.Size(420, 22);
            this.textApplicationPut.TabIndex = 18;
            this.textApplicationPut.TextChanged += new System.EventHandler(this.textApplicationPut_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Modules";
            // 
            // btnAllApplications
            // 
            this.btnAllApplications.Location = new System.Drawing.Point(878, 140);
            this.btnAllApplications.Margin = new System.Windows.Forms.Padding(4);
            this.btnAllApplications.Name = "btnAllApplications";
            this.btnAllApplications.Size = new System.Drawing.Size(164, 39);
            this.btnAllApplications.TabIndex = 16;
            this.btnAllApplications.Text = "All Modules From App";
            this.btnAllApplications.UseVisualStyleBackColor = true;
            this.btnAllApplications.Click += new System.EventHandler(this.btnAllApplications_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(203, 487);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 39);
            this.button3.TabIndex = 15;
            this.button3.Text = "Create Module";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUpdateApplication
            // 
            this.btnUpdateApplication.Location = new System.Drawing.Point(375, 487);
            this.btnUpdateApplication.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateApplication.Name = "btnUpdateApplication";
            this.btnUpdateApplication.Size = new System.Drawing.Size(164, 39);
            this.btnUpdateApplication.TabIndex = 14;
            this.btnUpdateApplication.Text = "Update Module";
            this.btnUpdateApplication.UseVisualStyleBackColor = true;
            this.btnUpdateApplication.Click += new System.EventHandler(this.btnUpdateApplication_Click);
            // 
            // btnGetApplication
            // 
            this.btnGetApplication.Location = new System.Drawing.Point(31, 487);
            this.btnGetApplication.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetApplication.Name = "btnGetApplication";
            this.btnGetApplication.Size = new System.Drawing.Size(164, 39);
            this.btnGetApplication.TabIndex = 13;
            this.btnGetApplication.Text = "Get Module";
            this.btnGetApplication.UseVisualStyleBackColor = true;
            this.btnGetApplication.Click += new System.EventHandler(this.btnGetApplication_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 191);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1011, 270);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textApplication
            // 
            this.textApplication.Location = new System.Drawing.Point(31, 48);
            this.textApplication.Margin = new System.Windows.Forms.Padding(4);
            this.textApplication.Name = "textApplication";
            this.textApplication.Size = new System.Drawing.Size(420, 22);
            this.textApplication.TabIndex = 11;
            this.textApplication.TextChanged += new System.EventHandler(this.textApplication_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "[ALL] Application name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "[PUT] New name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(460, 110);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(420, 22);
            this.textBox1.TabIndex = 20;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(546, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 39);
            this.button1.TabIndex = 22;
            this.button1.Text = "Delete Module";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormModules";
            this.Text = "Modules";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textApplicationPut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAllApplications;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnUpdateApplication;
        private System.Windows.Forms.Button btnGetApplication;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textApplication;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}