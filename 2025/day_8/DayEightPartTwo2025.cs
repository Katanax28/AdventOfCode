public class DayEightPartTwo2025
{
    public static long Solve()
    {
        string[] lines = File.ReadAllLines("./2025/day_8/input.txt");
        List<JunctionBox> junctionBoxes = [];
        foreach (string line in lines)
        {
            int[] coords = line.Split(',').Select(int.Parse).ToArray();
            junctionBoxes.Add(new JunctionBox(coords[0], coords[1], coords[2]));
        }

        List<(double, JunctionBox, JunctionBox)> distances = [];
        for (int i = 0; i < junctionBoxes.Count; i++){
            JunctionBox junctionBox = junctionBoxes[i];
            for(int j = i + 1; j < junctionBoxes.Count; j++){
                JunctionBox otherJunctionBox = junctionBoxes[j];
                double distanceX = Math.Abs(junctionBox.X - otherJunctionBox.X);
                double distanceY = Math.Abs(junctionBox.Y - otherJunctionBox.Y);
                double distanceZ = Math.Abs(junctionBox.Z - otherJunctionBox.Z);
                double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY + distanceZ * distanceZ);
                distances.Add((distance, junctionBox, otherJunctionBox));
            }
        }

        distances.Sort((x, y) => x.Item1.CompareTo(y.Item1)); // ascending sort

        List<List<JunctionBox>> circuits = []; 
        var current = distances[0];
        int totalJunctionBoxes = 1000; // should be 20 in example input
        while(circuits.Count == 0 || circuits[0].Count < totalJunctionBoxes)
        {
            current = distances[0];
            bool firstBoxIsInCircuit = circuits.Any(x => x.Contains(current.Item2) && !x.Contains(current.Item3));
            bool secondBoxIsInCircuit = circuits.Any(x => x.Contains(current.Item3) && !x.Contains(current.Item2));
            if (circuits.Any(x => x.Contains(current.Item2) && x.Contains(current.Item3))) { } // nothing happens as both are in the same circuit
            else if (firstBoxIsInCircuit && secondBoxIsInCircuit) // if both are already in a circuit, combine the circuits
            {
                List<JunctionBox> combinedList = [];
                combinedList.AddRange(circuits.First(x => x.Contains(current.Item2)));
                combinedList.AddRange(circuits.First(x => x.Contains(current.Item3)));
                circuits.RemoveAll(x => x.Contains(current.Item2));
                circuits.RemoveAll(x => x.Contains(current.Item3));
                circuits.Add(combinedList);
            } 
            else if (firstBoxIsInCircuit) circuits.First(x => x.Contains(current.Item2)).Add(current.Item3);
            else if (secondBoxIsInCircuit) circuits.First(x => x.Contains(current.Item3)).Add(current.Item2);
            else circuits.Add([current.Item2, current.Item3]); // if neither are in any circuit yet, make a new circuit.
            distances.RemoveAt(0);
        }
        long result = (long)current.Item2.X * (long)current.Item3.X; // cast to longs because result is higher than int limit
        return result;
    }

    private class JunctionBox(int x, int y, int z)
    {
        public readonly int X = x;
        public readonly int Y = y;
        public readonly int Z = z;
    }
}

// 64163550 is too low
// 663326041 is too low
// 9253260633