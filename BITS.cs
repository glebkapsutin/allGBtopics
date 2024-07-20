using System;
class BITS
{
    public long Value{get;}
    public BITS(long value)
    {
        Value=value;
    }
    public static implicit operator BITS(long value)
    {
        return new BITS(value);
    }
    public static implicit operator BITS(int value)
    {
        return new BITS(value);
    }
    public static implicit operator BITS(byte value)
    {
        return new BITS(value);
    }
    public override string ToString()
    {
        return $"{Value} ";
    }
}



