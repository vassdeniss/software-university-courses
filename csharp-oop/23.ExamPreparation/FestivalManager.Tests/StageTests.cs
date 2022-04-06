using System;

using NUnit.Framework;

using FestivalManager.Entities;

namespace FestivalManager.Tests
{
    [TestFixture]
	public class StageTests
    {
		private Stage stage;

		[SetUp]
		public void SetUp()
        {
			stage = new Stage();
        }

		[Test]
		public void Test_Add_Performer_Null_Should_Throw_Argument_Null_Exception()
		{
			Assert.Throws<ArgumentNullException>(
				() => stage.AddPerformer(null),
				"Null as value should throw exception.");
		}

		[Test]
		public void Test_Add_Performer_Invalid_Should_Throw_Argument_Exception()
		{
			Assert.Throws<ArgumentException>(
				() => stage.AddPerformer(
					new Performer("Denis", "Vasilev", 17)),
				"Performers under 18 should throw exception.");
		}

		[Test]
	    public void Test_Add_Performer_Should_Add_Correctly()
	    {
			stage.AddPerformer(new Performer("Denis", "Vasilev", 18));

			Assert.AreEqual(1, stage.Performers.Count, "Count does not match.");
		}

		[Test]
		public void Test_Add_Song_Null_Should_Throw_Argument_Null_Exception()
		{
			Assert.Throws<ArgumentNullException>(
				() => stage.AddSong(null),
				"Null as value should throw exception.");
		}

		[Test]
		public void Test_Add_Song_Invalid_Should_Throw_Argument_Exception()
		{
			Assert.Throws<ArgumentException>(
				() => stage.AddSong(
					new Song("Song", new TimeSpan(0, 0, 59))),
				"Songs under 1 minute should throw exception.");
		}

		[Test]
		public void Test_Add_Song_To_Performer_Null_Should_Throw_Argument_Null_Exception()
		{
			Assert.Throws<ArgumentNullException>(
				() => stage.AddSongToPerformer(null, "Dennis"),
				"Null song name as value should throw exception.");

			Assert.Throws<ArgumentNullException>(
				() => stage.AddSongToPerformer("Song", null),
				"Null performer name as value should throw exception.");
		}

		[Test]
		public void Test_Add_Song_To_Performer_Invalid_Should_Throw_Argument_Exception()
		{
			Assert.Throws<ArgumentException>(
				() => stage.AddSongToPerformer("Song", "IdontExist"),
				"Performers which are not found should throw exception.");

			stage.AddPerformer(new Performer("Denis", "Vasilev", 18));

			Assert.Throws<ArgumentException>(
				() => stage.AddSongToPerformer("IdontExist", "Denis Vasilev"),
				"Songs which are not found should throw exception.");
		}

		[Test]
		public void Test_Add_Song_To_Performer_Should_Add_Correctly()
		{
			Performer performer = new Performer("Denis", "Vasilev", 18);
			Song song = new Song("Song", new TimeSpan(0, 3, 2));

			stage.AddPerformer(performer);
			stage.AddSong(song);

			string expected = $"{song} will be performed by {performer}";
			string actual = stage.AddSongToPerformer("Song", "Denis Vasilev");

			Assert.AreEqual(1, performer.SongList.Count, "Count of performers songs does not match.");
			Assert.AreEqual(expected, actual, "Expected string result does not match.");
		}

		[Test]
		public void Test_Play_Should_Return_Correct_String()
		{
			Performer[] performers = new Performer[]
			{
				new Performer("Performer", "One", 18),
				new Performer("Performer", "Two", 19),
				new Performer("Performer", "Three", 20)
			};

			foreach (Performer performer in performers)
			{
				stage.AddPerformer(performer);
			}

			Song[] songs = new Song[]
			{
				new Song("One", new TimeSpan(0, 3, 2)),
				new Song("Two", new TimeSpan(0, 3, 2)),
				new Song("Three", new TimeSpan(0, 3, 2)),
				new Song("Four", new TimeSpan(0, 3, 2)),
				new Song("Five", new TimeSpan(0, 3, 2)),
				new Song("Six", new TimeSpan(0, 3, 2))
			};

			foreach (Song song in songs)
			{
				stage.AddSong(song);
			}

            for (int i = 0; i < performers.Length; i++)
            {
                for (int j = 0; j < songs.Length; j++)
                {
					stage.AddSongToPerformer(songs[j].Name, performers[i].FullName);
                }
            }

			string expected = $"3 performers played 18 songs";
			string actual = stage.Play();

			Assert.AreEqual(expected, actual, "Expected string was not recieved.");
		}
	}
}
