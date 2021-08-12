using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Parchis.Tests
{
   public class TokenTests
   {
      [Fact]
      public void TokenCannotGoToNullPosition()
      {
         Token token = Token.Blue.ToBoard(25);

         bool go = token.CanGoTo(null, Enumerable.Empty<Token>());

         Assert.False(go);
      }

      [Fact]
      public void TokenCanAlwaysGoToHeaven()
      {
         Token token = Token.Blue.ToBoard(25);

         bool go = token.CanGoTo(Position.Heaven, Enumerable.Empty<Token>());

         Assert.True(go);         
      }

      [Fact]
      public void TokenCannotGoToPositionTakenByTokenWithSameColor()
      {
         Token token = Token.Blue.ToBoard(25);

         bool go = token.CanGoTo(
            Position.OnBoard(27), 
            new List<Token> { Token.Blue.ToBoard(27) }
         );

         Assert.False(go);
      }

      [Fact]
      public void TokenCanGoToPositionTakenByTokenWithOtherColor()
      {
         Token token = Token.Blue.ToBoard(25);

         bool go = token.CanGoTo(
            Position.OnBoard(27), 
            new List<Token> { Token.Red.ToBoard(27) }
         );

         Assert.True(go);         
      }      
   }
}