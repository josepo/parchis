using Xunit;

namespace Parchis.Tests
{
   public class PlayerTests
   {
      [Fact]
      public void Clone()
      {
         Player player = PlayerBuilder.Blue().Token(Position.Home);

         Player clone = player.Clone();

         Assert.Equal(player.Color, clone.Color);
         Assert.NotEqual(player, clone);
      }

      [Fact]
      public void FirstTokenIsMoved()
      {
         Token token = new Token(Position.OnBoard(7));
         Player player = PlayerBuilder.Blue().Token(token);

         player.Move(3);

         Assert.True(token.Position.AtBoard(10));
      }
   }
}