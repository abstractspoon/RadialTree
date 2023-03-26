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

			this.CenterToScreen();

			int nNode = 1, nMinNodes = 2, nMaxNodes = 6;
			Random rnd = new Random();

			int iNodes = rnd.Next(nMinNodes, nMaxNodes);

			for (int i = 0; i < iNodes; i++)
			{
				var iNode = m_TreeRoot.AddChild(nNode.ToString());
				nNode++;

				int jNodes = rnd.Next(nMinNodes, nMaxNodes);

				for (int j = 0; j < jNodes; j++)
				{
					var jNode = iNode.AddChild(nNode.ToString());
					nNode++;

					int kNodes = rnd.Next(nMinNodes, nMaxNodes);

					for (int k = 0; k < kNodes; k++)
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
				float radius = 15;

				foreach (var c1 in m_TreeRoot.Children)
				{
					float centre1X = centreX + c1.Point.X;
					float centre1Y = centreY + c1.Point.Y;

					e.Graphics.FillEllipse(Brushes.Black, centre1X - radius / 2, centre1Y - radius / 2, radius, radius);

					foreach (var c2 in c1.Children)
					{
						float centre2X = centreX + c2.Point.X;
						float centre2Y = centreY + c2.Point.Y;

						e.Graphics.FillEllipse(Brushes.Blue, centre2X - radius / 2, centre2Y - radius / 2, radius, radius);
						e.Graphics.DrawLine(Pens.Purple, centre1X, centre1Y, centre2X, centre2Y);

						foreach (var c3 in c2.Children)
						{
							float centre3X = centreX + c3.Point.X;
							float centre3Y = centreY + c3.Point.Y;

							e.Graphics.FillEllipse(Brushes.Red, centre3X - radius / 2, centre3Y - radius / 2, radius, radius);
							e.Graphics.DrawLine(Pens.Teal, centre2X, centre2Y, centre3X, centre3Y);
						}
					}
				}

			}
		}
	}
}
