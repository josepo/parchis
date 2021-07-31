using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parchis
{
   public interface IPlayers
   {
      void Add(Player player);
      bool AnyWinner();

      Player GetRandom();
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

      public bool AnyWinner()
      {
         return _players.Any(p => p.Won());
      }

      public Player GetRandom()
      {
         return _players.First();
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