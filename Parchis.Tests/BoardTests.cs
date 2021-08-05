using Xunit;

namespace Parchis.Tests
{
   public class BoardTests
   {
      [Fact]
      public void ThereIsAWinner()
      {
         Board board = new Board(
            new Candidates(),
            new Token(Color.Red, Position.OnLadder(3)),
            new Token(Color.Blue, Position.Heaven)
         );

         Assert.True(board.AnyWinner());
      }

      [Fact]
      public void Winner()
      {
         Board board = new Board(
            new Candidates(),
            new Token(Color.Red, Position.OnLadder(3)),
            new Token(Color.Blue, Position.Heaven)
         );

         Assert.Equal(Color.Blue, board.Winner());
      }
   }
}