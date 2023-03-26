using System;
using System.Collections.Generic;

namespace RadialTree
{
    public class RadialTree
    {
        /// <summary>
        /// Calculate the positions of each node in a radial layout.
        /// </summary>
        /// <param name="node">The node you want to create the layout from.</param>
        /// <param name="alfa">The start angle for the radial layout (Radians).</param>
        /// <param name="beta">The amount of the circle to use for the radial layout (Radians).</param>
        /// <param name="circleRadius">Distance between the root node and first children.</param>
        /// <param name="deltaDistance">Distance between other child nodes.</param>
        /// <param name="outputGraph">Calculated positions for the nodes.</param>
        public static void RadialPositions<T>(TreeNode<T> node, float startAngleRad, float endAngleRad, float circleRadius, float deltaDistance, List<RadialPoint<T>> outputGraph)
        {
            //check if node is root of the tree
            if (node.IsRoot)
            {
                node.Point.X = 0;
                node.Point.Y = 0;
				outputGraph.Add(new RadialPoint<T>
				{
					Node = node,
					Point = new Point(0f, 0f),
                    ParentPoint = null
                });

            }
            //Depth of node starting from 0
            int depthOfVertex = node.Level;
            float theta = startAngleRad;
            float radius = circleRadius + (deltaDistance * depthOfVertex);

            int leavesNumber = BreadthFirstSearch(node);
            foreach (var child in node.Children)
            {
                float lambda = BreadthFirstSearch(child);
                float mi = theta + (lambda / leavesNumber * (endAngleRad - startAngleRad));

                float x = (float)(radius * Math.Cos((theta + mi) / 2.0));
                float y = (float)(radius * Math.Sin((theta + mi) / 2.0));

                child.Point.X = x;
                child.Point.Y = y;

                outputGraph.Add(new RadialPoint<T>
                {
                    Node = child,
                    Point = new Point(x, y, radius),
                    ParentPoint = node.Point
                });

                if (child.Children.Count > 0)
                {
                    child.Point.Y = y;
                    child.Point.X = x;
                    RadialPositions(child, theta, mi, circleRadius, deltaDistance, outputGraph);
                }
                theta = mi;
            }
        }

        private static int BreadthFirstSearch<T>(TreeNode<T> root)
        {
            var visited = new List<TreeNode<T>>();
            var queue = new Queue<TreeNode<T>>();
            int leaves = 0;

            visited.Add(root);
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                if (current.Children.Count == 0)
                    leaves++;
                foreach (var node in current.Children)
                {
                    if (!visited.Contains(node))
                    {
                        visited.Add(node);
                        queue.Enqueue(node);
                    }
                }
            }

            return leaves;
        }
    }
}
