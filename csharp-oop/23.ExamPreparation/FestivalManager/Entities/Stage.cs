using System;
using System.Collections.Generic;
using System.Linq;

namespace FestivalManager.Entities
{
    public class Stage
	{
        private const string CanNotBeNullMessage = "Can not be null!";

        private readonly List<Song> songs;
		private readonly List<Performer> performers;

        public Stage()
        {
            songs = new List<Song>();
            performers = new List<Performer>();
        }

        public IReadOnlyCollection<Performer> Performers => performers.AsReadOnly();

        public void AddPerformer(Performer performer)
        {
            ValidateNullValue(performer, nameof(performer), CanNotBeNullMessage);

            if (performer.Age < 18)
            {
                throw new ArgumentException("You can only add performers that are at least 18.");
            }

            performers.Add(performer);
        }

        public void AddSong(Song song)
        {
            ValidateNullValue(song, nameof(song), CanNotBeNullMessage);

            if (song.Duration.TotalMinutes < 1)
            {
                throw new ArgumentException("You can only add songs that are longer than 1 minute.");
            }

            songs.Add(song);
        }

        public string AddSongToPerformer(string songName, string performerName)
        {
            ValidateNullValue(songName, nameof(songName), CanNotBeNullMessage);
            ValidateNullValue(performerName, nameof(performerName), CanNotBeNullMessage);

            Performer perfomer = GetPerformer(performerName);
            Song song = GetSong(songName);

            perfomer.SongList.Add(song);

            return $"{song} will be performed by {perfomer}";
        }

        public string Play()
        {
            int songsCount = performers.Sum(p => p.SongList.Count());

            return $"{performers.Count} performers played {songsCount} songs";
        }

        private Performer GetPerformer(string performerName)
        {
            Performer performer = Performers.FirstOrDefault(p => p.FullName == performerName);

            if (performer == null)
            {
                throw new ArgumentException("There is no performer with this name.");
            }

            return performer;
        }

        private Song GetSong(string songName)
        {
            Song song = songs.FirstOrDefault(p => p.Name == songName);

            if (song == null)
            {
                throw new ArgumentException("There is no song with this name.");
            }

            return song;
        }

        private void ValidateNullValue(object variable, string variableName, string exceptionMessage)
        {
            if (variable == null)
            {
                throw new ArgumentNullException(variableName, exceptionMessage);
            }
        }
    }
}
