using System;
using System.Collections.Generic;

namespace CardDeck6._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountOfCardsInDeck = 52;

            Player player = new Player();
            Deck deck = new Deck(amountOfCardsInDeck);

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"1 - Вытянуть карту\n2 - Показать взятые карты\n3 - Закончить игру");
                Console.WriteLine("Что сделать");
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        player.TakeCard(deck);
                        break;
                    case 2:
                        player.ShowCardsInHand();                        
                        break;
                    case 3:                        
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Некоректные ввод");
                        break;
                }                
            }
        }
    }  

    class Deck
    {
        Random random = new Random();
        
        private const int _amountOfValeOfCard = 13;
        private const int _amountOfSuits = 4;
        private const int _amountOfColors = 2;
        
        private Queue<Card> _cardsInDeck = new Queue<Card>();      

        public Deck(int count)    
        {
            for (int i = 0; i < count; i++)
            {
                _cardsInDeck.Enqueue(new Card(random.Next(0, _amountOfValeOfCard), random.Next(0, _amountOfSuits), random.Next(0, _amountOfColors)));    
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

        public void ShowCardInfo()
        {
            Console.WriteLine($"{(CardColor)Color}     {(CardValue)Value}    {(CardSuit)Suit}");
        }

        public enum CardValue
        {
            Двойка,
            Тройка,
            Четверка,
            Пятерка,
            Шестерка,
            Семерка,
            Восьмерка,
            Девятка,
            Десятка,
            Валет,
            Дама,
            Король,
            Туз  
        }

        public enum CardSuit
        {
            Пики,
            Бубби,
            Черви,
            Крести
        }

        public enum CardColor
        {
            Красная,
            Черная 
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
                Console.WriteLine($"Вы взяли карту\nУ вас в руке {amountOfCardsInHand} карт");
                PrintPlugMassage();
            }
            else
            {
                Console.WriteLine("В колоде законились карты");
                PrintPlugMassage();
            }
        }

        public void ShowCardsInHand()
        {
            if (_cardInHand.Count > 0)
            {
                Console.WriteLine("\nЦвет  | Достоинство |  Масть ");

                for (int i = 0; i < _cardInHand.Count; i++)
                {                    
                    _cardInHand[i].ShowCardInfo();                    
                }
                PrintPlugMassage();
            }
            else
            {
                Console.WriteLine("В руке нет карт");
                PrintPlugMassage();
            }
        }

        private void PrintPlugMassage()
        {
            Console.WriteLine("Нажмите любую кнопку для продолжения");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
