using FiguresLib.Figures;

namespace FiguresLib;

public static class SquaresCounter
{
    public static double GetSquare(IFigure figure)
    {
        return figure.Square();
    }

    public static double GetCircleSquare(double radius)
    {
        return new Circle(radius).Square();
    }

    public static double GetTriangleSquare(double sideA, double sideB, double sideC)
    {
        return new Triangle(sideA, sideB, sideC).Square();
    }
}