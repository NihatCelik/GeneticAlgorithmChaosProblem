using System;

namespace GeneticAlgorithmChaosProblem
{
    static class Variables
    {
        public static double CrossingValue { get; } = 0.5;

        public static double MutationValue { get; } = 0.4;

        public static double BalanceValue { get; } = 0.5;

        public static double XValue { get; } = 0.5;

        public static int BitCount { get; } = 1000000;

        public static double MinAValue { get; } = 1;

        public static int PopulationCount { get; } = 100;

        public static Random Random { get; set; }

        public static int ChildrenCount { get; } = 20;
    }
}
