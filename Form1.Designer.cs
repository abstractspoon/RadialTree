namespace RadialTree
{
	partial class Form1
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
			this.NewLayout = new System.Windows.Forms.Button();
			this.ShowRootNode = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// NewLayout
			// 
			this.NewLayout.Location = new System.Drawing.Point(12, 12);
			this.NewLayout.Name = "NewLayout";
			this.NewLayout.Size = new System.Drawing.Size(75, 23);
			this.NewLayout.TabIndex = 0;
			this.NewLayout.Text = "New Layout";
			this.NewLayout.UseVisualStyleBackColor = true;
			this.NewLayout.Click += new System.EventHandler(this.OnNewLayout);
			// 
			// ShowRootNode
			// 
			this.ShowRootNode.AutoSize = true;
			this.ShowRootNode.Location = new System.Drawing.Point(12, 41);
			this.ShowRootNode.Name = "ShowRootNode";
			this.ShowRootNode.Size = new System.Drawing.Size(145, 17);
			this.ShowRootNode.TabIndex = 1;
			this.ShowRootNode.Text = "Toggle root node visibility";
			this.ShowRootNode.UseVisualStyleBackColor = true;
			this.ShowRootNode.CheckedChanged += new System.EventHandler(this.OnShowRootNode);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(698, 537);
			this.Controls.Add(this.ShowRootNode);
			this.Controls.Add(this.NewLayout);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button NewLayout;
		private System.Windows.Forms.CheckBox ShowRootNode;
	}
}

