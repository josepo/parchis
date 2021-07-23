using System.Collections.Generic;

namespace Parchis
{
   public class Board
   {
      public enum Section { Home, Board, Ladder, Heaven };

      private Dictionary<Color, Path> Paths = new Dictionary<Color, Path>
      {
         { Color.Yellow, new Path(4, 68, 7) },
         { Color.Red, new Path(38, 34, 7) },
         { Color.Blue, new Path(21, 17, 7) },
         { Color.Green, new Path(55, 51, 7) }
      };

      public Path PathFor(Color color)
      {
         Path path;

         if (!Paths.TryGetValue(color, out path))
            throw new System.Exception($"No path for color { color }");

         return path;
      }
   }
}