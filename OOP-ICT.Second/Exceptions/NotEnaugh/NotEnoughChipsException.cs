namespace SecondLab.Exceptions;

public class NotEnoughChipsException: NotEnoughException
{
    public NotEnoughChipsException(uint value) : base(value)
    {
        Console.WriteLine("Not enough chips on the balance");
        Console.WriteLine($"===> Deposit {value} chips <===");
    }
}