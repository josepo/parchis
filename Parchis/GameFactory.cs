using System.Linq;
using System.Collections.Generic;

namespace Parchis
{
   public static class GameFactory
   {
      public static Game For(params Color[] colors)
      {
         IEnumerable<Token> tokens =
            colors.Select(color => new Token(color));

         Board board = new Board(tokens.ToArray());

         Players players = new Players();
         
         foreach(Color color in colors)
            players.Add(
               new Player(color, board, new Dice()));

         return new Game(board, players);
      }
   }
}