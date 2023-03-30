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
			this.m_CentreGraph = new System.Windows.Forms.Button();
			this.ZoomIn = new System.Windows.Forms.Button();
			this.ZoomOut = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_NewLayout
			// 
			this.m_NewLayout.Location = new System.Drawing.Point(18, 18);
			this.m_NewLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.m_NewLayout.Name = "m_NewLayout";
			this.m_NewLayout.Size = new System.Drawing.Size(112, 35);
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
			this.m_ShowRootNode.Location = new System.Drawing.Point(18, 63);
			this.m_ShowRootNode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.m_ShowRootNode.Name = "m_ShowRootNode";
			this.m_ShowRootNode.Size = new System.Drawing.Size(147, 24);
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
			this.m_NodeControl.BackColor = System.Drawing.SystemColors.Window;
			this.m_NodeControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_NodeControl.EnableLayoutUpdates = true;
			this.m_NodeControl.InitialRadius = 45F;
			this.m_NodeControl.Location = new System.Drawing.Point(18, 98);
			this.m_NodeControl.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
			this.m_NodeControl.Name = "m_NodeControl";
			this.m_NodeControl.RadialIncrementOrSpacing = 45F;
			this.m_NodeControl.RootNode = null;
			this.m_NodeControl.Size = new System.Drawing.Size(732, 708);
			this.m_NodeControl.TabIndex = 2;
			// 
			// m_CentreGraph
			// 
			this.m_CentreGraph.Location = new System.Drawing.Point(280, 18);
			this.m_CentreGraph.Name = "m_CentreGraph";
			this.m_CentreGraph.Size = new System.Drawing.Size(131, 35);
			this.m_CentreGraph.TabIndex = 3;
			this.m_CentreGraph.Text = "Centre Graph";
			this.m_CentreGraph.UseVisualStyleBackColor = true;
			this.m_CentreGraph.Click += new System.EventHandler(this.OnCentreGraph);
			// 
			// ZoomIn
			// 
			this.ZoomIn.Location = new System.Drawing.Point(417, 18);
			this.ZoomIn.Name = "ZoomIn";
			this.ZoomIn.Size = new System.Drawing.Size(131, 35);
			this.ZoomIn.TabIndex = 3;
			this.ZoomIn.Text = "Zoom In";
			this.ZoomIn.UseVisualStyleBackColor = true;
			this.ZoomIn.Click += new System.EventHandler(this.OnZoomIn);
			// 
			// ZoomOut
			// 
			this.ZoomOut.Location = new System.Drawing.Point(554, 18);
			this.ZoomOut.Name = "ZoomOut";
			this.ZoomOut.Size = new System.Drawing.Size(131, 35);
			this.ZoomOut.TabIndex = 3;
			this.ZoomOut.Text = "Zoom Out";
			this.ZoomOut.UseVisualStyleBackColor = true;
			this.ZoomOut.Click += new System.EventHandler(this.OnZoomOut);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(770, 826);
			this.Controls.Add(this.ZoomOut);
			this.Controls.Add(this.ZoomIn);
			this.Controls.Add(this.m_CentreGraph);
			this.Controls.Add(this.m_NodeControl);
			this.Controls.Add(this.m_ShowRootNode);
			this.Controls.Add(this.m_NewLayout);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
		private System.Windows.Forms.Button m_CentreGraph;
		private System.Windows.Forms.Button ZoomIn;
		private System.Windows.Forms.Button ZoomOut;
	}
}

