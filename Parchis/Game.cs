using System;

namespace Parchis
{
   public class Game
   {
      private Board Board { get; set; }
      private Player[] Players { get; set; }

      public Game(Board board, Player[] players)
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
         return $"Game with { Players.Length } players";
      }
   }
}