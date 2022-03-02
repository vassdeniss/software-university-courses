using System;
using System.Collections.Generic;
using System.Text;

namespace E05.FootballTeamGenerator
{
    public enum ValidationType
    {
        NAME,
        RANGE,
        PLAYER
    }

    public static class Validator<T>
    {
        public static void ValidateData(ValidationType type, T value, string statName = null,
            string teamName = null, string playerName = null)
        {
            if (type == ValidationType.NAME)
            {
                string compare = (string)Convert.ChangeType(value, typeof(string));
                if (string.IsNullOrWhiteSpace(compare))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
            }

            if (type == ValidationType.RANGE)
            {
                ValidateInner(statName);

                int compare = (int)Convert.ChangeType(value, typeof(int));
                if (compare < 0 || compare > 100)
                {
                    throw new ArgumentException($"{statName} should be between 0 and 100.");
                }
            }

            if (type == ValidationType.PLAYER)
            {
                ValidateInner(teamName);
                ValidateInner(playerName);

                if (value == null)
                {
                    throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
                }
            }
        }

        private static void ValidateInner(string value)
        {
            if (value == null)
            {
                throw new ArgumentException("Field cannot be null!");
            }
        }
    }
}
