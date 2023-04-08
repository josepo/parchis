using System;
using System.Text;
using LanguageExt;

namespace Parchis
{
   public class Game
   {
      private IBoard Board { get; }
      private IPlayers Players { get; }
      private IDice Dice { get; }
      private int LastDiceRoll { get; set; }
      private Option<Move> LastMove { get; set; } = Option<Move>.None;

      public Game(IBoard board, IPlayers players, IDice dice)
      {
         Board = board ?? throw new ArgumentNullException(nameof(board));
         Players = players ?? throw new ArgumentNullException(nameof(players));
         Dice = dice ?? throw new ArgumentNullException(nameof(dice));
      }

      public bool End() => Board.AnyWinner();
      public Color Winner() => Board.Winner();

      public void Move()
      {
         LastDiceRoll = Dice.Roll();
         LastMove = Players.NextMove(LastDiceRoll);

         LastMove.IfSome(m =>
         {
            Board.Move(m);
         });

         Players.EndTurn();
      }

      public override string ToString()
      {
         return
            new StringBuilder()
               .AppendLine()
               .AppendLine("Game")
               .AppendLine($"  {Players.Current.Color} to play")
               .AppendLine()
               .AppendLine("Last move")
               .AppendLine("  " +
                  LastMove.Match(m => m.ToString() + " with dice roll of " + LastDiceRoll,
                  "-"))
               .AppendLine()
               .AppendLine(Board.ToString())
               .ToString();
      }
   }
}