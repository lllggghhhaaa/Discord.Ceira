using System;

namespace Discord.Ceira.Tests
{
    class Program
    {
        static void Main()
        {
            new Client("ceira").GetChannel("ceira").SendMessage("ceira");

            Console.Read();
        }
    }
}