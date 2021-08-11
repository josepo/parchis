using System.Collections.Generic;
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
            new List<Token> { Token.Red.ToLadder(3), Token.Blue.ToHeaven() }
         );

         Assert.True(board.AnyWinner());
         Assert.Equal(Color.Blue, board.Winner());
      }

      [Fact]
      public void MoveToken()
      {
         Token token = Token.Green.ToBoard(64);
         Move move = new Move(token, Position.OnBoard(66));

         Board board =
            new Board(new Candidates(), new List<Token> { token });

         board.Move(move);

         Assert.True(board.Tokens[0].Position.AtBoard(66));
      }


      [Fact]
      public void EatenTokenWillGoHome()
      {
         Token eater = Token.Blue.ToBoard(2);
         Token eaten = Token.Green.ToBoard(6);

         Board board = new Board (
            new Candidates(),
            new List<Token> { eater, eaten });
         
         board.Move(new Move(eater, eaten.Position));

         Assert.True(board.Tokens[1].Position.AtHome());
      }      
   }
}