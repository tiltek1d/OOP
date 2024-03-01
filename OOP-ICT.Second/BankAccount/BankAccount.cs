using SecondLab.Exceptions;

namespace SecondLab;

public class BankAccount
{
    public string AccountId { get; }
    public uint MoneyAmount { get; private set; }

    public BankAccount(string accountId, uint moneyAmount)
    {
        AccountId = accountId;
        MoneyAmount = moneyAmount;
    }

    public void DepositMoney(uint moneyAmount)
    {
        MoneyAmount += moneyAmount;
    }

    public void WithdrawalMoney(uint moneyAmount)
    {
        if (MoneyAmount < moneyAmount)
        {
            throw new NotEnoughMoneyException(moneyAmount);
        }

        MoneyAmount -= moneyAmount;
    }
}