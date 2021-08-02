using System;

namespace Parchis
{
   public class Token
   {
      public Color Color { get; private set; }
      public Position Position { get; set; }

      public Token(Color color) : this(color, Position.Home) {}

      internal Token(Color color, Position position)
      {
         Color = color;
         Position = position ?? throw new ArgumentNullException(nameof(position));
      }

      public override string ToString() => $"Token { Color } at { Position.ToString() } ";
   }
}