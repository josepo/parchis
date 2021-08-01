
using System;
using System.Text;

namespace Parchis
{
   public class Game
   {
      public Player Current { get; private set; }
      private IPlayers Players { get; }

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
         Current.Move();
         Current = Players.Next(Current.Color);
      }

      public Color Winner()
      {
         return Players.Winner();
      }

      public override string ToString()
      {
         return
            new StringBuilder()
               .AppendLine()
               .AppendLine($"Game - Player { Current.Color } to play")
               .AppendLine()
               .Append(Players.ToString())
               .ToString();
      }
   }
}