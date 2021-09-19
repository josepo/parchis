using System.Linq;
using Xunit;

namespace Parchis.Tests
{
   public class TokensTests
   {
      [Fact]
      public void TokensAt()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1"),
            Token.Red("R1"));

         Assert.Equal(2, tokens.At(Position.Home).Count());
      }

      [Fact]
      public void MovesToken()
      {
         Position final = Position.OnBoard(24);

         Tokens tokens = new Tokens(Token.Blue("B1"));
         tokens.Move("B1", final);

         Token token = tokens.At(final).Single();

         Assert.Equal("B1", token.Id);
      }
   }
}