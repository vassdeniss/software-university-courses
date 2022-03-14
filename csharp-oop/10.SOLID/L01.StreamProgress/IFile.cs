namespace L01.StreamProgress
{
    public interface IFile
    {
        int Length { get; }

        int BytesSent { get; }
    }
}
