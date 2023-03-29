using System;
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
		
		RadialTree.TreeNode<CustomType> m_TreeRoot = null;
		RadialTree.RadialTree<CustomType> m_RadialTree = null;

		const int NodeHeight = 10;
		const int NodeWidth = 20;
		const int NodeSpacing = 0;//5;

		readonly float InitialRadius = 50f;
		readonly float RadialIncrement = -(NodeHeight + NodeWidth + NodeSpacing);

		public Form1()
		{
			InitializeComponent();
			OnNewLayout(null, null);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			DrawNode(e.Graphics, m_TreeRoot, new Size((ClientSize.Width / 2), (ClientSize.Height / 2)));
		}

		protected void DrawNode(Graphics graphics, RadialTree.TreeNode<CustomType> node, Size offset)
		{
			var nodePos = GetNodePosition(node, offset);
			var nodeRect = GetNodeRectangle(node, offset);

			if (node.Data.FillBrush != null)
			{
				graphics.FillRectangle(node.Data.FillBrush, nodeRect);
			}

			if ((node.Parent != null) && (node.Parent.Data.LinePen != null))
			{
				var parentPos = GetNodePosition(node.Parent, offset);

				graphics.DrawLine(node.Parent.Data.LinePen, nodePos, parentPos);
			}

			foreach (var child in node.Children)
			{
				DrawNode(graphics, child, offset);
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

			m_TreeRoot = new RadialTree.TreeNode<CustomType>(new CustomType(0, null, null));

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

			m_RadialTree = new RadialTree.RadialTree<CustomType>(m_TreeRoot, InitialRadius, RadialIncrement);
			OnShowRootNode(null, null);

			Invalidate();
		}

		private void OnShowRootNode(object sender, EventArgs e)
		{
			float initialRadius = InitialRadius;

			if (ShowRootNode.Checked)
			{
				m_TreeRoot.Data.FillBrush = Brushes.Gray;
				m_TreeRoot.Data.LinePen = Pens.Gray;
			}
			else
			{
				m_TreeRoot.Data.FillBrush = null;
				m_TreeRoot.Data.LinePen = null;

				initialRadius = (m_TreeRoot.Count * -RadialIncrement) / (float)(2 * Math.PI);
			}
			m_RadialTree.CalculatePositions(initialRadius, RadialIncrement);

			Invalidate();
		}

		private Rectangle GetNodeRectangle(RadialTree.TreeNode<CustomType> node, Size offset)
		{
			var pos = GetNodePosition(node, offset);

			return new Rectangle((pos.X - NodeWidth / 2), (pos.Y - NodeHeight / 2), NodeWidth, NodeHeight);
		}

		private System.Drawing.Point GetNodePosition(RadialTree.TreeNode<CustomType> node, Size offset)
		{
			return new System.Drawing.Point((offset.Width + (int)node.Point.X), (offset.Height + (int)node.Point.Y));
		}
	}
}
