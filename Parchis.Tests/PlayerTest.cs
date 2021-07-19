using Xunit;

namespace Parchis.Tests
{
   public class PlayerTests
   {
      [Fact]
      public void Clone()
      {
         Player player = new Player(Color.Blue);
         Player clone = player.Clone() as Player;

         Assert.Equal(player.Color, clone.Color);
         Assert.NotEqual(player, clone);
      }
   }
}