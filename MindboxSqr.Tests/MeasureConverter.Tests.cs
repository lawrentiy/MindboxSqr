using Mindbox.Sqr2D;

namespace MindboxSqr.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DistanceConverter()
    {
        var v1 = new ValueWithMeasure(1, Measure.km);
        var v2 = MeasureConverter.Convert(v1, Measure.m);
        var v3 = MeasureConverter.Convert(v2, Measure.mm);
        var v4 = MeasureConverter.Convert(v3, Measure.m);
        var v5 = MeasureConverter.Convert(v4, Measure.km);

        Assert.AreEqual(v2.V, v1.V * 1000);
        Assert.AreEqual(v3.V, v2.V * 1000);
        Assert.AreEqual(v4.V, v3.V / 1000);
        Assert.AreEqual(v5.V, v4.V / 1000);
    }
    
    [Test]
    public void SquareConverter()
    {
        var v1 = new ValueWithMeasure(1, Measure.km2);
        var v2 = MeasureConverter.Convert(v1, Measure.m2);
        var v3 = MeasureConverter.Convert(v2, Measure.mm2);
        var v4 = MeasureConverter.Convert(v3, Measure.m2);
        var v5 = MeasureConverter.Convert(v4, Measure.km2);

        Assert.AreEqual(v2.V, v1.V * 1000000);
        Assert.AreEqual(v3.V, v2.V * 1000000);
        Assert.AreEqual(v4.V, v3.V / 1000000);
        Assert.AreEqual(v5.V, v4.V / 1000000);
    }
    
    [Test]
    public void ErrorConverter()
    {
        Assert.Catch(() =>
        {
            var v1 = new ValueWithMeasure(1, Measure.km2);
            var v2 = MeasureConverter.Convert(v1, Measure.m);
        }, "km2 is square measure but m is distance measure");
    }
    
    [Test]
    public void GetDistanceOrSqrMeasure()
    {
        Assert.AreEqual(Measure.km, MeasureConverter.GetDistanceMeasure(Measure.km2));
        Assert.AreEqual(Measure.m, MeasureConverter.GetDistanceMeasure(Measure.m2));
        Assert.AreEqual(Measure.mm, MeasureConverter.GetDistanceMeasure(Measure.mm2));
        Assert.AreEqual(Measure.km2, MeasureConverter.GetSqrMeasure(Measure.km));
        Assert.AreEqual(Measure.m2, MeasureConverter.GetSqrMeasure(Measure.m));
        Assert.AreEqual(Measure.mm2, MeasureConverter.GetSqrMeasure(Measure.mm));
        
        
        Assert.Catch(() =>
        {
            MeasureConverter.GetSqrMeasure(Measure.mm2);
        });
        
        
        Assert.Catch(() =>
        {
            MeasureConverter.GetDistanceMeasure(Measure.mm);
        });
    }
}