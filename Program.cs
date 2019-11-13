using System;

namespace laba_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] mas = new double[,] {
                { 2, 7, 5, 8, 4 },
                { 1, 6, 4, 7, 3 },
                { 3, 8, 6, 9, 5 },
                { 5, 3, 7, 9, 5 }
            };

            //double[,] mas = new double[,]
            //{
            //    { 4, 5, 6, 7},
            //    { 3, 4, 5, 5},
            //    { 7, 6, 10, 8},
            //    { 8, 5, 4, 3}
            //};

            //double[,] mas = new double[,]
            //{
            //    { 4, 8, 1, 12 },
            //    { 4, 11, 3, 7 },
            //    { 6, 9, 5, 10 },
            //    { 7, 14, 4, 5 },
            //    { 8, 16, 2, 20 }
            //};

            Kernel kernel = new Kernel(mas);
            Console.WriteLine();
            kernel.Print();
            Console.WriteLine();
            Kernel beforeChange;
            do {
                beforeChange = kernel;
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(0); j++)
                    {
                        if(i == j)
                        {
                            continue;
                        }
                        if (kernel.StrategyMatrix[i] <= kernel.StrategyMatrix[j])
                        {
                            kernel.RemoveStrategy(i);
                        }
                    }
                }
                kernel = Kernel.Transpose(kernel);
                kernel = new Kernel(Kernel.ToDouble(kernel));
                //Console.WriteLine();
                //kernel.Print();
                //Console.WriteLine();
                for (int i = 0; i < mas.GetLength(1); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        if(i == j)
                        {
                            continue;
                        }

                        if (kernel.StrategyMatrix[i] >= kernel.StrategyMatrix[j])
                        {
                            kernel.RemoveStrategy(i);
                        }
                    }
                }
                kernel = Kernel.Transpose(kernel);
            } while (kernel != beforeChange);

            Console.WriteLine();
            kernel.Print();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
