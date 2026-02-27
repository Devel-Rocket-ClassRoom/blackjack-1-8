using System;

class Card
{
    static readonly char[] _suits;
    private readonly int _number;
    private readonly int _suit;

    static Card()
    {
        _suits = new char[] { '♠', '♥', '♦', '♣' };
    }

    public Card(int number, int suit)
    {
        _number = number;
        _suit = suit;
    }

    public char GetSuitSymbol()
    {
        return _suits[_suit];
    }

    public string GetNumberSymbol()
    {
        switch (_number)
        {
            case 1:
                return "A";
            case 11:
                return "J";
            case 12:
                return "Q";
            case 13:
                return "K";
            default:
                return _number.ToString();

        }

    }

    public int GetScore()
    {
        return Math.Clamp(_number, 1, 10);
    }

    public override string ToString()
    {
        return $"[{GetSuitSymbol()}{GetNumberSymbol()}]";
    }



}
