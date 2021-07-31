using System.Collections.Generic;

namespace Parchis
{
   public static class GameFactory
   {
      public static Game For(params Color[] colors)
      {
         Players players = new Players();
         
         foreach(Color color in colors)
            players.Add(new Player(
               color,
               new List<Token> { new Token(Position.Home) }, 
               new Board(),
               new Dice()
            ));

         return new Game(players);
      }
   }
}