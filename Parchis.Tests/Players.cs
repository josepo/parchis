using System;
using Xunit;

namespace Parchis.Tests
{
   public class PlayersTests
   {
      [Fact]
      public void NoRepeatedColorsAllowed()
      {
         Assert.Throws<Exception>(() =>
         {
            new Players
            {
               new Player(Color.Yellow),
               new Player(Color.Green),
               new Player(Color.Yellow)
            };
         });
      }
   }
}
