namespace SecondLab.Exceptions;

public abstract class IncorrectAccountIdException: Exception
{
    private string _message;

    public IncorrectAccountIdException(string message)
    {
        _message = message;
    }
}