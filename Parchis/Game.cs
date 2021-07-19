using System;
using System.Text;

namespace Parchis
{
   public class Game
   {
      private Board Board { get; set; }
      private Players Players { get; set; }

      public Game(Board board, Players players)
      {
         Board = board ?? throw new ArgumentNullException(nameof(board));
         Players = players ?? throw new ArgumentNullException(nameof(players));
      }

      public bool End()
      {
         return true;
      }

      public void Move()
      {
      }

      public override string ToString()
      {
         return
            new StringBuilder()
               .AppendLine()
               .AppendLine("Game")
               .AppendLine()
               .Append(Players.ToString())
               .ToString();
      }
   }
}