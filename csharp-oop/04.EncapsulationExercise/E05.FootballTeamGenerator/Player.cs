namespace E05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, 
                      int sprint, int dribble,
                      int passing, int shooting)
        {
            Name = name;

            Validator<int>.ValidateData(ValidationType.RANGE, endurance, "Endurance");
            Validator<int>.ValidateData(ValidationType.RANGE, sprint, "Sprint");
            Validator<int>.ValidateData(ValidationType.RANGE, dribble, "Dribble");
            Validator<int>.ValidateData(ValidationType.RANGE, passing, "Passing");
            Validator<int>.ValidateData(ValidationType.RANGE, shooting, "Shooting");

            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
        }

        public string Name
        {
            get => name;
            private set
            {
                Validator<string>.ValidateData(ValidationType.NAME, value);
                name = value;
            }
        }

        public double Stats => (endurance + sprint + dribble + passing + shooting) / 5.0;
    }
}
