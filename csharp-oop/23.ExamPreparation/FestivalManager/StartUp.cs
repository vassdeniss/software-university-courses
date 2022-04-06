using System;

using FestivalManager.Entities;

namespace FestivalManager
{
    public static class StartUp
	{
		public static void Main()
		{
			Song song1 = new Song("SongOne", new TimeSpan(0, 3, 30));
			Song song2 = new Song("SongTwo", new TimeSpan(0, 2, 30));

			Performer performer = new Performer("Name", "FamilyName", 19);
			Stage stage = new Stage();

			stage.AddSong(song1);
			stage.AddSong(song2);
			stage.AddPerformer(performer);

            Console.WriteLine(stage.AddSongToPerformer("SongOne", "Name FamilyName"));

            Console.WriteLine(stage.Play());
		}
	}
}
