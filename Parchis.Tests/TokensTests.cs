using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Parchis.Tests
{
   public class TokensTests
   {
      [Fact]
      public void TokensAt()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1"),
            Token.Red("R1"));

         Assert.Equal(2, tokens.At(Position.Home).Count());
      }

      [Fact]
      public void MovesToken()
      {
         Position final = Position.OnBoard(24);

         Tokens tokens = new Tokens(Token.Blue("B1"));
         tokens.Move("B1", final);

         Token token = tokens.At(final).Single();

         Assert.Equal("B1", token.Id);
      }

      [Fact]
      public void OnBoard()
      {
         Tokens tokens = new Tokens(
            Token.Yellow("Y1").ToBoard(7));

         IEnumerable<Move> candidates = tokens.CandidatesFor(Color.Yellow, 2);

         Assert.True(candidates.Single().Destination.AtBoard(9));
      }

      [Fact]
      public void PassingBoardEnd()
      {
         Tokens tokens = new Tokens(
            Token.Green("G1").ToBoard(66));

         IEnumerable<Move> candidates = tokens.CandidatesFor(Color.Green, 5);

         Assert.True(candidates.Single().Destination.AtBoard(3));
      }

      [Fact]
      public void FromBoardToLadder()
      {
         Tokens tokens = new Tokens(
            Token.Yellow("Y1").ToBoard(66));

         IEnumerable<Move> candidates = tokens.CandidatesFor(Color.Yellow, 4);

         Assert.True(candidates.Single().Destination.AtLadder(2));
      }

      [Fact]
      public void FromLadderToHeaven()
      {
         Tokens tokens = new Tokens(
            Token.Yellow("Y1").ToLadder(3));

         IEnumerable<Move> candidates = tokens.CandidatesFor(Color.Yellow, 5);

         Assert.True(candidates.Single().Destination.AtHeaven());
      }

      [Fact]
      public void FromHomeToBoard()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1").ToBoard(12),
            Token.Blue("B2"));

         IEnumerable<Move> candidates = tokens.CandidatesFor(Color.Blue, 5);

         Assert.True(candidates.Single().Destination.AtBoard(21));
      }

      [Fact]
      public void AtHeaven()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1").ToHeaven());

         IEnumerable<Move> candidates = tokens.CandidatesFor(Color.Blue, 5);

         Assert.False(candidates.Any());
      }

      [Fact]
      public void MovingToTakenPosition()
      {
         Tokens tokens = new Tokens(
            Token.Yellow("Y1").ToBoard(5),
            Token.Yellow("Y2").ToBoard(7));

         Move move =
            tokens.CandidatesFor(Color.Yellow, 2).Single();

         Assert.True(move.Destination.AtBoard(9));
      }

      [Fact]
      public void TwoTokensToHome()
      {
         Tokens tokens = new Tokens(
            Token.Green("G1").ToBoard(55),
            Token.Green("G2"));

         Move move =
            tokens.CandidatesFor(Color.Green, 5).Single();

         Assert.True(move.Destination.AtBoard(60));
      }

      [Fact]
      public void MultipleTokensInHeaven()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1").ToHeaven(),
            Token.Blue("B2").ToLadder(6));

         Move move =
            tokens.CandidatesFor(Color.Blue, 2).Single();

         Assert.True(move.Destination.AtHeaven());
      }

      [Fact]
      public void TokenInHeavenWontBeEaten()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1").ToLadder(6),
            Token.Red("R1").ToHeaven());

         Move move =
            tokens.CandidatesFor(Color.Blue, 2).Single();

         Assert.True(move.Destination.AtHeaven());
         Assert.False(move.Eats);
      }
   }
}