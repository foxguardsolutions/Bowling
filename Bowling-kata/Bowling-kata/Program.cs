namespace Bowling {
    class Program {
        public static void Main(string[] args) {
            foreach (string rollSequence in args) {
                Game bowlingGame = new Game();
                bowlingGame.Start(rollSequence);
            }
        }
    }
}
