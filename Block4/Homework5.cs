namespace ijunior.Block4
{
    internal class Homework5
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            FillArray(numbers);
            ShowArray(numbers);
            ArrayShuffle(numbers);
            ShowArray(numbers);
        }

        static void FillArray(int[] numbers)
        {
            Random random = new Random();
            int minRandomNumber = 1;
            int maxRabdomNumber = 10;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandomNumber, maxRabdomNumber);
            }
        }

        static void ShowArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine();
        }

        static void ArrayShuffle(int[] numbers)
        {
            int tempNumber;
            Random random = new Random();
            int numbersLength = numbers.Length - 1;
            int maxRandomNumber = 2;

            for (int i = 0; i < numbersLength; i++)
            {
                for (int k = 0; k < numbersLength - i; k++)
                {
                    if (random.Next(maxRandomNumber) == 0)
                    {
                        tempNumber = numbers[k];
                        numbers[k] = numbers[k + 1];
                        numbers[k + 1] = tempNumber;
                    }
                }
            }
        }
    }
}
