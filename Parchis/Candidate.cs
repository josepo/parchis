using System;
using System.Linq;
using System.Collections.Generic;
using LanguageExt;

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

               Option<Token> eaten = FirstEdible(next, color);

               candidates.Add(new Move(token.Id, next, eaten));
            }
         }

         return candidates;
      }

      private Option<Token> FirstEdible(Position position, Color excludingColor)
      {
         if (position.AtHeaven())
            return Option<Token>.None;

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