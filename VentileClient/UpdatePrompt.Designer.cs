
namespace VentileClient
{
    partial class UpdatePrompt
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
            this.version = new System.Windows.Forms.Label();
            this.no = new Guna.UI2.WinForms.Guna2Button();
            this.update = new Guna.UI2.WinForms.Guna2Button();
            this.text2 = new System.Windows.Forms.Label();
            this.text1 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.changeLogLink = new System.Windows.Forms.LinkLabel();
            this.fadeIn = new System.Windows.Forms.Timer(this.components);
            this.fadeOut = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // version
            // 
            this.version.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.version.AutoSize = true;
            this.version.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.ForeColor = System.Drawing.Color.Silver;
            this.version.Location = new System.Drawing.Point(82, 60);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(75, 21);
            this.version.TabIndex = 11;
            this.version.Text = "VERSION";
            // 
            // no
            // 
            this.no.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.no.Animated = true;
            this.no.AutoRoundedCorners = true;
            this.no.BorderRadius = 13;
            this.no.CheckedState.Parent = this.no;
            this.no.CustomImages.Parent = this.no;
            this.no.DisabledState.Parent = this.no;
            this.no.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.no.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.no.ForeColor = System.Drawing.Color.White;
            this.no.HoverState.Parent = this.no;
            this.no.Location = new System.Drawing.Point(26, 207);
            this.no.Name = "no";
            this.no.ShadowDecoration.Parent = this.no;
            this.no.Size = new System.Drawing.Size(93, 29);
            this.no.TabIndex = 10;
            this.no.Text = "No thanks";
            this.no.Click += new System.EventHandler(this.no_Click);
            // 
            // update
            // 
            this.update.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.update.Animated = true;
            this.update.AutoRoundedCorners = true;
            this.update.BorderRadius = 13;
            this.update.CheckedState.Parent = this.update;
            this.update.CustomImages.Parent = this.update;
            this.update.DisabledState.Parent = this.update;
            this.update.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.update.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.update.ForeColor = System.Drawing.Color.White;
            this.update.HoverState.Parent = this.update;
            this.update.Location = new System.Drawing.Point(128, 207);
            this.update.Name = "update";
            this.update.ShadowDecoration.Parent = this.update;
            this.update.Size = new System.Drawing.Size(95, 29);
            this.update.TabIndex = 9;
            this.update.Text = "Update!";
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // text2
            // 
            this.text2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.text2.AutoSize = true;
            this.text2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text2.ForeColor = System.Drawing.Color.Silver;
            this.text2.Location = new System.Drawing.Point(25, 81);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(173, 63);
            this.text2.TabIndex = 8;
            this.text2.Text = "is avaliable! It is fully \r\noptional to download,\r\nbut is highly suggested.";
            // 
            // text1
            // 
            this.text1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.text1.AutoSize = true;
            this.text1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text1.ForeColor = System.Drawing.Color.Silver;
            this.text1.Location = new System.Drawing.Point(25, 60);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(62, 21);
            this.text1.TabIndex = 7;
            this.text1.Text = "Version";
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(25, 29);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(136, 21);
            this.Title.TabIndex = 6;
            this.Title.Text = "Update avaliable!";
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // changeLogLink
            // 
            this.changeLogLink.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.changeLogLink.AutoSize = true;
            this.changeLogLink.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.changeLogLink.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.changeLogLink.LinkColor = System.Drawing.Color.RoyalBlue;
            this.changeLogLink.Location = new System.Drawing.Point(25, 153);
            this.changeLogLink.Name = "changeLogLink";
            this.changeLogLink.Size = new System.Drawing.Size(64, 15);
            this.changeLogLink.TabIndex = 12;
            this.changeLogLink.Text = "Changelog";
            this.changeLogLink.VisitedLinkColor = System.Drawing.Color.RoyalBlue;
            this.changeLogLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.changeLogLink_LinkClicked);
            // 
            // fadeIn
            // 
            this.fadeIn.Enabled = true;
            this.fadeIn.Interval = 1;
            this.fadeIn.Tick += new System.EventHandler(this.fadeIn_Tick);
            // 
            // fadeOut
            // 
            this.fadeOut.Interval = 1;
            this.fadeOut.Tick += new System.EventHandler(this.fadeOut_Tick);
            // 
            // UpdatePrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(248, 264);
            this.Controls.Add(this.changeLogLink);
            this.Controls.Add(this.version);
            this.Controls.Add(this.no);
            this.Controls.Add(this.update);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.Title);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdatePrompt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdatePrompt";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label version;
        private Guna.UI2.WinForms.Guna2Button no;
        private Guna.UI2.WinForms.Guna2Button update;
        private System.Windows.Forms.Label text2;
        private System.Windows.Forms.Label text1;
        private System.Windows.Forms.Label Title;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.LinkLabel changeLogLink;
        public System.Windows.Forms.Timer fadeIn;
        public System.Windows.Forms.Timer fadeOut;
    }
}