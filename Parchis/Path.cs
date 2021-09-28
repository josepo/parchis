using System;
using System.Collections.Generic;
using LanguageExt;

namespace Parchis
{
   public class Path
   {
      public int Start { get; private set; }
      public int End { get; private set; }

      private List<Position> Positions = new List<Position>();

      public Path(int start, int end, int boardEnd)
      {
         Start = start;
         End = end;

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

      public Option<Position> NextPosition(Position start, int moves)
      {
         if (start.AtHeaven())
            return Option<Position>.None;

         int current = FindPositionIndex(start);

         if (current == -1)
            throw new Exception($"Position { start } not in path { this }");

         if (current == 0)
         {
            if (moves == 5)
               return Positions[1];

            return Option<Position>.None;;
         }

         int next = current + moves;

         if (next < Positions.Count)
            return Positions[next];

         return Option<Position>.None;;
      }

      private int FindPositionIndex(Position position)
      {
         return Positions.FindIndex(p => 
            p.Section == position.Section &&
            p.Square == position.Square);
      }
   }
}