using System;

namespace Distributions
{
    class Sequence
    {
        private readonly int number_of_successes;

        public Sequence (int nrOfTrials, int lambda) {
            number_of_successes = RunTrials (nrOfTrials, lambda);
        }

        private int RunTrials(int nrOfTrials, int lambda) {
            int success_rate = 0;
            Random random = new Random ();

            for (int i = 0; i < nrOfTrials; i++) {
                if (RunBernoulliTrial(lambda, random)) {
                    success_rate++;
                }
            }


            return success_rate;
        }

        private bool RunBernoulliTrial (int lambda, Random random) {
            bool success = false;

            var randomNumber = random.Next (0, lambda);
            if (randomNumber < lambda) success = true;

            return success;
        }

        public int GetNumberOfSuccesses() {
            return number_of_successes;
        }
    }
}
