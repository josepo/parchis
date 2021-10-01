using System;

namespace Parchis
{
   public class Color
   {
      private enum Colors { Yellow, Green, Red, Blue };

      private Colors Value { get; set; }

      public static Color Blue => new Color(Colors.Blue);
      public static Color Red => new Color(Colors.Red);
      public static Color Yellow => new Color(Colors.Yellow);
      public static Color Green => new Color(Colors.Green);

      public bool IsBlue() => Is(Color.Blue);
      public bool IsRed() => Is(Color.Red);
      public bool IsGreen() => Is(Color.Green);
      public bool IsYellow() => Is(Color.Yellow);

      public bool Is(Color color) => Value == color.Value;

      private Color(Colors color)
      {
         Value = color;
      }

      public Color Next()
      {
         if (Value == Colors.Yellow)
            return new Color(Colors.Green);

         if (Value == Colors.Green)
            return new Color(Colors.Red);

         if (Value == Colors.Red)
            return new Color(Colors.Blue);

         if (Value == Colors.Blue)
            return new Color(Colors.Yellow);                        

         throw new Exception($"No next color for { Value }");
      }

      public override string ToString() => Value.ToString();

      public override bool Equals(object obj) => Is(obj as Color);
      public override int GetHashCode() => HashCode.Combine(Value);
   }
}