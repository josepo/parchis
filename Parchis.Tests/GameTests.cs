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
   }
}