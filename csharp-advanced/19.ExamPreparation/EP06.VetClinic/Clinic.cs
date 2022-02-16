namespace VetClinic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Clinic
    {
        public Clinic(int capacity)
        {
            Data = new List<Pet>();
            Capacity = capacity;
        }

        public List<Pet> Data { get; private set; }
        public int Capacity { get; private set; }
        public int Count => Data.Count;

        public void Add(Pet pet)
        {
            if (Data.Count == Capacity) return;

            Data.Add(pet);
        }

        public bool Remove(string name)
        {
            Pet pet = Data.FirstOrDefault(x => x.Name == name);
            if (pet == null) return false;

            Data.Remove(pet);
            return true;
        }

        public Pet GetPet(string name, string owner)
        {
            return Data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return Data.OrderByDescending(x => x.Age).ToList()[0];
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            Data.ForEach(x => sb.AppendLine($"Pet {x.Name} with owner: {x.Owner}"));

            return sb.ToString().TrimEnd();
        }
    }
}
