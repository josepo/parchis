using System.Collections.Generic;

namespace Parchis
{
   public class Board
   {
      public enum Section { Home, Board, Ladder, Heaven };

      private class Path
      {
         public int Start { get; }
         public int End { get; }

         public Path(int start, int end)
         {
            Start = start;
            End = end;
         }
      }

      Dictionary<Color, Path> Paths = new Dictionary<Color, Path>
      {
         { Color.Yellow, new Path(4, 68) },
         { Color.Red, new Path(38, 34) },
         { Color.Blue, new Path(21, 17) },
         { Color.Green, new Path(55, 51) }
      };
   }
}