using System.Collections.Generic;
using Xunit;

namespace Parchis.Tests
{
   public class GameTests
   {
      [Fact]
      public void GameEnds()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1").ToHeaven(),
            Token.Red("R1"));

         Board board = new Board(tokens);

         Game game = new Game(board, new Players(board, new Dice()));

         Assert.True(game.End());
      }

      [Fact]
      public void TurnChanges()
      {
         Tokens tokens = new Tokens(
            Token.Blue("B1"),
            Token.Red("R1"));

         Board board = new Board(tokens);
         Game game = new Game(board, new Players(board, new Dice()));

         Player first = game.Current;

         game.Move();

         Assert.NotEqual(first.Color, game.Current.Color);
      }
   }
}