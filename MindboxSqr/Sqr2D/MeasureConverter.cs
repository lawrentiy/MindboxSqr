namespace Mindbox.Sqr2D;

/// <summary>
/// 
/// </summary>
public static class MeasureConverter
{
    /// <summary>
    /// 
    /// </summary>
    public static List<Measure> SquareMeasures = new() {Measure.km2, Measure.m2, Measure.mm2};
    
    /// <summary>
    /// 
    /// </summary>
    public static List<Measure> DistanceMeasures = new() {Measure.km, Measure.m, Measure.mm};

    /// <summary>
    /// Returns an analog for distance measure from square measures
    /// </summary>
    /// <param name="distanceMeasure"></param>
    /// <returns></returns>
    public static Measure GetSqrMeasure(Measure distanceMeasure)
    {
        return distanceMeasure switch
        {
            Measure.mm => Measure.mm2,
            Measure.m => Measure.m2,
            Measure.km => Measure.km2,
            _ => throw new ArgumentOutOfRangeException(nameof(distanceMeasure), distanceMeasure, null)
        };
    }

    /// <summary>
    /// Returns an analog for square measure from distance measures
    /// </summary>
    /// <param name="sqrMeasure"></param>
    /// <returns></returns>
    public static Measure GetDistanceMeasure(Measure sqrMeasure)
    {
        return sqrMeasure switch
        {
            Measure.mm2 => Measure.mm,
            Measure.m2 => Measure.m,
            Measure.km2 => Measure.km,
            _ => throw new ArgumentOutOfRangeException(nameof(sqrMeasure), sqrMeasure, null)
        };
    }

    private static bool CompareMeasuresTypes(Measure m1, Measure m2, out string? error)
    {
        var m1type = 
            SquareMeasures.Contains(m1) ? "square" 
            : DistanceMeasures.Contains(m1) ? "distance" 
            : "unknown"; 
        
        var m2type = 
              SquareMeasures.Contains(m2) ? "square" 
            : DistanceMeasures.Contains(m2) ? "distance" 
            : "unknown";

        error = m1type != m2type ? $"{m1} is {m1type} measure but {m2} is {m2type} measure" : null;
        return m1type != m2type;
    }
    
    /// <summary>
    /// Convert from value with measure. No mutation
    /// </summary>
    /// <param name="value"></param>
    /// <param name="destinationMeasure"></param>
    /// <returns></returns>
    public static ValueWithMeasure Convert(ValueWithMeasure value, Measure destinationMeasure)
    {
        if (CompareMeasuresTypes(value.M, destinationMeasure, out var error))
            throw new Exception(error);
        var result = value.Clone();
        
        // TODO: bad implementation - need to create base class for measure and multiplicity prefixes ещ universal conversion
        // upgrade
        if (result.M == Measure.mm && destinationMeasure == Measure.m) result.V /= 1000;
        if (result.M == Measure.m && destinationMeasure == Measure.km) result.V /= 1000;
        
        // downgrade
        if (result.M == Measure.km && destinationMeasure == Measure.m) result.V *= 1000;
        if (result.M == Measure.m && destinationMeasure == Measure.mm) result.V *= 1000;
        
        // upgrade
        if (result.M == Measure.mm2 && destinationMeasure == Measure.m2) result.V /= 1000000;
        if (result.M == Measure.m2 && destinationMeasure == Measure.km2) result.V /= 1000000;
        
        // downgrade
        if (result.M == Measure.km2 && destinationMeasure == Measure.m2) result.V *= 1000000;
        if (result.M == Measure.m2 && destinationMeasure == Measure.mm2) result.V *= 1000000;
        
        result.M = destinationMeasure;
        return result;
    }
}