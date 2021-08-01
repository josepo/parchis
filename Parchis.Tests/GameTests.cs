using NSubstitute;
using Xunit;

namespace Parchis.Tests
{
   public class GameTests
   {
      [Fact]
      public void GameEnds()
      {
         IPlayers players = Substitute.For<IPlayers>();
         players.AnyWinner().Returns(true);

         Game game = new Game(players);

         Assert.True(game.End());
      }

      [Fact]
      public void TurnChanges()
      {
         IPlayers players = Substitute.For<IPlayers>();
         players.GetRandom().Returns(PlayerBuilder.Blue().Token());
         players.Next(Color.Blue).Returns(PlayerBuilder.Red().Token());

         Game game = new Game(players);
         game.Move();

         Player current = game.Current;

         Assert.Equal(Color.Red, current.Color);
      }
   }
}