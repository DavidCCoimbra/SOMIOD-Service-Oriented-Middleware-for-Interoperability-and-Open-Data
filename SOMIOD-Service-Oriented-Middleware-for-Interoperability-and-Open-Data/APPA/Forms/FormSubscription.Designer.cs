namespace APPA.Forms
{
    partial class FormSubscription
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
            this.textBoxSubEndpoint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textSubName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnUpdateApplication = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textApplication = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxModule = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSubEvent = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(679, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "[POST] Endpoint";
            // 
            // textBoxSubEndpoint
            // 
            this.textBoxSubEndpoint.Location = new System.Drawing.Point(683, 103);
            this.textBoxSubEndpoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSubEndpoint.Name = "textBoxSubEndpoint";
            this.textBoxSubEndpoint.Size = new System.Drawing.Size(275, 22);
            this.textBoxSubEndpoint.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "[POST:DELETE] Subscription name";
            // 
            // textSubName
            // 
            this.textSubName.Location = new System.Drawing.Point(45, 103);
            this.textSubName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textSubName.Name = "textSubName";
            this.textSubName.Size = new System.Drawing.Size(420, 22);
            this.textSubName.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 29;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(47, 472);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 39);
            this.button3.TabIndex = 27;
            this.button3.Text = "New Subscription";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUpdateApplication
            // 
            this.btnUpdateApplication.Location = new System.Drawing.Point(232, 472);
            this.btnUpdateApplication.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateApplication.Name = "btnUpdateApplication";
            this.btnUpdateApplication.Size = new System.Drawing.Size(177, 39);
            this.btnUpdateApplication.TabIndex = 26;
            this.btnUpdateApplication.Text = "Delete Subscription";
            this.btnUpdateApplication.UseVisualStyleBackColor = true;
            this.btnUpdateApplication.Click += new System.EventHandler(this.btnUpdateApplication_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 153);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1011, 290);
            this.dataGridView1.TabIndex = 24;
            // 
            // textApplication
            // 
            this.textApplication.Location = new System.Drawing.Point(45, 47);
            this.textApplication.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textApplication.Name = "textApplication";
            this.textApplication.Size = new System.Drawing.Size(420, 22);
            this.textApplication.TabIndex = 23;
            this.textApplication.TextChanged += new System.EventHandler(this.textApplication_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "[ALL] Application name";
            // 
            // textBoxModule
            // 
            this.textBoxModule.Location = new System.Drawing.Point(512, 47);
            this.textBoxModule.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxModule.Name = "textBoxModule";
            this.textBoxModule.Size = new System.Drawing.Size(445, 22);
            this.textBoxModule.TabIndex = 35;
            this.textBoxModule.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "[ALL] Module name";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // comboBoxSubEvent
            // 
            this.comboBoxSubEvent.FormattingEnabled = true;
            this.comboBoxSubEvent.Items.AddRange(new object[] {
            "Creation",
            "Deletion",
            "Both"});
            this.comboBoxSubEvent.Location = new System.Drawing.Point(512, 103);
            this.comboBoxSubEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSubEvent.Name = "comboBoxSubEvent";
            this.comboBoxSubEvent.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSubEvent.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(509, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 16);
            this.label6.TabIndex = 37;
            this.label6.Text = "[POST] Event";
            // 
            // FormSubscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 524);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxSubEvent);
            this.Controls.Add(this.textBoxModule);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSubEndpoint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textSubName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnUpdateApplication);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textApplication);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSubscription";
            this.Text = "Subscriptions";
            this.Load += new System.EventHandler(this.FormSubscription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSubEndpoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textSubName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnUpdateApplication;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textApplication;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxModule;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSubEvent;
        private System.Windows.Forms.Label label6;
    }
}