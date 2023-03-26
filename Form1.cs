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
		TreeNode<string> m_TreeRoot = new TreeNode<string>("");
		
		public Form1()
		{
			InitializeComponent();

			int nNode = 1;

			for (int i = 0; i < 10; i++)
			{
				var iNode = m_TreeRoot.AddChild(nNode.ToString());
				nNode++;

				for (int j = 0; j < 10; j++)
				{
					var jNode = iNode.AddChild(nNode.ToString());
					nNode++;

					for (int k = 0; k < 10; k++)
					{
						var kNode = jNode.AddChild(nNode.ToString());
					}
				}
			}

			var listOutput = new List<RadialPoint<string>>();
			RadialTree.RadialPositions(m_TreeRoot, 0, (float)(2 * Math.PI), 50, 100, listOutput);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (m_TreeRoot.Count > 0)
			{
				float centreX = ClientSize.Width / 2, centreY = ClientSize.Height / 2;

				foreach (var c1 in m_TreeRoot.Children)
				{
					e.Graphics.FillEllipse(Brushes.Black, centreX + c1.Point.X, centreY + c1.Point.Y, 5, 5);

					foreach (var c2 in c1.Children)
					{
						e.Graphics.FillEllipse(Brushes.Blue, centreX + c2.Point.X, centreY + c2.Point.Y, 5, 5);
						e.Graphics.DrawLine(Pens.Purple, centreX + c1.Point.X, centreY + c1.Point.Y, centreX + c2.Point.X, centreY + c2.Point.Y);

						foreach (var c3 in c2.Children)
						{
							e.Graphics.FillEllipse(Brushes.Red, centreX + c3.Point.X, centreY + c3.Point.Y, 5, 5);
							e.Graphics.DrawLine(Pens.Teal, centreX + c2.Point.X, centreY + c2.Point.Y, centreX + c3.Point.X, centreY + c3.Point.Y);
						}
					}
				}

			}
		}
	}
}
