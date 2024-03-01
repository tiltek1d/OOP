using System.Collections.Immutable;
using FirstLab.Models.Enums;

namespace FirstLab.Models;

public class CardDeck
{
    public List<Card> Cards;

    public CardDeck()
    {
        Cards = GetCreateDeck();
    }
    public List<Card> GetCreateDeck()
    {
        var cardDeck = new List<Card>();   
        for (var suit = 0; suit < 4; suit++)
        {
            for (var name = 2; name <= 10; name++)
            {
                cardDeck.Add(new Card(name.ToString(), (CardSuit)suit, false));
            }

            var symbolCards = new List<Card>()
            {
                new Card("A", (CardSuit)suit, false),
                new Card("K", (CardSuit)suit, false),
                new Card("Q", (CardSuit)suit, false),
                new Card("J", (CardSuit)suit, false)
            };
            cardDeck.AddRange(symbolCards);
        }
        
        return cardDeck;
    }
    public Card GetOneCard()
    {
        Card returnedCard = Cards.First();
        Cards.RemoveAt(0);
        return returnedCard;
    }
    
}