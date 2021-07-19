using System;
using System.Collections.Generic;
using System.Text;

namespace Parchis
{
   public class Player : ICloneable
   {
      public Color Color { get; private set; }

      private List<Token> Tokens { get; set; }

      public Player(Color color)
      {
         Color = color;

         Tokens = new List<Token>
         {
            new Token()
         };
      }

      public object Clone()
      {
         return new Player(Color);
      }

      public override string ToString()
      {
         StringBuilder builder =
            new StringBuilder().AppendLine("Player " + Color);

         for (int i = 0; i < Tokens.Count; i++)
            builder = builder.AppendLine($"{ i }: " + Tokens[i]);

         return builder.ToString();
      }
   }
}