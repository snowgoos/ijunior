namespace ijunior.OOP.Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string TakeCardCommand = "1";
            const string StopPlayCommand = "2";

            int maxPlayerCard = 5;
            string userInput;
            bool isFinish = false;

            CardDeck cardDeck = new CardDeck();
            Player player = new Player();

            while (isFinish == false)
            {
                Console.WriteLine("Please select action:");
                Console.WriteLine($"{TakeCardCommand}. Take a card");
                Console.WriteLine($"{StopPlayCommand}. Stop play");

                userInput = Console.ReadLine();

                if (userInput == TakeCardCommand)
                {
                    if (cardDeck.CardCount > 0)
                    {
                        Card card = cardDeck.GetCard();

                        player.TakeCard(card);
                    }
                    else
                    {
                        Console.Write("Card deck is empty. Please press enter for reshuffle.");
                        Console.ReadKey();

                        cardDeck.Shuffle();
                    }
                }

                if (userInput == StopPlayCommand || player.CardCount >= maxPlayerCard)
                {
                    player.ShowCards();
                    isFinish = true;
                }
            }
        }
    }

    class Player
    {
        private List<Card> _cards = new List<Card>();

        public int CardCount { get; private set; }

        public void TakeCard(Card card)
        {
            _cards.Add(card);
            CardCount = _cards.Count;
        }

        public void ShowCards()
        {
            foreach (var card in _cards)
            {
                Console.WriteLine($"Card name: {card.Type}, Card power: {card.Power}");
            }
        }
    }

    class Card
    {
        private int _minPower = 1;
        private int _maxPower = 30;
        private Random _random = new Random();

        public Card(string type)
        {
            Type = type;
            Power = _random.Next(_minPower, _maxPower + 1);
        }

        public string Type { get; private set; }
        public int Power { get; private set; }
    }

    class CardDeck
    {
        private int _deckSize = 10;
        private Stack<Card> _cards = new Stack<Card>();
        private Random _random = new Random();

        public CardDeck()
        {
            CallectCards();
            CardCount = _cards.Count;
        }

        public int CardCount { get; private set; }

        public Card GetCard()
        {
            Card card = _cards.Pop();
            CardCount = _cards.Count;

            return card;
        }

        public void Shuffle()
        {
            _cards.Clear();
            CallectCards();
            CardCount = _cards.Count;
        }

        private void CallectCards()
        {
            string[] type = { "Fire", "Water", "Wind", "Earth" };

            for (int i = 0; i < _deckSize; i++)
            {
                string cardType = type[_random.Next(0, type.Length)];

                _cards.Push(new Card(cardType));
            }
        }
    }
}
