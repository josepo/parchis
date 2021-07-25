using System;
using System.Collections.Generic;
using System.Text;

namespace Parchis
{
   public class Player
   {
      public Color Color { get; }
      private List<Token> Tokens { get; }

      public Player(Color color, List<Token> tokens)
      {
         Color = color;
         Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
      }

      public Player Clone()
      {
         return new Player(Color, Tokens);
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