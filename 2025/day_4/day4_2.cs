using System.Text;

public class day4_2
{
    private static readonly string[] Grid = File.ReadAllLines("./2025/day_4/input.txt");
    private static int _totalPaper;

    public static int Solve()
    {
        for (int y = 0; y < Grid.Length; y++)
        {
            for (int x = 0; x < Grid[y].Length; x++)
            {
                _totalPaper += SolveRecursively(x, y);
            }
        }
        return _totalPaper;
    }

    private static int SolveRecursively(int _x, int _y)
    {
        string y = Grid[_y];
        char x = y[_x];
        if (x == '.') return 0;
        int adjacentPaper = 0;
        int arrayWidth = y.Length - 1;
        int arrayHeight = Grid.Length - 1;
        if (_x != 0 && _y != 0 && Grid[_y - 1][_x - 1] == '@') adjacentPaper++; // left above
        if (_y != 0 && Grid[_y - 1][_x] == '@') adjacentPaper++; // center above
        if (_x < arrayWidth && _y != 0 && Grid[_y - 1][_x + 1] == '@') adjacentPaper++; // right above
        if (_x != 0 && Grid[_y][_x - 1] == '@') adjacentPaper++; // left center
        if (_x < arrayWidth && Grid[_y][_x + 1] == '@') adjacentPaper++; // right center
        if (_x != 0 && _y < arrayHeight && Grid[_y + 1][_x - 1] == '@') adjacentPaper++; // left below
        if (_y < arrayHeight && Grid[_y + 1][_x] == '@') adjacentPaper++; // center below
        if (_x < arrayWidth && _y < arrayHeight && Grid[_y + 1][_x + 1] == '@') adjacentPaper++; // right below

        if (adjacentPaper >= 4) return 0;
        
        StringBuilder sb = new StringBuilder(Grid[_y]) { [_x] = '.' };
        Grid[_y] = sb.ToString();

        int resultPaper = 0;
        if (_x != 0 && _y != 0 && Grid[_y - 1][_x - 1] == '@') resultPaper += SolveRecursively(_x - 1, _y - 1); // left above
        if (_y != 0 && Grid[_y - 1][_x] == '@') resultPaper += SolveRecursively(_x, _y - 1); // center above
        if (_x < arrayWidth && _y != 0 && Grid[_y - 1][_x + 1] == '@') resultPaper += SolveRecursively(_x + 1, _y - 1); // right above
        if (_x != 0 && Grid[_y][_x - 1] == '@') resultPaper += SolveRecursively(_x - 1, _y); // left center
        if (_x < arrayWidth && Grid[_y][_x + 1] == '@') resultPaper += SolveRecursively(_x + 1, _y); // right center
        if (_x != 0 && _y < arrayHeight && Grid[_y + 1][_x - 1] == '@') resultPaper += SolveRecursively(_x - 1, _y + 1); // left below
        if (_y < arrayHeight && Grid[_y + 1][_x] == '@') resultPaper += SolveRecursively(_x, _y + 1); // center below
        if (_x < arrayWidth && _y < arrayHeight && Grid[_y + 1][_x + 1] == '@') resultPaper += SolveRecursively(_x + 1, _y + 1); // right below

        return 1 + resultPaper;
    }
}