using FiguresLib.Figures;
using FluentAssertions;
using NUnit.Framework;

namespace FiguresTests.Figures;

public class TriangleTests
{
    [TestCase(3, 4, 5, ExpectedResult = true, TestName = "Sides > 0, right triangle")]
    [TestCase(-3, 4, 5, ExpectedResult = false, TestName = "SideA < 0")]
    [TestCase(3, -4, 5, ExpectedResult = false, TestName = "SideB < 0")]
    [TestCase(3, 4, -5, ExpectedResult = false, TestName = "SideC < 0")]
    [TestCase(3, 4, 7, ExpectedResult = false, TestName = "Sides > 0, not triangle")]
    [TestCase(3, 4, 10, ExpectedResult = false, TestName = "Sides > 0, not triangle")]
    public bool IsTriangle_ReturnsRightAnswer(double sideA, double sideB, double sideC)
    {
        return Triangle.IsTriangle(sideA, sideB, sideC);
    }
    
    [TestCase(-3, 4, 5, TestName = "SideA < 0 (exception)")]
    [TestCase(3, -4, 5, TestName = "SideB < 0 (exception)")]
    [TestCase(3, 4, -5, TestName = "SideC < 0 (exception)")]
    [TestCase(3, 4, 7, TestName = "Sides > 0, not triangle (exception)")]
    [TestCase(3, 4, 10, TestName = "Sides > 0, not triangle (exception)")]
    public void Triangle_ThrowsException_WhenRadiusIsLessOrEqualsZero(double sideA, double sideB, double sideC)
    {
        Action action = () =>
        {
            var triangle = new Triangle(sideA, sideB, sideC);
        };

        action.Should().Throw<ArgumentException>();
    }

    [TestCase(5, 4, 3, ExpectedResult = true, TestName = "Right triangle 5 4 3")]
    [TestCase(3, 5, 4, ExpectedResult = true, TestName = "Right triangle 3 5 4")]
    [TestCase(3, 4, 5, ExpectedResult = true, TestName = "Right triangle 3 4 5")]
    [TestCase(6, 7, 10, ExpectedResult = false, TestName = "Not right triangle")]
    public bool IsRight_ReturnsRightAnswer(double sideA, double sideB, double sideC)
    {
        var triangle = new Triangle(sideA, sideB, sideC);
        return triangle.IsRight();
    } 
    
    [TestCase(3, 4, 5, ExpectedResult = 6, TestName = "Right triangle square")]
    [TestCase(40, 13, 37, ExpectedResult = 240, TestName = "Not right triangle square")]
    public double Square_ReturnsRightAnswer_WhenFigureIsTriangle(double sideA, double sideB, double sideC)
    {
        var triangle = new Triangle(sideA, sideB, sideC);

        return triangle.Square();
    }
    
}