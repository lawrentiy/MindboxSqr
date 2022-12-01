namespace Mindbox.Sqr2D;

/// <summary>
/// Interface responsible for figures, who has square and can calculate square by itself
/// </summary>
public interface ISquerable
{
    /// <summary>
    /// Calculation of a square for a 
    /// </summary>
    /// <returns></returns>
    public ValueWithMeasure GetSquare(Measure outputMeasure);
}