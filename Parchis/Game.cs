using System;
using System.Text;
using LanguageExt;

namespace Parchis
{
   public class Game
   {
      private IBoard Board { get; }
      private IPlayers Players { get; }
      private Option<Move> LastMove { get; set; }

      public Game(IBoard board, IPlayers players)
      {
         Board = board ?? throw new ArgumentNullException(nameof(board));
         Players = players ?? throw new ArgumentNullException(nameof(players));
         LastMove = Option<Move>.None;
      }

      public bool End() => Board.AnyWinner();
      public Color Winner() => Board.Winner();

      public void Move()
      {
         LastMove = Players.NextMove();

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
               .AppendLine($"  { Players.Current.Color } to play")
               .AppendLine()
               .AppendLine("Last move")
               .AppendLine("  " + LastMove.Match(m => m.ToString(), "-"))
               .AppendLine()
               .AppendLine(Board.ToString())
               .ToString();
      }
   }
}