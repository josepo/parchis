
using System;
using System.Text;

namespace Parchis
{
   public class Game
   {
      private Player Current { get; set; }
      private IPlayers Players { get; set; }

      public Game(IPlayers players)
      {
         Players = players ?? throw new ArgumentNullException(nameof(players));
         Current = Players.GetRandom();
      }

      public bool End()
      {
         return Players.AnyWinner();
      }

      public void Move()
      {
         Current.Move(5);
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