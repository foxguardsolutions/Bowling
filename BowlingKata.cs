namespace BowlingKata
{
    public class BowlingKata
    {
        public static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                ShowUsage();
                return 1;
            }

            Game g = new Game(args[0]);
            System.Console.WriteLine(string.Format("{0} = {1}", args[0], g.GetScore()));
            return 0;
        }

        public static void ShowUsage()
        {
            System.Console.WriteLine(
                string.Format(
                    "Usage: {0} <bowlingGameString>", System.AppDomain.CurrentDomain.FriendlyName));
        }
    }
}
