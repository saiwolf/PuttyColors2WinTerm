using System;

namespace PuttyColors2WinTerm.Helpers
{
    public static class ConsoleUtils
    {
        /// <summary>
        /// From: https://stackoverflow.com/a/54127216
        /// </summary>
        /// <param name="title">Prompt string</param>
        /// <returns>Boolean</returns>
        public static bool Confirm(string title = "Do you wish to continue?")
        {
            ConsoleKey response;
            do
            {
                Console.Write($"{ title } [y/n] ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return (response == ConsoleKey.Y);
        }
    }
}
