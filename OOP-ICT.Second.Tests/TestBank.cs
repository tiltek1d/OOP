namespace SecondLab.Tests;
using Xunit;
using SecondLab.Exceptions;

public class TestBank
{
    [Fact]
    public void TestBankFunctions()
    {
        Guid accountId = Guid.NewGuid();
        string accountIdStr = accountId.ToString();
        uint moneyAmount = 100;
        
        Bank bank = new();
        bank.CreateBankAccount(accountIdStr, moneyAmount);
        
        uint depositMoney = 100;
        bank.DepositMoney(depositMoney, accountIdStr);
        Assert.Equal(moneyAmount + depositMoney,bank.GetMoneyBalance(accountIdStr));

        uint balance = bank.GetMoneyBalance(accountIdStr);
        Assert.Equal(balance, moneyAmount + depositMoney);
        Assert.Throws<IncorrectBankAccountIdException>(() => bank.GetBankAccount(accountIdStr+"1"));

        uint withdrawalMoney = 100;
        uint anythingMoneyAmount = 1000;
        bank.WithdrawalMoney(withdrawalMoney, accountIdStr);
        Assert.Equal(withdrawalMoney, bank.GetMoneyBalance(accountIdStr));
        Assert.Throws<NotEnoughMoneyException>(
            () => bank.WithdrawalMoney(anythingMoneyAmount, accountIdStr)
        );
        
        Assert.Throws<IncorrectBankAccountIdException>(() => bank.GetBankAccount(accountId + "1"));
        Assert.IsType<BankAccount>(bank.GetBankAccount(accountIdStr));
    } 
}