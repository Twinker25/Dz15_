using static System.Net.Mime.MediaTypeNames;

namespace Dz15_
{
    internal class Program
    {

        static bool Prime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        static bool Fibonacci(int number)
        {
            int a = 0;
            int b = 1;

            while (b < number)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }

            return b == number;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter task (1 - 5): ");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        string primeFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\PrimeNumber.txt";
                        string fibFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\FibNumber.txt";

                        Random r = new Random();
                        int[] array = new int[100];
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i] = r.Next(0, 100);
                        }

                        int prime = 0;
                        int fib = 0;

                        using (StreamWriter primeWriter = new StreamWriter(primeFile))
                        {
                            using (StreamWriter fibWriter = new StreamWriter(fibFile))
                            {
                                foreach (int number in array)
                                {
                                    if (Prime(number))
                                    {
                                        primeWriter.WriteLine(number);
                                        prime++;
                                    }

                                    if (Fibonacci(number))
                                    {
                                        fibWriter.WriteLine(number);
                                        fib++;
                                    }
                                }
                            }
                        }

                        int total = prime + fib;

                        Console.WriteLine("Statistics:");
                        Console.WriteLine($"Prime numbers: {prime}");
                        Console.WriteLine($"Fibonacci numbers: {fib}");
                        Console.WriteLine($"Total: {total}");
                        break;

                    case 2:
                        string searchFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\Search.txt";

                        using (FileStream fs = File.Create(searchFile))
                        {
                            Console.WriteLine("File create");
                        }

                        using (StreamWriter writer = new StreamWriter(searchFile))
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Write("Enter 3 strings to file: ");
                                string str = Console.ReadLine();
                                writer.WriteLine(str);
                            }
                        }

                        Console.Write("Enter text for search: ");
                        string searchText = Console.ReadLine();
                        Console.Write("Enter text for replace: ");
                        string replaceText = Console.ReadLine();

                        string fileContent = File.ReadAllText(searchFile);
                        if (fileContent.Contains(searchText))
                        {
                            fileContent = fileContent.Replace(searchText, replaceText);
                            File.WriteAllText(searchFile, fileContent);
                            Console.WriteLine("Text replaced");
                        }
                        else
                        {
                            Console.WriteLine("Search text not found");
                        }
                        break;

                    case 3:
                        string textFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\TextFile.txt";
                        string moderationFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\ModerationWords.txt";

                        using (StreamWriter writer = new StreamWriter(textFile))
                        {
                            Console.Write("Enter text: ");
                            string Words = Console.ReadLine();
                            writer.WriteLine(Words);
                        }

                        using (StreamWriter writer = new StreamWriter(moderationFile))
                        {
                            Console.Write("Enter moderator word: ");
                            string modWord = Console.ReadLine();
                            writer.WriteLine(modWord);
                        }

                        string[] moderationWords = File.ReadAllLines(moderationFile);
                        string text = File.ReadAllText(textFile);

                        foreach (string word in moderationWords)
                        {
                            text = text.Replace(word, new string('*', word.Length));
                        }

                        File.WriteAllText(textFile, text);
                        Console.WriteLine("Moderation completed.");
                        break;

                    case 4:
                        string originalFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\OriginalFile.txt";
                        string reverseFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\ReverseFile.txt";

                        using (StreamWriter writer = new StreamWriter(originalFile))
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Write("Enter 3 strings to file: ");
                                string str = Console.ReadLine();
                                writer.WriteLine(str);
                            }
                        }

                        string content = File.ReadAllText(originalFile);

                        char[] arr = content.ToCharArray();
                        Array.Reverse(arr);
                        string reverseContent = new string(arr);

                        File.WriteAllText(reverseFile, reverseContent);

                        Console.WriteLine("Complete!");
                        break;

                    case 5:
                        string numberFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\Numbers.txt";
                        string positiveFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\PositiveNumbers.txt";
                        string negativeFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\NegativeNumbers.txt";
                        string twoDigitFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\TwoDigitNumbers.txt";
                        string fiveDigitFile = "D:\\Games\\Visual Studio\\Dz15_\\Dz15_\\FiveDigitNumbers.txt";

                        Random rnd = new Random();

                        using (StreamWriter writer = new StreamWriter(numberFile))
                        {
                            for (int i = 0; i < 100000; i++)
                            {
                                int number = rnd.Next(-50000, 50000);
                                writer.WriteLine(number);
                            }
                        }

                        string[] lines = File.ReadAllLines(numberFile);

                        int positiveCount = 0;
                        int negativeCount = 0;
                        int twoDigitCount = 0;
                        int fiveDigitCount = 0;

                        using (StreamWriter positiveWriter = new StreamWriter(positiveFile))
                        {
                            using (StreamWriter negativeWriter = new StreamWriter(negativeFile))
                            {
                                using (StreamWriter twoDigitWriter = new StreamWriter(twoDigitFile))
                                {
                                    using (StreamWriter fiveDigitWriter = new StreamWriter(fiveDigitFile))
                                    {
                                        foreach (string line in lines)
                                        {
                                            if (int.TryParse(line, out int number))
                                            {
                                                if (number > 0)
                                                {
                                                    positiveCount++;
                                                    positiveWriter.WriteLine(number);
                                                }
                                                else if (number < 0)
                                                {
                                                    negativeCount++;
                                                    negativeWriter.WriteLine(number);
                                                }

                                                if (number >= 10 && number <= 99)
                                                {
                                                    twoDigitCount++;
                                                    twoDigitWriter.WriteLine(number);
                                                }

                                                if (number >= 10000 && number <= 99999)
                                                {
                                                    fiveDigitCount++;
                                                    fiveDigitWriter.WriteLine(number);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        Console.WriteLine("Statistics:");
                        Console.WriteLine($"Positive numbers: {positiveCount}");
                        Console.WriteLine($"Negative numbers: {negativeCount}");
                        Console.WriteLine($"Two-digit numbers: {twoDigitCount}");
                        Console.WriteLine($"Five-digit numbers: {fiveDigitCount}");
                        break;
                    default: Console.WriteLine("Error!"); break;
                }
            }
        }
    }
}