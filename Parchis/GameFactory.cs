namespace Parchis
{
   public static class GameFactory
   {
      public static Game New()
      {
         Tokens tokens = new Tokens
         (
            Token.Blue("B1"),
            Token.Blue("B2"),
            Token.Blue("B3"),
            Token.Blue("B4"),

            Token.Red("R1"),
            Token.Red("R2"),
            Token.Red("R3"),
            Token.Red("R4"),

            Token.Yellow("Y1"),
            Token.Yellow("Y2"),
            Token.Yellow("Y3"),
            Token.Yellow("Y4"),

            Token.Green("G1"),
            Token.Green("G2"),
            Token.Green("G3"),
            Token.Green("G4")
         );

         Board board = new Board(tokens);
         Dice dice = new Dice();

         return new Game(board, new Players(board, dice));
      }
   }
}