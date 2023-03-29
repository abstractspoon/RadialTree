using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RadialTree
{
	public partial class Form1 : Form
	{
		protected class CustomType
		{
			public CustomType(uint id, Brush fillBrush = null, Pen linePen = null)
			{
				Id = id;
				FillBrush = fillBrush;
				LinePen = linePen;
			}

			public readonly uint Id;
			public Brush FillBrush;
			public Pen LinePen;
		}
		
		TreeNode<CustomType> m_TreeRoot = null;
		RadialTree<CustomType> m_RadialTree = null;

		public Form1()
		{
			InitializeComponent();
			OnNewLayout(null, null);

			WindowState = FormWindowState.Maximized;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			DrawNode(e.Graphics, m_TreeRoot, (ClientSize.Width / 2), (ClientSize.Height / 2));
		}

		protected void DrawNode(Graphics graphics, TreeNode<CustomType> node, float panelCentreX, float panelCentreY)
		{
			const float nodeRadius = 5;

			float nodeX = panelCentreX + node.Point.X;
			float nodeY = panelCentreY + node.Point.Y;

			if (node.Data.FillBrush != null)
			{
				graphics.FillEllipse(node.Data.FillBrush, nodeX - nodeRadius, nodeY - nodeRadius, nodeRadius * 2, nodeRadius * 2);
			}

			if ((node.Parent != null) && (node.Parent.Data.LinePen != null))
			{
				float parentX = panelCentreX + node.Parent.Point.X;
				float parentY = panelCentreY + node.Parent.Point.Y;

				graphics.DrawLine(node.Parent.Data.LinePen, nodeX, nodeY, parentX, parentY);
			}

			foreach (var child in node.Children)
			{
				DrawNode(graphics, child, panelCentreX, panelCentreY);
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			Invalidate();
		}

		private void OnNewLayout(object sender, EventArgs e)
		{
			uint nNode = 1;
			const int nMinNodes = 1, nMaxNodes = 6;
			Random rnd = new Random();

			m_TreeRoot = new TreeNode<CustomType>(new CustomType(0, null, null));

			int iNodes = rnd.Next(nMinNodes, nMaxNodes);

			for (int i = 0; i < iNodes; i++)
			{
				var iNode = m_TreeRoot.AddChild(new CustomType(nNode, Brushes.Black, Pens.Purple));
				nNode++;

				int jNodes = rnd.Next(nMinNodes, nMaxNodes);

				for (int j = 0; j < jNodes; j++)
				{
					var jNode = iNode.AddChild(new CustomType(nNode, Brushes.Blue, Pens.Teal));
					nNode++;

					int kNodes = rnd.Next(0, nMaxNodes);

					for (int k = 0; k < kNodes; k++)
					{
						var kNode = jNode.AddChild(new CustomType(nNode, Brushes.Red, null));
					}
				}
			}

			m_RadialTree = new RadialTree<CustomType>(m_TreeRoot, 50, -30);
			//m_RadialTree = new RadialTree<uint>(m_TreeRoot, 50, 100);

			m_RadialTree.CalculatePositions();

			Invalidate();
		}

		private void OnShowRootNode(object sender, EventArgs e)
		{
			if (ShowRootNode.Checked)
			{
				m_TreeRoot.Data.FillBrush = Brushes.Gray;
				m_TreeRoot.Data.LinePen = Pens.Gray;
			}
			else
			{
				m_TreeRoot.Data.FillBrush = null;
				m_TreeRoot.Data.LinePen = null;
			}

			Invalidate();
		}
	}
}
