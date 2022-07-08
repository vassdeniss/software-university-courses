namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        public int SongId { get; set; }

        public virtual Song Song { get; set; }

        public int PerformerId { get; set; }

        public virtual Performer Performer { get; set; }
    }
}
