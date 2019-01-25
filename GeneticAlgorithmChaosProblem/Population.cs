using System;

namespace GeneticAlgorithmChaosProblem
{
    public class Population
    {
        Chromosome[] chromosomes;
        public Population(int populationCount, bool newPopulation = false)
        {
            chromosomes = new Chromosome[populationCount];
            if (newPopulation)
            {
                for (int i = 0; i < chromosomes.Length; i++)
                {
                    chromosomes[i] = new Chromosome();
                }
            }
        }

        internal Chromosome GetChromosome(int order)
        {
            return chromosomes[order];
        }

        internal int GetChromosomeCount()
        {
            return chromosomes.Length;
        }

        public Chromosome[] GetBestChromosomes()
        {
            for (int i = 0; i < chromosomes.Length; i++)
            {
                chromosomes[i].GetFitness();
            }
            Array.Sort(chromosomes, delegate (Chromosome c1, Chromosome c2)
            {
                return c1.GetFitness().CompareTo(c2.GetFitness());
            });
            return chromosomes;
        }

        internal void AddBestChromosome(Chromosome chromosome)
        {
            AddChromosome(0, chromosome);
        }

        internal void AddChromosome(int order, Chromosome chromosome)
        {
            chromosomes[order] = chromosome;
        }
    }
}
