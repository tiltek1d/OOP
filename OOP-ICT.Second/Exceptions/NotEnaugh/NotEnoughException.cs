namespace SecondLab.Exceptions;
public abstract class NotEnoughException : Exception
{
    private uint _value;
    public NotEnoughException( uint value)
    {
        _value = value;
    }
}
