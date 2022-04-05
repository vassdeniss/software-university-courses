using System;
using System.Collections.Generic;
using System.Linq;

namespace Gyms
{
    public class Gym
    {
        private string name;
        private int size;
        private List<Athlete> athletes;

        public Gym(string name, int size)
        {
            Name = name;
            Capacity = size;
            athletes = new List<Athlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Invalid gym name.");
                }

                name = value;
            }
        }

        public int Capacity
        {
            get => size;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid gym capacity.");
                }

                size = value;
            }
        }

        public int Count => athletes.Count;

        public void AddAthlete(Athlete athlete)
        {
            if (athletes.Count == size)
            {
                throw new InvalidOperationException("The gym is full.");
            }

            athletes.Add(athlete);
        }

        public void RemoveAthlete(string fullName)
        {
            Athlete athleteToRemove = athletes.FirstOrDefault(x => x.FullName == fullName);

            if (athleteToRemove == null)
            {
                throw new InvalidOperationException($"The athlete {fullName} doesn't exist.");
            }

            athletes.Remove(athleteToRemove);
        }

        public Athlete InjureAthlete(string fullName)
        {
            Athlete requestedAthlete = athletes.FirstOrDefault(x => x.FullName == fullName);

            if (requestedAthlete == null)
            {
                throw new InvalidOperationException($"The athlete {fullName} doesn't exist.");
            }

            requestedAthlete.IsInjured = true;

            return requestedAthlete;
        }

        public string Report()
        {
            string athleteNames = string.Join(", ", athletes.Where(x => !x.IsInjured).Select(f => f.FullName));
            string report = $"Active athletes at {Name}: {athleteNames}";

            return report;
        }
    }
}
