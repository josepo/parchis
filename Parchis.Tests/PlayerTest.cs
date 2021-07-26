using System.Collections.Generic;
using Xunit;

namespace Parchis.Tests
{
   public class PlayerTests
   {
      [Fact]
      public void Clone()
      {
         Player player = new Player(
            Color.Blue,
            new List<Token> { new Token(Position.Home) },
            new Board());

         Player clone = player.Clone();

         Assert.Equal(player.Color, clone.Color);
         Assert.NotEqual(player, clone);
      }

      [Fact]
      public void FirstTokenIsMoved()
      {
         Token token = new Token(Position.OnBoard(7));

         Player player = new Player(
            Color.Blue,
            new List<Token> { token },
            new Board());

         player.Move(3);

         Assert.True(token.Position.AtBoard(10));
      }
   }
}