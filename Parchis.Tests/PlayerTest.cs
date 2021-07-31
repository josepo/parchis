using NSubstitute;
using Xunit;

namespace Parchis.Tests
{
   public class PlayerTests
   {
      [Fact]
      public void Clone()
      {
         Player player = PlayerBuilder.Blue();
         Player clone = player.Clone();

         Assert.Equal(player.Color, clone.Color);
         Assert.NotEqual(player, clone);
      }

      [Fact]
      public void FirstTokenIsMoved()
      {
         Token token = new Token(Position.OnBoard(7));
         
         IDice dice = Substitute.For<IDice>();
         dice.Roll().Returns(3);

         Player player =
            PlayerBuilder.Blue().Token(token).Dice(dice);

         player.Move();

         Assert.True(token.Position.AtBoard(10));
      }
   }
}