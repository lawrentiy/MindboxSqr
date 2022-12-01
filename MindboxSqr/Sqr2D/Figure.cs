namespace Mindbox.Sqr2D;

/// <summary>
/// Base class for all kinds of 2D figures on the Earth
/// </summary>
public abstract class Figure
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name"></param>
    protected Figure(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Name of the figure, to display for convenience
    /// </summary>
    public string Name { get;  protected set; }
}