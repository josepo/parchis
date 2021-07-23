using System;
using System.Text;

namespace Parchis
{
   public class Game
   {
      private Players Players { get; set; }

      public Game(Players players)
      {
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