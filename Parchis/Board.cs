using System.Collections.Generic;

namespace Parchis
{
   public class Board
   {
      public enum Section { Home, Board, Ladder, Heaven };

      private Dictionary<Color, Path> Paths = new Dictionary<Color, Path>
      {
         { Color.Yellow, new Path(5, 68, 7) },
         { Color.Red, new Path(39, 34, 7) },
         { Color.Blue, new Path(22, 17, 7) },
         { Color.Green, new Path(56, 51, 7) }
      };

      public Position NextPosition(Position position, int moves, Color color)
      {
         return Paths[color].NextPosition(position, moves);
      }
   }
}