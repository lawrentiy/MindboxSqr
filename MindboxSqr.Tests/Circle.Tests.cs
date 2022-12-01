using Mindbox.Sqr2D;

namespace MindboxSqr.Tests;

public class CircleTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetSquareForCircle()
    {
        var c = new Circle(1.001);
        Assert.AreEqual("Circle", c.Name);
        Assert.AreEqual(1.001, c.Radius.V);
        Assert.AreEqual(Measure.m, c.Radius.M);
        
        var sqr = c.GetSquare();
        Assert.AreEqual(Measure.m2, sqr.M);
        Assert.AreEqual(Math.PI*1.001*1.001, sqr.V);
    }

    [Test]
    public void CircleConstructor()
    {
        var c = new Circle(1.001);
        Assert.AreEqual("Circle", c.Name);
        Assert.AreEqual(1.001, c.Radius.V);
        Assert.AreEqual(Measure.m, c.Radius.M);
        
        c = new Circle(new ValueWithMeasure(2.002, Measure.km));
        Assert.AreEqual("Circle", c.Name);
        Assert.AreEqual(2.002, c.Radius.V);
        Assert.AreEqual(Measure.km, c.Radius.M);


        Assert.Catch(() => new Circle(0));
        Assert.Catch(() => new Circle(new ValueWithMeasure(0, Measure.km)));
    }
}