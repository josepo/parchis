using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;

namespace Parchis
{
   public class Player
   {
      public Color Color { get; }
      private IBoard Board { get; }
      private IDice Dice { get; }

      public Player(Color color, IBoard board, IDice dice)
      {
         Color = color;
         Board = board ?? throw new ArgumentNullException(nameof(board));
         Dice = dice ?? throw new ArgumentNullException(nameof(dice));
      }

      public Option<Move> Move()
      {
         IEnumerable<Move> candidates = Board.GetCandidates(Color, Dice.Roll());

         if (candidates.Any())
         {
            Move move = candidates.First();

            Board.Move(move);
            return move;
         }

         return Option<Move>.None;
      }

      public Player Clone() => new Player(Color, Board, Dice);
   }
}