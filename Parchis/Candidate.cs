using System;
using System.Linq;
using System.Collections.Generic;

namespace Parchis
{
   public interface ICandidate
   {
      IEnumerable<Move> For(Color color, int moves);
   }

   internal class Candidate : ICandidate
   {
      private Tokens Tokens;

      public Candidate(Tokens tokens)
      {
         Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
      }

      public IEnumerable<Move> For(Color color, int moves)
      {
         List<Move> candidates = new List<Move>();
         Path path = Board.Paths.For(color);

         foreach (Token token in Tokens.GetByColor(color))
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

         return Tokens
            .At(position)
            .FirstOrDefault(t => t.Color != excludingColor);
      }      

      private bool CanMoveTo(Token token, Position next)
      {
         if (next == null)
            return false;

         if (next.AtHeaven())
            return true;

         return !Tokens.At(next).Any(t => t.Color == token.Color);
      }
   }
}