using Xunit;

namespace Parchis.Tests
{
   public class GameTests
   {
      [Fact]
      public void GameEnds()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1").ToHeaven(),
            Token.Red("R1"));

         Board board = new Board(tokens, new Candidate(tokens));
         Game game = new Game(board, new Players(board), new Dice());

         Assert.True(game.End());
      }

      [Fact]
      public void GameDoesNotEnd()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1").ToHeaven(),
            Token.Blue("B2"),
            Token.Red("R1"),
            Token.Red("R2"));

         Board board = new Board(tokens, new Candidate(tokens));
         Game game = new Game(board, new Players(board), new Dice());

         Assert.False(game.End());
      }

      [Fact]
      public void TurnChanges()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1"),
            Token.Red("R1"));

         Board board = new Board(tokens, new Candidate(tokens));
         Players players = new Players(board);

         Game game = new Game(board, players, new Dice());

         Player first = players.Current;

         game.Move();

         Assert.NotEqual(first.Color, players.Current.Color);
      }
   }
}