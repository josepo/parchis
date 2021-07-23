using Xunit;

namespace Parchis.Tests
{
   public class TokenTests
   {
      [Fact]
      public void StartsAtHome()
      {
         Token token = new Token();

         Assert.True(token.AtHome());
      }

      [Fact]
      public void MoveOnBoard()
      {
         Position start = Position.OnBoard(3);
         Token token = new Token(start).Move(2);

         Assert.True(token.AtBoard());
         Assert.True(token.At(5));
      }
   }
}