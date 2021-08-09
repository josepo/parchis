using System;
using System.Linq;
using System.Collections.Generic;

namespace Parchis
{
   public class Candidates
   {
      public IEnumerable<Move> For(Color color, int moves, IEnumerable<Token> tokens)
      {
         if (!tokens.Any())
            throw new Exception("No tokens to select candidates from!");

         IEnumerable<Token> colorTokens = tokens.Where(t => t.Color == color);

         Path path = Board.Paths.For(color);
         Token atHome;

         if (TryGetTokenAtHome(colorTokens, out atHome) && (moves == 5))
            return MoveToStartingPosition(atHome, path);

         return colorTokens
            .Select(t => new { Token = t, Next = NextPosition(t, path, moves) })
            .Where(x => x.Next != null)
            .Where(x => !tokens.Any(t => t.Position.Same(x.Next)))
            .Select(x => new Move(x.Token, x.Next));
      }

      private bool TryGetTokenAtHome(IEnumerable<Token> tokens, out Token atHome)
      {
         atHome = tokens.FirstOrDefault(t => t.Position.AtHome());

         return atHome != null;
      }

      private List<Move> MoveToStartingPosition(Token token, Path path) =>
         new List<Move> { new Move(token, NextPosition(token, path, 5)) };

      private Position NextPosition(Token token, Path path, int moves) =>
         path.NextPosition(token.Position, moves);
   }
}