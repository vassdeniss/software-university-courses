using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly PilotRepository pilotRepo;    
        private readonly RaceRepository raceRepo;    
        private readonly FormulaOneCarRepository carRepo;

        public Controller()
        {
            pilotRepo = new PilotRepository();
            raceRepo = new RaceRepository();
            carRepo = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepo.FindByName(pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar car = carRepo.FindByName(carModel);

            if (car == null)
            {
                throw new NullReferenceException(
                    string.Format(
                        ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            carRepo.Remove(car);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepo.FindByName(raceName);

            if (race == null)   
            {
                throw new NullReferenceException(
                    string.Format(
                        ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = pilotRepo.FindByName(pilotFullName);

            if (pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.Pilots.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepo.FindByName(model) != null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            object[] args = { model, horsepower, engineDisplacement };
            Type reflectType = Type.GetType($"Formula1.Models.{type}");
            FormulaOneCar instance;
            try
            {
                instance = Activator.CreateInstance(reflectType, args) as FormulaOneCar;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            carRepo.Add(instance);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepo.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilotRepo.Add(new Pilot(fullName));

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepo.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            raceRepo.Add(new Race(raceName, numberOfLaps));

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IPilot pilot in pilotRepo.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IRace race in raceRepo.Models.Where(x => x.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepo.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(
                    string.Format(
                        ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> pilots = pilotRepo.Models.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            pilots[0].WinRace();

            race.TookPlace = true;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, pilots[0].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, pilots[1].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, pilots[2].FullName, raceName));

            return sb.ToString().Trim();
        }
    }
}
