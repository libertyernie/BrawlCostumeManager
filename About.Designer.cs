namespace BrawlCostumeManager {
	partial class About {
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
			this.software_title = new System.Windows.Forms.Label();
			this.version = new System.Windows.Forms.Label();
			this.copyright = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.brawllib = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// software_title
			// 
			this.software_title.AutoSize = true;
			this.software_title.Dock = System.Windows.Forms.DockStyle.Left;
			this.software_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.software_title.Location = new System.Drawing.Point(0, 0);
			this.software_title.Name = "software_title";
			this.software_title.Size = new System.Drawing.Size(118, 20);
			this.software_title.TabIndex = 0;
			this.software_title.Text = "software_title";
			// 
			// version
			// 
			this.version.AutoSize = true;
			this.version.Dock = System.Windows.Forms.DockStyle.Right;
			this.version.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.version.Location = new System.Drawing.Point(326, 0);
			this.version.Name = "version";
			this.version.Size = new System.Drawing.Size(66, 20);
			this.version.TabIndex = 1;
			this.version.Text = "version";
			this.version.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// copyright
			// 
			this.copyright.AutoSize = true;
			this.copyright.Dock = System.Windows.Forms.DockStyle.Top;
			this.copyright.Location = new System.Drawing.Point(0, 0);
			this.copyright.Name = "copyright";
			this.copyright.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.copyright.Size = new System.Drawing.Size(50, 17);
			this.copyright.TabIndex = 3;
			this.copyright.Text = "copyright";
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(0, 17);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(392, 156);
			this.textBox1.TabIndex = 4;
			// 
			// brawllib
			// 
			this.brawllib.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.brawllib.Location = new System.Drawing.Point(0, 173);
			this.brawllib.Name = "brawllib";
			this.brawllib.Size = new System.Drawing.Size(392, 32);
			this.brawllib.TabIndex = 5;
			this.brawllib.Text = "brawllib";
			this.brawllib.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.version);
			this.panel1.Controls.Add(this.software_title);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(392, 28);
			this.panel1.TabIndex = 5;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.textBox1);
			this.panel2.Controls.Add(this.brawllib);
			this.panel2.Controls.Add(this.copyright);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 28);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(392, 205);
			this.panel2.TabIndex = 6;
			// 
			// About
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 233);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "About";
			this.Text = "About";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label software_title;
		private System.Windows.Forms.Label version;
		private System.Windows.Forms.Label copyright;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label brawllib;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
	}
}