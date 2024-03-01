namespace FirstLab.Tests;
using FirstLab.Models;
using FirstLab.Models.Enums;
using Xunit;
using Xunit.Abstractions;

public class TestDealerFunctions
{
    [Fact]
    public void TestDealer()
    {
        CardDeck createdCardDeck = new CardDeck();
        List<Card> shuffledCardDeck = new Dealer().GetShuffledCardDeck();
        Assert.NotEqual(createdCardDeck.Cards, shuffledCardDeck);
        
        // At shuffling the first card stays the same, the others change
        Assert.Equal(CardSuit.Hearts, shuffledCardDeck.ElementAt(0).Suit);
        Assert.Equal(CardSuit.Diamonds, shuffledCardDeck.ElementAt(1).Suit);
        Assert.Equal(CardSuit.Spades, shuffledCardDeck.ElementAt(2).Suit);
        Assert.Equal(CardSuit.Clubs, shuffledCardDeck.ElementAt(3).Suit);
    }
}