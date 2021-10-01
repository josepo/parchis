using Xunit;

namespace Parchis.Tests
{
   public class ColorTests
   {
      [Fact]
      public void EqualsToSameColor()
      {
         Assert.True(Color.Blue.Is(Color.Blue));
      }
   }
}