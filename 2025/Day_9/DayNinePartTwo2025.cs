public static class DayNinePartTwo2025
{
    private class Point(long x, long y)
    {
        public readonly long X = x;
        public readonly long Y = y;
    }

    private class Edge
    {
        public required Point P1;
        public required Point P2;

        public long MinX => Math.Min(P1.X, P2.X);
        public long MaxX => Math.Max(P1.X, P2.X);
        public long MinY => Math.Min(P1.Y, P2.Y);
        public long MaxY => Math.Max(P1.Y, P2.Y);

        public bool IsVertical => P1.X == P2.X;
    }

    public static long Solve()
    {
        string[] lines = File.ReadAllLines("./2025/day_9/input.txt");

        List<Point> coords = new List<Point>();
        foreach (string line in lines)
        {
            var splitLine = line.Split(',');
            long x = long.Parse(splitLine[0]);
            long y = long.Parse(splitLine[1]);
            coords.Add(new Point(x, y));
        }

        List<Edge> edges = new List<Edge>();
        for (int i = 0; i < coords.Count; i++)
        {
            Point p1 = coords[i];
            Point p2 = coords[(i + 1) % coords.Count]; // Wrap to 0
            edges.Add(new Edge { P1 = p1, P2 = p2 });
        }

        long maxArea = 0;

        for (int i = 0; i < coords.Count; i++)
        {
            for (int j = i + 1; j < coords.Count; j++)
            {
                Point t1 = coords[i];
                Point t2 = coords[j];

                long width = Math.Abs(t1.X - t2.X) + 1;
                long height = Math.Abs(t1.Y - t2.Y) + 1;
                long area = width * height;

                if (area <= maxArea) continue;

                long rMinX = Math.Min(t1.X, t2.X);
                long rMaxX = Math.Max(t1.X, t2.X);
                long rMinY = Math.Min(t1.Y, t2.Y);
                long rMaxY = Math.Max(t1.Y, t2.Y);

                if (IsRectangleValid(rMinX, rMaxX, rMinY, rMaxY, edges))
                {
                    maxArea = area;
                }
            }
        }

        return maxArea;
    }

    static bool IsRectangleValid(long rMinX, long rMaxX, long rMinY, long rMaxY, List<Edge> edges)
    {
        foreach (var edge in edges)
        {
            if (edge.IsVertical)
            {
                long vx = edge.P1.X;
                if (vx > rMinX && vx < rMaxX)
                {
                    long eY1 = edge.MinY;
                    long eY2 = edge.MaxY;

                    long overlapStart = Math.Max(eY1, rMinY);
                    long overlapEnd = Math.Min(eY2, rMaxY);

                    if (overlapStart < overlapEnd) return false;
                }
            }
            else
            {
                long hy = edge.P1.Y;
                if (hy > rMinY && hy < rMaxY)
                {
                    long eX1 = edge.MinX;
                    long eX2 = edge.MaxX;

                    long overlapStart = Math.Max(eX1, rMinX);
                    long overlapEnd = Math.Min(eX2, rMaxX);

                    if (overlapStart < overlapEnd) return false;
                }
            }
        }

        double centerX = (rMinX + rMaxX) / 2.0;
        double centerY = (rMinY + rMaxY) / 2.0;

        return IsPointInPolygon(centerX, centerY, edges);
    }

    static bool IsPointInPolygon(double px, double py, List<Edge> edges)
    {
        int intersections = 0;

        foreach (var edge in edges)
        {
            if (edge.IsVertical)
            {
                double vx = edge.P1.X;
                double vy1 = edge.MinY;
                double vy2 = edge.MaxY;
                if (vx > px && py >= vy1 && py < vy2)
                {
                    intersections++;
                }
            }
        }

        return intersections % 2 != 0;
    }
    
    private static void DisplayGrid(bool[][] grid)
    {
        foreach (var row in grid)
        {
            var builder = new System.Text.StringBuilder(row.Length * 2);
            foreach (var col in row)
            {
                builder.Append(col ? "X " : ". ");
            }

            string sb = builder.ToString();

            Console.WriteLine(sb);
        }
    }
}

// too high: 4581960734