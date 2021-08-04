using System;
using System.Collections.Generic;
using System.Linq;

namespace Parchis
{
   internal class Path
   {
      private List<Position> Positions = new List<Position>();

      public Path(int start, int end, int boardEnd)
      {
         Positions.Add(Position.Home);

         for (int i = start; i <= boardEnd; i++)
            Positions.Add(Position.OnBoard(i));

         if (end != boardEnd)
            for (int i = 1; i <= end; i++)
               Positions.Add(Position.OnBoard(i));

         for (int i = 1; i <= 7; i++)
            Positions.Add(Position.OnLadder(i));

         Positions.Add(Position.Heaven);
      }

      public Position NextPosition(Position start, int moves)
      {
         if (start.AtHeaven())
            return null;

         int current =
            Positions.FindIndex(p => p.Section == start.Section && p.Square == start.Square);

         if (current == -1)
            throw new Exception($"Position { start } not in path { this }");

         if (current == 0)
         {
            if (moves == 5)
               return Positions[1];

            return null;
         }

         int next = current + moves;

         if (next < Positions.Count)
            return Positions[next];

         return null;
      }
   }
}