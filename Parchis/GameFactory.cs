using System.Collections.Generic;

namespace Parchis
{
   public static class GameFactory
   {
      public static Game For(params Color[] colors)
      {
         Board board = new Board();
         Players players = new Players();
         
         foreach(Color color in colors)
            players.Add(
               new Player(color, new List<Token> {
                  new Token(Position.Home)
               }, board));

         return new Game(players);
      }
   }
}