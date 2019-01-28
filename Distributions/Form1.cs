using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using static Distributions.MyFunctions;

namespace Distributions
{
    public partial class Form1 : Form
    {
        Random random;
        OxyPlot.PlotModel plotModel;

        public Form1 () {
            InitializeComponent ();

            random = new Random ();

            var model = new PlotModel { Title = "ColumnSeries" };
            // A ColumnSeries requires a CategoryAxis on the x-axis.
            model.Axes.Add (new CategoryAxis ());
            var series = new ColumnSeries ();
            model.Series.Add (series);
            series.Items.Add (new ColumnItem (100));
            plotView.Model = model;
        }

        private void goBernoulliButton_Click (object sender, EventArgs e) {
            int nrOfTrials, nrOfSequences, lambda;

            nrOfTrials = int.Parse (numberOfExperimentsTextBox.Text);
            nrOfSequences = int.Parse (numberOfSequencesTextBox.Text);
            lambda = int.Parse (lambdaTextBox.Text);

            // create sequences

            Sequence[] sequences = new Sequence[nrOfSequences];
            
            for (int i = 0; i < nrOfSequences; i++) {
                Sequence sequence = new Sequence ();

                for (int j = 0; j < nrOfTrials; j++) {
                    var random_number = random.Next (0, nrOfTrials);
                    if (random_number < lambda) sequence.Success_Rate++;    
                }

                sequences[i] = sequence;
            }

            // get unique rates and their corresponding number of appearences

            var sorted_rates_probability = ReturnSortedList (GetUniqueRatesAndTheirCounters (GetSuccessRatesFromSequences (sequences)));
            CalculateProbabilityOfEachRateBasedOnSampleData (ref sorted_rates_probability, nrOfSequences);

            // display the data in Oxyplot
            #region Displaying it in the graph

            plotModel = new PlotModel () { Title = "Chart" };
            ColumnSeries columnSeries = new ColumnSeries ();
            List<ColumnItem> columnItems = new List<ColumnItem> ();

            for (int i = 0; i < sorted_rates_probability.Count; i++) {
                var columnItem = new ColumnItem (sorted_rates_probability[sorted_rates_probability.Keys.ElementAt (i)]);
                columnItems.Add (columnItem);
            }
            columnSeries.Items.AddRange (columnItems);
            plotModel.Series.Add (columnSeries);

            var categoryAxis = new CategoryAxis {
                Position = AxisPosition.Bottom,
                Key = "CakeAxis"
            };
            
            var minmax = GetMinAndMaxOccurrences (sorted_rates_probability);

            List<double> xs = new List<double> ();
            for (int i = 0; i < sorted_rates_probability.Count; i++) {
                xs.Add (sorted_rates_probability.Keys.ElementAt (i));
            }

            FunctionSeries function = new FunctionSeries ();
            List<DataPoint> dataPoints = new List<DataPoint> ();


            for (int i = minmax.min; i <= minmax.max; i++) {
                var k = CalculatePoisson (lambda, i);
                dataPoints.Add (new DataPoint (i - minmax.min, k));
            }

            function.Points.AddRange (dataPoints);

           

            plotModel.Series.Add (function);
            categoryAxis.ItemsSource = xs;
            plotModel.Axes.Add (categoryAxis);
            plotView.Model = plotModel;

            #endregion


            // Display mean, variance, and standard deviation 
            
            meanLabel.Text = "Mean: " + CalculateMean (sequences);
            varianceLabel.Text = "Variance: " + CalculateVariance (sequences);
            standardDeviationLabel.Text = "Standart deviation: " + CalculateStandardDeviation (sequences);
        }

        private (int min, int max) GetMinAndMaxOccurrences(SortedList<double, double> list) {
            var result = (min: -1, max: -1);

            var min = list.Keys.ElementAt (0);
            var max = list.Keys.ElementAt (list.Count - 1);
         
            result.min = (int)min;
            result.max = (int)max;

            return result;
        }

        private void exponentialButton_Click (object sender, EventArgs e) {

            int lambda = int.Parse (lambdaTextBox.Text);
            int interval = int.Parse (intervalTextBox.Text);
            int runs = int.Parse (runsTextBox.Text);

            List<int> distances = new List<int> ();
            int distance = 0;

            for (int i = 0; i < runs; i++) {
                var random_number = random.Next (0, interval);
                if (random_number >= lambda) distance++;
                else {
                    distances.Add (distance);
                    distance = 0;
                }
            }

            var uniqueDistances = ReturnSortedList(GetUniqueRatesAndTheirCounters (distances.ToArray ()));
            CalculateProbabilityOfEachRateBasedOnSampleData (ref uniqueDistances, distances.Count);


            plotModel = new PlotModel () { Title = "Chart" };


            ColumnSeries columnSeries = new ColumnSeries ();
            List<ColumnItem> columnItems = new List<ColumnItem> ();

            for (int i = 0; i < uniqueDistances.Count; i++) {
                var columnItem = new ColumnItem (uniqueDistances[uniqueDistances.Keys.ElementAt (i)]);
                columnItems.Add (columnItem);
            }
            columnSeries.Items.AddRange (columnItems);
            plotModel.Series.Add (columnSeries);

            var categoryAxis = new CategoryAxis {
                Position = AxisPosition.Bottom,
                Key = "CakeAxis"
            };

            List<double> xs = new List<double> ();
            for (int i = 0; i < uniqueDistances.Count; i++) {
                xs.Add (uniqueDistances.Keys.ElementAt (i));
            }


            FunctionSeries densityFunction = new FunctionSeries ();
            List<DataPoint> points = new List<DataPoint> ();

            var minmax = GetMinAndMaxOccurrences (uniqueDistances);

            for (double i = minmax.min; i < minmax.max; i += 0.1) {
                var res = CalculateProbabilityDensityFunction ( (double)lambda / (double)interval, i);
                points.Add (new DataPoint (i, res));
            }

            densityFunction.Points.AddRange (points);
            plotModel.Series.Add (densityFunction);
            categoryAxis.ItemsSource = xs;
            plotModel.Axes.Add (categoryAxis);
            plotView.Model = plotModel;

            // Display mean, variance, and standard deviation 

            meanLabel.Text = "Mean: " + CalculateMean (distances.ToArray());
            varianceLabel.Text = "Variance: " + CalculateVariance (distances.ToArray ());
            standardDeviationLabel.Text = "Standart deviation: " + CalculateStandardDeviation (distances.ToArray ());
        }

        private void partBButton_Click (object sender, EventArgs e) {
            int lambda = int.Parse (lambdaTextBox.Text);
            int interval = int.Parse (intervalTextBox.Text);
            int fraction = int.Parse (realIntervalTextBox.Text);
            int runs = int.Parse (runsTextBox.Text);
            int m = int.Parse (mTextBox.Text);


            double counter = 0;

            for (int i = 0; i < (runs / fraction)*fraction; i++) {
                int success = 0;

                for (int j = 0; j < fraction; j++) {
                    var random_number = random.Next (0, interval);
                    if (random_number < lambda) success++;
                }

                if (success == m) counter++;
            }

            counter /= (runs / fraction) * fraction;

            var xx = CalculatePoisson (((double)lambda/(double)interval)*fraction, m);

            MessageBox.Show ("From experiments: " + counter.ToString() + " || " + "Poisson: " + xx.ToString());
        }
    }
}
