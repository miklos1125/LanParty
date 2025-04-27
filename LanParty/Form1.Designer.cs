namespace LanParty
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
            this.startServer = new System.Windows.Forms.Button();
            this.findServer = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.messagesBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startServer
            // 
            this.startServer.Enabled = false;
            this.startServer.ForeColor = System.Drawing.Color.Gray;
            this.startServer.Location = new System.Drawing.Point(38, 92);
            this.startServer.Name = "startServer";
            this.startServer.Size = new System.Drawing.Size(103, 30);
            this.startServer.TabIndex = 0;
            this.startServer.Text = "Start Server";
            this.startServer.UseVisualStyleBackColor = true;
            this.startServer.Click += new System.EventHandler(this.startServer_Click);
            // 
            // findServer
            // 
            this.findServer.Enabled = false;
            this.findServer.ForeColor = System.Drawing.Color.Gray;
            this.findServer.Location = new System.Drawing.Point(38, 149);
            this.findServer.Name = "findServer";
            this.findServer.Size = new System.Drawing.Size(103, 30);
            this.findServer.TabIndex = 1;
            this.findServer.Text = "Find Server";
            this.findServer.UseVisualStyleBackColor = true;
            this.findServer.Click += new System.EventHandler(this.findServer_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(38, 47);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 2;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.ForeColor = System.Drawing.Color.Red;
            this.nameLabel.Location = new System.Drawing.Point(35, 21);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(111, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Enter your name here:";
            // 
            // messagesBox
            // 
            this.messagesBox.Location = new System.Drawing.Point(260, 47);
            this.messagesBox.Multiline = true;
            this.messagesBox.Name = "messagesBox";
            this.messagesBox.Size = new System.Drawing.Size(217, 132);
            this.messagesBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(522, 229);
            this.Controls.Add(this.messagesBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.findServer);
            this.Controls.Add(this.startServer);
            this.Name = "Form1";
            this.Text = "LAN Party-maker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startServer;
        private System.Windows.Forms.Button findServer;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox messagesBox;
    }
}

