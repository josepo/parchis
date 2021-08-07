using System;
using System.Linq;
using System.Collections.Generic;

namespace Parchis
{
   public class Candidates
   {
      public IEnumerable<Move> From(IEnumerable<Token> tokens, int moves)
      {
         if (!tokens.Any())
            throw new Exception("No tokens to select candidates from!");

         if (tokens.Select(t => t.Color).Distinct().Count() > 1)
            throw new Exception("Candidates from multiple colors!");

         Path path = Board.Paths.For(tokens.First().Color);

         List<Move> candidates = new List<Move>();

         Token atHome = tokens.FirstOrDefault(t => t.Position.AtHome());

         if ((atHome != null) && (moves == 5))
         {
            candidates.Add(new Move(atHome, NextPosition(atHome, path, moves)));
            return candidates;
         }

         foreach (Token token in tokens)
         {
            Position next = NextPosition(token, path, moves);

            if (next != null)
               candidates.Add(new Move(token, next));
         }

         return candidates;
      }

      private Position NextPosition(Token token, Path path, int moves) =>
         path.NextPosition(token.Position, moves);
   }
}