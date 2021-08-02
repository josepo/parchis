using Xunit;

namespace Parchis.Tests
{
   public class BoardTests
   {
      [Fact]
      public void NextPositionOnBoard()
      {
         Token token = new Token(Color.Yellow, Position.OnBoard(7));
         Board board = new Board(token);

         Position end = board.NextPosition(token, 2);

         Assert.True(end.AtBoard(9));
      }

      [Fact]
      public void NextPositionOnBoardPassingBoardEnd()
      {
         Token token = new Token(Color.Green, Position.OnBoard(66));
         Board board = new Board(token);

         Position end = board.NextPosition(token, 5);

         Assert.True(end.AtBoard(3));
      }

      [Fact]
      public void NextPositionFromBoardToLadder()
      {
         Token token = new Token(Color.Yellow, Position.OnBoard(66));
         Board board = new Board(token);

         Position end = board.NextPosition(token, 4);

         Assert.True(end.AtLadder(2));
      }

      [Fact]
      public void NextPositionFromLadderToHeaven()
      {
         Token token = new Token(Color.Yellow, Position.OnLadder(3));
         Board board = new Board(token);

         Position end = board.NextPosition(token, 5);

         Assert.True(end.AtHeaven());
      }

      [Fact]
      public void NextPositionFromHomeToStart()
      {
         Token token = new Token(Color.Yellow);
         Board board = new Board(token);

         Position end = board.NextPosition(token, 5);

         Assert.True(end.AtBoard(4));
      }

      [Fact]
      public void ThereIsAWinner()
      {
         Board board = new Board(
            new Token(Color.Red, Position.OnLadder(3)),
            new Token(Color.Blue, Position.Heaven)
         );

         Assert.True(board.AnyWinner());
      }

      [Fact]
      public void Winner()
      {
         Board board = new Board(
            new Token(Color.Red, Position.OnLadder(3)),
            new Token(Color.Blue, Position.Heaven)
         );

         Assert.Equal(Color.Blue, board.Winner());
      }      
   }
}