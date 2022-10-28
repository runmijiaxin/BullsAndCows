using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            secret = this.secretGenerator.GenerateSecret();
            var guessDigits = guess.Split(" ");
            var secretDigits = secret.Split(" ");
            int countBull = 0;
            for (var index = 0; index < 4; index++)
            {
                if (guessDigits[index] == secretDigits[index])
                {
                    countBull++;
                }
            }

            return $"{countBull}A0B";
        }
    }
}