using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IEquipment> repo;
        private readonly ICollection<IGym> gyms;

        public Controller()
        {
            repo = new EquipmentRepository();
            gyms = new List<IGym>();
        }       

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gyms.First(x => x.Name == gymName);

            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            Type type = Type.GetType($"Gym.Models.Athletes.{athleteType}");
            object[] args = new object[]
            {
                athleteName,
                motivation,
                numberOfMedals
            };

            Athlete instance = null;
            try
            {
                instance = Activator.CreateInstance(type, args) as Athlete;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            if (instance.AllowedGym != gym.GetType().Name)
            {
                return OutputMessages.InappropriateGym;
            }

            gym.AddAthlete(instance);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            Type type = Type.GetType($"Gym.Models.Equipment.{equipmentType}");
            IEquipment instance = Activator.CreateInstance(type) as IEquipment;
            repo.Add(instance);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            Type type = Type.GetType($"Gym.Models.Gyms.{gymType}");

            IGym instance;
            try
            {
                instance = Activator.CreateInstance(type, new object[] { gymName }) as IGym;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            gyms.Add(instance);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.First(x => x.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = repo.FindByType(equipmentType);

            if (equipment == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));

            gyms.First(x => x.Name == gymName).AddEquipment(equipment);
            repo.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IGym gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            ICollection<IAthlete> athletes = gyms.First(x => x.Name == gymName).Athletes;
            foreach (IAthlete athlete in athletes)
            {
                athlete.Exercise();
            }

            return string.Format(OutputMessages.AthleteExercise, athletes.Count);
        }
    }
}
