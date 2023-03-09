namespace APPA
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.BtnSubscription = new System.Windows.Forms.Button();
            this.BtnData = new System.Windows.Forms.Button();
            this.BtnModules = new System.Windows.Forms.Button();
            this.ButtonAppDrop = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Notifications = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMenu.Controls.Add(this.BtnSubscription);
            this.panelMenu.Controls.Add(this.BtnData);
            this.panelMenu.Controls.Add(this.BtnModules);
            this.panelMenu.Controls.Add(this.ButtonAppDrop);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(293, 644);
            this.panelMenu.TabIndex = 0;
            // 
            // BtnSubscription
            // 
            this.BtnSubscription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnSubscription.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSubscription.FlatAppearance.BorderSize = 0;
            this.BtnSubscription.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSubscription.ForeColor = System.Drawing.Color.Black;
            this.BtnSubscription.Image = global::APPA.Properties.Resources.subscription_1742827_1479747;
            this.BtnSubscription.Location = new System.Drawing.Point(0, 376);
            this.BtnSubscription.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSubscription.Name = "BtnSubscription";
            this.BtnSubscription.Size = new System.Drawing.Size(293, 90);
            this.BtnSubscription.TabIndex = 11;
            this.BtnSubscription.Text = "Subscription";
            this.BtnSubscription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubscription.UseVisualStyleBackColor = false;
            this.BtnSubscription.Click += new System.EventHandler(this.BtnSubscription_Click);
            // 
            // BtnData
            // 
            this.BtnData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnData.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnData.FlatAppearance.BorderSize = 0;
            this.BtnData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnData.ForeColor = System.Drawing.Color.Black;
            this.BtnData.Image = global::APPA.Properties.Resources.apiicon;
            this.BtnData.Location = new System.Drawing.Point(0, 281);
            this.BtnData.Margin = new System.Windows.Forms.Padding(4);
            this.BtnData.Name = "BtnData";
            this.BtnData.Size = new System.Drawing.Size(293, 95);
            this.BtnData.TabIndex = 10;
            this.BtnData.Text = "Data";
            this.BtnData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnData.UseVisualStyleBackColor = false;
            this.BtnData.Click += new System.EventHandler(this.BtnData_Click);
            // 
            // BtnModules
            // 
            this.BtnModules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnModules.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnModules.FlatAppearance.BorderSize = 0;
            this.BtnModules.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnModules.ForeColor = System.Drawing.Color.Black;
            this.BtnModules.Image = global::APPA.Properties.Resources.moduleicon1;
            this.BtnModules.Location = new System.Drawing.Point(0, 190);
            this.BtnModules.Margin = new System.Windows.Forms.Padding(4);
            this.BtnModules.Name = "BtnModules";
            this.BtnModules.Size = new System.Drawing.Size(293, 91);
            this.BtnModules.TabIndex = 9;
            this.BtnModules.Text = "Modules";
            this.BtnModules.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnModules.UseVisualStyleBackColor = false;
            this.BtnModules.Click += new System.EventHandler(this.BtnModules_Click);
            // 
            // ButtonAppDrop
            // 
            this.ButtonAppDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ButtonAppDrop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ButtonAppDrop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonAppDrop.FlatAppearance.BorderSize = 0;
            this.ButtonAppDrop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonAppDrop.ForeColor = System.Drawing.Color.Black;
            this.ButtonAppDrop.Image = global::APPA.Properties.Resources.applicationicon1;
            this.ButtonAppDrop.Location = new System.Drawing.Point(0, 98);
            this.ButtonAppDrop.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonAppDrop.Name = "ButtonAppDrop";
            this.ButtonAppDrop.Size = new System.Drawing.Size(293, 92);
            this.ButtonAppDrop.TabIndex = 8;
            this.ButtonAppDrop.Text = "Application";
            this.ButtonAppDrop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAppDrop.UseVisualStyleBackColor = false;
            this.ButtonAppDrop.Click += new System.EventHandler(this.ButtonAppDrop_Click_1);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelLogo.BackgroundImage = global::APPA.Properties.Resources.eadmini;
            this.panelLogo.Controls.Add(this.panel1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(4);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(293, 98);
            this.panelLogo.TabIndex = 1;
            this.panelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLogo_Paint);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(297, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 640);
            this.panel1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(325, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(719, 596);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Notifications
            // 
            this.Notifications.AutoSize = true;
            this.Notifications.Location = new System.Drawing.Point(322, 9);
            this.Notifications.Name = "Notifications";
            this.Notifications.Size = new System.Drawing.Size(80, 16);
            this.Notifications.TabIndex = 2;
            this.Notifications.Text = "Notifications";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1067, 644);
            this.Controls.Add(this.Notifications);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panelMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ButtonAppDrop;
        private System.Windows.Forms.Button BtnSubscription;
        private System.Windows.Forms.Button BtnData;
        private System.Windows.Forms.Button BtnModules;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label Notifications;
    }
}

