using System.Collections.Immutable;

namespace FirstLab.Models;

public class Dealer: IDealer
{
    private readonly CardDeck _gameDeck;
    private readonly List<Card> _dealerCards;
    
    public Dealer()
    {
        _gameDeck = new CardDeck();
        _gameDeck.Cards = ShuffledCardDeck();
        _dealerCards = new List<Card>();
    }
    
    private List<Card> ShuffledCardDeck()
    {
        List<Card> cards = _gameDeck.Cards;
        int halfSize = cards.Count / 2;
        List<Card> shuffledDeck = new ();
        for (int i = 0; i < halfSize; i++) {
            shuffledDeck.Add(cards[i]);
            shuffledDeck.Add(cards[i + halfSize]);
        }
        _gameDeck.Cards = shuffledDeck;
        return _gameDeck.Cards;
    }

    public List<Card> GetShuffledCardDeck()
    {
        _gameDeck.Cards = ShuffledCardDeck();
        return _gameDeck.Cards;
    }
    public Card ReturnCard()
    {
        Card returnedCard = _gameDeck.Cards.First();
        _gameDeck.Cards.RemoveAt(0);
        return returnedCard;
    }
    public void TakeCard()
    {
        _dealerCards.Add(_gameDeck.GetOneCard());
    }

    public List<Card> GetDealerHand()
    {
        return _dealerCards;
    }
    public List<Card> GetCardDeck()
    {
        return _gameDeck.Cards;
    }
}