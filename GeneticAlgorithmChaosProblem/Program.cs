using System;

namespace GeneticAlgorithmChaosProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            /* ----------------Random Nesnesi--------------------------
             * For içinde new Random() yaparsak aynı değerleri üretir. 
             * Bundan dolayı başlangıçta oluşturup her yerde bunu kullanmalıyız.
             * --------------------------------------------------------
             * Popülasyonumuzdaki tüm kromozomları dolaşıp her zaman en iyi kromozomu almak zorundayız.
             * Bu en iyi kromozomu ekrana yazdırıp, genetik algoritma ile yeni popülasyon türetiyoruz.
             */
            Variables.Random = new Random();
            int populationCount = Variables.PopulationCount;
            Population population = new Population(populationCount, true);

            for (int i = 0; i < populationCount; i++)
            {
                Chromosome bestChromosome = population.GetBestChromosomes()[0];
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Generation: " + (i + 1));
                Console.WriteLine(bestChromosome.ToString());
                population = Genetic.NewPopulation(population);
            }
            Console.ReadLine();
        }
    }
}