﻿namespace BrawlCostumeManager {
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
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToOtherPacpcsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.changeDirectory = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.screenshotPortraitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updateSSSStockIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updateMewtwoHatForCurrentKirbyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.limitModelViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.defaultZoomLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.hidePolygonsCheckbox = new System.Windows.Forms.ToolStripMenuItem();
			this.swapPortraitsForWarioStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cBlissCheckbox = new System.Windows.Forms.ToolStripMenuItem();
			this.projectMCheckbox = new System.Windows.Forms.ToolStripMenuItem();
			this.separator = new System.Windows.Forms.ToolStripSeparator();
			this.nameportraitPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.otherPVsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.battlePortraitViewer1 = new BrawlCostumeManager.BattleSinglePortraitViewer();
			this.resultPortraitViewer1 = new BrawlCostumeManager.ResultSinglePortraitViewer();
			this.collapsibleSplitter2 = new BrawlManagerLib.CollapsibleSplitter();
			this.collapsibleSplitter3 = new BrawlManagerLib.CollapsibleSplitter();
			this.modelManager1 = new BrawlCostumeManager.ModelManager();
			this.collapsibleSplitter1 = new BrawlManagerLib.CollapsibleSplitter();
			this.cssPortraitViewer1 = new BrawlCostumeManager.CSSPortraitViewer();
			this.costumeNumberLabel = new BrawlCostumeManager.CostumeNumberLabel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.otherPVsFlowLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(206, 187);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Left;
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
			this.splitContainer2.Size = new System.Drawing.Size(206, 381);
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
			this.listBox2.Size = new System.Drawing.Size(206, 190);
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
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1,
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(684, 25);
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
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.screenshotPortraitsToolStripMenuItem,
            this.updateSSSStockIconsToolStripMenuItem,
            this.updateMewtwoHatForCurrentKirbyToolStripMenuItem});
			this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(49, 22);
			this.toolStripDropDownButton2.Text = "Tools";
			// 
			// screenshotPortraitsToolStripMenuItem
			// 
			this.screenshotPortraitsToolStripMenuItem.Name = "screenshotPortraitsToolStripMenuItem";
			this.screenshotPortraitsToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
			this.screenshotPortraitsToolStripMenuItem.Text = "Screenshot -> portraits";
			this.screenshotPortraitsToolStripMenuItem.Click += new System.EventHandler(this.screenshotPortraitsToolStripMenuItem_Click);
			// 
			// updateSSSStockIconsToolStripMenuItem
			// 
			this.updateSSSStockIconsToolStripMenuItem.Name = "updateSSSStockIconsToolStripMenuItem";
			this.updateSSSStockIconsToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
			this.updateSSSStockIconsToolStripMenuItem.Text = "Copy stock icons to SSS";
			this.updateSSSStockIconsToolStripMenuItem.Click += new System.EventHandler(this.updateSSSStockIconsToolStripMenuItem_Click);
			// 
			// updateMewtwoHatForCurrentKirbyToolStripMenuItem
			// 
			this.updateMewtwoHatForCurrentKirbyToolStripMenuItem.Name = "updateMewtwoHatForCurrentKirbyToolStripMenuItem";
			this.updateMewtwoHatForCurrentKirbyToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
			this.updateMewtwoHatForCurrentKirbyToolStripMenuItem.Text = "Update Mewtwo hat for current Kirby";
			this.updateMewtwoHatForCurrentKirbyToolStripMenuItem.Click += new System.EventHandler(this.updateMewtwoHatForCurrentKirbyToolStripMenuItem_Click);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limitModelViewerToolStripMenuItem,
            this.defaultZoomLevelToolStripMenuItem,
            this.separator2,
            this.hidePolygonsCheckbox,
            this.swapPortraitsForWarioStylesToolStripMenuItem,
            this.cBlissCheckbox,
            this.projectMCheckbox,
            this.separator,
            this.nameportraitPreviewToolStripMenuItem,
            this.backgroundColorToolStripMenuItem});
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(62, 22);
			this.toolStripDropDownButton1.Text = "Options";
			// 
			// limitModelViewerToolStripMenuItem
			// 
			this.limitModelViewerToolStripMenuItem.CheckOnClick = true;
			this.limitModelViewerToolStripMenuItem.Name = "limitModelViewerToolStripMenuItem";
			this.limitModelViewerToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.limitModelViewerToolStripMenuItem.Text = "Limit model viewer to 256x320";
			this.limitModelViewerToolStripMenuItem.Click += new System.EventHandler(this.limitModelViewerToolStripMenuItem_Click);
			// 
			// defaultZoomLevelToolStripMenuItem
			// 
			this.defaultZoomLevelToolStripMenuItem.Checked = true;
			this.defaultZoomLevelToolStripMenuItem.CheckOnClick = true;
			this.defaultZoomLevelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.defaultZoomLevelToolStripMenuItem.Name = "defaultZoomLevelToolStripMenuItem";
			this.defaultZoomLevelToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.defaultZoomLevelToolStripMenuItem.Text = "+-20 default X bounds";
			this.defaultZoomLevelToolStripMenuItem.Click += new System.EventHandler(this.defaultZoomLevelToolStripMenuItem_Click);
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
			// swapPortraitsForWarioStylesToolStripMenuItem
			// 
			this.swapPortraitsForWarioStylesToolStripMenuItem.CheckOnClick = true;
			this.swapPortraitsForWarioStylesToolStripMenuItem.Name = "swapPortraitsForWarioStylesToolStripMenuItem";
			this.swapPortraitsForWarioStylesToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.swapPortraitsForWarioStylesToolStripMenuItem.Text = "Swap portraits for Wario styles";
			this.swapPortraitsForWarioStylesToolStripMenuItem.Visible = false;
			this.swapPortraitsForWarioStylesToolStripMenuItem.Click += new System.EventHandler(this.swapPortraitsForWarioStylesToolStripMenuItem_Click);
			// 
			// cBlissCheckbox
			// 
			this.cBlissCheckbox.CheckOnClick = true;
			this.cBlissCheckbox.Name = "cBlissCheckbox";
			this.cBlissCheckbox.Size = new System.Drawing.Size(274, 22);
			this.cBlissCheckbox.Text = "Use cBliss costume/portrait mappings";
			this.cBlissCheckbox.Click += new System.EventHandler(this.cBlissCheckbox_Click);
			// 
			// projectMCheckbox
			// 
			this.projectMCheckbox.CheckOnClick = true;
			this.projectMCheckbox.Name = "projectMCheckbox";
			this.projectMCheckbox.Size = new System.Drawing.Size(274, 22);
			this.projectMCheckbox.Text = "Use Project M 3.5 mappings";
			this.projectMCheckbox.Click += new System.EventHandler(this.projectMCheckbox_Click);
			// 
			// separator
			// 
			this.separator.Name = "separator";
			this.separator.Size = new System.Drawing.Size(271, 6);
			// 
			// nameportraitPreviewToolStripMenuItem
			// 
			this.nameportraitPreviewToolStripMenuItem.Checked = true;
			this.nameportraitPreviewToolStripMenuItem.CheckOnClick = true;
			this.nameportraitPreviewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nameportraitPreviewToolStripMenuItem.Name = "nameportraitPreviewToolStripMenuItem";
			this.nameportraitPreviewToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.nameportraitPreviewToolStripMenuItem.Text = "Name/portrait preview";
			this.nameportraitPreviewToolStripMenuItem.Click += new System.EventHandler(this.nameportraitPreviewToolStripMenuItem_Click);
			// 
			// backgroundColorToolStripMenuItem
			// 
			this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
			this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.backgroundColorToolStripMenuItem.Text = "Right panel BG color...";
			this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(44, 22);
			this.toolStripButton1.Text = "About";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// otherPVsFlowLayoutPanel
			// 
			this.otherPVsFlowLayoutPanel.AutoSize = true;
			this.otherPVsFlowLayoutPanel.Controls.Add(this.costumeNumberLabel);
			this.otherPVsFlowLayoutPanel.Controls.Add(this.battlePortraitViewer1);
			this.otherPVsFlowLayoutPanel.Controls.Add(this.resultPortraitViewer1);
			this.otherPVsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.otherPVsFlowLayoutPanel.Location = new System.Drawing.Point(550, 25);
			this.otherPVsFlowLayoutPanel.Name = "otherPVsFlowLayoutPanel";
			this.otherPVsFlowLayoutPanel.Size = new System.Drawing.Size(134, 381);
			this.otherPVsFlowLayoutPanel.TabIndex = 7;
			// 
			// battlePortraitViewer1
			// 
			this.battlePortraitViewer1.Location = new System.Drawing.Point(3, 23);
			this.battlePortraitViewer1.Name = "battlePortraitViewer1";
			this.battlePortraitViewer1.Size = new System.Drawing.Size(128, 120);
			this.battlePortraitViewer1.TabIndex = 5;
			// 
			// resultPortraitViewer1
			// 
			this.resultPortraitViewer1.Location = new System.Drawing.Point(3, 149);
			this.resultPortraitViewer1.Name = "resultPortraitViewer1";
			this.resultPortraitViewer1.Size = new System.Drawing.Size(128, 224);
			this.resultPortraitViewer1.TabIndex = 4;
			// 
			// collapsibleSplitter2
			// 
			this.collapsibleSplitter2.AnimationDelay = 20;
			this.collapsibleSplitter2.AnimationStep = 20;
			this.collapsibleSplitter2.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
			this.collapsibleSplitter2.ControlToHide = this.otherPVsFlowLayoutPanel;
			this.collapsibleSplitter2.Dock = System.Windows.Forms.DockStyle.Right;
			this.collapsibleSplitter2.ExpandParentForm = false;
			this.collapsibleSplitter2.Location = new System.Drawing.Point(542, 25);
			this.collapsibleSplitter2.Name = "collapsibleSplitter2";
			this.collapsibleSplitter2.Size = new System.Drawing.Size(8, 381);
			this.collapsibleSplitter2.TabIndex = 0;
			this.collapsibleSplitter2.TabStop = false;
			this.collapsibleSplitter2.UseAnimations = false;
			this.collapsibleSplitter2.VisualStyle = BrawlManagerLib.VisualStyles.Mozilla;
			// 
			// collapsibleSplitter3
			// 
			this.collapsibleSplitter3.AnimationDelay = 20;
			this.collapsibleSplitter3.AnimationStep = 20;
			this.collapsibleSplitter3.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
			this.collapsibleSplitter3.ControlToHide = this.splitContainer2;
			this.collapsibleSplitter3.ExpandParentForm = false;
			this.collapsibleSplitter3.Location = new System.Drawing.Point(206, 25);
			this.collapsibleSplitter3.Name = "collapsibleSplitter3";
			this.collapsibleSplitter3.Size = new System.Drawing.Size(8, 381);
			this.collapsibleSplitter3.TabIndex = 8;
			this.collapsibleSplitter3.TabStop = false;
			this.collapsibleSplitter3.UseAnimations = false;
			this.collapsibleSplitter3.VisualStyle = BrawlManagerLib.VisualStyles.Mozilla;
			// 
			// modelManager1
			// 
			this.modelManager1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelManager1.Location = new System.Drawing.Point(214, 25);
			this.modelManager1.ModelPreviewSize = null;
			this.modelManager1.Name = "modelManager1";
			this.modelManager1.Size = new System.Drawing.Size(192, 381);
			this.modelManager1.TabIndex = 1;
			// 
			// collapsibleSplitter1
			// 
			this.collapsibleSplitter1.AnimationDelay = 20;
			this.collapsibleSplitter1.AnimationStep = 20;
			this.collapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
			this.collapsibleSplitter1.ControlToHide = this.cssPortraitViewer1;
			this.collapsibleSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.collapsibleSplitter1.ExpandParentForm = false;
			this.collapsibleSplitter1.Location = new System.Drawing.Point(406, 25);
			this.collapsibleSplitter1.Name = "collapsibleSplitter1";
			this.collapsibleSplitter1.Size = new System.Drawing.Size(8, 381);
			this.collapsibleSplitter1.TabIndex = 0;
			this.collapsibleSplitter1.TabStop = false;
			this.collapsibleSplitter1.UseAnimations = false;
			this.collapsibleSplitter1.VisualStyle = BrawlManagerLib.VisualStyles.Mozilla;
			// 
			// cssPortraitViewer1
			// 
			this.cssPortraitViewer1.Dock = System.Windows.Forms.DockStyle.Right;
			this.cssPortraitViewer1.Location = new System.Drawing.Point(414, 25);
			this.cssPortraitViewer1.Name = "cssPortraitViewer1";
			this.cssPortraitViewer1.NamePortraitPreview = false;
			this.cssPortraitViewer1.Size = new System.Drawing.Size(128, 381);
			this.cssPortraitViewer1.TabIndex = 3;
			// 
			// costumeNumberLabel
			// 
			this.costumeNumberLabel.Location = new System.Drawing.Point(3, 0);
			this.costumeNumberLabel.Name = "costumeNumberLabel";
			this.costumeNumberLabel.Size = new System.Drawing.Size(128, 20);
			this.costumeNumberLabel.TabIndex = 6;
			this.costumeNumberLabel.Text = "No costume selected";
			this.costumeNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CostumeManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 406);
			this.Controls.Add(this.modelManager1);
			this.Controls.Add(this.collapsibleSplitter3);
			this.Controls.Add(this.splitContainer2);
			this.Controls.Add(this.collapsibleSplitter1);
			this.Controls.Add(this.cssPortraitViewer1);
			this.Controls.Add(this.collapsibleSplitter2);
			this.Controls.Add(this.otherPVsFlowLayoutPanel);
			this.Controls.Add(this.toolStrip1);
			this.Name = "CostumeManager";
			this.Text = "Brawl Costume Manager";
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.otherPVsFlowLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private ModelManager modelManager1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ListBox listBox2;
		private CSSPortraitViewer cssPortraitViewer1;
		private ResultSinglePortraitViewer resultPortraitViewer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton changeDirectory;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem hidePolygonsCheckbox;
		private System.Windows.Forms.ToolStripMenuItem cBlissCheckbox;
		private System.Windows.Forms.ToolStripSeparator separator;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToToolStripMenuItem;
		private BattleSinglePortraitViewer battlePortraitViewer1;
		private System.Windows.Forms.ToolStripMenuItem updateSSSStockIconsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.ToolStripMenuItem swapPortraitsForWarioStylesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToOtherPacpcsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameportraitPreviewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem screenshotPortraitsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem limitModelViewerToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
		private System.Windows.Forms.ToolStripMenuItem defaultZoomLevelToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripMenuItem projectMCheckbox;
		private System.Windows.Forms.FlowLayoutPanel otherPVsFlowLayoutPanel;
		private BrawlManagerLib.CollapsibleSplitter collapsibleSplitter1;
		private BrawlManagerLib.CollapsibleSplitter collapsibleSplitter2;
		private BrawlManagerLib.CollapsibleSplitter collapsibleSplitter3;
		private System.Windows.Forms.ToolStripMenuItem updateMewtwoHatForCurrentKirbyToolStripMenuItem;
		private CostumeNumberLabel costumeNumberLabel;
	}
}