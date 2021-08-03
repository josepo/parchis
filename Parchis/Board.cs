using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Parchis
{
   public interface IBoard
   {
      IEnumerable<Move> Candidates(Color color, int moves);
      bool AnyWinner();
      Color Winner();
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

      public IEnumerable<Move> Candidates(Color color, int moves)
      {
         List<Move> candidates = new List<Move>();
         IEnumerable<Token> tokens = Tokens.Where(t => t.Color == color);

         Token atHome = tokens.FirstOrDefault(t => t.Position.AtHome());

         if ((atHome != null) && (moves == 5))
         {
            candidates.Add(new Move(atHome, NextPosition(atHome, moves)));
            return candidates;
         }

         foreach (Token token in tokens)
         {
            Position next = NextPosition(token, moves);

            if (next != null)
               candidates.Add(new Move(token, next));
         }

         return candidates;
      }

      private Position NextPosition(Token token, int moves) =>
         Paths[token.Color].NextPosition(token.Position, moves);

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