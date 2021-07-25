using System.Collections.Generic;
using Xunit;

namespace Parchis.Tests
{
   public class PlayerTests
   {
      [Fact]
      public void Clone()
      {
         Player player = new Player(Color.Blue, new List<Token>
         {
            new Token(Position.Home, new Board().PathFor(Color.Blue))
         });

         Player clone = player.Clone();

         Assert.Equal(player.Color, clone.Color);
         Assert.NotEqual(player, clone);
      }
   }
}