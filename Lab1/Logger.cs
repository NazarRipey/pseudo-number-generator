using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Lab1
{
    static class Logger
    {
        public static void LogToConsole(List<ulong> sequence)
        {
            Console.WriteLine(String.Join(", ", sequence));
        }

        public static async Task LogToFileAsync(List<ulong> sequence, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                await sw.WriteAsync(String.Join(", ", sequence));
            }
        }
    }
}
