using FirstLab.Models;
using SecondLab;
using ThirdLab.BJPerson;
using ThirdLab.Exceptions;

namespace ThirdLab;

public class PlayerFacade
{
    private Bank _bank;
    private BlackjackCasino _casino;
    private BJPlayer _player;
    private uint _betAmount;

    public PlayerFacade(BJPlayer player, Bank bank, BlackjackCasino casino)
    {
        _betAmount = 0;
        _player = player;
        _bank = bank;
        _casino = casino;
    }

    public void MakeBet(uint chipsAmount)
    {
        _betAmount += chipsAmount;
        _bank.WithdrawalMoney(chipsAmount, _player._playerId);
        _casino.DepositChips(chipsAmount, _player._playerId);
        _casino.AccrualOfLose(chipsAmount, _player._playerId);
    }

    public void PlayBj(List<Card> dealerCards)
    
    {
        const int maxGameValue = 21;
        
        if (dealerCards == null || dealerCards.Count == 0) throw new EmptyDealerHandException();
        int playerPoints = CalculateHandValue(_player.GetHand());
        int dealerPoints = CalculateHandValue(dealerCards);

        if (dealerPoints > maxGameValue || 
            dealerPoints < maxGameValue && playerPoints < maxGameValue && dealerPoints < playerPoints)
        {
            _casino.AccrualOfWin(_betAmount * 2, _player._playerId);
            _betAmount = 0;
            return;
        }
        
        if (playerPoints > maxGameValue ||
            dealerPoints < maxGameValue && playerPoints < maxGameValue && dealerPoints > playerPoints)
        {
            _casino.AccrualOfLose(_betAmount * 2, _player._playerId);
            _betAmount = 0;
            return;
        }
        if (playerPoints == maxGameValue && _player.GetHand().Count == 2 && dealerPoints != maxGameValue)
        {
            _casino.AccrualBlackjack(_player._playerId, _betAmount * 2);
            _betAmount = 0;
            return;
        }

        if (playerPoints < maxGameValue && dealerPoints < maxGameValue && dealerPoints == playerPoints)
        {
            _casino.AccrualOfWin(_betAmount, _player._playerId);
            _betAmount = 0;
        }
    }

    public void TransferChipsFromCasinoToBank(uint chipsAmount)
    {
        _casino.WithdrawalChips(chipsAmount, _player._playerId);
        _bank.DepositMoney(chipsAmount, _player._playerId);
    }
    
    private int CalculateHandValue(List<Card> hand)
    
    {
        int handValue = 0;
        uint acesCount = 0;
        const int maxGameValue = 21;

        foreach (Card card in hand)
        {
            handValue += card.Value;
            if (card.Name == "A")
            {
                acesCount++;
            }
        }
        
        while (handValue > maxGameValue && acesCount > 0)
        {
            handValue -= 10;
            acesCount--;
        }

        return handValue;
    }
}