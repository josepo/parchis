using System;

namespace Parchis
{
   public class Paths
   {
      public Path Yellow { get; set; }
      public Path Red { get; set; }
      public Path Blue { get; set; }
      public Path Green { get; set; }

      public Path For(Color color)
      {
         if (color.IsYellow())
            return Yellow;

         if (color.IsRed())
            return Red;

         if (color.IsBlue())
            return Blue;

         if (color.IsGreen())
            return Green;

         throw new Exception($"{ color } not a valid color");
      }
   }
}