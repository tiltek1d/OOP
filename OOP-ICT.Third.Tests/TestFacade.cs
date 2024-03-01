using FirstLab.Models;
using SecondLab;
using ThirdLab.BJPerson;
using ThirdLab.Exceptions;

namespace ThirdLab.Tests;
using Xunit;
public class TestFacade
{
    [Fact]
    public void TestFacadeFunc()
    {
        string playerId = Guid.NewGuid().ToString();
        Bank bank = new Bank();
        Dealer dealer = new Dealer();
        dealer.GetShuffledCardDeck();
        BlackjackCasino blackjackCasino = new BlackjackCasino();
        BJPlayer player = new BJPlayer(playerId, bank, blackjackCasino);

        uint moneyAmount = 200;
        player.CreateCasinoAccount();
        player.CreateBankAccount();
        bank.DepositMoney(moneyAmount, player._playerId);
        player.TransferMoneyToCasino(moneyAmount);
        
        uint chipsAmount = 100;
        
        
        player.MakeBet(chipsAmount);
        
        
        player.TurnCard(dealer.ReturnCard());
        player.TurnCard(dealer.ReturnCard());
        
        dealer.TakeCard();
        dealer.TakeCard();
        
        player.PlayGame(dealer.GetDealerHand());
        Assert.Equal(48, dealer.GetCardDeck().Count);
        Assert.Throws<EmptyDealerHandException>(
            () => player.PlayGame(new List<Card>())
            );
    }
}