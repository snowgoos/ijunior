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
            bool isRunning = false;

            Deck deck = new Deck();
            Player player = new Player();

            while (isRunning == false)
            {
                Console.WriteLine("Please select action:");
                Console.WriteLine($"{TakeCardCommand}. Take a card");
                Console.WriteLine($"{StopPlayCommand}. Stop play");

                userInput = Console.ReadLine();

                if (userInput == TakeCardCommand)
                {
                    if (deck.CardCount > 0)
                    {
                        Card card = deck.GiveCard();

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
                    isRunning = true;
                }
            }
        }
    }

    class Player
    {
        private List<Card> _cards = new List<Card>();

        public int CardCount => _cards.Count;

        public void TakeCard(Card card)
        {
            _cards.Add(card);
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

        private Stack<Card> _cards = new Stack<Card>();

        public Deck()
        {
            Shuffle();
        }

        public int CardCount => _cards.Count;

        public Card GiveCard()
        {
            Card card = _cards.Pop();

            return card;
        }

        public void Shuffle()
        {
            int size = 10;

            _cards.Clear();

            for (int i = 0; i < size; i++)
            {
                _cards.Push(CreateCard());
            }
        }

        private Card CreateCard()
        {
            string[] type = { "Fire", "Water", "Wind", "Earth" };
            int minPower = 1;
            int maxPower = 30;

            string cardType = type[s_random.Next(0, type.Length)];
            int power = s_random.Next(minPower, maxPower + 1);

            return new Card(cardType, power);
        }
    }
}
