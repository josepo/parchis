using System;

namespace Parchis
{
   public class Player : ICloneable
   {
      public Color Color { get; private set; }

      public Player(Color color)
      {
         Color = color;
      }

      public object Clone()
      {
         return new Player(Color);
      }
   }
}