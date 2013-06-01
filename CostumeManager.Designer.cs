namespace BrawlCharacterManager {
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
			this.modelManager1 = new BrawlCharacterManager.ModelManager();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 273);
			this.listBox1.TabIndex = 0;
			// 
			// modelManager1
			// 
			this.modelManager1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelManager1.Location = new System.Drawing.Point(120, 0);
			this.modelManager1.Name = "modelManager1";
			this.modelManager1.Size = new System.Drawing.Size(172, 273);
			this.modelManager1.TabIndex = 1;
			// 
			// CostumeManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.modelManager1);
			this.Controls.Add(this.listBox1);
			this.Name = "CostumeManager";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private ModelManager modelManager1;
	}
}