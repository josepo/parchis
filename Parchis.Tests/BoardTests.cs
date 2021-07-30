using Xunit;

namespace Parchis.Tests
{
   public class BoardTests
   {
      [Fact]
      public void NextPositionOnBoard()
      {
         Board board = new Board();

         Position start = Position.OnBoard(7);
         Position end = board.NextPosition(start, 2, Color.Yellow);

         Assert.True(end.AtBoard(9));
      }

      [Fact]
      public void NextPositionFromBoardToLadder()
      {
         Board board = new Board();

         Position start = Position.OnBoard(66);
         Position end = board.NextPosition(start, 4, Color.Yellow);

         Assert.True(end.AtLadder(2));
      }

      [Fact]
      public void NextPositionFromLadderToHeaven()
      {
         Board board = new Board();

         Position start = Position.OnLadder(3);
         Position end = board.NextPosition(start, 5, Color.Yellow);

         Assert.True(end.AtHeaven());
      }

      [Fact]
      public void NextPositionFromHomeToStart()
      {
         Board board = new Board();

         Position start = Position.Home;
         Position end = board.NextPosition(start, 5, Color.Yellow);

         Assert.True(end.AtBoard(4));
      }
   }
}