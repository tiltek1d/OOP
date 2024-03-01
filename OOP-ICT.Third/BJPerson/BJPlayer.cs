using SecondLab;

namespace ThirdLab.BJPerson;
using FirstLab.Models;

public class BJPlayer : IPerson
{
    public string _playerId;
    private Bank _bank;
    private BlackjackCasino _casino;
    private List<Card> _hand;
    private PlayerFacade _playerFacade;

    public BJPlayer(string playerId, Bank bank, BlackjackCasino casino)
    {
        _playerId = playerId;
        _bank = bank;
        _casino = casino;
        _hand = new List<Card>();
        _playerFacade = new PlayerFacade(this, bank, casino);
    }

    public BankAccount CreateBankAccount()
    {
        _bank.CreateBankAccount(_playerId, 0);
        return _bank.GetBankAccount(_playerId);
    }

    public CasinoAccount CreateCasinoAccount()
    {
        _casino.CreateCasinoAccount(_playerId, 0);
        return _casino.GetCasinoAccount(_playerId);
    }

    public void MakeBet(uint chipsAmount)
    {
        _playerFacade.MakeBet(chipsAmount);
    }

    public void TurnCard(Card card)
    {
        _hand.Add(card);
    }

    public void TransferMoneyToCasino(uint chipsAmount)
    {
        if (_casino.GetCasinoAccount(_playerId) != null)
        {
            _casino.DepositChips(chipsAmount, _playerId);
        }
    }

    public void TransferChipsFromCasinoToBank(uint chipsAmount)
    {
        _playerFacade.TransferChipsFromCasinoToBank(chipsAmount);
    }

    public List<Card> GetHand()
    {
        return _hand;
    }

    public void PlayGame(List<Card> dealerCards)
    {
        _playerFacade.PlayBj(dealerCards);
    }
}