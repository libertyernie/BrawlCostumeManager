namespace BrawlCostumeManager {
	partial class CostumeManager {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToOtherPacpcsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.changeDirectory = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.updateSSSStockIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.hidePolygonsCheckbox = new System.Windows.Forms.ToolStripMenuItem();
			this.cBlissCheckbox = new System.Windows.Forms.ToolStripMenuItem();
			this.swapPortraitsForWarioStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.separator = new System.Windows.Forms.ToolStripSeparator();
			this.nameportraitPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.separator3 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutBrawlCostumeManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.spaceFiller1 = new System.Windows.Forms.Panel();
			this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modelManager1 = new BrawlCostumeManager.ModelManager();
			this.cssPortraitViewer1 = new BrawlCostumeManager.CSSPortraitViewer();
			this.battlePortraitViewer1 = new BrawlCostumeManager.BattlePortraitViewer();
			this.resultPortraitViewer1 = new BrawlCostumeManager.ResultPortraitViewer();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(207, 187);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.modelManager1);
			this.splitContainer1.Panel2.Controls.Add(this.button1);
			this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
			this.splitContainer1.Size = new System.Drawing.Size(684, 406);
			this.splitContainer1.SplitterDistance = 207;
			this.splitContainer1.TabIndex = 2;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 25);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.listBox1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.listBox2);
			this.splitContainer2.Size = new System.Drawing.Size(207, 381);
			this.splitContainer2.SplitterDistance = 187;
			this.splitContainer2.TabIndex = 1;
			// 
			// listBox2
			// 
			this.listBox2.ContextMenuStrip = this.contextMenuStrip1;
			this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point(0, 0);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(207, 190);
			this.listBox2.TabIndex = 0;
			this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToToolStripMenuItem,
            this.copyToOtherPacpcsToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(193, 70);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// copyToToolStripMenuItem
			// 
			this.copyToToolStripMenuItem.Name = "copyToToolStripMenuItem";
			this.copyToToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.copyToToolStripMenuItem.Text = "Copy to...";
			this.copyToToolStripMenuItem.Click += new System.EventHandler(this.copyToToolStripMenuItem_Click);
			// 
			// copyToOtherPacpcsToolStripMenuItem
			// 
			this.copyToOtherPacpcsToolStripMenuItem.Name = "copyToOtherPacpcsToolStripMenuItem";
			this.copyToOtherPacpcsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.copyToOtherPacpcsToolStripMenuItem.Text = "Copy to other pac/pcs";
			this.copyToOtherPacpcsToolStripMenuItem.Click += new System.EventHandler(this.copyToOtherPacpcsToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeDirectory,
            this.toolStripDropDownButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(207, 25);
			this.toolStrip1.TabIndex = 6;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// changeDirectory
			// 
			this.changeDirectory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.changeDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.changeDirectory.Name = "changeDirectory";
			this.changeDirectory.Size = new System.Drawing.Size(103, 22);
			this.changeDirectory.Text = "Change Directory";
			this.changeDirectory.Click += new System.EventHandler(this.changeDirectory_Click);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateSSSStockIconsToolStripMenuItem,
            this.separator2,
            this.hidePolygonsCheckbox,
            this.cBlissCheckbox,
            this.swapPortraitsForWarioStylesToolStripMenuItem,
            this.separator,
            this.nameportraitPreviewToolStripMenuItem,
            this.backgroundColorToolStripMenuItem,
            this.separator3,
            this.aboutBrawlCostumeManagerToolStripMenuItem});
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(62, 22);
			this.toolStripDropDownButton1.Text = "Options";
			// 
			// updateSSSStockIconsToolStripMenuItem
			// 
			this.updateSSSStockIconsToolStripMenuItem.Name = "updateSSSStockIconsToolStripMenuItem";
			this.updateSSSStockIconsToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.updateSSSStockIconsToolStripMenuItem.Text = "Update SSS stock icons";
			this.updateSSSStockIconsToolStripMenuItem.Click += new System.EventHandler(this.updateSSSStockIconsToolStripMenuItem_Click);
			// 
			// separator2
			// 
			this.separator2.Name = "separator2";
			this.separator2.Size = new System.Drawing.Size(271, 6);
			// 
			// hidePolygonsCheckbox
			// 
			this.hidePolygonsCheckbox.Checked = true;
			this.hidePolygonsCheckbox.CheckOnClick = true;
			this.hidePolygonsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.hidePolygonsCheckbox.Name = "hidePolygonsCheckbox";
			this.hidePolygonsCheckbox.Size = new System.Drawing.Size(274, 22);
			this.hidePolygonsCheckbox.Text = "Hide certain polygons/textures";
			this.hidePolygonsCheckbox.Click += new System.EventHandler(this.hidePolygonsCheckbox_Click);
			// 
			// cBlissCheckbox
			// 
			this.cBlissCheckbox.CheckOnClick = true;
			this.cBlissCheckbox.Name = "cBlissCheckbox";
			this.cBlissCheckbox.Size = new System.Drawing.Size(274, 22);
			this.cBlissCheckbox.Text = "Use cBliss costume/portrait mappings";
			this.cBlissCheckbox.Click += new System.EventHandler(this.cBlissCheckbox_Click);
			// 
			// swapPortraitsForWarioStylesToolStripMenuItem
			// 
			this.swapPortraitsForWarioStylesToolStripMenuItem.CheckOnClick = true;
			this.swapPortraitsForWarioStylesToolStripMenuItem.Name = "swapPortraitsForWarioStylesToolStripMenuItem";
			this.swapPortraitsForWarioStylesToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.swapPortraitsForWarioStylesToolStripMenuItem.Text = "Swap portraits for Wario styles";
			this.swapPortraitsForWarioStylesToolStripMenuItem.Click += new System.EventHandler(this.swapPortraitsForWarioStylesToolStripMenuItem_Click);
			// 
			// separator
			// 
			this.separator.Name = "separator";
			this.separator.Size = new System.Drawing.Size(271, 6);
			// 
			// nameportraitPreviewToolStripMenuItem
			// 
			this.nameportraitPreviewToolStripMenuItem.CheckOnClick = true;
			this.nameportraitPreviewToolStripMenuItem.Name = "nameportraitPreviewToolStripMenuItem";
			this.nameportraitPreviewToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.nameportraitPreviewToolStripMenuItem.Text = "Name/portrait preview";
			this.nameportraitPreviewToolStripMenuItem.Click += new System.EventHandler(this.nameportraitPreviewToolStripMenuItem_Click);
			// 
			// separator3
			// 
			this.separator3.Name = "separator3";
			this.separator3.Size = new System.Drawing.Size(271, 6);
			// 
			// aboutBrawlCostumeManagerToolStripMenuItem
			// 
			this.aboutBrawlCostumeManagerToolStripMenuItem.Name = "aboutBrawlCostumeManagerToolStripMenuItem";
			this.aboutBrawlCostumeManagerToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.aboutBrawlCostumeManagerToolStripMenuItem.Text = "About Brawl Costume Manager";
			this.aboutBrawlCostumeManagerToolStripMenuItem.Click += new System.EventHandler(this.aboutBrawlCostumeManagerToolStripMenuItem_Click);
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Right;
			this.button1.Location = new System.Drawing.Point(185, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(20, 406);
			this.button1.TabIndex = 6;
			this.button1.Text = ">";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.spaceFiller1);
			this.flowLayoutPanel1.Controls.Add(this.cssPortraitViewer1);
			this.flowLayoutPanel1.Controls.Add(this.battlePortraitViewer1);
			this.flowLayoutPanel1.Controls.Add(this.resultPortraitViewer1);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(205, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(268, 406);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// spaceFiller1
			// 
			this.spaceFiller1.Location = new System.Drawing.Point(0, 0);
			this.spaceFiller1.Margin = new System.Windows.Forms.Padding(0);
			this.spaceFiller1.Name = "spaceFiller1";
			this.spaceFiller1.Size = new System.Drawing.Size(100, 4);
			this.spaceFiller1.TabIndex = 6;
			// 
			// backgroundColorToolStripMenuItem
			// 
			this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
			this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.backgroundColorToolStripMenuItem.Text = "Right panel BG color...";
			this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
			// 
			// modelManager1
			// 
			this.modelManager1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelManager1.Location = new System.Drawing.Point(0, 0);
			this.modelManager1.Name = "modelManager1";
			this.modelManager1.Size = new System.Drawing.Size(185, 406);
			this.modelManager1.TabIndex = 1;
			// 
			// cssPortraitViewer1
			// 
			this.cssPortraitViewer1.Location = new System.Drawing.Point(3, 7);
			this.cssPortraitViewer1.Name = "cssPortraitViewer1";
			this.cssPortraitViewer1.NamePortraitPreview = false;
			this.cssPortraitViewer1.Size = new System.Drawing.Size(128, 306);
			this.cssPortraitViewer1.TabIndex = 3;
			// 
			// battlePortraitViewer1
			// 
			this.battlePortraitViewer1.Location = new System.Drawing.Point(137, 3);
			this.battlePortraitViewer1.Name = "battlePortraitViewer1";
			this.battlePortraitViewer1.Size = new System.Drawing.Size(128, 100);
			this.battlePortraitViewer1.TabIndex = 5;
			// 
			// resultPortraitViewer1
			// 
			this.resultPortraitViewer1.Location = new System.Drawing.Point(137, 109);
			this.resultPortraitViewer1.Name = "resultPortraitViewer1";
			this.resultPortraitViewer1.Size = new System.Drawing.Size(128, 204);
			this.resultPortraitViewer1.TabIndex = 4;
			// 
			// CostumeManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 406);
			this.Controls.Add(this.splitContainer1);
			this.Name = "CostumeManager";
			this.Text = "Brawl Costume Manager";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private ModelManager modelManager1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ListBox listBox2;
		private CSSPortraitViewer cssPortraitViewer1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private ResultPortraitViewer resultPortraitViewer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton changeDirectory;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem hidePolygonsCheckbox;
		private System.Windows.Forms.ToolStripMenuItem cBlissCheckbox;
		private System.Windows.Forms.ToolStripSeparator separator;
		private System.Windows.Forms.ToolStripMenuItem aboutBrawlCostumeManagerToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToToolStripMenuItem;
		private BattlePortraitViewer battlePortraitViewer1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel spaceFiller1;
		private System.Windows.Forms.ToolStripMenuItem updateSSSStockIconsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.ToolStripSeparator separator3;
		private System.Windows.Forms.ToolStripMenuItem swapPortraitsForWarioStylesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToOtherPacpcsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameportraitPreviewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
	}
}