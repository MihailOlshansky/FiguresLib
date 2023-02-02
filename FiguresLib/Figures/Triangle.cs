namespace FiguresLib.Figures;

public class Triangle : IFigure
{
    public double SideA { get; private set; }
    public double SideB { get; private set; }
    public double SideC { get; private set; }

    private const double Accuracy = 0.00000001;
    private readonly double[] _sortedSides;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (!IsTriangle(sideA, sideB, sideC))
        {
            throw new ArgumentException($"Figure with sides {sideA}, {sideB}, {sideC} is not a triangle");
        }
        
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;

        _sortedSides = new[] { SideA, SideB, SideC };
        Array.Sort(_sortedSides);
    }
    
    public double Square()
    {
        if (IsRight())
            return 0.5 * _sortedSides[0] * _sortedSides[1];

        var p = (SideA + SideB + SideC) / 2;

        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    public static bool IsTriangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 ||
            sideB <= 0 ||
            sideC <= 0)
            return false;

        double[] sides = { sideA, sideB, sideC };
        Array.Sort(sides);

        return sides[0] + sides[1] > sides[2];
    }

    public bool IsRight()
    {
        var a = _sortedSides[0];
        var b = _sortedSides[1];
        var c = _sortedSides[2];
        
        return Math.Abs(a * a + b * b - c * c) < Accuracy;
    }
}