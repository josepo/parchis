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
                  new Token(Position.Home)
               }, board),

               new Player(Color.Green, new List<Token> {
                  new Token(Position.Home)
               }, board),

               new Player(Color.Yellow, new List<Token> {
                  new Token(Position.Home)
               }, board),
            };
         });
      }
   }
}
