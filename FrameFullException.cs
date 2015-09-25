namespace BowlingKata
{
    public class FrameFullException : System.InvalidOperationException
    {
        public FrameFullException(string message) : base(message)
        {
        }
    }
}
