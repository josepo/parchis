using System;

namespace Parchis
{
   public class Game
   {
      private Player[] Players { get; set; }

      public Game(Player[] players)
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
         return $"Game with { Players.Length } players";
      }
   }
}