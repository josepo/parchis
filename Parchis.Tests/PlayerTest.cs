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
         Tokens tokens = new Tokens(
            Token.Blue("B1").ToBoard(7),
            Token.Blue("B2"));

         IDice dice = Substitute.For<IDice>();
         dice.Roll().Returns(3);

         Board board = new Board(tokens);
         Player player = PlayerBuilder.Blue().Dice(dice).Board(board);

         player.Move();

         Assert.True(tokens.Get("B1").Position.AtBoard(10));
         Assert.True(tokens.Get("B2").Position.AtHome());
      }
   }
}