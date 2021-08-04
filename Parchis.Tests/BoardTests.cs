using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Parchis.Tests
{
   public class BoardTests
   {
      [Fact]
      public void CandidateOnBoard()
      {
         Board board = new Board(
            new Candidates(),
            new Token(Color.Yellow, Position.OnBoard(7)));

         Move candidate = board.GetCandidates(Color.Yellow, 2).Single();

         Assert.Equal(Color.Yellow, candidate.Token.Color);
         Assert.True(candidate.Destination.AtBoard(9));
      }

      [Fact]
      public void CandidateOnBoardPassingBoardEnd()
      {
         Board board = new Board(
            new Candidates(),
            new Token(Color.Green, Position.OnBoard(66)));

         Move candidate = board.GetCandidates(Color.Green, 5).Single();

         Assert.Equal(Color.Green, candidate.Token.Color);
         Assert.True(candidate.Destination.AtBoard(3));
      }

      [Fact]
      public void CandidateFromBoardToLadder()
      {
         Board board = new Board(
            new Candidates(),
            new Token(Color.Yellow, Position.OnBoard(66)));

         Move candidate = board.GetCandidates(Color.Yellow, 4).Single();

         Assert.Equal(Color.Yellow, candidate.Token.Color);
         Assert.True(candidate.Destination.AtLadder(2));
      }

      [Fact]
      public void CandidateFromLadderToHeaven()
      {
         Board board = new Board(
            new Candidates(),
            new Token(Color.Yellow, Position.OnLadder(3)));

         Move candidate = board.GetCandidates(Color.Yellow, 5).Single();

         Assert.Equal(Color.Yellow, candidate.Token.Color);
         Assert.True(candidate.Destination.AtHeaven());
      }

      [Fact]
      public void OneCandidateOnlyWhenTokenAtHomeAndDiceRollsFive()
      {
         Board board = new Board(
            new Candidates(),
            new Token(Color.Red, Position.OnBoard(25)),
            new Token(Color.Blue, Position.OnBoard(12)),
            new Token(Color.Blue)
         );

         IEnumerable<Move> moves = board.GetCandidates(Color.Blue, 5);
         Move move = moves.Single();

         Assert.Equal(Color.Blue, move.Token.Color);
         Assert.True(move.Destination.AtBoard(21));
      }

      [Fact]
      public void TokenAtHeavenIsNeverACandidate()
      {
         Board board = new Board(
            new Candidates(),
            new Token(Color.Blue, Position.OnBoard(12)),
            new Token(Color.Blue, Position.Heaven)
         );

         IEnumerable<Move> moves = board.GetCandidates(Color.Blue, 5);
         Move move = moves.Single();

         Assert.True(move.Destination.AtBoard(17));
      }

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