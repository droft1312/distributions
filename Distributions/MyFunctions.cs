﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions
{
    static class MyFunctions {

        public static int[] GetSuccessRatesFromSequences (Sequence[] sequences) {
            int[] rates = new int[sequences.Length];

            for (int i = 0; i < sequences.Length; i++) rates[i] = sequences[i].Success_Rate;

            return rates;
        }

        public static Dictionary<int, int> GetUniqueRatesAndTheirCounters (int[] rates) {
            return rates.GroupBy (x => x).ToDictionary (x => x.Key, x => x.Count ());
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
