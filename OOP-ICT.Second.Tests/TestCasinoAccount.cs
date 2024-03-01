namespace SecondLab.Tests;
using Xunit;
using SecondLab;
public class TestCasinoAccount
{
    [Fact]
    public void TestBankAccountFunctions()
    {
        
        Guid accountId = Guid.NewGuid();
        string accountIdStr = accountId.ToString();
        uint chipsAmount = 100;
        CasinoAccountBuilder builder = new(); 
        CasinoAccountDirector director = new(builder);
        director.Construct(accountIdStr, chipsAmount);
        CasinoAccount casinoAccount = builder.CreateCasinoAccount();
        
        Assert.Equal(accountIdStr, casinoAccount.AccountId);
        Assert.Equal(chipsAmount, casinoAccount.ChipsAmount);
    }
}