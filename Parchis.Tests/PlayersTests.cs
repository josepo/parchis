using Xunit;

namespace Parchis.Tests
{
   public class PlayersTests
   {
      [Fact]
      public void RedIsNextFromGreen()
      {
         Tokens tokens = new Tokens(
            Token.Yellow("Y1"),
            Token.Green("G1"),
            Token.Red("R1"));

         Players players =
            new Players(new Board(tokens), new Dice());

         Player next = players.Next(Color.Green);

         Assert.Equal(Color.Red, next.Color);
      }

      [Fact]
      public void YellowIsNextFromRedWhenNoBlue()
      {
         Tokens tokens = new Tokens(
            Token.Yellow("Y1"),
            Token.Red("R1"));

         Players players =
            new Players(new Board(tokens), new Dice());

         Player next = players.Next(Color.Red);

         Assert.Equal(Color.Yellow, next.Color);         
      }
   }
}
