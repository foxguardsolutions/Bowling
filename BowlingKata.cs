namespace BowlingKata
{
    public class BowlingKata
    {
        public static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                Usage();
                return 1;
            }

            Game g = new Game(args[0], maxSize: 10);
            System.Console.WriteLine(string.Format("{0} = {1}", args[0], g.GetScore()));
            return 0;
        }

        public static void Usage()
        {
            System.Console.WriteLine(
                string.Format(
                    "Usage: {0} <bowlingGameString>", System.AppDomain.CurrentDomain.FriendlyName));
        }
    }
}
