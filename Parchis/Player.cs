using System;
using System.Collections.Generic;
using System.Text;

namespace Parchis
{
   public class Player
   {
      public Color Color { get; }
      private Board Board { get; }

      private List<Token> Tokens { get; }

      public Player(Color color, Board board)
      {
         Color = color;
         Board = board ?? throw new ArgumentNullException(nameof(board));

         Tokens = new List<Token>
         {
            new Token(Position.Home, Board.PathFor(Color))
         };
      }

      public Player Clone()
      {
         return new Player(Color, Board);
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