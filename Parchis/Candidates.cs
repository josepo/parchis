using System.Linq;
using System.Collections.Generic;

namespace Parchis
{
   public class Candidates
   {
      public IEnumerable<Move> For(Color color, int moves, IEnumerable<Token> tokens)
      {
         List<Move> candidates = new List<Move>();
         Path path = Board.Paths.For(color);

         foreach (Token token in tokens.Where(t => t.Color == color))
         {
            Position next = path.NextPosition(token.Position, moves);

            if (CanTakePosition(next, tokens))
            {
               if (next.AtBoard(path.Start))
                  return new List<Move> { new Move(token, next) };

               candidates.Add(new Move(token, next));
            }
         }

         return candidates;
      }

      private bool CanTakePosition(Position next, IEnumerable<Token> tokens)
      {
         if (next == null)
            return false;

         if (next.AtHeaven())
            return true;

         return tokens.All(t => !t.Position.Same(next));
      }
   }
}