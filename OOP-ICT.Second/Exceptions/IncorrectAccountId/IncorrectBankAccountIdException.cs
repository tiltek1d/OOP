namespace SecondLab.Exceptions;

public class IncorrectBankAccountIdException: IncorrectAccountIdException
{
    public IncorrectBankAccountIdException(string message) : base(message)
    {
        Console.WriteLine("Incorrect bank account ID, please write right ID");
    }
}