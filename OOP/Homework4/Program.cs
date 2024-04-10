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

            Deck deck = new Deck();
            Player player = new Player();

            while (isFinish == false)
            {
                Console.WriteLine("Please select action:");
                Console.WriteLine($"{TakeCardCommand}. Take a card");
                Console.WriteLine($"{StopPlayCommand}. Stop play");

                userInput = Console.ReadLine();

                if (userInput == TakeCardCommand)
                {
                    if (deck.CardCount > 0)
                    {
                        Card card = deck.RemoveCard();

                        player.TakeCard(card);
                    }
                    else
                    {
                        Console.Write("Card deck is empty. Please press enter for reshuffle.");
                        Console.ReadKey();

                        deck.Shuffle();
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
        public Card(string type, int power)
        {
            Type = type;
            Power = power;
        }

        public string Type { get; private set; }
        public int Power { get; private set; }
    }

    class Deck
    {
        private static Random s_random = new Random();

        private int _size = 10;
        private Stack<Card> _cards = new Stack<Card>();

        public Deck()
        {
            Shuffle();
        }

        public int CardCount => _cards.Count;

        public Card RemoveCard()
        {
            Card card = _cards.Pop();

            return card;
        }

        public void Shuffle()
        {
            _cards.Clear();

            for (int i = 0; i < _size; i++)
            {
                _cards.Push(CardCreation());
            }
        }

        private Card CardCreation()
        {
            string[] type = { "Fire", "Water", "Wind", "Earth" };
            int _minPower = 1;
            int _maxPower = 30;

            string cardType = type[s_random.Next(0, type.Length)];
            int power = s_random.Next(_minPower, _maxPower + 1);

            return new Card(cardType, power);
        }
    }
}
