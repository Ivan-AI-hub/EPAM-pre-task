using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GreatestCommonDivisorLibrary
{
    public class GCDCalculator
    {
        /// <summary>
        /// Calculates the Greatest Common Divisor
        /// by Euclid's Algorithm
        /// </summary>
        /// <param name="array">The numbers between
        /// which you need to calculate the GCD</param>
        /// <returns>Greatest Common Divisor</returns>
        public int EuclidAlgorithm(params int[] array)
        {
            if (array.Length == 1)
                return array[0];

            int rezaltLength = (int)Math.Ceiling(array.Length / 2f);
            int[] rezalt = new int[rezaltLength];

            int n = 0;
            for (int i = 0; i < rezaltLength; i++)
            {
                for (int j = 0; j < array.Length; j += 2)
                {
                    if (j + 1 < array.Length)
                    {
                        rezalt[n] = EuclidAlgorithm(array[j], array[j + 1]);
                    }
                    else
                    {
                        rezalt[n] = array[j];
                    }
                    n++;
                }
                n = 0;
                int[] box = rezalt.Clone() as int[];
                rezalt = array.Clone() as int[];
                array = box.Clone() as int[];
            }

            return array[0];
        }

        /// <summary>
        ///  Calculates the Greatest Common Divisor
        ///  by Euclid's Algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="time">Variable for transferring
        /// the running time of the algorithm</param>
        /// <returns>Greatest Common Divisor</returns>
        public int EuclidAlgorithm(int a, int b, out double time)
        {
            if (a <= 0 || b <= 0)
                throw new Exception("The value <= 0 was passed to the function");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            EuclidAlgorithm(a, b);
            stopwatch.Stop();
            time = stopwatch.Elapsed.TotalMilliseconds;
            return a;
        }

        /// <summary>
        /// Calculates the Greatest Common Divisor
        /// by Stein's Algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest Common Divisor</returns>
        public int SteinAlgorithm(int a, int b)
        {
            if (a == 0)
                return b;

            else if (b == 0 || a == b)
                return a;

            else if (a == 1 || b == 1)
                return 1;

            else if (a % 2 == 0 && b % 2 == 0)
                return 2 * SteinAlgorithm(a / 2, b / 2);

            else if (a % 2 != 0 && b % 2 == 0)
                return SteinAlgorithm(a, b / 2);

            else if (a % 2 == 0 && b % 2 != 0)
                return SteinAlgorithm(a / 2, b);

            else if (a > b)
                return SteinAlgorithm((a - b) / 2, b);

            else
                return SteinAlgorithm(a, (b - a) / 2);
        }

        /// <summary>
        /// Calculates the Greatest Common Divisor
        /// by Stein's Algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="time">Variable for transferring
        /// the running time of the algorithm</param>
        /// <returns>Greatest Common Divisor</returns>
        public int SteinAlgorithm(int a, int b, out double time)
        {
            if (a <= 0 || b <= 0)
                throw new Exception("The value <= 0 was passed to the function");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int rezalt = SteinAlgorithm(a, b);
            stopwatch.Stop();
            time = stopwatch.Elapsed.TotalMilliseconds;
            return rezalt;
        }

        /// <summary>
        /// Returns data for plotting a counting time histogram
        /// EuclidAlgorithm and SteinAlgorithm
        /// </summary>
        /// <param name="list">List of data for histogram</param>
        public List<Tuple<double, double>> GetGistagramaData(List<Tuple<int,int>> list)
        {
            List<Tuple<double, double>> rezaltList = new List<Tuple<double, double>>();
            for(int i = 0; i < list.Count; i++)
            {
                rezaltList.Add(GetTimeAlgotithm(list[i].Item1, list[i].Item2));
            }
            return rezaltList;
        }

        /// <summary>
        /// Returns the counting time Euclid Algorithm and Stein Algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        private Tuple<double,double> GetTimeAlgotithm(int a, int b)
        {
            double timeEuclid;
            EuclidAlgorithm(a, b, out timeEuclid);
            double timeStein;
            SteinAlgorithm(a, b, out timeStein);

            return Tuple.Create(timeEuclid,timeStein);
        }

        /// <summary>
        ///  Calculates the Greatest Common Divisor
        ///  by Euclid's Algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest Common Divisor</returns>
        private int EuclidAlgorithm(int a, int b)
        {
            if (a <= 0 || b <= 0)
                throw new Exception("The value <= 0 was passed to the function");
            while (b != 0)
            {
                a = a % b;
                int box = b;
                b = a;
                a = box;
            }
            return a;
        }
    }
}
