using FiguresLib.Figures;
using FluentAssertions;
using NUnit.Framework;

namespace FiguresTests.Figures;

public class CircleTests
{
    [TestCase(10, ExpectedResult = true, TestName = "Radius > 0")]
    [TestCase(-10, ExpectedResult = false, TestName = "Radius < 0")]
    [TestCase(0, ExpectedResult = false, TestName = "Radius == 0")]
    public bool IsCircle_ReturnsRightAnswer(double radius)
    {
        return Circle.IsCircle(radius);
    }
    
    [TestCase(-10, TestName = "Radius < 0")]
    [TestCase(0, TestName = "Radius == 0")]
    public void Circle_ThrowsException_WhenRadiusIsLessOrEqualsZero(double radius)
    {
        Action action = () =>
        {
            var circle = new Circle(radius);
        };

        action.Should().Throw<ArgumentException>();
    }

    [Test]
    public void Square_ReturnsRightAnswer_WhenFigureIsCircle()
    {
        const int radius = 10;
        var circle = new Circle(radius);

        var square = circle.Square();

        square.Should().Be(2 * Math.PI * radius);
    }
}