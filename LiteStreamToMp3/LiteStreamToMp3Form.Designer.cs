﻿namespace LiteStreamToMp3
{
    partial class LiteStreamToMp3Form
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
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.SFDTo = new System.Windows.Forms.SaveFileDialog();
            this.LayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.LblFrom = new System.Windows.Forms.Label();
            this.LblTo = new System.Windows.Forms.Label();
            this.TBFrom = new System.Windows.Forms.TextBox();
            this.TBTo = new System.Windows.Forms.TextBox();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.BtnDownload = new System.Windows.Forms.Button();
            this.SSMain = new System.Windows.Forms.StatusStrip();
            this.SSLblLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnAutoSetTo = new System.Windows.Forms.Button();
            this.LayoutMain.SuspendLayout();
            this.SSMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStripMain
            // 
            this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Size = new System.Drawing.Size(624, 24);
            this.MenuStripMain.TabIndex = 0;
            this.MenuStripMain.Text = "menuStrip1";
            // 
            // SFDTo
            // 
            this.SFDTo.DefaultExt = "mp3";
            this.SFDTo.Filter = "Mp3 files|*.mp3";
            this.SFDTo.Title = "Select Download Location";
            this.SFDTo.FileOk += new System.ComponentModel.CancelEventHandler(this.SFDTo_FileOk);
            // 
            // LayoutMain
            // 
            this.LayoutMain.ColumnCount = 3;
            this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutMain.Controls.Add(this.BtnAutoSetTo, 2, 0);
            this.LayoutMain.Controls.Add(this.LblFrom, 0, 0);
            this.LayoutMain.Controls.Add(this.LblTo, 0, 1);
            this.LayoutMain.Controls.Add(this.TBFrom, 1, 0);
            this.LayoutMain.Controls.Add(this.TBTo, 1, 1);
            this.LayoutMain.Controls.Add(this.BtnSelect, 2, 1);
            this.LayoutMain.Controls.Add(this.BtnDownload, 0, 2);
            this.LayoutMain.Controls.Add(this.SSMain, 0, 3);
            this.LayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutMain.Location = new System.Drawing.Point(0, 24);
            this.LayoutMain.Name = "LayoutMain";
            this.LayoutMain.RowCount = 4;
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutMain.Size = new System.Drawing.Size(624, 177);
            this.LayoutMain.TabIndex = 1;
            // 
            // LblFrom
            // 
            this.LblFrom.AutoSize = true;
            this.LblFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFrom.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblFrom.Location = new System.Drawing.Point(15, 12);
            this.LblFrom.Margin = new System.Windows.Forms.Padding(15, 12, 5, 12);
            this.LblFrom.Name = "LblFrom";
            this.LblFrom.Size = new System.Drawing.Size(107, 20);
            this.LblFrom.TabIndex = 0;
            this.LblFrom.Text = "From (URL):";
            this.LblFrom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblTo
            // 
            this.LblTo.AutoSize = true;
            this.LblTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblTo.Location = new System.Drawing.Point(15, 59);
            this.LblTo.Margin = new System.Windows.Forms.Padding(15, 12, 5, 12);
            this.LblTo.Name = "LblTo";
            this.LblTo.Size = new System.Drawing.Size(107, 20);
            this.LblTo.TabIndex = 1;
            this.LblTo.Text = "To (File Path):";
            this.LblTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TBFrom
            // 
            this.TBFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.TBFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TBFrom.Location = new System.Drawing.Point(132, 10);
            this.TBFrom.Margin = new System.Windows.Forms.Padding(5, 10, 0, 10);
            this.TBFrom.Name = "TBFrom";
            this.TBFrom.Size = new System.Drawing.Size(347, 26);
            this.TBFrom.TabIndex = 2;
            this.TBFrom.TextChanged += new System.EventHandler(this.TBFrom_TextChanged);
            // 
            // TBTo
            // 
            this.TBTo.BackColor = System.Drawing.SystemColors.Window;
            this.TBTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.TBTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TBTo.Location = new System.Drawing.Point(132, 57);
            this.TBTo.Margin = new System.Windows.Forms.Padding(5, 10, 0, 10);
            this.TBTo.Name = "TBTo";
            this.TBTo.ReadOnly = true;
            this.TBTo.Size = new System.Drawing.Size(347, 26);
            this.TBTo.TabIndex = 3;
            // 
            // BtnSelect
            // 
            this.BtnSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnSelect.Location = new System.Drawing.Point(479, 56);
            this.BtnSelect.Margin = new System.Windows.Forms.Padding(0, 9, 15, 10);
            this.BtnSelect.MinimumSize = new System.Drawing.Size(0, 28);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(130, 28);
            this.BtnSelect.TabIndex = 4;
            this.BtnSelect.Text = "Select";
            this.BtnSelect.UseVisualStyleBackColor = true;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // BtnDownload
            // 
            this.LayoutMain.SetColumnSpan(this.BtnDownload, 3);
            this.BtnDownload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnDownload.Location = new System.Drawing.Point(15, 104);
            this.BtnDownload.Margin = new System.Windows.Forms.Padding(15, 10, 15, 5);
            this.BtnDownload.Name = "BtnDownload";
            this.BtnDownload.Size = new System.Drawing.Size(594, 45);
            this.BtnDownload.TabIndex = 5;
            this.BtnDownload.Text = "Download MP3!";
            this.BtnDownload.UseVisualStyleBackColor = true;
            this.BtnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
            // 
            // SSMain
            // 
            this.LayoutMain.SetColumnSpan(this.SSMain, 3);
            this.SSMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SSLblLog});
            this.SSMain.Location = new System.Drawing.Point(0, 155);
            this.SSMain.MaximumSize = new System.Drawing.Size(0, 22);
            this.SSMain.MinimumSize = new System.Drawing.Size(0, 0);
            this.SSMain.Name = "SSMain";
            this.SSMain.Size = new System.Drawing.Size(624, 22);
            this.SSMain.TabIndex = 6;
            this.SSMain.Text = "statusStrip1";
            // 
            // SSLblLog
            // 
            this.SSLblLog.Name = "SSLblLog";
            this.SSLblLog.Size = new System.Drawing.Size(0, 17);
            // 
            // BtnAutoSetTo
            // 
            this.BtnAutoSetTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAutoSetTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnAutoSetTo.Location = new System.Drawing.Point(479, 9);
            this.BtnAutoSetTo.Margin = new System.Windows.Forms.Padding(0, 9, 15, 10);
            this.BtnAutoSetTo.MinimumSize = new System.Drawing.Size(0, 28);
            this.BtnAutoSetTo.Name = "BtnAutoSetTo";
            this.BtnAutoSetTo.Size = new System.Drawing.Size(130, 28);
            this.BtnAutoSetTo.TabIndex = 7;
            this.BtnAutoSetTo.Text = "Auto Set Save";
            this.BtnAutoSetTo.UseVisualStyleBackColor = true;
            this.BtnAutoSetTo.Click += new System.EventHandler(this.BtnAutoSetTo_Click);
            // 
            // LiteStreamToMp3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 201);
            this.Controls.Add(this.LayoutMain);
            this.Controls.Add(this.MenuStripMain);
            this.MainMenuStrip = this.MenuStripMain;
            this.MinimumSize = new System.Drawing.Size(640, 240);
            this.Name = "LiteStreamToMp3Form";
            this.Text = "LiteStreamToMp3";
            this.LayoutMain.ResumeLayout(false);
            this.LayoutMain.PerformLayout();
            this.SSMain.ResumeLayout(false);
            this.SSMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStripMain;
        private System.Windows.Forms.SaveFileDialog SFDTo;
        private System.Windows.Forms.TableLayoutPanel LayoutMain;
        private System.Windows.Forms.Label LblFrom;
        private System.Windows.Forms.Label LblTo;
        private System.Windows.Forms.TextBox TBFrom;
        private System.Windows.Forms.TextBox TBTo;
        private System.Windows.Forms.Button BtnSelect;
        private System.Windows.Forms.Button BtnDownload;
        private System.Windows.Forms.StatusStrip SSMain;
        private System.Windows.Forms.ToolStripStatusLabel SSLblLog;
        private System.Windows.Forms.Button BtnAutoSetTo;
    }
}

