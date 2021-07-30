using System.Collections.Generic;

namespace Parchis
{
   public class Board
   {
      public int Start = 1;
      public int End = 68;

      public enum Section { Home, Board, Ladder, Heaven };

      private Dictionary<Color, Path> Paths = new Dictionary<Color, Path>
      {
         { Color.Yellow, Path.Yellow },
         { Color.Red, Path.Red },
         { Color.Blue, Path.Blue },
         { Color.Green, Path.Green }
      };

      public Position NextPosition(Position position, int moves, Color color)
      {
         return Paths[color].NextPosition(position, moves);
      }
   }
}