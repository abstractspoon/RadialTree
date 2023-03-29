namespace RadialTreeDemo
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
			this.m_NewLayout = new System.Windows.Forms.Button();
			this.m_ShowRootNode = new System.Windows.Forms.CheckBox();
			this.m_NodeControl = new RadialTreeDemo.NodeControl();
			this.SuspendLayout();
			// 
			// m_NewLayout
			// 
			this.m_NewLayout.Location = new System.Drawing.Point(12, 12);
			this.m_NewLayout.Name = "m_NewLayout";
			this.m_NewLayout.Size = new System.Drawing.Size(75, 23);
			this.m_NewLayout.TabIndex = 0;
			this.m_NewLayout.Text = "New Layout";
			this.m_NewLayout.UseVisualStyleBackColor = true;
			this.m_NewLayout.Click += new System.EventHandler(this.OnNewLayout);
			// 
			// m_ShowRootNode
			// 
			this.m_ShowRootNode.AutoSize = true;
			this.m_ShowRootNode.Checked = true;
			this.m_ShowRootNode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ShowRootNode.Location = new System.Drawing.Point(12, 41);
			this.m_ShowRootNode.Name = "m_ShowRootNode";
			this.m_ShowRootNode.Size = new System.Drawing.Size(101, 17);
			this.m_ShowRootNode.TabIndex = 1;
			this.m_ShowRootNode.Text = "Show root node";
			this.m_ShowRootNode.UseVisualStyleBackColor = true;
			this.m_ShowRootNode.CheckedChanged += new System.EventHandler(this.OnShowRootNode);
			// 
			// m_NodeControl
			// 
			this.m_NodeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.m_NodeControl.AutoCalculateRadialIncrement = false;
			this.m_NodeControl.AutoScroll = true;
			this.m_NodeControl.BackColor = System.Drawing.SystemColors.Window;
			this.m_NodeControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_NodeControl.EnableLayoutUpdates = true;
			this.m_NodeControl.InitialRadius = 45F;
			this.m_NodeControl.Location = new System.Drawing.Point(12, 64);
			this.m_NodeControl.Name = "m_NodeControl";
			this.m_NodeControl.RadialIncrementOrSpacing = 45F;
			this.m_NodeControl.RootNode = null;
			this.m_NodeControl.Size = new System.Drawing.Size(489, 461);
			this.m_NodeControl.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(513, 537);
			this.Controls.Add(this.m_NodeControl);
			this.Controls.Add(this.m_ShowRootNode);
			this.Controls.Add(this.m_NewLayout);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button m_NewLayout;
		private System.Windows.Forms.CheckBox m_ShowRootNode;
		private RadialTreeDemo.NodeControl m_NodeControl;
	}
}

