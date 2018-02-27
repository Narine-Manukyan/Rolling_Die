using System;

namespace RollingDieSimulation
{
    // This Delagate is for triggering events...
    public delegate void RollingADie(string message);

    /// <summary>
    /// This Class is for rolling die simulation and handling Events with it.
    /// </summary>
    public class Die
    {
        // This is a number that shows a die.
        public int number { private set; get; }

        // Random number Generator
        private readonly Random random = new Random();

        /* Event that describes a situation,
           when die shows two sixes in a row and count
           the number of times ‘two sixes in a row’ appear.*/
        public event RollingADie TwoSixesInARow;

        /* Event that describes a situation,
           when in the consequent 5 tosses the 
           sum of all numbers is greater than or equal to 20. */
        public event RollingADie SumGreatOrEqual20;

        // The parameterless constructor.
        public Die()
        {
            this.number = this.random.Next(1, 7);
        }

        // The Rolling function.
        public int[] RollingDie()
        {
            // Initializing the number of Tests we want to execute.
            Console.WriteLine("Enter the number of Tests: ");
            int numberOfTests = int.Parse(Console.ReadLine());
            // An Array, in which save the Rolling die numbers.
            int[] array = new int[numberOfTests];
            for (int i = 0; i < array.Length; i++)
            {
                // Generating The Random number for Die.
                this.number = random.Next(1, 7);
                array[i] = this.number;
            }
            return array;
        }

        public void Test(int[] array)
        {
            // The Count of ‘two sixes in a row’ apearing.
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i] + "\t");
                // When die shows two sixes in a row.
                if (i >= array.Length - 1)
                    break;
                if (array[i] == 6 && array[i] == array[i + 1])
                {
                    if(this.TwoSixesInARow != null)
                        // Invoking. 
                        this.TwoSixesInARow("Two Sixes in a Row.");
                    count++;
                }
            }
            Console.WriteLine("The Count of ‘two sixes in a row’ apearing: " + count + "\n");

            // The Sum of consequent 5 tosses.
            int sum;
            for (int i = 0; i < array.Length - 4; i++)
            {
                sum = 0;
                for (int j = i; j < i + 5; j++)
                {
                    sum += array[j];
                    Console.Write(array[j] + "\t");
                }
                // When the Sum is greater than or equal to 20.
                if (sum >= 20)
                {
                    if (this.SumGreatOrEqual20 != null)
                        // Invoking. 
                        this.SumGreatOrEqual20("Sum is greater or Equal to 20!\n\n");
                }
                else
                    Console.WriteLine("Sum isn't greater or Equal to 20!\n\n");
            }
        }
    }
}
