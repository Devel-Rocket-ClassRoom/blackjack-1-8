using System;

class Dealer
{
    private Card[] _hand;
    int _count = 0;


    public Dealer()
    {
        _hand = new Card[11];
    }

    public int GetScore()
    {
        int scr = 0;

        bool hasAce = false;
        for(int i = 0; i< _count; i++)
        {
             int s = _hand[i].GetScore();

            if (s == 1)
            {
                if(hasAce)
                {
                     scr++;
                }
                else
                {
                    hasAce = true;
                }
                continue;
            }
            scr += s;
        }

        if(hasAce)
        {
            if(scr > 10)
            {
                scr++;
            }
            else
            {
                scr += 11;
            }
        }
        return scr;
    }

    public void ReceiveCard(Card c)
    {

        _hand[_count++] = c;
    }

    public void PrintHand(bool hidden)
    {
        if(hidden)
        {
            Console.Write("[??]");
        }
        else
        {
            Console.Write(_hand[0]);
        }
        for (int i = 1; i < _count; i++)
        {
            Console.Write(_hand[i]);
        }
        Console.WriteLine();

    }

    public void PrintHidden()
    {

        Console.WriteLine($"딜러의 숨겨진 카드: {_hand[0]}");
        Console.WriteLine();
    }
    public void Reset()
    {
        _count = 0;
    }
}
   
