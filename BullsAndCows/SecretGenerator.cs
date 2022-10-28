using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        private Random random;

        public SecretGenerator()
        {
        }

        public SecretGenerator(Random random)
        {
            this.random = random;
        }

        public virtual string GenerateSecret()
        {
            var secertList = new List<int>();
            for (var secertListLength = 0; secertListLength < 4;)
            {
                var next = random.Next(10);
                if (!secertList.Contains(next))
                {
                    secertList.Add(next);
                    secertListLength++;
                }
            }

            return string.Join(" ", secertList);
        }
    }
}