using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions
{
    static class MyFunctions {

        public static double CalculateStandardDeviation (int[] set) {
            return Math.Sqrt (CalculateVariance (set));
        }

        public static double CalculateVariance (int[] set) {
            var mean = CalculateMean (set);
            List<double> deviation = new List<double> ();
            for (int i = 0; i < set.Length; i++) {
                deviation.Add (mean - set[i]);
            }
            double sum = 0;
            for (int i = 0; i < deviation.Count; i++) {
                sum += Math.Pow (deviation[i], 2);
            }
            sum /= set.Length;
            return sum;
        }

        public static double CalculateMean(int[] set) {
            double sum = 0;
            for (int i = 0; i < set.Length; i++) {
                sum += set[i];
            }
            sum /= set.Length;
            return sum;
        }
        
        public static double CalculateMean (Sequence[] sequences) {
            double sum = 0;
            for (int i = 0; i < sequences.Length; i++) {
                sum += sequences[i].Success_Rate;
            }
            sum /= sequences.Length;
            return sum;
        }
        
        public static double CalculateVariance (Sequence[] sequences) {
            var mean = CalculateMean (sequences);
            List<double> deviation = new List<double> ();
            for (int i = 0; i < sequences.Length; i++) {
                deviation.Add (mean - sequences[i].Success_Rate);
            }
            double sum = 0;
            for (int i = 0; i < deviation.Count; i++) {
                sum += Math.Pow (deviation[i], 2);
            }
            sum /= sequences.Length;
            return sum;
        }
        
        public static double CalculateStandardDeviation (Sequence[] sequences) {
            return Math.Sqrt (CalculateVariance (sequences));
        }

        public static double CalculateProbabilityDensityFunction(double lambda, double x) {
            return lambda * Math.Pow (Math.E, (-lambda * x));
        }

        public static double CalculatePoisson(double lambda, double x) {
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

        public static double ExponentialRandomNumber(double lambda, double ranNum) {
            var randomNumber = Math.Log (1 - ranNum) / (-lambda);
            return randomNumber;
        }
    }
}
