using System;

class Player
{
    private Card[] _hand;
    int _count = 0;


    public Player()
    {
        _hand = new Card[11];
    }

    public int GetScore()
    {
        int scr = 0;

        bool hasAce = false;
        for (int i = 0; i < _count; i++)
        {
            int s = _hand[i].GetScore();

            if (s == 1)
            {
                if (hasAce)
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

        if (hasAce)
        {
            if (scr > 10)
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

    public void PrintHand()
    {
        
        for (int i = 0; i < _count; i++)
        {
            Console.Write(_hand[i]);
        }
        Console.WriteLine();

    }
    public void Reset()
    {
        _count = 0;
    }
}