using System;
using System.Collections.Generic;
using Xunit;

namespace Parchis.Tests
{
   public class PlayersTests
   {
      [Fact]
      public void NoRepeatedColorsAllowed()
      {
         Board board = new Board();

         Assert.Throws<Exception>(() =>
         {
            new Players
            {
               new Player(Color.Yellow, new List<Token> {
                  new Token(Position.Home, board.PathFor(Color.Yellow))
               }),

               new Player(Color.Green, new List<Token> {
                  new Token(Position.Home, board.PathFor(Color.Green))
               }),

               new Player(Color.Yellow, new List<Token> {
                  new Token(Position.Home, board.PathFor(Color.Yellow))
               }),
            };
         });
      }
   }
}
