using System;
using System.Text;

namespace Parchis
{
   public class Token
   {
      public Position Position { get; set; }

      public Token(Position position)
      {
         Position = position ?? throw new ArgumentNullException(nameof(position));
      }

      public override string ToString()
      {
         return
            new StringBuilder()
               .Append("Token ")
               .Append($"at { Position.Section } ")
               .ToString();
      }
   }
}