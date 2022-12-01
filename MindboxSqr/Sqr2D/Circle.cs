namespace Mindbox.Sqr2D;

/// <summary>
/// Just a circle
/// </summary>
public class Circle: Figure, ISquerable
{
    /// <summary>
    /// Radius
    /// </summary>
    public ValueWithMeasure Radius { get; internal set; }
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="name"></param>
    public Circle(ValueWithMeasure radius, string name = "Circle"): base(name)
    {
        CheckRadius(radius.V);
        Radius = radius;
    }

    private void CheckRadius(double radius)
    {
        if (radius <= 0)
            throw new Exception($"Radius have to be more than zero. Check it: {radius}");
    }
    
    /// <summary>
    /// Constructor. Radius as double number (measure is meter)
    /// </summary>
    /// <param name="radius">in meters</param>
    /// <param name="name"></param>
    public Circle(double radius, string name = "Circle"): base(name)
    {
        CheckRadius(radius);
        Radius = new ValueWithMeasure(radius, Measure.m);
    }

    /// <summary>
    /// Square of a circle
    /// </summary>
    /// <param name="outputMeasure">Output measure. default m2</param>
    /// <returns></returns>
    public ValueWithMeasure GetSquare(Measure outputMeasure = Measure.m2)
    {
        var r = MeasureConverter.Convert(Radius, MeasureConverter.GetDistanceMeasure(outputMeasure)).V;
        var result = Math.PI * r * r;
        return new ValueWithMeasure(result, outputMeasure);
    }
}