using FirstLab.Models;
using SecondLab;
using ThirdLab.BJPerson;

namespace ThirdLab.Tests;
using Xunit;
public class TestPlayer
{
    [Fact]
    public void TestPlayerFunc()
    {
        string playerId = Guid.NewGuid().ToString();
        Bank bank = new Bank();
        Dealer dealer = new Dealer();
        dealer.GetShuffledCardDeck();
        BlackjackCasino blackjackCasino = new BlackjackCasino();
        BJPlayer player = new BJPlayer(playerId, bank, blackjackCasino);
        player.CreateCasinoAccount();
        player.CreateBankAccount();
        uint moneyAmount = 100;
        bank.DepositMoney(moneyAmount, player._playerId);
        Assert.Equal(bank.GetMoneyBalance(player._playerId), moneyAmount);
        player.TransferMoneyToCasino(100);
        Assert.Equal(bank.GetMoneyBalance(player._playerId), moneyAmount);
        player.TurnCard(dealer.ReturnCard());
        Assert.Single(player.GetHand());
    }
}
