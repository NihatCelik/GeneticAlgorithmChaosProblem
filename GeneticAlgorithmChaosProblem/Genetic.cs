using System;

namespace GeneticAlgorithmChaosProblem
{
    public class Genetic
    {
        /// <summary>
        /// Yeni Popülasyonumuz en iyi 2 kromozomumuzdan verilen çocuk sayısı kadar türesin.
        /// </summary>
        /// <param name="population"></param>
        /// <returns></returns>
        public static Population NewPopulation(Population population)
        {
            Population newPopulation = new Population(Variables.ChildrenCount);
            Chromosome[] orderedChromosomes = population.GetBestChromosomes();
            newPopulation.AddBestChromosome(orderedChromosomes[0]);
            for (int i = 1; i < Variables.ChildrenCount; i++)
            {
                Chromosome newChromosome = CrossingChromosome(orderedChromosomes[0], orderedChromosomes[1]);
                newChromosome = MutationChromosome(newChromosome);
                newPopulation.AddChromosome(i, newChromosome);
            }

            return newPopulation;
        }

        /// <summary>
        /// En iyi 2 kromozomu al ve Çaprazlama Değerine göre yeni kromozom üret.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private static Chromosome CrossingChromosome(Chromosome first, Chromosome second)
        {
            string newValue = "1.";
            string firstAValue = first.AValue.ToString().Substring(2);
            string secondAValue = second.AValue.ToString().Substring(2);
            int lenght = firstAValue.Length < secondAValue.Length ? firstAValue.Length : secondAValue.Length;
            for (int i = 0; i < lenght; i++)
            {
                if (Variables.Random.NextDouble() <= Variables.CrossingValue) newValue += firstAValue[i];
                else newValue += secondAValue[i];
            }
            return new Chromosome(double.Parse(newValue));
        }

        /// <summary>
        /// Üretilen yeni değeri mutasyona uğrat.
        /// </summary>
        /// <param name="chromosome"></param>
        /// <returns></returns>
        private static Chromosome MutationChromosome(Chromosome chromosome)
        {
            string strNewAValue = "1.";

            Random rnd = Variables.Random;
            for (int i = 2; i < chromosome.AValue.ToString().Length; i++)
            {
                if (rnd.NextDouble() <= Variables.MutationValue) strNewAValue += rnd.Next(0, 10).ToString();
                else strNewAValue += chromosome.AValue.ToString()[i];
            }
            double newAValue = Convert.ToDouble(strNewAValue);
            return new Chromosome(newAValue);
        }
    }
}