using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Parchis
{
   public interface IBoard
   {
      IEnumerable<Move> GetCandidates(Color color, int moves);
      bool AnyWinner();
      Color Winner();
   }

   internal class Board : IBoard
   {
      private const int Start = 1;
      private const int End = 68;

      private IEnumerable<Token> Tokens { get; }
      private Candidates Candidates { get; }

      public static Paths Paths = new Paths()
      {
         Yellow = new Path(4, 68, End),
         Red = new Path(38, 34, End),
         Blue = new Path(21, 17, End),
         Green = new Path(55, 51, End)
      };

      public Board(Candidates candidates, params Token[] tokens)
      {
         Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
         Candidates = candidates ?? throw new ArgumentNullException(nameof(candidates));
      }

      public IEnumerable<Move> GetCandidates(Color color, int moves) =>
         Candidates.From(Tokens.Where(t => t.Color == color), moves);

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

         foreach(IGrouping<Color, Token> group in Tokens.GroupBy(t => t.Color))
         {
            foreach(Token token in group)
               builder = builder.AppendLine($"  { token }");

            builder = builder.AppendLine();
         }

         return builder.ToString();
      }
   }
}