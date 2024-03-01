using FirstLab.Models;

namespace FourthLab.Models;

public class Calculator
{
    private readonly List<Card> _board;

    public Calculator(PokerGame game)
    {
        _board = game.Board;
    }
    
    public int CountScore(PokerPlayer player)
    {
        var cards = player.GetHand().Concat(_board).ToList();
        return Pair(cards) + TwoPair(cards) + ThreeOfKind(cards) + Straight(cards) + Flush(cards) +
               FullHouse(cards) + Quads(cards) + StraightFlush(cards) + RoyalFlush(cards);
    }

    public int HighCard(PokerPlayer player)
    {
        var cards = player.GetHand();
        return cards.Max(card => card.Value);
    }

    private int Pair(List<Card> cards)
    {
        const int points = 2;
        const int cardAmount = 2;
        return cards.GroupBy(card => card.Value).Count(group => group.Count() == cardAmount) == 1 ? points : 0;
    }

    private int TwoPair(List<Card> cards)
    {
        const int points = 3;
        const int cardAmount = 2;
        return cards.GroupBy(card => card.Value).Count(group => group.Count() == cardAmount) == 2 ? points : 0;
    }

    private int ThreeOfKind(List<Card> cards)
    {
        const int points = 4;
        const int cardAmount = 3;
        return cards.GroupBy(card => card.Value).Any(group => group.Count() == cardAmount) ? points : 0;
    }

    private int Straight(List<Card> cards)
    {
        const int points = 5;
        const int cardAmount = 5;
        var combs = Combinations(cards, cardAmount);
        if (combs.Any(set => FiveInRow(set.ToList())))
        {
            return points;
        }
        return 0;
    }
    
    private int Flush(List<Card> cards)
    {
        const int points = 6;
        const int cardAmount = 5;
        return cards.GroupBy(card => card.Suit).Count(group => group.Count() >= cardAmount) == 1 ? points : 0;
    }

    private int FullHouse(List<Card> cards)
    {
        const int pointsPair = 2;
        const int pointsThree = 4;
        const int points = 7;
        if (Pair(cards) == pointsPair && ThreeOfKind(cards) == pointsThree) return points;
        return 0;
    }

    private int Quads(List<Card> cards)
    {
        const int points = 8;
        const int cardAmount = 4;
        return cards.GroupBy(card => card.Value).Any(group => group.Count() == cardAmount) ? points : 0;
    }

    private int StraightFlush(List<Card> cards)
    {
        const int points = 9;
        const int cardAmount = 5;
        var combs = Combinations(cards, cardAmount);
        if (combs.Any(set => FiveInRow(set.ToList()) && Flush(set.ToList())==6))
        {
            return points;
        }
        return 0;
    }

    private int RoyalFlush(List<Card> cards)
    {
        const int points = 10;
        const int pointsFlush = 6;
        const int cardAmount = 5;
        const int aceValue = 11;
        var combs = Combinations(cards, cardAmount);
        if (combs.Any(set => FiveInRow(set.ToList()) && Flush(set.ToList())==pointsFlush && cards.Max(card => card.Value)==aceValue))
        {
            return points;
        }
        return 0;
    }
    
    private bool FiveInRow(List<Card> cards)
    {
        const int valueDiff = 4;
        return cards.GroupBy(card => card.Value).Count() == cards.Count() &&
               cards.Max(card => card.Value) - cards.Min(card => card.Value) == valueDiff;
    }
    
    private static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> elements, int k)
    {
        var elem = elements.ToArray();
        var size = elem.Length;
 
        if (k > size) yield break;
 
        var numbers = new int[k];
 
        for (var i = 0; i < k; i++)
            numbers[i] = i;
 
        do
        {
            yield return numbers.Select(n => elem[n]);
        } while (NextCombination(numbers, size, k));
    }
    
    private static bool NextCombination(IList<int> num, int n, int k)
    {
        bool finished;
 
        var changed = finished = false;
 
        if (k <= 0) return false;
 
        for (var i = k - 1; !finished && !changed; i--)
        {
            if (num[i] < n - 1 - (k - 1) + i)
            {
                num[i]++;
 
                if (i < k - 1)
                    for (var j = i + 1; j < k; j++)
                        num[j] = num[j - 1] + 1;
                changed = true;
            }
            finished = i == 0;
        }
 
        return changed;
    }

}