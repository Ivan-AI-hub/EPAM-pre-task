using GreatestCommonDivisorLibrary;
using System;
using System.Collections.Generic;
using Xunit;

namespace GCDTests
{
    public class GCDTests
    {

        [Theory]
        [InlineData(1, 435, 217)]
        [InlineData(3, 423, 60)]
        [InlineData(62, 62, 124)]
        [InlineData(16, 32, 48)]
        [InlineData(3, 6, 9, 3)]
        [InlineData(5, 15, 225, 55)]
        [InlineData(25, 25, 225, 50, 75)]
        [InlineData(25, 25, 225, 50, 75, 250)]
        public void EuclidAlgorithmTest(int rezalt, params int[] array)
        {
            GCDCalculator gcd = new GCDCalculator();

            Assert.Equal(gcd.EuclidAlgorithm(array), rezalt);
        }

        [Theory]
        [InlineData(1, 435, 217)]
        [InlineData(3, 423, 60)]
        [InlineData(62, 62, 124)]
        [InlineData(16, 32, 48)]
        public void SteinAlgorithmTest(int rezalt, int a, int b)
        {
            GCDCalculator gcd = new GCDCalculator();
            double time;
            Assert.Equal(gcd.SteinAlgorithm(a, b, out time), rezalt);
        }

        [Theory]
        [InlineData(435, 217)]
        [InlineData(423, 60)]
        [InlineData(62, 124)]
        [InlineData(32, 48)]
        public void GetGistagramaDataTest(int a, int b)
        {
            GCDCalculator gcd = new GCDCalculator();

            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();

            for(int i = 0; i < 10; i++)
            {
                tuples.Add(Tuple.Create(a, b));
            }

            Assert.NotEmpty(gcd.GetGistagramaData(tuples));
        }
    }
}
