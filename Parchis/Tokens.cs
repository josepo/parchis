using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parchis
{
   public class Tokens
   {
      private List<Token> _tokens { get; set; }

      public Tokens(params Token[] tokens)
      {
         _tokens = tokens.ToList() ?? throw new ArgumentNullException(nameof(tokens));
      }

      public IEnumerable<Token> At(Position position) => 
         _tokens.Where(t => t.Position == position);

      public Token Get(string id) => _tokens.Single(t => t.Id == id);

      public void Move(string id, Position position)
      {
         _tokens[GetIndex(id)] = Get(id).To(position);
      }

      private int GetIndex(string id) => _tokens.FindIndex(t => t.Id == id);

      public IEnumerable<Move> CandidatesFor(Color color, int moves)
      {
         List<Move> candidates = new List<Move>();
         Path path = Board.Paths.For(color);

         foreach (Token token in _tokens.Where(t => t.Color == color))
         {
            Position next = path.NextPosition(token.Position, moves);

            if (CanMoveTo(token, next))
            {
               if (next.AtBoard(path.Start))
                  return new List<Move> { new Move(token.Id, next) };

               Token eaten = FirstEdible(next, color);

               Move move = (eaten != null)
                  ? new Move(token.Id, next).WouldEat(eaten)
                  : new Move(token.Id, next);

               candidates.Add(move);
            }
         }

         return candidates;
      }

      private Token FirstEdible(Position position, Color excludingColor)
      {
         if (position.AtHeaven())
            return null;

         return _tokens
            .Where(t => t.Position.Same(position))
            .FirstOrDefault(t => t.Color != excludingColor);
      }

      private bool CanMoveTo(Token token, Position next)
      {
         if (next == null)
            return false;

         if (next.AtHeaven())
            return true;

         return !_tokens.Any(t => t.Color == token.Color && t.Position.Same(next));
      }

      public bool AnyWinner() => Winners().Any();
      public bool AnyOf(Color color) => _tokens.Any(t => t.Color == color);
      public Color Winner() => Winners().Single();

      private IEnumerable<Color> Winners() =>
         _tokens
            .GroupBy(t => t.Color)
            .Where(g => g.All(t => t.Position.AtHeaven()))
            .Select(g => g.Key);

      public override string ToString()
      {
         StringBuilder builder = new StringBuilder();

         foreach(IGrouping<Color, Token> group in _tokens.GroupBy(t => t.Color))
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