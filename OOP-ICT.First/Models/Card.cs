namespace FirstLab.Models;
using FirstLab.Models.Enums;

public class Card
{       
    private string _name = null!;
    
    private readonly string[] _names = new[] {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    public string Name
    {
        get => _name;
        private set
        {
            if (!_names.Contains(value))
                throw new Exception("Unknowing card name");
            _name = value;
        }
    }

    public int Value { get; }

   public CardSuit Suit { get; }

    public bool IsOpen { get; set; }
    
    public Card(string name, CardSuit suit, bool isOpen)
    {
        Name = name;
        Suit = suit;
        
        int value;
        try
        {
            value = int.Parse(name);
        }
        catch
        {
            value = name == "A" ? 11 : 10;
        }

        Value = value;
        IsOpen = isOpen;
    }
}