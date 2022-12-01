using Mindbox.Sqr2D;

namespace MindboxSqr.Tests;

public class TriangleTests
{
    [SetUp]
    public void Setup()
    {
    }
    
    //TODO: test for negative coordinates

    [Test]
    public void GetSquareForTriangle()
    {
        var points = new[]
        {
            new Point(1, 1, Measure.m),
            new Point(3, 3, Measure.m),
            new Point(6, 1, Measure.m),
        };
        
        var tr = new Triangle(points);
        Assert.AreEqual("Triangle", tr.Name);
        
        var sqr = tr.GetSquare();
        Assert.LessOrEqual(Math.Abs(sqr.V-5), 1E12);
    }

    [Test]
    public void TriangleConstructor()
    {
        var p3 = new Point(1, 3, Measure.km);
        var points = new List<Point>
        {
            new(1, 1, Measure.m),
            new(1, 2, Measure.m)
        };
        Assert.Catch(() => new Triangle(points), "Triangle has 3 point. Dude!");

        points.Add(p3);
        Assert.Catch(() => new Triangle(points), "Please, set all points for triangle in the same measure");

        points.Remove(p3);
        points.Add(new Point(1, 4, Measure.m));        
        Assert.Catch(() => new Triangle(points), "Points on the same line");
    }
}