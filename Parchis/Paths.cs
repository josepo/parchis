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
         switch(color)
         {
            case Color.Yellow:
               return Yellow;

            case Color.Red:
               return Red;

            case Color.Blue:
               return Blue;

            case Color.Green:
               return Green;

            default:
               throw new Exception($"{ color } not a valid color");
         }
      }
   }
}