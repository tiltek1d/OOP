using FourthLab.Models;
using FirstLab.Models;
using SecondLab;
using Xunit;
using Xunit.Abstractions;

namespace FourthLab.Tests;


public class TestPokerGame
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TestPokerGame(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public void AddPlayer_AddsPlayerToPlayersList()
    {
        var game = new PokerGame(new CardDeck(), new PokerCasino(1));
        var player = new PokerPlayer(1, 100);
        player.JoinGame(game);
        Assert.Equal(game.Players[0].GetId(), player.GetId());
    }
    
    [Fact]
    public void StartGame_InitializesGameProperties()
    {
        var cardDeck = new CardDeck();
        var casino = new PokerCasino(1);
        var game = new PokerGame(cardDeck, casino);
        var player1 = new PokerPlayer(1, 100);
        var player2 = new PokerPlayer(2, 100);
        game.AddPlayer(player1);
        game.AddPlayer(player2);
        
        game.StartGame();

        Assert.NotNull(game.MoneyService);
        Assert.NotNull(game.Dealer);
        Assert.Equal(game.Players[0], player1);
        Assert.Equal(game.Players[1], player2);
    }
    
    [Fact]
    public void StartFlop_AddsThreeCardsToBoardAndTwoCardsToEachPlayer()
    {
        var cardDeck = new CardDeck();
        var casino = new PokerCasino(1);
        var game = new PokerGame(cardDeck, casino);
        var player1 = new PokerPlayer(1, 100);
        var player2 = new PokerPlayer(2, 100);
        game.AddPlayer(player1);
        game.AddPlayer(player2);
        game.StartGame();
        
        game.StartFlop();
        
        Assert.Equal(3, game.Board.Count);
        Assert.Equal(2, player1.GetHand().Count);
        Assert.Equal(2, player2.GetHand().Count);
    }
    
    [Fact]
    public void StartTermOrRiver_AddsOneCardToBoard()
    {
        var cardDeck = new CardDeck();
        var casino = new PokerCasino(1);
        var game = new PokerGame(cardDeck, casino);
        var player1 = new PokerPlayer(1, 100);
        var player2 = new PokerPlayer(2, 100);
        game.AddPlayer(player1);
        game.AddPlayer(player2);
        game.StartGame();
        game.StartFlop();
        
        game.StartTermOrRiver();
        
        Assert.Equal(4, game.Board.Count);
    }
    
    [Fact]
    public void EndRound_DeactivatesPlayersAndWritesOffBets()
    {
        var casino = new PokerCasino(1);
        var game = new PokerGame(new CardDeck(), casino);
        var player1 = new PokerPlayer(1, 100);
        var player2 = new PokerPlayer(2, 100);
        player1.CreateCasinoAccount(casino);
        player2.CreateCasinoAccount(casino);
        player1.BuyChips(casino,70);
        player2.BuyChips(casino,70);
        game.AddPlayer(player1);
        game.AddPlayer(player2);
        game.StartGame();
        game.StartFlop();
        player1.MakeBet(game, 50);
        player2.MakeBet(game, 30);
        
        game.EndRound();

        
        Assert.True(player1.IsActive);
        Assert.False(player2.IsActive);
        Assert.Equal(20, (int)casino.GetCasinoAccount(player1.GetId()).ChipsAmount);
        Assert.Equal(40, (int)casino.GetCasinoAccount(player2.GetId()).ChipsAmount);
    }
    
    [Fact]
    public void DetermineWinner_ReturnsWinningPlayers()
    {
        var casino = new PokerCasino(1);
        var game = new PokerGame(new CardDeck(), casino);
        var player1 = new PokerPlayer(1, 100);
        var player2 = new PokerPlayer(2, 100);
        player1.CreateCasinoAccount(casino);
        player2.CreateCasinoAccount(casino);
        player1.BuyChips(casino,70);
        player2.BuyChips(casino,70);
        game.AddPlayer(player1);
        game.AddPlayer(player2);
        game.StartGame();
        game.StartFlop();
        player1.MakeBet(game, 50);
        player2.MakeBet(game, 30);
        game.StartTermOrRiver();
        game.StartTermOrRiver();
        var winners = game.DetermineWinner();
        
        Assert.NotNull(winners);
        
    }
}