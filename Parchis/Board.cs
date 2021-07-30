using System.Collections.Generic;

namespace Parchis
{
   public class Board
   {
      private const int Start = 1;
      private const int End = 68;

      public enum Section { Home, Board, Ladder, Heaven };

      private Dictionary<Color, Path> Paths = new Dictionary<Color, Path>
      {
         { Color.Yellow, new Path(4, 68, End) },
         { Color.Red, new Path(38, 34, End) },
         { Color.Blue, new Path(21, 17, End) },
         { Color.Green, new Path(55, 51, End) }
      };

      public Position NextPosition(Position position, int moves, Color color)
      {
         return Paths[color].NextPosition(position, moves);
      }
   }
}