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
         Token token = new Token(Color.Blue, Position.OnBoard(7));

         IDice dice = Substitute.For<IDice>();
         dice.Roll().Returns(3);

         IBoard board = Substitute.For<IBoard>();
         board.Candidates(Color.Blue, 3).Returns(new List<Token> { token });
         board.NextPosition(token, 3).Returns(Position.OnBoard(10));

         Player player =
            PlayerBuilder.Blue().Dice(dice).Board(board);

         player.Move();

         Assert.True(token.Position.AtBoard(10));
      }
   }
}