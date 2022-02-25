using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.ConsoleApp
{
    public static class CommandHelper
    {
        public static void PrintAcknowledgment(string message, bool isSuccess)
        {
            Console.ForegroundColor = isSuccess ? ConsoleColor.DarkGreen : ConsoleColor.Red;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        public static void PrintAcknowledgment(IList<string> messages, bool isSuccess)
        {
            foreach (var message in messages)
            {
                Console.ForegroundColor = isSuccess ? ConsoleColor.DarkGreen : ConsoleColor.Red;
                Console.WriteLine($"{ message}");
                Console.ResetColor();
            }
        }
        public static Tuple<string,string> SplitHelper(string input, string splitter)
        {
            try
            {
                var arguments = input.Split(new String[] { splitter }, StringSplitOptions.RemoveEmptyEntries);
                var userName = arguments[0].Trim();
                var message = arguments[1].Trim();
                return Tuple.Create(userName, message);
            }
            catch(IndexOutOfRangeException iex)
            {
                throw iex;
            }
            
        }
        public static string SplitHelperShort(string input, string splitter)
        {
            try
            {
                var arguments = input.Split(new String[] { splitter }, StringSplitOptions.RemoveEmptyEntries);
                var userName = arguments[0].Trim();
                return userName;
            }
            catch (IndexOutOfRangeException iex)
            {
                throw iex;
            }

        }
    }
}
