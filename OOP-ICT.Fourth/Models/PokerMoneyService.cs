namespace FourthLab.Models;

public class PokerMoneyService
{
    private PokerCasino _casino;
    private PokerGame _game;
    private List<uint> _bets;
    private uint _sum;
    private uint _dealerBet;
    
    public PokerMoneyService(PokerCasino casino, PokerGame game)
    {
        _casino = casino;
        _game = game;
        _bets = new List<uint>();
        _sum = 0;
        _dealerBet = 0;
    }

    public void AddPlayer()
    {
        _bets.Add(0);
    }

    public void MakeBet(PokerPlayer player, uint amount)
    {
        var ind = _game.Players.IndexOf(player);
        _bets[ind] = amount;
        if (player.GetId() == _game.Dealer.GetId())
        {
            _dealerBet = amount;
        }
    }
    
    public void WriteOffBets()
    {
        foreach (var player in _game.Players)
        {
            var ind = _game.Players.IndexOf(player);
            _casino.ExchangeChips(player.GetId(), _bets[ind]); 
            _sum += _bets[ind];
            _bets[ind] = 0;
        }
    }

    public void CheckEndRound()
    {
        foreach (var player in _game.Players)
        {
            var ind = _game.Players.IndexOf(player);
            if (_bets[ind] < _dealerBet)
            {
                _game.Players[ind].IsActive = false;
            }
        }
    }

    public void PayPlayers(List<PokerPlayer> winners)
    {
        var count = winners.Aggregate<PokerPlayer, uint>(0, (current, winner) => current + 1);
        if (count != 0)
        {
            var winMoney = _sum / count;
            foreach (var winner in winners)
            {
                _casino.BuyChips(winner.GetId(), winMoney);
            }
        }
        _sum = 0;
    }
}