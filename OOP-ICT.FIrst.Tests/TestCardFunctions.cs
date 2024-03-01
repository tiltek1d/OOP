using FirstLab.Models;
using FirstLab.Models.Enums;
using Xunit;

namespace FirstLab.Tests;

public class TestCardFunctions
{
    [Fact]
    public void TestCard()
    {
        Card card = new ("A", CardSuit.Clubs, false);
        Assert.Equal("A", card.Name);
        Assert.False(card.IsOpen);
        card.IsOpen = true;
        Assert.True(card.IsOpen);
    }
}