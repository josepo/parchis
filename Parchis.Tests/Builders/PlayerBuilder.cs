using System.Collections.Generic;

namespace Parchis.Tests
{
   public class PlayerBuilder
   {
      private Color _color;

      private PlayerBuilder(Color color)
      {
         _color = color;
      }

      public static PlayerBuilder Blue() => new PlayerBuilder(Color.Blue);
      public static PlayerBuilder Yellow() => new PlayerBuilder(Color.Yellow);
      public static PlayerBuilder Green() => new PlayerBuilder(Color.Green);
      public static PlayerBuilder Red() => new PlayerBuilder(Color.Red);

      public static implicit operator Player(PlayerBuilder builder) =>
         new Player(builder._color);
   }
}