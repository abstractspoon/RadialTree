﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RadialTreeDemo
{
	public partial class Form1 : Form
	{
		private readonly Size m_DefaultNodeSize = new Size(50, 25);

		public Form1()
		{
			InitializeComponent();
			OnNewLayout(null, null);
		}

		private void OnNewLayout(object sender, EventArgs e)
		{
			uint nNode = 1;
			const int nMinNodes = 1, nMaxNodes = 6;
			Random rnd = new Random();

			var rootNode = new RadialTree.TreeNode<CustomType>(new CustomType(0, Pens.Gray, SystemBrushes.Window, Pens.Gray));

			int iNodes = rnd.Next(nMinNodes, nMaxNodes);

			for (int i = 0; i < iNodes; i++)
			{
				var iNode = rootNode.AddChild(new CustomType(nNode, Pens.Black, SystemBrushes.Window, Pens.Purple));
				nNode++;

				int jNodes = rnd.Next(nMinNodes, nMaxNodes);

				for (int j = 0; j < jNodes; j++)
				{
					var jNode = iNode.AddChild(new CustomType(nNode, Pens.Blue, SystemBrushes.Window, Pens.Teal));
					nNode++;

					int kNodes = rnd.Next(0, nMaxNodes);

					for (int k = 0; k < kNodes; k++)
					{
						var kNode = jNode.AddChild(new CustomType(nNode, Pens.Red, SystemBrushes.Window, null));
					}
				}
			}

			m_NodeControl.EnableLayoutUpdates = false;

			m_NodeControl.RootNode = rootNode;
			ShowRootNode(m_ShowRootNode.Checked);

			m_NodeControl.EnableLayoutUpdates = true;
		}

		private void OnShowRootNode(object sender, EventArgs e)
		{
			ShowRootNode(m_ShowRootNode.Checked);
		}

		private void ShowRootNode(bool show)
		{
			m_NodeControl.RootNode.Data.NodePen = (show ? Pens.Gray : null);
			m_NodeControl.RootNode.Data.NodeBrush = (show ? SystemBrushes.Window : null);
			m_NodeControl.RootNode.Data.LinePen = (show ? Pens.Gray : null);

			if (show)
			{
				m_NodeControl.InitialRadius = m_NodeControl.DefaultInitialRadius;
				m_NodeControl.RadialIncrementOrSpacing = m_NodeControl.DefaultInitialRadius;
			}
			else
			{
				m_NodeControl.InitialRadius = ((m_NodeControl.RootNode.Count * m_NodeControl.RadialIncrementOrSpacing) / (float)(2 * Math.PI));
			}
		}

		private void OnCentreGraph(object sender, EventArgs e)
		{
			m_NodeControl.CentreGraph();
		}

		private void OnZoomIn(object sender, EventArgs e)
		{
			m_NodeControl.ZoomIn();
		}

		private void OnZoomOut(object sender, EventArgs e)
		{
			m_NodeControl.ZoomOut();
		}
	}
}
