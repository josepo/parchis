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

      public Player Current { get; private set; }

      public Game(IBoard board, IPlayers players)
      {
         Board = board ?? throw new ArgumentNullException(nameof(board));
         Players = players ?? throw new ArgumentNullException(nameof(players));
         Current = Players.GetRandom();
         LastMove = Option<Move>.None;
      }

      public bool End() => Board.AnyWinner();
      public Color Winner() => Board.Winner();

      public void Move()
      {
         LastMove = Current.Move();
         Current = Players.Next(Current);
      }

      public override string ToString()
      {
         return
            new StringBuilder()
               .AppendLine()
               .AppendLine("Game")
               .AppendLine($"  { Current.Color } to play")
               .AppendLine()
               .AppendLine("Last move")
               .AppendLine("  " + LastMove.Match(m => m.ToString(), "-"))
               .AppendLine()
               .AppendLine(Board.ToString())
               .ToString();
      }
   }
}