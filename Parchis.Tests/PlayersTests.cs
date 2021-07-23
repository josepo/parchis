using System;
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
               new Player(Color.Yellow, board),
               new Player(Color.Green, board),
               new Player(Color.Yellow, board)
            };
         });
      }
   }
}
