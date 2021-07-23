using Xunit;

namespace Parchis.Tests
{
   public class PlayerTests
   {
      [Fact]
      public void Clone()
      {
         Player player = new Player(Color.Blue, new Board());
         Player clone = player.Clone();

         Assert.Equal(player.Color, clone.Color);
         Assert.NotEqual(player, clone);
      }
   }
}