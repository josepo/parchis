using Xunit;

namespace Parchis
{
   public class DiceTests
   {
      [Fact]
      public void Roll()
      {
         Dice dice = new Dice();

         Assert.InRange(dice.Roll(), 1, 6);
      }
   }
}