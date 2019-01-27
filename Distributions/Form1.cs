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

            // display
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
            List<double> xs = new List<double> ();
            for (int i = 0; i < sorted_rates_probability.Count; i++) {
                xs.Add (sorted_rates_probability.Keys.ElementAt (i));
            }

            FunctionSeries function = new FunctionSeries ();
            List<DataPoint> dataPoints = new List<DataPoint> ();

            var minmax = GetMinAndMaxOccurrences (sorted_rates_probability);

            for (int i = minmax.min; i <= minmax.max; i++) {
                var k = CalculatePoisson (lambda, i);
                dataPoints.Add (new DataPoint (i, k));
            }

            function.Points.AddRange (dataPoints);
            plotModel.Series.Add (function);
            categoryAxis.ItemsSource = xs;
            plotModel.Axes.Add (categoryAxis);
            plotView.Model = plotModel;

            #endregion
        }

        private (int min, int max) GetMinAndMaxOccurrences(SortedList<double, double> list) {
            var result = (min: -1, max: -1);

            var min = list.Keys.ElementAt (0);
            var max = list.Keys.ElementAt (list.Count - 1);
         
            result.min = (int)min;
            result.max = (int)max;

            return result;
        }
    }
}
