using System.Collections.Generic;

using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;

namespace Gym.Models.Gyms.Contracts
{
    public interface IGym
    {
        string Name { get; }

        int Capacity { get; }

        double EquipmentWeight { get; }

        ICollection<IEquipment> Equipment { get; }

        ICollection<IAthlete> Athletes { get; }

        void AddAthlete(IAthlete athlete);

        bool RemoveAthlete(IAthlete athlete);

        void AddEquipment(IEquipment equipment);

        void Exercise();

        string GymInfo();
    }
}
