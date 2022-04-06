using System;

namespace FestivalManager.Entities
{
	public class Song
    {
		public Song(string name, TimeSpan duration)
		{
			Name = name;
			Duration = duration;
		}

		public string Name { get; }

	    public TimeSpan Duration { get; }

	    public override string ToString()
	    {
		    return $"{Name} ({Duration:mm\\:ss})";
	    }
    }
}
