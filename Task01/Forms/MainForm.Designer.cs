namespace Task01.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tvServer = new TreeView();
            dgvResults = new DataGridView();
            tbContent = new TextBox();
            toolStrip1 = new ToolStrip();
            tsbRun = new ToolStripButton();
            tsbSave = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tvServer
            // 
            tvServer.Location = new Point(12, 28);
            tvServer.Name = "tvServer";
            tvServer.Size = new Size(265, 656);
            tvServer.TabIndex = 0;
            tvServer.BeforeExpand += tvServer_BeforeExpand;
            // 
            // dgvResults
            // 
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(283, 425);
            dgvResults.Name = "dgvResults";
            dgvResults.RowTemplate.Height = 25;
            dgvResults.Size = new Size(459, 259);
            dgvResults.TabIndex = 2;
            // 
            // tbContent
            // 
            tbContent.Location = new Point(283, 28);
            tbContent.Multiline = true;
            tbContent.Name = "tbContent";
            tbContent.Size = new Size(459, 391);
            tbContent.TabIndex = 3;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbRun, tsbSave });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(754, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbRun
            // 
            tsbRun.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRun.Image = (Image)resources.GetObject("tsbRun.Image");
            tsbRun.ImageTransparentColor = Color.Magenta;
            tsbRun.Name = "tsbRun";
            tsbRun.Size = new Size(23, 22);
            tsbRun.Text = "toolStripButton1";
            tsbRun.Click += tsbRun_Click;
            // 
            // tsbSave
            // 
            tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSave.Image = (Image)resources.GetObject("tsbSave.Image");
            tsbSave.ImageTransparentColor = Color.Magenta;
            tsbSave.Name = "tsbSave";
            tsbSave.Size = new Size(23, 22);
            tsbSave.Text = "toolStripButton2";
            tsbSave.Click += tsbSave_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 696);
            Controls.Add(toolStrip1);
            Controls.Add(tbContent);
            Controls.Add(dgvResults);
            Controls.Add(tvServer);
            Name = "MainForm";
            Text = "MainForm";
            FormClosed += MainForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView tvServer;
        private DataGridView dgvResults;
        private TextBox tbContent;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbRun;
        private ToolStripButton tsbSave;
    }
}