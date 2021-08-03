using System;

namespace Parchis
{
   public class Move
   {
      public Token Token { get; private set; }
      public Position Destination { get; private set; }

      public Move(Token token, Position position)
      {
         Token = token ?? throw new ArgumentNullException(nameof(token));
         Destination = position ?? throw new ArgumentNullException(nameof(position));
      }
   }
}