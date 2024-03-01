namespace ThirdLab.Exceptions;

public class EmptyDealerHandException: Exception
{
    public EmptyDealerHandException()
    {
        Console.WriteLine("Error: Dealer does not have the cards");
    }
}