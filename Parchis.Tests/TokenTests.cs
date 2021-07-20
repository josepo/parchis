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
   }
}