using Xunit.Abstractions;

namespace FirstLab.Tests;

using Xunit;
using FirstLab.Models;

public class TestCardDeckFunctions
{
    private readonly ITestOutputHelper _testOutputHelper;
    public TestCardDeckFunctions(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public void TestCardDeck()
    {
        int rightCount = 52;
        var cardDeck = new CardDeck().GetCreateDeck();
        Assert.Equal(cardDeck.Count(), rightCount);
        foreach (var card in cardDeck)
        {
            _testOutputHelper.WriteLine(card.Name);
        }
    }
}