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
                    Card card = cardDeck.GetCard();

                    player.TakeCard(card);
                }

                if (userInput == StopPlayCommand || player.GetCardCount() >= maxPlayerCard)
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

        public int GetCardCount()
        {
            return _cards.Count;
        }
    }

    class Card
    {
        private string[] _type = { "Fire", "Water", "Wind", "Earth" };
        private int _minPower = 1;
        private int _maxPower = 30;
        private Random _random = new Random();

        public Card()
        {
            Type = _type[_random.Next(0, _type.Length)];
            Power = _random.Next(_minPower, _maxPower + 1);
        }

        public string Type { get; private set; }
        public int Power { get; private set; }
    }

    class CardDeck
    {
        private int _deckSize = 20;
        private Stack<Card> _cards = new Stack<Card>();

        public CardDeck()
        {
            CallectCards();
        }

        public Card GetCard()
        {
            return _cards.Pop();
        }

        private void CallectCards()
        {
            for (int i = 0; i < _deckSize; i++)
            {
                _cards.Push(new Card());
            }
        }
    }
}
