namespace Mindbox.Sqr2D;

/// <summary>
/// A figure defined on a plane by a set of points
/// TODO: now it only as an example, because algorithm for such figure is not programmable for a 1-2 hours, as I think firstly
/// TODO: no problem, will do in version 2 
/// </summary>
public class CommonFigure: Figure, ISquerable
{
    /// <summary>
    /// Set of point, define that figure
    /// </summary>
    public IEnumerable<Point> Points { get; internal set; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="points"></param>
    /// <param name="name"></param>
    public CommonFigure(IEnumerable<Point> points, string name): base(name)
    {
        // TODO: where to check that figure has right points (no intersections etc) 
        // in version 1 consider user always know, that he/she do
        Points = points;
    }

    /// <summary>
    /// Square of a custom figure (only triangle in v1)
    /// </summary>
    /// <param name="outputMeasure">Output measure. default m2</param>
    /// <returns></returns>
    public ValueWithMeasure GetSquare(Measure outputMeasure = Measure.m2)
    {
        try
        {
            var triangle = new Triangle(Points);
            return triangle.GetSquare(outputMeasure);
        }
        catch (Exception e)
        {
            throw new NotImplementedException("Not implemented for custom figure. Only triangle", e);
        }
    }
}