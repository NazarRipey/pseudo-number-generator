using System;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string filePath = "sequence.txt";
            ulong m = (ulong)(Math.Pow(2, 11) - 1);
            ulong a = (ulong)Math.Pow(3, 5);
            ulong c = 1;
            ulong x0 = 4;

            PseudoNumberGenerator pseudoNumberGenerator = new PseudoNumberGenerator(m, a, c, x0);

            Console.WriteLine("How much numbers do you want to generate: ");
            if (!ulong.TryParse(Console.ReadLine(), out ulong numbersToGenerate))
            {
                Console.WriteLine("Wrong input");
                return;
            }

            Console.WriteLine("Generating sequence...");
            var sequence = pseudoNumberGenerator.GenerateNumbers(numbersToGenerate);

            await Logger.LogToFileAsync(sequence, filePath);
            Console.WriteLine("Generated sequence: ");
            Logger.LogToConsole(sequence);

            Console.WriteLine();
            Console.WriteLine(pseudoNumberGenerator.GetPeriod());

            Console.ReadLine();
        }
    }
}
