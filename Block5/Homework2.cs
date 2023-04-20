namespace ijunior.Block5
{
    internal class Homework2
    {
        static void Main(string[] args)
        {
            Queue<int> purchaseAmounts;

            purchaseAmounts = FillQueue();

            ServiceShop(purchaseAmounts);
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

        static void ServiceShop(Queue<int> purchaseAmounts)
        {
            int shopAccount = 0;

            while (purchaseAmounts.Count > 0)
            {
                shopAccount += purchaseAmounts.Dequeue();

                Console.WriteLine($"Shop account: {shopAccount}");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
