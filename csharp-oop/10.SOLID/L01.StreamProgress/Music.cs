namespace L01.StreamProgress
{
    public class Music : IFile
    {
        private string artist;
        private string album;

        public Music(string artist, string album, int length, int bytesSent)
        {
            this.artist = artist;
            this.album = album;
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; }

        public int BytesSent { get; }
    }
}
