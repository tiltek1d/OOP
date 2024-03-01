namespace SecondLab;

public class BankAccountBuilder: IBankAccountBuilder
{
    private string _accountId = null!;
    private uint _moneyAmount;
    
    public void AccountId(string accountId)
    {
        _accountId = accountId;
    }

    public void MoneyAmount(uint moneyAmount)
    {
        _moneyAmount = moneyAmount;
    }
    
    public BankAccount CreateBankAccount()
    {
        BankAccount account = new(_accountId, _moneyAmount);

        return account;
    }
}