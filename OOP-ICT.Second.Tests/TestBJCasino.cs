namespace SecondLab.Tests;
using Xunit;
using SecondLab;
using SecondLab.Exceptions;
public class TestBJCasino
{
    [Fact]
    public void TestCasinoFunctions()
    {
        Guid accountId = Guid.NewGuid();
        string accountIdStr = accountId.ToString();
        uint chipsAmount = 100;
        
        BlackjackCasino casino = new();
        casino.CreateCasinoAccount(accountIdStr, chipsAmount);
        
        uint accrueChips = 100;
        casino.AccrualOfWin(accrueChips, accountIdStr);
        Assert.Equal(chipsAmount + accrueChips,casino.GetChipsBalance(accountIdStr));

        
        uint balance = casino.GetChipsBalance(accountIdStr);
        Assert.Equal(balance, chipsAmount + accrueChips);

        uint withdrawalMoney = 100;
        uint anythingMoneyAmount = 1000;
        casino.AccrualOfLose(withdrawalMoney, accountIdStr);
        Assert.Equal(withdrawalMoney, casino.GetChipsBalance(accountIdStr));
        Assert.Throws<NotEnoughChipsException>(
            () => casino.AccrualOfLose(anythingMoneyAmount, accountIdStr)
        );
        
        Assert.Throws<IncorrectCasinoAccountIdException>(() => casino.GetChipsBalance(accountId + "1"));
    } 
}