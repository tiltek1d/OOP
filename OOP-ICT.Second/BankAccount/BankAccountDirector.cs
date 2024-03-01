namespace SecondLab;

public class BankAccountDirector
{
    private readonly BankAccountBuilder _bankBuilder;

    public BankAccountDirector(BankAccountBuilder builder)
    {
        _bankBuilder = builder;
    }
    
    public void Construct(string accountId, uint moneyAmount)
    {
        _bankBuilder.AccountId(accountId);
        _bankBuilder.MoneyAmount(moneyAmount);
    }
}