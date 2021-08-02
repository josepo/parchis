using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Parchis
{
   public interface IBoard
   {
      IEnumerable<Token> Candidates(Color color, int moves);
      bool AnyWinner();
      Color Winner();
      Position NextPosition(Token token, int moves);
   }

   internal class Board : IBoard
   {
      private const int Start = 1;
      private const int End = 68;

      private IEnumerable<Token> Tokens { get; }

      private Dictionary<Color, Path> Paths = new Dictionary<Color, Path>
      {
         { Color.Yellow, new Path(4, 68, End) },
         { Color.Red, new Path(38, 34, End) },
         { Color.Blue, new Path(21, 17, End) },
         { Color.Green, new Path(55, 51, End) }
      };

      public Board(params Token[] tokens)
      {
         Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
      }

      public IEnumerable<Token> Candidates(Color color, int moves)
      {
         return Tokens.Where(t => t.Color == color);
      }

      public bool AnyWinner()
      {
         return Tokens
            .GroupBy(t => t.Color)
            .Any(g => g.All(t => t.Position.AtHeaven()));
      }

      public Color Winner()
      {
         return Tokens
            .GroupBy(t => t.Color)
            .Single(g => g.All(t => t.Position.AtHeaven()))
            .First()
            .Color;
      }

      public Position NextPosition(Token token, int moves)
      {
         if (!Tokens.Contains(token))
            throw new Exception($"{ token } not in board!");

         return Paths[token.Color].NextPosition(token.Position, moves);
      }

      public override string ToString()
      {
         StringBuilder builder =
            new StringBuilder().AppendLine("Board ");

         foreach(Token token in Tokens)
            builder = builder.AppendLine($"  { token }");

         return builder.ToString();
      }
   }
}