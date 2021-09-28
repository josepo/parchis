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

         Dice dice = new Dice();

         Board board = 
            new Board(tokens, new Candidate(tokens));

         Players players = new Players(board, dice);
         Player current = new Player(Color.Green, board, dice);

         Assert.Equal(Color.Red, players.Next(current).Color);
      }

      [Fact]
      public void YellowIsNextFromRedWhenNoBlue()
      {
         Tokens tokens = new Tokens(
            Token.Yellow("Y1"),
            Token.Red("R1"));

         Dice dice = new Dice();

         Board board =
            new Board(tokens, new Candidate(tokens));

         Players players = new Players(board, dice);
         Player current = new Player(Color.Red, board, dice);

         Assert.Equal(Color.Yellow, players.Next(current).Color);         
      }
   }
}
