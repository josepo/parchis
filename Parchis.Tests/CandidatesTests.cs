using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace Parchis.Tests
{
   public class CandidatesTests
   {
      [Fact]
      public void OnBoard()
      {
         List<Token> tokens =
            new List<Token> { Token.Yellow.ToBoard(7) };

         IEnumerable<Move> candidates =
            new Candidates().For(Color.Yellow, 2, tokens);

         Assert.True(candidates.Single().Destination.AtBoard(9));
      }

      [Fact]
      public void PassingBoardEnd()
      {
         List<Token> tokens =
            new List<Token> { Token.Green.ToBoard(66) };

         IEnumerable<Move> candidates =
            new Candidates().For(Color.Green, 5, tokens);

         Assert.True(candidates.Single().Destination.AtBoard(3));
      }

      [Fact]
      public void FromBoardToLadder()
      {
         List<Token> tokens =
            new List<Token> { Token.Yellow.ToBoard(66) };

         IEnumerable<Move> candidates =
            new Candidates().For(Color.Yellow, 4, tokens);

         Assert.True(candidates.Single().Destination.AtLadder(2));
      }

      [Fact]
      public void FromLadderToHeaven()
      {
         List<Token> tokens =
            new List<Token> { Token.Yellow.ToLadder(3) };

         IEnumerable<Move> candidates =
            new Candidates().For(Color.Yellow, 5, tokens);

         Assert.True(candidates.Single().Destination.AtHeaven());
      }

      [Fact]
      public void FromHomeToBoard()
      {
         List<Token> tokens =
            new List<Token> { Token.Blue.ToBoard(12), Token.Blue };

         IEnumerable<Move> candidates =
            new Candidates().For(Color.Blue, 5, tokens);

         Assert.True(candidates.Single().Destination.AtBoard(21));
      }

      [Fact]
      public void AtHeaven()
      {
         List<Token> tokens =
            new List<Token> { Token.Blue.ToHeaven() };

         IEnumerable<Move> candidates =
            new Candidates().For(Color.Blue, 5, tokens);

         Assert.False(candidates.Any());
      }

      [Fact]
      public void MovingToTakenPosition()
      {
         List<Token> tokens = new List<Token>
         {
            Token.Yellow.ToBoard(5),
            Token.Yellow.ToBoard(7)
         };

         Move move =
            new Candidates().For(Color.Yellow, 2, tokens).Single();

         Assert.True(move.Destination.AtBoard(9));
      }
   }
}