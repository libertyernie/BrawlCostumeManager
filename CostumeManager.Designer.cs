﻿namespace BrawlCharacterManager {
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.modelManager1 = new BrawlCharacterManager.ModelManager();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.cssPortraitViewer1 = new BrawlCharacterManager.CSSPortraitViewer();
			this.resultPortraitViewer1 = new BrawlCharacterManager.ResultPortraitViewer();
			this.changeDirectory = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(196, 231);
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
			this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
			this.splitContainer1.Size = new System.Drawing.Size(592, 493);
			this.splitContainer1.SplitterDistance = 196;
			this.splitContainer1.TabIndex = 2;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeDirectory});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(196, 25);
			this.toolStrip1.TabIndex = 6;
			this.toolStrip1.Text = "toolStrip1";
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
			this.splitContainer2.Size = new System.Drawing.Size(196, 468);
			this.splitContainer2.SplitterDistance = 231;
			this.splitContainer2.TabIndex = 1;
			// 
			// listBox2
			// 
			this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point(0, 0);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(196, 233);
			this.listBox2.TabIndex = 0;
			this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
			// 
			// modelManager1
			// 
			this.modelManager1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelManager1.Location = new System.Drawing.Point(0, 0);
			this.modelManager1.Name = "modelManager1";
			this.modelManager1.Size = new System.Drawing.Size(258, 493);
			this.modelManager1.TabIndex = 1;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.cssPortraitViewer1);
			this.flowLayoutPanel1.Controls.Add(this.resultPortraitViewer1);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(258, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(134, 493);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// cssPortraitViewer1
			// 
			this.cssPortraitViewer1.Location = new System.Drawing.Point(3, 3);
			this.cssPortraitViewer1.Name = "cssPortraitViewer1";
			this.cssPortraitViewer1.Size = new System.Drawing.Size(128, 240);
			this.cssPortraitViewer1.TabIndex = 3;
			// 
			// resultPortraitViewer1
			// 
			this.resultPortraitViewer1.Location = new System.Drawing.Point(3, 249);
			this.resultPortraitViewer1.Name = "resultPortraitViewer1";
			this.resultPortraitViewer1.Size = new System.Drawing.Size(128, 240);
			this.resultPortraitViewer1.TabIndex = 4;
			// 
			// changeDirectory
			// 
			this.changeDirectory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.changeDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.changeDirectory.Name = "changeDirectory";
			this.changeDirectory.Size = new System.Drawing.Size(95, 22);
			this.changeDirectory.Text = "Change Directory";
			this.changeDirectory.Click += new System.EventHandler(this.changeDirectory_Click);
			// 
			// CostumeManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 493);
			this.Controls.Add(this.splitContainer1);
			this.Name = "CostumeManager";
			this.Text = "Form1";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
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
	}
}