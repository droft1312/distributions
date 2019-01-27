using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions
{
    static class MyFunctions {

        public static double CalculatePoisson (double lambda, double x) {
            double enumerator = Math.Pow (lambda, x) * Math.Pow (Math.E, -lambda);
            double denominator = MathNet.Numerics.SpecialFunctions.Factorial ((int)x);
            return enumerator / denominator;
        }

        public static int[] GetSuccessRatesFromSequences (Sequence[] sequences) {
            int[] rates = new int[sequences.Length];

            for (int i = 0; i < sequences.Length; i++) rates[i] = sequences[i].Success_Rate;

            return rates;
        }

        public static Dictionary<int, int> GetUniqueRatesAndTheirCounters (int[] rates) {
            return rates.GroupBy (x => x).ToDictionary (x => x.Key, x => x.Count ());
        }

        public static void CalculateProbabilityOfEachRateBasedOnSampleData (ref SortedList<double, double> arr, double nrSequences) {
            for (int i = 0; i < arr.Count; i++) {
                arr[arr.Keys.ElementAt (i)] /= nrSequences;
            }
        }

        public static SortedList<double, double> ReturnSortedList (Dictionary<int, int> dictionary) {
            SortedList<double, double> list = new SortedList<double, double> ();
            for (int i = 0; i < dictionary.Count; i++) {
                list.Add (dictionary.Keys.ElementAt (i), dictionary[dictionary.Keys.ElementAt (i)]);
            }
            return list;
        }
    }
}
