namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;

    using Data;
    using Initializer;

    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumInfo = context.Albums
                .Where(x => x.ProducerId.Value == producerId)
                .Include(x => x.Producer)
                .Include(x => x.Songs)
                .ThenInclude(x => x.Writer)
                .ToArray()
                .Select(x => new
                {
                    AlbumName = x.Name,
                    AlbumReleaseDate = $"{x.ReleaseDate:MM/dd/yyyy}",
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(x => new
                    {
                        SongName = x.Name,
                        SongPrice = x.Price,
                        WriterName = x.Writer.Name
                    })
                    .OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.WriterName)
                    .ToArray(),
                    TotalPrice = x.Price
                })
                .OrderByDescending(x => x.TotalPrice)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var album in albumInfo)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.AlbumReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int counter = 0;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{++counter}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Include(x => x.SongPerformers)
                .ThenInclude(x => x.Performer)
                .Include(x => x.Writer)
                .Include(x => x.Album)
                .ThenInclude(x => x.Producer)
                .ToArray()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    x.Name,
                    PerformerName = x.SongPerformers
                        .Select(x => $"{x.Performer.FirstName} {x.Performer.LastName}")
                        .FirstOrDefault(),
                    WriterName = x.Writer.Name,
                    AlbumProducerName = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c")
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            int counter = 0;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{++counter}")
                  .AppendLine($"---SongName: {song.Name}")
                  .AppendLine($"---Writer: {song.WriterName}")
                  .AppendLine($"---Performer: {song.PerformerName}")
                  .AppendLine($"---AlbumProducer: {song.AlbumProducerName}")
                  .AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().Trim();
        }
    }
}
