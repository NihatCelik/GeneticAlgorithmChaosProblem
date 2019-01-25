using System;
using System.Linq;

namespace GeneticAlgorithmChaosProblem
{
    public class Fitness
    {
        public static double CalculateFitness(Chromosome chromosome)
        {
            double aValue = chromosome.AValue;
            double x = Variables.XValue;
            double balance = Variables.BalanceValue;
            int bitCount = Variables.BitCount;
            chromosome.ZeroCount = chromosome.OneCount = 0;
            string binary = "";
            int[] numbers = new int[16];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = 0;
            }

            for (int i = 0; i < bitCount; i++)
            {
                if ((i + 1) % 4 == 0 && i != 0)
                {
                    numbers[Convert.ToInt32(binary, 2)]++;
                    binary = "";
                }

                if (x < 0.5) x = x * aValue;
                else x = aValue * (1 - x);

                if (x < balance)
                {
                    binary += "0";
                    chromosome.ZeroCount++;
                }
                else
                {
                    binary += "1";
                    chromosome.OneCount++;
                }
            }
            chromosome.Numbers = numbers;

            return numbers.Max() - numbers.Min();
        }
    }
}
