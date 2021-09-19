using System.Collections.Generic;
using Xunit;

namespace Parchis.Tests
{
   public class BoardTests
   {
      [Fact]
      public void ThereIsAWinner()
      {
         Tokens tokens = new Tokens(
            Token.Red("R1").ToLadder(3),
            Token.Blue("B1").ToHeaven());

         Board board = new Board(tokens, new Candidate(tokens));

         Assert.True(board.AnyWinner());
         Assert.Equal(Color.Blue, board.Winner());
      }

      [Fact]
      public void MoveToken()
      {
         Tokens tokens = new Tokens(
            Token.Green("G1").ToBoard(64));

         Board board = new Board(tokens, new Candidate(tokens));
         Move move = new Move("G1", Position.OnBoard(66));

         board.Move(move);

         Assert.True(tokens.Get("G1").Position.AtBoard(66));
      }

      [Fact]
      public void EatenTokenWillGoHome()
      {
         Token eater = Token.Blue("B1").ToBoard(2);
         Token eaten = Token.Green("G1").ToBoard(6);

         Tokens tokens = new Tokens(eater, eaten);
         Board board = new Board(tokens, new Candidate(tokens));
         Move move = new Move(eater.Id, eaten.Position).WouldEat(eaten);
         
         board.Move(move);

         Assert.True(tokens.Get("G1").Position.AtHome());
      }      
   }
}