using System.Collections.Generic;
using Xunit;

namespace Parchis.Tests
{
   public class GameTests
   {
      [Fact]
      public void GameEnds()
      {
         Board board = new Board(
            new Candidates(),
            new List<Token> { Token.Blue.ToHeaven(), Token.Red });

         IPlayers players = new Players();
         players.Add(PlayerBuilder.Blue().Board(board));
         players.Add(PlayerBuilder.Red().Board(board));

         Game game = new Game(board, players);

         Assert.True(game.End());
      }

      [Fact]
      public void TurnChanges()
      {
         Board board = new Board(
            new Candidates(),
            new List<Token> { Token.Blue, Token.Red });

         IPlayers players = new Players();
         players.Add(PlayerBuilder.Blue().Board(board));
         players.Add(PlayerBuilder.Red().Board(board));

         Game game = new Game(board, players);
         Player first = game.Current;

         game.Move();

         Assert.NotEqual(first.Color, game.Current.Color);
      }
   }
}