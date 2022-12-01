using Mindbox.Sqr2D;

namespace MindboxSqr.Tests;

public class CommonFigureTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetSquareForCommonFigure()
    {
        var points = new List<Point>()
        {
            new(1, 1, Measure.m),
            new(3, 3, Measure.m),
            new(6, 1, Measure.m),
        };
        
        var tr = new CommonFigure(points, "MySpecialTriangle");
        Assert.AreEqual("MySpecialTriangle", tr.Name);
        
        var sqr = tr.GetSquare();
        Assert.LessOrEqual(Math.Abs(sqr.V-5), 1E12);


        points.Add(new(6, 1, Measure.m));
        var tr2 = new CommonFigure(points, "MySpecialTriangle2");

        Assert.Catch<NotImplementedException>(() => tr2.GetSquare());
    }
}