using System;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int DiffBetweenDates(string firstDate, string secondDate)
        {
            DateTime firstParsed = DateTime.Parse(firstDate);
            DateTime secondParsed = DateTime.Parse(secondDate);

            return Math.Abs((firstParsed - secondParsed).Days);
        }
    }
}
