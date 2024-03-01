namespace SecondLab.Exceptions;

public class NotEnoughMoneyException: NotEnoughException
{
    public NotEnoughMoneyException(uint value) : base( value)
    {
        Console.WriteLine("Not enough money on the balance");
        Console.WriteLine($"===> Deposit {value} money <===");
    }
}