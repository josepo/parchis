using System;
using System.Collections.Generic;
using System.Linq;

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

      public void Move()
      {
         IEnumerable<Move> candidates = Board.GetCandidates(Color, Dice.Roll());

         if (candidates.Any())
            Board.Move(candidates.First());
      }

      public Player Clone() => new Player(Color, Board, Dice);
   }
}