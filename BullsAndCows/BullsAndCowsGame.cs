using System;
using System.Linq;
using System.Net.Sockets;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = this.secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var countBull = CountBull(guess);
            var countCow = CountCow(guess, countBull);

            return $"{countBull}A{countCow}B";
        }

        private int CountCow(string guess, int countBull)
        {
            var guessDigits = guess.Split(" ");
            var secretDigits = secret.Split(" ");
            return guessDigits.Count(digit => secretDigits.Contains(digit)) - countBull;
        }

        private int CountBull(string guess)
        {
            var guessDigits = guess.Split(" ");
            var secretDigits = secret.Split(" ");
            return guessDigits.Where((t, index) => t == secretDigits[index]).Count();
        }
    }
}