using System;
using System.Collections.Generic;

namespace CardDeck6._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;

            int amountOfCardsInDeck = 52;

            Player player = new Player();
            Deck deck = new Deck(amountOfCardsInDeck);

            while (isWorking)
            {
                Console.WriteLine($"1 - Вытянуть карту\n2 - Показать взятые карты\n3 - Закончить игру\nЧто сделать");

                switch (Console.ReadLine())
                {
                    case "1":
                        player.TakeCard(deck);
                        break;
                    case "2":
                        player.ShowCardsInHand();                        
                        break;
                    case "3":                        
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Некоректны ввод");
                        break;
                }                
            }
        }
    }  

    class Deck
    {
        private const int _amountOfValeOfCard = 13;
        private const int _amountOfSuits = 4;
        private const int _amountOfColors = 2;

        private Random random = new Random();

        private Queue<Card> _cardsInDeck = new Queue<Card>();      

        public Deck(int count)    
        {
            for (int i = 0; i < count; i++)
            {
                _cardsInDeck.Enqueue(new Card(random.Next(0, _amountOfValeOfCard), random.Next(0,_amountOfSuits), random.Next(0,_amountOfColors)));    
            }            
        }

        public bool TryTakeCard(out Card card)
        {
            if (_cardsInDeck.Count > 0)
            {
                card = _cardsInDeck.Dequeue();                
                return true;
            }
            else
            {
                card = null;
                return false;
            }
        }
    }    

    class Card
    {
        public int Value { get; private set; } 
        public int Suit { get; private set; }
        public int Color { get; private set; }

        public Card(int value, int suit, int color)
        {           
            Value = value;
            Suit = suit;
            Color = color;            
        }

        public enum CardValue
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace  
        }

        public enum CardSuit
        {
            Spades,
            Diamonds,
            Hearts,
            Clubs
        }

        public enum CardColor
        {
            Red,
            Black 
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{(CardColor)Color}     {(CardValue)Value}    {(CardSuit)Suit}");
        }
    }

    class Player
    {
        private int amountOfCardsInHand = 0;

        private List<Card> _cardInHand = new List<Card>();

        public void TakeCard(Deck deck)
        {
            if (deck.TryTakeCard(out Card card))
            {
                _cardInHand.Add(card);
                amountOfCardsInHand++;                
                PrintPlugMassage($"Вы взяли карту\nУ вас в руке {amountOfCardsInHand} карт\nНажмите любую кнопку для продолжения");
            }
            else
            {                
                PrintPlugMassage("В колоде законились карты\nНажмите любую кнопку для продолжения");
            }
        }

        public void ShowCardsInHand()
        {
            if (_cardInHand.Count > 0)
            {
                Console.WriteLine("\nЦвет  | Достоинство |  Масть ");

                for (int i = 0; i < _cardInHand.Count; i++)
                {                    
                    _cardInHand[i].ShowInfo();                    
                }
                PrintPlugMassage("Нажмите любую кнопку для продолжения");
            }
            else
            {                
                PrintPlugMassage("В руке нет картНажмите любую кнопку для продолжения");
            }
        }

        private void PrintPlugMassage(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
