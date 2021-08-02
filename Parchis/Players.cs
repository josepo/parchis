using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parchis
{
   public interface IPlayers
   {
      void Add(Player player);
      Player GetRandom();
      Player Next(Color color);
   }

   internal class Players : IPlayers
   {
      private List<Player> _players;

      public Players()
      {
         _players = new List<Player>();
      }

      public void Add(Player player)
      {
         if (_players.Any(p => p.Color == player.Color))
            throw new System.Exception("All players should have a unique color.");

         _players.Add(player.Clone());
      }

      public Player GetRandom()
      {
         return _players.First();
      }

      public Player Next(Color color)
      {
         if (_players.Count == 1)
            throw new Exception("Only one player!");

         Color nextColor = NextColor(color);
         Player next = null;

         while (next == null)
         {
            next = _players.FirstOrDefault(p => p.Color == nextColor);
            nextColor = NextColor(nextColor);
         }

         return next;
      }

      private Color NextColor(Color color)
      {
         return (Color) ((int)(color + 1) % 4);
      }

      public override string ToString()
      {
         StringBuilder builder = new StringBuilder();
         
         foreach(Player player in _players)
            builder = builder.AppendLine(player.ToString());

         return builder.ToString();
      }
   }
}