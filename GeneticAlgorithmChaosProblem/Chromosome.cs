using System;

namespace GeneticAlgorithmChaosProblem
{
    public class Chromosome
    {
        //Bizim Uygunluk Değerimiz. 0-15 Arasındaki Sayıların En Büyüğü ile En Küçüğünün Farkıdır.
        private double FitnessValue;

        public double AValue { get; }

        public int ZeroCount { get; set; }
        public int OneCount { get; set; }
        public int[] Numbers { get; set; }

        public Chromosome()
        {
            AValue = Variables.Random.NextDouble();

            if (AValue < Variables.MinAValue)
                AValue += Variables.MinAValue;
        }

        public Chromosome(double aValue)
        {
            AValue = aValue;
        }

        public double GetFitness()
        {
            if (FitnessValue == 0)
            {
                FitnessValue = Fitness.CalculateFitness(this);
            }
            return FitnessValue;
        }

        public override string ToString()
        {
            string returnText = "";
            returnText += "A: " + AValue;
            returnText += Environment.NewLine;
            returnText += "0 Bit Count: " + ZeroCount;
            returnText += Environment.NewLine;
            returnText += "1 Bit Count: " + OneCount;
            returnText += Environment.NewLine;
            returnText += "0-1 Bit Difference: " + Math.Abs(ZeroCount - OneCount);
            returnText += Environment.NewLine;

            for (int i = 0; i < Numbers.Length; i++)
            {
                returnText += i + " Numbers: " + Numbers[i] + " Difference: " + Math.Abs(15625 - Numbers[i]);
                returnText += Environment.NewLine;
            }

            returnText += "Fitness Value: " + Fitness.CalculateFitness(this);

            return returnText;
        }
    }
}
