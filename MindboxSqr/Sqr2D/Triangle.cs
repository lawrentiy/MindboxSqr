namespace Mindbox.Sqr2D;

/// <summary>
/// Just a triangle
/// </summary>
public class Triangle: Figure, ISquerable
{
    /// <summary>
    /// 3 Points, describes a triangle
    /// </summary>
    public IEnumerable<Point> Points { get; internal set; }
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="points"></param>
    /// <param name="name"></param>
    public Triangle(IEnumerable<Point> points, string name = "Triangle"): base(name)
    {
        if (points.Count() != 3)
            throw new Exception($"Triangle has 3 point. Dude!");

        var measure = points.First().Measure;
        if (points.Any(p=>p.XMeasure != measure || p.YMeasure != measure))
            throw new Exception($"Please, set all points for triangle in the same measure");
        
        Points = points;

        var segments = GetSegments().ToArray();
        if (segments[0].V<=Math.Abs((segments[1]-segments[2]).V) || segments[0]>=segments[1]+segments[2])
            throw new Exception($"Points on the same line");
    }

    private List<ValueWithMeasure> GetSegments()
    {
        var measure = Points.First().Measure;
        var p1 = Points.ElementAt(0);
        var p2 = Points.ElementAt(1);
        var p3 = Points.ElementAt(2);
        var d1 = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        var d2 = Math.Sqrt(Math.Pow(p3.X - p2.X, 2) + Math.Pow(p3.Y - p2.Y, 2));
        var d3 = Math.Sqrt(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p1.Y - p3.Y, 2));
        return new List<ValueWithMeasure>() {new (d1, measure), new (d2, measure), new (d3, measure)};
    }
    
    /// <summary>
    /// Square of a triangle
    /// </summary>
    /// <param name="outputMeasure">Output measure. default m2</param>
    /// <returns></returns>
    public ValueWithMeasure GetSquare(Measure outputMeasure = Measure.m2)
    {
        var segments = GetSegments()
            .Select(s=>MeasureConverter.Convert(s, MeasureConverter.GetDistanceMeasure(outputMeasure)));
        
        var p = segments.Sum(v => v.V) / 2;
        var result = Math.Sqrt(p)
                     *Math.Sqrt(p-segments.ElementAt(0).V)
                     *Math.Sqrt(p-segments.ElementAt(1).V)
                     *Math.Sqrt(p-segments.ElementAt(2).V);
        return new ValueWithMeasure(result, outputMeasure);
    }
}