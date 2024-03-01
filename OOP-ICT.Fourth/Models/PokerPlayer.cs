using SecondLab.Exceptions;
using FourthLab.Exceptions;
using FirstLab.Models;

namespace FourthLab.Models;

public class PokerPlayer
{
    private readonly uint _id;
    private uint _cash;
    private readonly List<Card> _hand;
    public bool IsActive;
    public decimal Bet { get; private set; }

    public PokerPlayer(uint id, uint cash)
    {
        _id = id;
        _cash = cash;
        _hand = new List<Card>();
        IsActive = true;
        Bet = 0;
    }
    
    
    public void JoinGame(PokerGame game)
    {
        game.AddPlayer(this);
    }

    public void MakeBet(PokerGame game, uint bet)
    {
        Bet = bet;
        game.MoneyService.MakeBet(this, bet);
    }

    public void Fold()
    {
        IsActive = false;
        _hand.Clear();
    }
    
    public void CreateCasinoAccount(PokerCasino casino)
    {
        casino.CreateNewAccount(_id);
    }
    
    public void BuyChips(PokerCasino casino, uint amount)
    {
        if (!IsEnoughCash(amount*casino.GetExchangeRate())) throw new NotEnoughOnBalanceException("There is not enough cash :(");
        casino.BuyChips(_id, amount);
        _cash -= amount * casino.GetExchangeRate();
    }
    
    public void ExchangeChips(PokerCasino casino, uint amount)
    {
        if (!casino.IsEnoughChips(_id, amount)) throw new NotEnoughOnBalanceException("There is not enough chips on casino account :(");
        casino.ExchangeChips(_id,amount);
        _cash += amount * casino.GetExchangeRate();
    }
    
    private bool IsEnoughCash(uint money)
    {
        return _cash > money;
    }

    public uint GetCashAmount()
    {
        return _cash;
    }
    
    public void GetCard(Card card)
    {
        _hand.Add(card);
    }

    public uint GetId()
    {
        return _id;
    }

    public List<Card> GetHand()
    {
        return _hand;
    }
}