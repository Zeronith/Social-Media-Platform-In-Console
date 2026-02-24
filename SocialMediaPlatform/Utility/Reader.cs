using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaPlatform.Helpers
{
    internal class Reader
    {
        public static string ReadString(string msg)
        {
            while (true)
            {
                Console.WriteLine(msg);
                string? ans = Console.ReadLine();
                if (ans != null)
                {
                    return ans;
                }
                Console.WriteLine("Input cannot by empty");
            }
        }
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Enter a number.");
            }
        }
    }
}
