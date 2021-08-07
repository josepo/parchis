using Xunit;

namespace Parchis.Tests
{
   public class GameFactoryTests
   {
      [Fact]
      public void GameIsCreated()
      {
         Game game = GameFactory.New();

         Assert.NotNull(game);
      }
   }
}