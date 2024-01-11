using System;
using System.Collections.Generic;

namespace Online_Card_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            (Queue<int> firstDeck, Queue<int> secondDeck) = generateDeck(1, 11);

            Console.WriteLine("PLAYER 1:");
            Console.WriteLine(string.Join("\n", firstDeck));

            Console.WriteLine("\nPLAYER 2:");
            Console.WriteLine(string.Join("\n", secondDeck));

            PlayCardGame(firstDeck, secondDeck);

            Console.WriteLine("\n== Post-game results ==");
            Console.WriteLine($"Player 1`s deck: {string.Join(", ", firstDeck)}");
            Console.WriteLine($"Player 2`s deck: {string.Join(", ", secondDeck)}");

            Console.ReadKey();
        }

        static void PlayCardGame(Queue<int> firstDeck, Queue<int> secondDeck)
        {
            int count = 1;
            do
            {
                Console.WriteLine($"\n-- Round{count++} --");

                Console.WriteLine($"Player 1`s deck: {string.Join(", ", firstDeck)}");
                Console.WriteLine($"Player 2`s deck: {string.Join(", ", secondDeck)}");

                var firstPlayerCard = firstDeck.Dequeue();
                var secondPlayerCard = secondDeck.Dequeue();

                Console.WriteLine($"Player 1 plays: {firstPlayerCard}");
                Console.WriteLine($"Player 2 plays: {secondPlayerCard}");

                if (firstPlayerCard > secondPlayerCard)
                {
                    firstDeck.Enqueue(firstPlayerCard);
                    firstDeck.Enqueue(secondPlayerCard);
                    Console.WriteLine("Player 1 wins the round!");
                }
                else
                {
                    secondDeck.Enqueue(secondPlayerCard);
                    secondDeck.Enqueue(firstPlayerCard);
                    Console.WriteLine("Player 2 wins the round!");
                }

            } while (firstDeck.Count > 0 && secondDeck.Count > 0);
        }


        static (Queue<int>, Queue<int>) generateDeck(int minCard, int maxCard)
        {
            Random random = new Random();

            Queue<int> firstDeck = new Queue<int>();

            Queue<int> secondDeck = new Queue<int>();

            while (firstDeck.Count < 5)
            {
                int card = random.Next(minCard, maxCard);

                if (!firstDeck.Contains(card))
                    firstDeck.Enqueue(card);
            }

            while (secondDeck.Count < 5)
            {
                int card = random.Next(minCard, maxCard);

                if (!firstDeck.Contains(card) && !secondDeck.Contains(card))
                    secondDeck.Enqueue(card);
            }

            return (firstDeck, secondDeck);
        }
    }
}
