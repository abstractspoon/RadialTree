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
		public Size NodeSize = new Size(50, 25);
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
			m_InitialRadius = DefaultInitialRadius;
			m_RadialIncrementOrSpacing = m_InitialRadius;

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

		public float DefaultInitialRadius
		{
			get { return ((2 * NodeSize.Width) + NodeSpacing); }
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
			var nodePos = node.GetPosition(offset);
			var nodeRect = node.GetRectangle(NodeSize, offset);

			if (node.Data.NodeBrush != null)
			{
				graphics.FillRectangle(node.Data.NodeBrush, nodeRect);
			}

			if (node.Data.NodePen != null)
			{
				graphics.DrawRectangle(node.Data.NodePen, nodeRect);
			}

			if ((node.Parent != null) && (node.Parent.Data.LinePen != null))
			{
				var parentPos = node.Parent.GetPosition(offset);

				graphics.DrawLine(node.Parent.Data.LinePen, nodePos, parentPos);
			}

			foreach (var child in node.Children)
			{
				DrawNode(graphics, child, offset);
			}
		}

		public void RecalcLayout()
		{
			if (m_EnableLayoutUpdates && (m_RadialTree != null))
			{
				m_RadialTree.CalculatePositions(m_InitialRadius, m_RadialIncrementOrSpacing);
				Invalidate();
			}
		}

	}

	public class CustomType
	{
		public CustomType(uint id, Pen nodePen = null, Brush nodeBrush = null, Pen linePen = null)
		{
			Id = id;
			NodePen = nodePen;
			NodeBrush = nodeBrush;
			LinePen = linePen;
		}

		public readonly uint Id;
		public Brush NodeBrush;
		public Pen NodePen, LinePen;
	}

}
