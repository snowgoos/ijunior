namespace ijunior.Block5
{
    internal class Homework5
    {
        static void Main(string[] args)
        {
            List<string> vehicles = new List<string>();
            string[] cars = { "test1", "test2", "test3" };
            string[] bikes = { "test2", "test4", "test1", "test5" };

            FillCollection(vehicles, cars);
            FillCollection(vehicles, bikes);
            ShowCollection(vehicles);
        }

        static void FillCollection(List<string> collection, string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                if (collection.Contains(strings[i]) == false)
                {
                    collection.Add(strings[i]);
                }
            }
        }

        static void ShowCollection(List<string> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
