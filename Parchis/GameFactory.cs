using System.Collections.Generic;

namespace Parchis
{
   public static class GameFactory
   {
      public static Game New()
      {
         List<Token> tokens = new List<Token> {};

         tokens.AddRange(BlueTokens());
         tokens.AddRange(RedTokens());
         tokens.AddRange(YellowTokens());
         tokens.AddRange(GreenTokens());                                    

         Board board = new Board(new Candidates(), tokens);
         Dice dice = new Dice();

         Players players = new Players();
         
         players.Add(new Player(Color.Blue, board, dice));
         players.Add(new Player(Color.Green, board, dice));
         players.Add(new Player(Color.Yellow, board, dice));
         players.Add(new Player(Color.Red, board, dice));

         return new Game(board, players);
      }

      private static List<Token> BlueTokens() =>
         new List<Token> { Token.Blue, Token.Blue, Token.Blue, Token.Blue };

      private static List<Token> RedTokens() =>
         new List<Token> { Token.Red, Token.Red, Token.Red, Token.Red };

      private static List<Token> YellowTokens() =>
         new List<Token> { Token.Yellow, Token.Yellow, Token.Yellow, Token.Yellow };

      private static List<Token> GreenTokens() =>
         new List<Token> { Token.Green, Token.Green, Token.Green, Token.Green };                           
   }
}