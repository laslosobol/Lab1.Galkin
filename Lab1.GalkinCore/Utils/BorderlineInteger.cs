using Lab1.GalkinCore.Utils.Interfaces;

namespace Lab1.GalkinCore.Utils;

public class BorderlineInteger : IBorderline<int>, IComparable<BorderlineInteger>
{
    public int MinValue() => int.MinValue;

    public int MaxValue() => int.MaxValue;
        
    public int Value { get; set; }
        
    public int CompareTo(BorderlineInteger other)
    {
        return Value.CompareTo(other.Value);
    }

    public BorderlineInteger(int value)
    {
        Value = value;
    }

    public BorderlineInteger()
    {
            
    }
}