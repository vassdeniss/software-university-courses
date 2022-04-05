using System;

using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, 60, numberOfMedals) { }

        public override string AllowedGym => "BoxingGym";

        public override void Exercise()
        {
            if (Stamina + 15 > 100)
            {
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }

            Stamina += 15;
        }
    }
}
