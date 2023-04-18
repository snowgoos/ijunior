namespace ijunior.Block5
{
    internal class Homework2
    {
        static void Main(string[] args)
        {
            Queue<int> purchaseAmounts;

            purchaseAmounts = FillQueue();

            QueueHandler(purchaseAmounts);
        }

        static Queue<int> FillQueue()
        {
            Queue<int> purchaseAmounts = new Queue<int>();
            purchaseAmounts.Enqueue(10);
            purchaseAmounts.Enqueue(20);
            purchaseAmounts.Enqueue(30);
            purchaseAmounts.Enqueue(40);
            purchaseAmounts.Enqueue(50);

            return purchaseAmounts;
        }

        static void QueueHandler(Queue<int> purchaseAmounts)
        {
            int shopAccount = 0;

            while (purchaseAmounts.Count > 0)
            {
                int amount = purchaseAmounts.Dequeue();
                shopAccount += amount;

                Console.WriteLine($"Order amount: {amount}");
                Console.WriteLine($"Shop account: {shopAccount}");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
