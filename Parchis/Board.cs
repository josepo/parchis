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

      void Move(Move move);
   }

   internal class Board : IBoard
   {
      private const int Start = 1;
      private const int End = 68;

      public List<Token> Tokens { get; private set; }
      private Candidates Candidates { get; }

      public static Paths Paths = new Paths()
      {
         Yellow = new Path(4, 68, End),
         Red = new Path(38, 34, End),
         Blue = new Path(21, 17, End),
         Green = new Path(55, 51, End)
      };

      public Board(Candidates candidates, List<Token> tokens)
      {
         Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
         Candidates = candidates ?? throw new ArgumentNullException(nameof(candidates));
      }

      public IEnumerable<Move> GetCandidates(Color color, int moves) =>
         Candidates.From(Tokens.Where(t => t.Color == color), moves);

      public void Move(Move move)
      {
         int index = Tokens.FindIndex(t => t == move.Token);

         if (index == -1)
            throw new Exception("Cannot move token, it is not in board!");

         Tokens[index] = move.Token.To(move.Destination);
      }

      public bool AnyWinner() => Winners().Any();
      public Color Winner() => Winners().Single();

      private IEnumerable<Color> Winners()
      {
         return
            Tokens
               .GroupBy(t => t.Color)
               .Where(g => g.All(t => t.Position.AtHeaven()))
               .Select(g => g.Key);
      }

      public override string ToString()
      {
         StringBuilder builder =
            new StringBuilder().AppendLine("Board ");

         foreach(IGrouping<Color, Token> group in Tokens.GroupBy(t => t.Color))
         {
            builder = builder.Append($" { group.Key, 10 }:");

            foreach(Token token in group)
               builder = builder.Append($"\t{ token.Position, -10 }");

            builder = builder.AppendLine();
         }

         return builder.ToString();
      }
   }
}