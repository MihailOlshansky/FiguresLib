using System.Reflection.Metadata.Ecma335;

namespace FiguresLib.Figures;

public class Circle : IFigure
{
    public double Radius { get; private set; }

    public Circle(double radius)
    {
        if (!IsCircle(radius))
            throw new ArgumentException("Radius must be greater than zero");
        
        Radius = radius;
    }
    
    public double Square()
    {
        return 2 * Math.PI * Radius;
    }

    public static bool IsCircle(double radius)
    {
        return radius > 0;
    }
}