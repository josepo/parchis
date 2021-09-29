using Xunit;

namespace Parchis.Tests
{
   public class PlayersTests
   {
      [Fact]
      public void EndsTurn()
      {
         Tokens tokens = new Tokens(
            Token.Yellow("Y1"),
            Token.Red("R1"));

         Board board = 
            new Board(tokens, new Candidate(tokens));

         Players players = new Players(board, new Dice());
         Player first = players.Current;

         players.EndTurn();

         Assert.NotEqual(first.Color, players.Current.Color);
      }
   }
}
