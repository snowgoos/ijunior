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
                        Console.WriteLine("Card deck is empty.");

                        player.ShowCards();
                        isRunning = true;
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
            CreateCards();
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
            Card[] cards = _cards.ToArray();
            int cardsCount = cards.Length;

            while (cardsCount > 1)
            {
                int randomIndex = s_random.Next(cardsCount);
                Card card = cards[randomIndex];
                cards[randomIndex] = cards[cardsCount - 1];
                cards[cardsCount - 1] = card;
                cardsCount--;
            }

            _cards.Clear();

            foreach (var card in cards)
            {
                _cards.Push(card);
            }
        }

        private void CreateCards()
        {
            int size = 10;
            string[] type = { "Fire", "Water", "Wind", "Earth" };
            int minPower = 1;
            int maxPower = 30;

            for (int i = 0; i < size; i++)
            {
                string cardType = type[s_random.Next(0, type.Length)];
                int power = s_random.Next(minPower, maxPower + 1);

                _cards.Push(new Card(cardType, power));
            }
        }
    }
}
