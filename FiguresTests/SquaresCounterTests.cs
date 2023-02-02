using FiguresLib;
using FiguresLib.Figures;
using FluentAssertions;
using NUnit.Framework;

namespace FiguresTests;

public class SquaresCounterTests
{

    [Test]
    public void CountCircleSquare_ReturnsRightAnswer()
    {
        var radius = 10;
        var square = SquaresCounter.GetCircleSquare(radius);

        square.Should().Be(2 * Math.PI * radius);
    }
    
    [Test]
    public void CountTriangleSquare_ReturnsRightAnswer()
    {
        var square = SquaresCounter.GetTriangleSquare(3, 4, 5);

        square.Should().Be(6);
    }
    
    [TestCaseSource(typeof(FiguresCases), nameof(FiguresCases.FigureSquareTests))]
    public double CountFiguresSquare_ReturnsRightAnswer(IFigure figure)
    {
        return SquaresCounter.GetSquare(figure);
    }

    private class FiguresCases
    {
        public static IEnumerable<TestCaseData> FigureSquareTests
        {
            get
            {
                const double radius = 10;
                yield return new TestCaseData(new Circle(10))
                    .SetName("Circle square")
                    .Returns(2 * Math.PI * radius);
                yield return new TestCaseData(new Triangle(3, 4, 5))
                    .SetName("Triangle square")
                    .Returns(6);
            }
        }
    }
    
}