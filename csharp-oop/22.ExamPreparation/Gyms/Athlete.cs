namespace Gyms
{
    public class Athlete
    {
        public Athlete(string fullName)
        {
            FullName = fullName;
            IsInjured = false;
        }

        public string FullName { get; set; }

        public bool IsInjured { get; set; }
    }
}
