using System;

namespace laba_2 {
    public class Program {
        public static void Main(string[] args) {
            Console.Write("Введите Размерность матрицы\nx = ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y = ");
            int y = Convert.ToInt32(Console.ReadLine());

            double[,] mas = new double[x, y];
            Console.WriteLine("Введите матрицу через пробелы");
            for (int i = 0; i < x; i++) {
                var tmp = Console.ReadLine().Replace(".", ",").Replace("  ", " ").Split(' ');
                for (int j = 0; j < tmp.Length && j < y; j++)
                    double.TryParse(tmp[j], out mas[i, j]);
            }
            Kernel beforeChange, kernel = new Kernel(mas);
            kernel.Print();
            do {
                beforeChange = kernel;
                for (int i = 0; i < mas.GetLength(0); i++) {
                    for (int j = 0; j < mas.GetLength(0); j++) {
                        if(i == j) {
                            continue;
                        }
                        if (kernel.StrategyMatrix[i] <= kernel.StrategyMatrix[j]) {
                            kernel.RemoveStrategy(i);
                        }
                    }
                }
                kernel = Kernel.Transpose(kernel);
                kernel = new Kernel(Kernel.ToDouble(kernel));
                for (int i = 0; i < mas.GetLength(1); i++) {
                    for (int j = 0; j < mas.GetLength(1); j++) {
                        if(i == j) {
                            continue;
                        }

                        if (kernel.StrategyMatrix[i] >= kernel.StrategyMatrix[j]) {
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
