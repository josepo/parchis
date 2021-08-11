using System.Collections.Generic;
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
         List<Token> tokens =
            new List<Token> { Token.Blue.ToBoard(7), Token.Blue };

         IDice dice = Substitute.For<IDice>();
         dice.Roll().Returns(3);

         Board board = new Board (new Candidates(), tokens);
         Player player = PlayerBuilder.Blue().Dice(dice).Board(board);

         player.Move();

         Assert.True(board.Tokens[0].Position.AtBoard(10));
      }
   }
}