using System.Linq;
using System.Collections.Generic;

namespace Parchis
{
   public class Candidates
   {
      public IEnumerable<Move> From(IEnumerable<Token> tokens, Path path, int moves)
      {
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