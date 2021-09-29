using System.Collections.Generic;
using System.Linq;
using LanguageExt;

namespace Parchis
{
   public class Player
   {
      public Color Color { get; }

      public Player(Color color)
      {
         Color = color;
      }

      public Option<Move> SelectMove(IEnumerable<Move> moves)
      {
         return moves.Any() ? moves.First() : Option<Move>.None;
      }
   }
}