using Xunit;
using SecondLab;
namespace SecondLab.Tests;

public class TestBankAccount
{
    [Fact]
    public void TestBankAccountFunctions()
    {
        
        Guid accountId = Guid.NewGuid();
        string accountIdStr = accountId.ToString();
        uint moneyAmount = 100;
        BankAccountBuilder builder = new();
        BankAccountDirector director = new(builder);
        director.Construct(accountIdStr, moneyAmount);
        BankAccount bankAccount = builder.CreateBankAccount();
        
        Assert.Equal(accountIdStr, bankAccount.AccountId);
        Assert.Equal(moneyAmount, bankAccount.MoneyAmount);
    }
}