using System;

namespace RollingDieSimulation
{
    class Program
    {
        // Function that Shows Messages.
        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            // Creating a Die instance.
            Die die = new Die();

            // An Array, in which save the Rolling die numbers.
            int[] array = die.RollingDie();

            // Adding Function in event.
            die.TwoSixesInARow += ShowMessage;

            // Adding Function in event.
            die.SumGreatOrEqual20 += ShowMessage;

            // Rolling a Die and Testing it.
            die.Test(array);
        }
    }
}
