using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
Console.WriteLine("=== 블랙잭 게임 === ");
Console.WriteLine();
Deck deck = new Deck();
Player player = new Player();
Dealer dealer = new Dealer();

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    player.ReceiveCard(deck.Draw());
    player.ReceiveCard(deck.Draw());
    dealer.ReceiveCard(deck.Draw());
    dealer.ReceiveCard(deck.Draw());

    Console.WriteLine("=== 초기 패 ===");
    Console.Write("딜러의 패:");
    dealer.PrintHand(true);
    Console.WriteLine("딜러 점수: ?");

    Console.WriteLine();
    Console.Write("플레이어의 패:");
    player.PrintHand();
    Console.WriteLine($"플레이어 점수: {player.GetScore()}");
    while (true)
    {
        Console.WriteLine("H(Hit) 또는 S(Stand)를 선택하세요: ");
        string H = Console.ReadLine();
        if (H == "H")
        {
            Card c = deck.Draw();
            Console.WriteLine($"플레이어가 카드를 받았습니다:{c}");
            player.ReceiveCard(c);

            Console.WriteLine();
            Console.Write("플레이어의 패:");
            player.PrintHand();
            Console.WriteLine($"플레이어 점수: {player.GetScore()}");
            if (player.GetScore() > 21)
            {
                break;
            }
        }
        else if (H == "S")
        {
            Console.WriteLine("플레이어가 Stand를 선택했습니다.");
            break;
        }
    }

    if (player.GetScore() <= 21) {
        dealer.PrintHidden();
        Console.Write("딜러의 패:");
        dealer.PrintHand(false);
        Console.WriteLine($"딜러 점수: {dealer.GetScore()}");
        Console.WriteLine();

        while (dealer.GetScore() < 17)
        {

            Card c = deck.Draw();
            Console.WriteLine($"딜러가 카드를 받았습니다:{c}");
            dealer.ReceiveCard(c);

            Console.Write("딜러의 패:");
            dealer.PrintHand(false);
            Console.WriteLine($"딜러 점수: {dealer.GetScore()}");


        }
    }

    Console.WriteLine("=== 게임 결과 ===");
    Console.WriteLine($"플레이어: {player.GetScore()}");
    Console.WriteLine($"딜러:{dealer.GetScore()} ");
    Console.WriteLine();
     
    if(dealer.GetScore() > 21)
    {
         
        Console.WriteLine($"플레이어 승리!");
    }
    else if(player.GetScore() > 21)
    {
        Console.WriteLine("딜러 승리!");
    }
    else
    {
        if(player.GetScore() > dealer.GetScore())
        {
            Console.WriteLine($"플레이어 승리!");
        }
        else if(player.GetScore() < dealer.GetScore())
        {
            Console.WriteLine("딜러 승리!");
        }
        else
        {
            Console.WriteLine("무승부! ");
        }
    }
    bool isPlayAgain = false;
    while (true)
    {

        Console.WriteLine();
        Console.WriteLine("새 게임을 하시겠습니까?(Y/N): ");
        string Y = Console.ReadLine();
        if (Y == "Y")
        {
            player.Reset();
            dealer.Reset();
            isPlayAgain = true;
            break;
        }
        else if (Y == "N")
        {
            Console.WriteLine("게임을 종료합니다.");
            break;
        }
    }

    if(!isPlayAgain)
    {
        break;
    }

}


