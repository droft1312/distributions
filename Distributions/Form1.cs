using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Distributions.MyFunctions;

namespace Distributions
{
    public partial class Form1 : Form
    {
        Random random;

        public Form1 () {
            InitializeComponent ();

            random = new Random ();
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

            var sorted_rates = ReturnSortedList (GetUniqueRatesAndTheirCounters (GetSuccessRatesFromSequences (sequences)));
        }
    }
}
