public class DayFourPartOne2025
{
    public static int Solve()
    {
        string[] grid = File.ReadAllLines("./2025/day_4/input.txt");
        int totalPaper = 0;

        for(int _y = 0; _y < grid.Length; _y++)
        {
            string y = grid[_y];
            for(int _x = 0; _x < grid[_y].Length; _x++)
            {
                char x = grid[_y][_x];
                if (x == '.') continue;
                
                int adjacentPaper = 0;
                int arrayWidth = y.Length - 1;
                int arrayHeight = grid.Length - 1;
                if (_x != 0 && _y != 0 && grid[_y - 1][_x - 1] == '@') adjacentPaper++; // left above
                if (_y != 0 && grid[_y - 1][_x] == '@') adjacentPaper++; // center above
                if (_x < arrayWidth && _y != 0 && grid[_y - 1][_x + 1] == '@') adjacentPaper++; // right above
                if (_x != 0 && grid[_y][_x - 1] == '@') adjacentPaper++; // left center
                if (_x < arrayWidth && grid[_y][_x + 1] == '@') adjacentPaper++; // right center
                if (_x != 0 && _y < arrayHeight && grid[_y + 1][_x - 1] == '@') adjacentPaper++; // left below
                if (_y < arrayHeight && grid[_y + 1][_x] == '@') adjacentPaper++; // center below
                if (_x < arrayWidth && _y < arrayHeight && grid[_y + 1][_x + 1] == '@') adjacentPaper++; // right below
                
                if (adjacentPaper < 4) totalPaper++;
            }
        }

        return totalPaper;
    }
}