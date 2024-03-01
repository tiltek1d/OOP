using FirstLab.Models;

namespace FourthLab.Models;

public class PokerGame
{
    
    public readonly List<Card> Board;
    public readonly List<PokerPlayer> Players;
    private CardDeck _cardDeck;
    public PokerDealer Dealer;
    private int _dealerPos;
    private readonly PokerCasino _casino;
    public PokerMoneyService MoneyService;
    private int _round;
    private Calculator _calculator;


    public PokerGame(CardDeck cardDeck, PokerCasino casino)
    {
        Board = new List<Card>();
        Players = new List<PokerPlayer>();
        _cardDeck = cardDeck;
        _casino = casino;
        _dealerPos = -1;
        MoneyService = new PokerMoneyService(_casino, this);
    }
    
    public void AddPlayer(PokerPlayer player)
    {
        Players.Add(player);
        MoneyService.AddPlayer();
    }

    public void StartGame()
    {
        _round = 0;
        if (_dealerPos == Players.Count)
        {
            _dealerPos = 0;
        }
        else
        {
            _dealerPos += 1;
        }
        Dealer = new PokerDealer(_cardDeck, (int)Players[_dealerPos].GetId());
        Dealer.Shuffle();
        
    }

    public void StartFlop()
    {
        Board.Add(Dealer.GiveCard());
        Board.Add(Dealer.GiveCard());
        Board.Add(Dealer.GiveCard());
        foreach (var player in Players)
        {
            player.GetCard(Dealer.GiveCard());
        }
        foreach (var player in Players)
        {
            player.GetCard(Dealer.GiveCard());
        }
    }

    public void StartTermOrRiver()
    {
        Board.Add(Dealer.GiveCard());
    }

    public void EndRound()
    {
        MoneyService.CheckEndRound();
        MoneyService.WriteOffBets();
        _round += 1;
    }

    public List<PokerPlayer>? DetermineWinner()
    {
        _calculator = new Calculator(this);
        var playerPoints = new Dictionary<uint, int>();
        foreach (var player in Players.Where(player => player.IsActive))
        {
            playerPoints.Add(player.GetId(), _calculator.CountScore(player));
        }
        var maxScore = playerPoints.Values.Max();
        var winners = 
            (from p in playerPoints where p.Value == maxScore select 
                Players.FirstOrDefault(pl => pl.GetId() == p.Key)).ToList();
        if (winners.Count > 1)
        {
                var maxKiker = winners.Select(man => _calculator.HighCard(man)).Max();
                winners = winners.Where(man => man.GetHand().Any(card => card.Value == maxKiker)).ToList();
        }
        return winners;
    }
    }