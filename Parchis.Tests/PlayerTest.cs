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
         Token token = Token.Blue.ToBoard(7);

         IDice dice = Substitute.For<IDice>();
         dice.Roll().Returns(3);

         Board board =
            new Board(new Candidates(), new List<Token> { token, Token.Blue });

         Player player =
            PlayerBuilder.Blue().Dice(dice).Board(board);

         player.Move();

         Assert.True(board.Tokens[0].Position.AtBoard(10));
      }
   }
}