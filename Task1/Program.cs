using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Implement the task here.
            var flag = true;
            while(flag)
            {
                Console.Write("Enter the string: ");
                var inputString = Console.ReadLine();
                try
                {
                    Console.WriteLine(inputString[0]);
                    Console.WriteLine("If you want to stop enter 0.");
                    var result = Console.ReadLine();
                    if(result == "0")
                        flag = false;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Sorry, but you write uncorrect string");
                }
            }
        }
    }
}