namespace Lab1.GalkinCore.Utils.Interfaces;

public interface IBorderline<T>
{
    T MinValue();
    T MaxValue();
    T Value { get; set; }
}