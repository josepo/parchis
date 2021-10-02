using Xunit;

namespace Parchis.Tests
{
   public class PathTests
   {
      [Fact]
      public void PositionIsStart()
      {
         Path path = new Path(3, 15, 68);
         Position position = Position.OnBoard(3);

         Assert.True(path.IsStart(position));
      }

      [Fact]
      public void PositionIsNotStart()
      {
         Path path = new Path(3, 15, 68);
         Position position = Position.OnBoard(5);

         Assert.False(path.IsStart(position));         
      }
   }
}