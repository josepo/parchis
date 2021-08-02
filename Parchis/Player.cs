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
         int moves = Dice.Roll();

         IEnumerable<Token> candidates = Board.Candidates(Color, moves);
         Token token = candidates.First();

         token.Position = Board.NextPosition(token, moves);
      }

      public Player Clone() => new Player(Color, Board, Dice);
   }
}