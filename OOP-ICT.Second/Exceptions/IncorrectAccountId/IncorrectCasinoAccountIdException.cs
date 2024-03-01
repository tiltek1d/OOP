namespace SecondLab.Exceptions;

public class IncorrectCasinoAccountIdException: IncorrectAccountIdException
{
    public IncorrectCasinoAccountIdException(string message) : base(message)
    {
        Console.WriteLine("Incorrect casino account ID, please write right ID");
    }
}