namespace RMS
{
    partial class Settings
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbIntegSecurity = new System.Windows.Forms.CheckBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbDbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbServerError = new System.Windows.Forms.Label();
            this.tbDatabaseError = new System.Windows.Forms.Label();
            this.tbUserIdError = new System.Windows.Forms.Label();
            this.tbDbPasswordError = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(7)))), ((int)(((byte)(48)))));
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.ForeColor = System.Drawing.Color.White;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(734, 36);
            this.topPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(34)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.cbIntegSecurity);
            this.panel1.Controls.Add(this.tbDatabase);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbServer);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.tbDbPassword);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbUserID);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tbServerError);
            this.panel1.Controls.Add(this.tbDatabaseError);
            this.panel1.Controls.Add(this.tbUserIdError);
            this.panel1.Controls.Add(this.tbDbPasswordError);
            this.panel1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(89, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 600);
            this.panel1.TabIndex = 2;
            // 
            // cbIntegSecurity
            // 
            this.cbIntegSecurity.AutoSize = true;
            this.cbIntegSecurity.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIntegSecurity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cbIntegSecurity.Location = new System.Drawing.Point(56, 463);
            this.cbIntegSecurity.Name = "cbIntegSecurity";
            this.cbIntegSecurity.Size = new System.Drawing.Size(187, 26);
            this.cbIntegSecurity.TabIndex = 3;
            this.cbIntegSecurity.Text = "Integrated Security";
            this.cbIntegSecurity.UseVisualStyleBackColor = true;
            this.cbIntegSecurity.CheckedChanged += new System.EventHandler(this.cbIntegSecurity_CheckedChanged);
            // 
            // tbDatabase
            // 
            this.tbDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbDatabase.Font = new System.Drawing.Font("Segoe Print", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDatabase.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbDatabase.Location = new System.Drawing.Point(56, 229);
            this.tbDatabase.MaxLength = 50;
            this.tbDatabase.Multiline = true;
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(449, 32);
            this.tbDatabase.TabIndex = 11;
            this.tbDatabase.TextChanged += new System.EventHandler(this.tbDatabase_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(51, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "DataBase";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label4.Location = new System.Drawing.Point(51, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "Server";
            // 
            // tbServer
            // 
            this.tbServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbServer.Font = new System.Drawing.Font("Segoe Print", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbServer.Location = new System.Drawing.Point(56, 140);
            this.tbServer.MaxLength = 50;
            this.tbServer.Multiline = true;
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(449, 32);
            this.tbServer.TabIndex = 8;
            this.tbServer.TextChanged += new System.EventHandler(this.tbServer_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(7)))), ((int)(((byte)(48)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnSave.Location = new System.Drawing.Point(56, 515);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(449, 48);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbDbPassword
            // 
            this.tbDbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbDbPassword.Font = new System.Drawing.Font("Segoe Print", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDbPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbDbPassword.Location = new System.Drawing.Point(56, 407);
            this.tbDbPassword.MaxLength = 50;
            this.tbDbPassword.Multiline = true;
            this.tbDbPassword.Name = "tbDbPassword";
            this.tbDbPassword.Size = new System.Drawing.Size(449, 32);
            this.tbDbPassword.TabIndex = 6;
            this.tbDbPassword.TextChanged += new System.EventHandler(this.tbDbPassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label3.Location = new System.Drawing.Point(51, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label2.Location = new System.Drawing.Point(51, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "User ID";
            // 
            // tbUserID
            // 
            this.tbUserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbUserID.Font = new System.Drawing.Font("Segoe Print", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbUserID.Location = new System.Drawing.Point(56, 318);
            this.tbUserID.MaxLength = 50;
            this.tbUserID.Multiline = true;
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(449, 32);
            this.tbUserID.TabIndex = 2;
            this.tbUserID.TextChanged += new System.EventHandler(this.tbUserID_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RMS.Properties.Resources.AS__Restaurant__1_;
            this.pictureBox1.Location = new System.Drawing.Point(-88, -44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tbServerError
            // 
            this.tbServerError.AutoSize = true;
            this.tbServerError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbServerError.Location = new System.Drawing.Point(485, 112);
            this.tbServerError.Name = "tbServerError";
            this.tbServerError.Size = new System.Drawing.Size(20, 25);
            this.tbServerError.TabIndex = 12;
            this.tbServerError.Text = "*";
            this.tbServerError.Visible = false;
            // 
            // tbDatabaseError
            // 
            this.tbDatabaseError.AutoSize = true;
            this.tbDatabaseError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbDatabaseError.Location = new System.Drawing.Point(485, 199);
            this.tbDatabaseError.Name = "tbDatabaseError";
            this.tbDatabaseError.Size = new System.Drawing.Size(20, 25);
            this.tbDatabaseError.TabIndex = 13;
            this.tbDatabaseError.Text = "*";
            this.tbDatabaseError.Visible = false;
            // 
            // tbUserIdError
            // 
            this.tbUserIdError.AutoSize = true;
            this.tbUserIdError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbUserIdError.Location = new System.Drawing.Point(485, 290);
            this.tbUserIdError.Name = "tbUserIdError";
            this.tbUserIdError.Size = new System.Drawing.Size(20, 25);
            this.tbUserIdError.TabIndex = 14;
            this.tbUserIdError.Text = "*";
            this.tbUserIdError.Visible = false;
            // 
            // tbDbPasswordError
            // 
            this.tbDbPasswordError.AutoSize = true;
            this.tbDbPasswordError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbDbPasswordError.Location = new System.Drawing.Point(485, 379);
            this.tbDbPasswordError.Name = "tbDbPasswordError";
            this.tbDbPasswordError.Size = new System.Drawing.Size(20, 25);
            this.tbDbPasswordError.TabIndex = 15;
            this.tbDbPasswordError.Text = "*";
            this.tbDbPasswordError.Visible = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(734, 767);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.topPanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(752, 814);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(752, 814);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbDbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbIntegSecurity;
        private System.Windows.Forms.Label tbDbPasswordError;
        private System.Windows.Forms.Label tbUserIdError;
        private System.Windows.Forms.Label tbDatabaseError;
        private System.Windows.Forms.Label tbServerError;
    }
}