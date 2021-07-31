using System;

namespace Parchis
{
   public interface IDice
   {
      int Roll();
   }

   internal class Dice : IDice
   {
      public int Roll() => new Random().Next(1, 6);
   }
}