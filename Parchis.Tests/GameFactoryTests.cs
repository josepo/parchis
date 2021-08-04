using Xunit;

namespace Parchis.Tests
{
   public class GameFactoryTests
   {
      [Fact]
      public void GameIsCreated()
      {
         Game game =
            GameFactory.For(Color.Yellow, Color.Blue, Color.Red, Color.Green);

         Assert.NotNull(game);
      }
   }
}