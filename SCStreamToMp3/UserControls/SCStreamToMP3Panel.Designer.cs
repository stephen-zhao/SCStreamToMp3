namespace SCStreamToMp3
{
    partial class SCStreamToMp3Panel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TBSoundcloudUrl = new System.Windows.Forms.TextBox();
            this.BtnGetMp3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TBSoundcloudUrl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnGetMp3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(866, 505);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paste the track URL into the box below. It should follow the format of \"http[s]:/" +
    "/soundcloud.com/[author-name]/[track-name]\"";
            // 
            // TBSoundcloudUrl
            // 
            this.TBSoundcloudUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBSoundcloudUrl.Location = new System.Drawing.Point(10, 43);
            this.TBSoundcloudUrl.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.TBSoundcloudUrl.Name = "TBSoundcloudUrl";
            this.TBSoundcloudUrl.Size = new System.Drawing.Size(722, 20);
            this.TBSoundcloudUrl.TabIndex = 1;
            // 
            // BtnGetMp3
            // 
            this.BtnGetMp3.Location = new System.Drawing.Point(742, 43);
            this.BtnGetMp3.Margin = new System.Windows.Forms.Padding(5, 10, 10, 10);
            this.BtnGetMp3.Name = "BtnGetMp3";
            this.BtnGetMp3.Size = new System.Drawing.Size(114, 20);
            this.BtnGetMp3.TabIndex = 2;
            this.BtnGetMp3.Text = "Get MP3";
            this.BtnGetMp3.UseVisualStyleBackColor = true;
            // 
            // SCStreamToMp3Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SCStreamToMp3Panel";
            this.Size = new System.Drawing.Size(866, 505);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBSoundcloudUrl;
        private System.Windows.Forms.Button BtnGetMp3;
    }
}
