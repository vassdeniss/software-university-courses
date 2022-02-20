using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;

        public Net()
        {
            fish = new List<Fish>();
        }

        public Net(string material, int capacity) : this()
        {
            Material = material;
            Capacity = capacity;
        }

        public IReadOnlyCollection<Fish> Fish => fish;
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => fish.Count;

        public string AddFish(Fish fish)
        {
            if (this.fish.Count == Capacity)
            {
                return "Fishing net is full.";
            }

            if (fish.FishType == null 
                || fish.FishType == " "
                || fish.Length <= 0 
                || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish fish = this.fish.FirstOrDefault(x => x.Weight == weight);
            if (fish == null) return false;
            this.fish.Remove(fish);
            return true;
        }

        public Fish GetFish(string fishType)
        {
            return fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return fish.OrderByDescending(x => x.Length).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {Material}:");
            foreach (Fish fish in fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
