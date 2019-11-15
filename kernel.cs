using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba_2
{
    internal class Strategy
    {
        public List<double> strategy = new List<double>();
        public double this[int index]
        {
            get => strategy[index];
            set => strategy[index] = value;
        }
        public Strategy(double[] mas)
        {
            mas.ToList().ForEach(item => strategy.Add(item));
        }

        public static bool operator ==(Strategy a, Strategy b)
        {
            if (a.strategy.Count != b.strategy.Count)
            {
                return false;
            }

            for (int i = 0; i < a.strategy.Count; i++)
            {
                if (a.strategy[i] != b.strategy[i])
                {
                    return false;
                }
            }

            return true;
        }
        public static bool operator !=(Strategy a, Strategy b)
        {
            if (a.strategy.Count != b.strategy.Count)
            {
                return false;
            }

            for (int i = 0; i < a.strategy.Count; i++)
            {
                if (a.strategy[i] != b.strategy[i])
                {
                    return true;
                }
            }

            return false;
        }
        public static bool operator <=(Strategy a, Strategy b)
        {
            if (a.strategy.Count != b.strategy.Count)
            {
                return false;
            }

            if (a.strategy.All(x => x == double.MaxValue) || b.strategy.All(x => x == double.MaxValue))
            {
                return false;
            }

            for (int i = 0; i < a.strategy.Count; i++)
            {
                if (a.strategy[i] > b.strategy[i])
                {
                    return false;
                }
            }

            return true;
        }
        public static bool operator >=(Strategy a, Strategy b)
        {
            if (a.strategy.Count != b.strategy.Count)
            {
                return false;
            }

            if (a.strategy.All(x => x == double.MaxValue) || b.strategy.All(x => x == double.MaxValue))
            {
                return false;
            }

            for (int i = 0; i < a.strategy.Count; i++)
            {
                if (a.strategy[i] < b.strategy[i])
                {
                    return false;
                }
            }

            return true;
        }
        public static bool operator <(Strategy a, Strategy b)
        {
            if (a.strategy.Count != b.strategy.Count || 
                a.strategy.All(x => x == double.MaxValue) || 
                b.strategy.All(x => x == double.MaxValue))
            {
                return false;
            }

            for (int i = 0; i < a.strategy.Count; i++)
            {
                if (a.strategy[i] >= b.strategy[i])
                {
                    return false;
                }
            }

            return true;
        }
        public static bool operator >(Strategy a, Strategy b)
        {
            if (a.strategy.Count != b.strategy.Count ||
                a.strategy.All(x => x == double.MaxValue) || 
                b.strategy.All(x => x == double.MaxValue))
            {
                return false;
            }

            for (int i = 0; i < a.strategy.Count; i++)
            {
                if (a.strategy[i] <= b.strategy[i])
                {
                    return false;
                }
            }

            return true;
        }
        public void Print()
        {
            strategy.ForEach(value =>
            {
                Console.Write(value == double.MaxValue ? " 0 " : $" {value} ");
            });
            Console.WriteLine();
        }
    }

    internal class Kernel
    {
        public List<Strategy> StrategyMatrix = new List<Strategy>();
        public Kernel(double[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                double[] tmp = new double[mas.GetLength(1)];
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    tmp[j] = mas[i, j];
                }

                StrategyMatrix.Add(new Strategy(tmp));
            }
        }
        public void Print()
        {
            StrategyMatrix.ForEach(strategy => 
            {
                strategy.Print();
            });
        }

        public static double[,] ToDouble(Kernel kernel)
        {
            double[,] result = new double[kernel.StrategyMatrix.Count, Convert.ToInt32(kernel.StrategyMatrix.Max(x => x.strategy.Count))];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = kernel.StrategyMatrix[i][j];
                }
            }

            return result;
        }
        public static Kernel Transpose(Kernel k)
        {
            double[,] result = new double[k.StrategyMatrix.Max(x => x.strategy.Count), k.StrategyMatrix.Count];
            for (int i = 0; i < k.StrategyMatrix.Count(); i++)
            {
                for (int j = 0; j < k.StrategyMatrix[i].strategy.Count; j++)
                {
                    result[j, i] = k.StrategyMatrix[i].strategy[j];
                }
            }

            return new Kernel(result);
        }
        public void RemoveStrategy(int line)
        {
            for (int i = 0; i < StrategyMatrix[line].strategy.Count; i++)
            {
                StrategyMatrix[line].strategy[i] = double.MaxValue;
            }
        }
        public Strategy this[int index]
        {
            get => StrategyMatrix[index];
            set => StrategyMatrix[index] = value;
        }
        public static bool operator ==(Kernel a, Kernel b)
        {
            if (a.StrategyMatrix.Count != b.StrategyMatrix.Count)
            {
                return false;
            }

            for (int i = 0; i < a.StrategyMatrix.Count; i++)
            {
                for (int j = 0; j < a.StrategyMatrix[i].strategy.Count; j++)
                {
                    if (a[i].strategy[j] != b.StrategyMatrix[i].strategy[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public static bool operator !=(Kernel a, Kernel b)
        {
            if (a.StrategyMatrix.Count != b.StrategyMatrix.Count)
            {
                return false;
            }

            for (int i = 0; i < a.StrategyMatrix.Count; i++)
            {
                for (int j = 0; j < a.StrategyMatrix[i].strategy.Count; j++)
                {
                    if (a[i].strategy[j] != b[i].strategy[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
