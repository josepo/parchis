using System;
using System.Linq;
using System.Collections.Generic;
using LanguageExt;

namespace Parchis
{
   public interface ICandidate
   {
      Moves For(Color color, int moves);
   }

   internal class Candidate : ICandidate
   {
      private Tokens Tokens;

      public Candidate(Tokens tokens)
      {
         Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
      }

      public Moves For(Color color, int n)
      {
         Moves moves = new Moves();
         Path path = Board.Paths.For(color);

         foreach (Move move in MovesFor(color, n))
         {
            if (path.IsStart(move.Destination))
               return new Moves(move);

            moves.Add(move);
         }

         return moves;
      }

      private IEnumerable<Move> MovesFor(Color color, int moves)
      {
         Path path = Board.Paths.For(color);

         return Tokens
            .GetByColor(color)
            .Select(t => NextMove(t, path, moves))
            .Where(m => m.IsSome)
            .Select<Option<Move>, Move>(m => (Move)m);
      }

      private Option<Move> NextMove(Token token, Path path, int moves)
      {
         Option<Position> next =
            path.NextPosition(token.Position, moves);

         if (next.IsNone)
            return Option<Move>.None;

         return NextMove(token, (Position)next);
      }

      private Option<Move> NextMove(Token token, Position next)
      {
         if (next.AtHeaven())
            return new Move(token, next);

         IEnumerable<Token> atNext = Tokens.At(next);

         if (!atNext.Any())
            return new Move(token, next);

         if (atNext.Any(t => t.Color.Is(token.Color)))
            return Option<Move>.None;

         return new Move(token, next, atNext.First());
      }
   }
}