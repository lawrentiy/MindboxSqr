namespace Mindbox.Sqr2D;

/// <summary>
/// Class contains description for point on a plane
/// </summary>
public sealed class Point
{
    /// <summary>
    /// X
    /// </summary>
    private ValueWithMeasure _x { get; set; }
    
    /// <summary>
    /// Y
    /// </summary>
    private ValueWithMeasure _y { get; set; }

    /// <summary>
    /// X
    /// </summary>
    public double X => _x.V;

    /// <summary>
    /// Y
    /// </summary>
    public double Y => _y.V;
    
    /// <summary>
    /// X measure
    /// </summary>
    public Measure XMeasure => _x.M;

    /// <summary>
    /// Y measure
    /// </summary>
    public Measure YMeasure => _y.M;

    /// <summary>
    /// measure (if the same by X and Y)
    /// </summary>
    public Measure Measure => _x.M;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Point(ValueWithMeasure x, ValueWithMeasure y)
    {
        _x = x;
        _y = y;
    }
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="m">Measure for both</param>
    public Point(double x, double y, Measure m)
    {
        _x = new ValueWithMeasure(x, m);
        _y = new ValueWithMeasure(y, m);
    }
}