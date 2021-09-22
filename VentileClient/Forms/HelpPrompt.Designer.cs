
namespace VentileClient
{
    partial class HelpPrompt
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
            this.Title = new System.Windows.Forms.Label();
            this.ChangeLog = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.fadeIn = new System.Windows.Forms.Timer(this.components);
            this.fadeOut = new System.Windows.Forms.Timer(this.components);
            this.CloseButton = new Guna.UI2.WinForms.Guna2Button();
            this.ChangeLogScrollPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.CoverUpSliderPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.ChangeLogScrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(7, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(61, 30);
            this.Title.TabIndex = 1;
            this.Title.Text = "Help:";
            // 
            // ChangeLog
            // 
            this.ChangeLog.AutoSize = true;
            this.ChangeLog.BackColor = System.Drawing.Color.Transparent;
            this.ChangeLog.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeLog.ForeColor = System.Drawing.Color.Silver;
            this.ChangeLog.Location = new System.Drawing.Point(0, 0);
            this.ChangeLog.Name = "ChangeLog";
            this.ChangeLog.Size = new System.Drawing.Size(0, 20);
            this.ChangeLog.TabIndex = 2;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
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
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Animated = true;
            this.CloseButton.AutoRoundedCorners = true;
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BorderRadius = 16;
            this.CloseButton.CheckedState.Parent = this.CloseButton;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CloseButton.CustomImages.Parent = this.CloseButton;
            this.CloseButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CloseButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CloseButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CloseButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CloseButton.DisabledState.Parent = this.CloseButton;
            this.CloseButton.FillColor = System.Drawing.Color.Transparent;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.HoverState.Parent = this.CloseButton;
            this.CloseButton.Location = new System.Drawing.Point(294, -5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.ShadowDecoration.Parent = this.CloseButton;
            this.CloseButton.Size = new System.Drawing.Size(35, 35);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "X";
            this.CloseButton.UseTransparentBackground = true;
            this.CloseButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ChangeLogScrollPanel
            // 
            this.ChangeLogScrollPanel.AutoScroll = true;
            this.ChangeLogScrollPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ChangeLogScrollPanel.Controls.Add(this.ChangeLog);
            this.ChangeLogScrollPanel.Location = new System.Drawing.Point(22, 53);
            this.ChangeLogScrollPanel.Name = "ChangeLogScrollPanel";
            this.ChangeLogScrollPanel.ShadowDecoration.Parent = this.ChangeLogScrollPanel;
            this.ChangeLogScrollPanel.Size = new System.Drawing.Size(302, 280);
            this.ChangeLogScrollPanel.TabIndex = 4;
            // 
            // CoverUpSliderPanel
            // 
            this.CoverUpSliderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CoverUpSliderPanel.Location = new System.Drawing.Point(306, 53);
            this.CoverUpSliderPanel.Name = "CoverUpSliderPanel";
            this.CoverUpSliderPanel.ShadowDecoration.Parent = this.CoverUpSliderPanel;
            this.CoverUpSliderPanel.Size = new System.Drawing.Size(18, 280);
            this.CoverUpSliderPanel.TabIndex = 5;
            // 
            // HelpPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(324, 350);
            this.Controls.Add(this.CoverUpSliderPanel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.ChangeLogScrollPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HelpPrompt";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangelogPrompt";
            this.ChangeLogScrollPanel.ResumeLayout(false);
            this.ChangeLogScrollPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label ChangeLog;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        public System.Windows.Forms.Timer fadeIn;
        public System.Windows.Forms.Timer fadeOut;
        private Guna.UI2.WinForms.Guna2Button CloseButton;
        private Guna.UI2.WinForms.Guna2Panel ChangeLogScrollPanel;
        private Guna.UI2.WinForms.Guna2Panel CoverUpSliderPanel;
    }
}