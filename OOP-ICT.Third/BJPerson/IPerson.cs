using FirstLab.Models;
using SecondLab;

namespace ThirdLab.BJPerson;


public interface IPerson
{
    BankAccount CreateBankAccount();
    CasinoAccount CreateCasinoAccount();
    
    void MakeBet(uint moneyAmount);
    void TurnCard(Card card);
    void TransferMoneyToCasino(uint chipsAmount);
    void TransferChipsFromCasinoToBank(uint chipsAmount);
    
    void PlayGame(List<Card> dealerCards);
}