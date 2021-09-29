using System.Collections.Generic;
using Xunit;

namespace Parchis.Tests
{
   public class PlayerTests
   {
      [Fact]
      public void FistMoveIsSelected()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1").ToBoard(7),
            Token.Blue("B2"));

         Board board = new Board(tokens, new Candidate(tokens));
         IEnumerable<Move> moves = board.GetCandidates(Color.Blue, 3);

         Player player = PlayerBuilder.Blue();
         Move move = (Move) player.SelectMove(moves);

         Assert.Equal("B1", move.TokenId);
         Assert.True(move.Destination.AtBoard(10));
      }
   }
}