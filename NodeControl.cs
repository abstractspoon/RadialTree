using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RadialTreeDemo
{
	public partial class NodeControl : UserControl
	{
		public int NodeHeight = 10;
		public int NodeWidth = 20;
		public int NodeSpacing = 5;

		float m_InitialRadius = 50f;
		float m_RadialIncrementOrSpacing = 50f;

		RadialTree.TreeNode<CustomType> m_RootNode = null;
		RadialTree.RadialTree<CustomType> m_RadialTree = null;

		bool m_AutoCalcRadialIncrement = false;
		bool m_EnableLayoutUpdates = true;

		// -------------------------------------------------------------------

		public NodeControl()
		{
			m_InitialRadius = (NodeWidth + NodeWidth + NodeSpacing);
			m_RadialIncrementOrSpacing = (NodeWidth + NodeWidth + NodeSpacing);

			InitializeComponent();
		}

		public bool AutoCalculateRadialIncrement
		{
			get { return m_AutoCalcRadialIncrement; }

			set
			{
				if (value != m_AutoCalcRadialIncrement)
				{
					m_AutoCalcRadialIncrement = value;
					RecalcLayout();
				}
			}
		}

		public bool EnableLayoutUpdates
		{
			get { return m_EnableLayoutUpdates; }

			set
			{
				if (value != m_EnableLayoutUpdates)
				{
					m_EnableLayoutUpdates = value;

					if (value)
						RecalcLayout();
				}
			}
		}

		public float RadialIncrementOrSpacing
		{
			get { return m_RadialIncrementOrSpacing; }

			set
			{
				if ((value > 0f) && (value != m_RadialIncrementOrSpacing))
				{
					m_RadialIncrementOrSpacing = value;
					RecalcLayout();
				}
			}
		}

		public float InitialRadius
		{
			get { return m_InitialRadius; }

			set
			{
				if ((value > 0f) && (value != m_InitialRadius))
				{
					m_InitialRadius = value;
					RecalcLayout();
				}
			}
		}

		public RadialTree.TreeNode<CustomType> RootNode
		{
			get { return m_RootNode; }

			set
			{
				if ((value != null) && (value != m_RootNode))
				{
					m_RootNode = value;
					m_RadialTree = new RadialTree.RadialTree<CustomType>(value, m_InitialRadius, (AutoCalculateRadialIncrement ? -m_RadialIncrementOrSpacing : m_RadialIncrementOrSpacing));

					RecalcLayout();
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (RootNode != null)
			{
				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

				DrawNode(e.Graphics, RootNode, new Size((ClientSize.Width / 2), (ClientSize.Height / 2)));
			}
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

		public Rectangle GetNodeRectangle(RadialTree.TreeNode<CustomType> node, Size offset)
		{
			var pos = GetNodePosition(node, offset);

			return new Rectangle((pos.X - NodeWidth / 2), (pos.Y - NodeHeight / 2), NodeWidth, NodeHeight);
		}

		public System.Drawing.Point GetNodePosition(RadialTree.TreeNode<CustomType> node, Size offset)
		{
			return new System.Drawing.Point((offset.Width + (int)node.Point.X), (offset.Height + (int)node.Point.Y));
		}

		public void RecalcLayout()
		{
			if (m_EnableLayoutUpdates)
			{
				m_RadialTree.CalculatePositions(m_InitialRadius, m_RadialIncrementOrSpacing);
				Invalidate();
			}
		}

	}

	public class CustomType
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

}
