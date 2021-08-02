using System;
using System.Text;

namespace Parchis
{
   public class Game
   {
      private IBoard Board { get; }
      private IPlayers Players { get; }
      public Player Current { get; private set; }

      public Game(IBoard board, IPlayers players)
      {
         Board = board ?? throw new ArgumentNullException(nameof(board));
         Players = players ?? throw new ArgumentNullException(nameof(players));
         Current = Players.GetRandom();
      }

      public bool End() => Board.AnyWinner();
      public Color Winner() => Board.Winner();

      public void Move()
      {
         Current.Move();
         Current = Players.Next(Current.Color);
      }

      public override string ToString()
      {
         return
            new StringBuilder()
               .AppendLine()
               .AppendLine("Game")
               .AppendLine($"  { Current.Color } to play")
               .AppendLine()
               .Append(Board.ToString())
               .ToString();
      }
   }
}