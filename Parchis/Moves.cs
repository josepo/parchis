using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;

namespace Parchis
{
   public class Moves
   {
      private List<Move> _moves;
      
      public Moves()
      {
         _moves = new List<Move>();
      }

      public Moves(Move move) : this()
      {
         if (move == null)
            throw new ArgumentNullException(nameof(move));

         _moves.Add(move);
      }

      public void Add(Move move)
      {
         _moves.Add(move);
      }

      public Option<Move> First() => _moves.FirstOrDefault();

      public Move Single() => _moves.Single();

      public bool Empty() => !_moves.Any();
   }
}