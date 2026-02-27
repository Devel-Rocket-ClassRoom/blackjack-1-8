using System;

class Deck
{
    private Card[] _deck;
    private int _index;

    public Deck()
    {
        _deck = new Card[13 * 4];
        _index = 0;
        for (int suit = 0; suit < 4; suit++)
        {
            for (int number = 1; number <= 13; number++)
            {
                _deck[_index++] = new Card(number, suit);
            }
        }
        Shuffle();
    }

    public void Shuffle()
    {
        Random random = new Random();
        random.Shuffle(_deck);
        _index = 0;
        Console.WriteLine("카드를 섞는 중...");
    }

    public Card Draw()
    {
        if(_index == 52)
        {
            Shuffle();
        }
        return _deck[_index++];
    }
}
