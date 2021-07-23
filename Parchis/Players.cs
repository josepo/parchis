using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parchis
{
   public class Players : IEnumerable<Player>
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

      public override string ToString()
      {
         StringBuilder builder = new StringBuilder();
         
         foreach(Player player in _players)
            builder = builder.AppendLine(player.ToString());

         return builder.ToString();
      }

      public IEnumerator<Player> GetEnumerator()
      {
         return _players.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }
   }
}