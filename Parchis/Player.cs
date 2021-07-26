using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parchis
{
   public class Player
   {
      public Color Color { get; }
      private List<Token> Tokens { get; }
      private Board Board { get; }

      public Player(Color color, List<Token> tokens, Board board)
      {
         Color = color;
         Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
         Board = board ?? throw new ArgumentNullException(nameof(board));
      }

      public void Move(int moves)
      {
         Token token = Tokens.First();

         token.Position = Board.NextPosition(token.Position, moves, Color);
      }

      public Player Clone()
      {
         return new Player(Color, Tokens, Board);
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