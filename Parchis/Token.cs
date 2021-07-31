using System;

namespace Parchis
{
   public class Token
   {
      public Position Position { get; set; }

      public Token(Position position)
      {
         Position = position ?? throw new ArgumentNullException(nameof(position));
      }

      public override string ToString() => $"Token at { Position.ToString() } ";
   }
}