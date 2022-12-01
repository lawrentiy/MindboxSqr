namespace Mindbox.Sqr2D;

/// <summary>
/// Class contains description for point on a plane
/// </summary>
public sealed class ValueWithMeasure
{
    /// <summary>
    /// Value
    /// </summary>
    public double V;
    
    /// <summary>
    /// Measure
    /// </summary>
    public Measure M;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value"></param>
    /// <param name="measure"></param>
    public ValueWithMeasure(double value, Measure measure)
    {
        V = value;
        M = measure;
    }

    /// <summary>
    /// Converting to human readable string 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{V}{Enum.GetName(M)}";
    }

    /// <summary>
    /// Create new instance as copy of that one
    /// </summary>
    /// <returns></returns>
    public ValueWithMeasure Clone()
    {
        return new ValueWithMeasure(V, M);
    }

    private const string ErrorTheSameMeasures = "ValueWithMeasure operator +. Only the same measures";
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static ValueWithMeasure operator +(ValueWithMeasure a) => a;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static ValueWithMeasure operator -(ValueWithMeasure a) => new (-a.V, a.M);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static ValueWithMeasure operator +(ValueWithMeasure a, ValueWithMeasure b)
    {
        if (a.M != b.M) throw new Exception(ErrorTheSameMeasures);
        return new ValueWithMeasure(a.V + b.V, a.M);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static ValueWithMeasure operator -(ValueWithMeasure a, ValueWithMeasure b)
    {
        if (a.M != b.M) throw new Exception(ErrorTheSameMeasures);
        return new ValueWithMeasure(a.V - b.V, a.M);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static bool operator >=(ValueWithMeasure a, ValueWithMeasure b)
    {
        if (a.M != b.M) throw new Exception(ErrorTheSameMeasures);
        return a.V >= b.V;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static bool operator <=(ValueWithMeasure a, ValueWithMeasure b)
    {
        if (a.M != b.M) throw new Exception(ErrorTheSameMeasures);
        return a.V <= b.V;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueWithMeasure operator *(ValueWithMeasure a, ValueWithMeasure b)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueWithMeasure operator /(ValueWithMeasure a, ValueWithMeasure b)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (obj?.GetType() != typeof(ValueWithMeasure))
            return false;

        var vm = (ValueWithMeasure) obj;
        return V.Equals(vm.V) && M == vm.M;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(V, (int) M);
    }
}