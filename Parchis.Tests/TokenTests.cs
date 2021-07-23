using Xunit;

namespace Parchis.Tests
{
   public class TokenTests
   {
      [Fact]
      public void MoveOnBoard()
      {
         Position start = Position.OnBoard(3);
         Path path = new Path(1, 10, 5);

         Token token = new Token(start, path);
         token.Move(2);

         Assert.True(token.AtBoard());
         Assert.True(token.At(5));
      }

      [Fact]
      public void MoveFromBoardToLadder()
      {
         Position start = Position.OnBoard(8);
         Path path = new Path(1, 10, 5);

         Token token = new Token(start, path);
         token.Move(4);

         Assert.True(token.AtLadder());
         Assert.True(token.At(2));
      }

      [Fact]
      public void MoveFromBoardToHeaven()
      {
         Position start = Position.OnBoard(8);
         Path path = new Path(1, 10, 3);

         Token token = new Token(start, path);
         token.Move(6);

         Assert.True(token.AtHeaven());
      }

      [Fact]
      public void MoveFromLadderToHeaven()
      {
         Position start = Position.OnLadder(3);
         Path path = new Path(1, 10, 3);

         Token token = new Token(start, path);
         token.Move(1);

         Assert.True(token.AtHeaven());
      }

      [Fact]
      public void MoveFromHomeToStart()
      {
         Path path = new Path(1, 10, 3);

         Token token = new Token(Position.Home, path);
         token.Move(5);

         Assert.True(token.AtBoard());
         Assert.True(token.At(1));
      }
   }
}