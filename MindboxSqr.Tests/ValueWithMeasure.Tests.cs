using Mindbox.Sqr2D;

namespace MindboxSqr.Tests;

public class ValueWithMeasureTests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void ValueWithMeasureAllTests()
    {
        var v = new ValueWithMeasure(1, Measure.m);
        Assert.AreEqual("1m", v.ToString());
        
        var v1 = new ValueWithMeasure(1, Measure.m);
        var v2 = new ValueWithMeasure(2, Measure.m);
        Assert.AreEqual("3m", (v1+v2).ToString());
        Assert.AreEqual("1m", (v2-v1).ToString());
        Assert.AreEqual("1m", (+v1).ToString());
        Assert.AreEqual("-2m", (-v2).ToString());
        
        Assert.AreEqual(v1, new ValueWithMeasure(1, Measure.m));
        
        var v3 = new ValueWithMeasure(3, Measure.km);
        Assert.Catch(() => { var vv = v1 + v3; } );
        Assert.Catch(() => { var vv = v1 - v3; } );
    }
}