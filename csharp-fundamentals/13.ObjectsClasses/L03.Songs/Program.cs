using System;
using System.Collections.Generic;
using System.Linq;

namespace L03.Songs
{
    class Song
    {
        public string ListType { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int songQty = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < songQty; i++)
            {
                string[] data = Console.ReadLine().Split('_');

                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song();
                song.ListType = type;
                song.Name = name;
                song.Time = time;
                
                songs.Add(song);
            }

            string wantedList = Console.ReadLine();
            if (wantedList == "all")
            {
                foreach (Song song in songs)
                    Console.WriteLine(song.Name);
            }
            else
            {
                List<Song> filteredList =
                    songs.Where(s => s.ListType == wantedList).ToList();
                foreach (Song song in filteredList)
                    Console.WriteLine(song.Name);
            }
        }
    }
}
