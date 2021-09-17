using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parchis
{
   public interface IPlayers
   {
      Player GetRandom();
      Player Next(Color color);
   }

   internal class Players : IPlayers
   {
      private List<Player> _players = new List<Player>();

      public Players(IBoard board, IDice dice)
      {
         if (board.AnyBlue())
            _players.Add(new Player(Color.Blue, board, dice));

         if (board.AnyRed())
            _players.Add(new Player(Color.Red, board, dice));
            
         if (board.AnyYellow())
            _players.Add(new Player(Color.Yellow, board, dice));

         if (board.AnyGreen())
            _players.Add(new Player(Color.Green, board, dice));

         if (!_players.Any())
            throw new Exception("Not even one player in the game!");
      }

      public Player GetRandom() => _players.First();

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

      private Color NextColor(Color color) => (Color) ((int)(color + 1) % 4);

      public override string ToString()
      {
         StringBuilder builder = new StringBuilder();
         
         foreach(Player player in _players)
            builder = builder.AppendLine(player.ToString());

         return builder.ToString();
      }
   }
}