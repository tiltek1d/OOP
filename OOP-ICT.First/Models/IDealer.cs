namespace FirstLab.Models;

public interface IDealer
{
    Card ReturnCard();

    List<Card> GetCardDeck();

    void TakeCard();
}