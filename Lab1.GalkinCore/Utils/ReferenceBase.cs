using Lab1.GalkinCore.Utils.Atomic;

namespace Lab1.GalkinCore.Utils;

public class ReferenceBase<T>
{
    public readonly T Value;
    public readonly AtomicBool Marked;

    public ReferenceBase(T value, bool marked)
    {
        this.Value = value;
        this.Marked = new AtomicBool(marked);
    }
}