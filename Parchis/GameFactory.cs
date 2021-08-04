using System.Linq;
using System.Collections.Generic;

namespace Parchis
{
   public static class GameFactory
   {
      public static Game For(params Color[] colors)
      {
         IEnumerable<Token> tokens = Enumerable.Empty<Token>();

         foreach (Color color in colors)
         {
            IEnumerable<Token> colorTokens = 
               Enumerable.Range(1, 4).Select(i => new Token(color));

            tokens = tokens.Concat(colorTokens);
         }

         Board board = new Board(new Candidates(), tokens.ToArray());

         Players players = new Players();
         
         foreach(Color color in colors)
            players.Add(
               new Player(color, board, new Dice()));

         return new Game(board, players);
      }
   }
}