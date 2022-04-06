using System.Collections.Generic;

namespace FestivalManager.Entities
{
	public class Performer
	{
		public Performer(string firstName, string lastName, int age)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;

			SongList = new List<Song>();
		}

        private string FirstName { get; }

		private string LastName { get; }

		public string FullName => $"{FirstName} {LastName}";

		public int Age { get; }

        public List<Song> SongList { get; }

        public override string ToString()
		{
			return FullName;
		}
	}
}
