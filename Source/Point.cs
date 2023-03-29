namespace RadialTree
{
    public class Point
    {
		public Point(float x, float y, float radius = 1)
		{
			X = x;
			Y = y;
			Radius = radius;
		}

        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }

		public System.Drawing.Point GetPosition(System.Drawing.Size offset)
		{
			return new System.Drawing.Point((int)X + offset.Width, (int)Y + offset.Height);
		}

		public System.Drawing.Rectangle GetRectangle(System.Drawing.Size size, System.Drawing.Size offset)
		{
			var pos = GetPosition(offset);

			return new System.Drawing.Rectangle(pos.X - (size.Width / 2), 
												pos.Y - (size.Height / 2),
												size.Width,
												size.Height);
		}
	}
}
