using System;

namespace Parchis
{
   public class Path
   {
      public int Start { get; }
      public int End { get; }
      public int Steps { get; }

      public Path(int start, int end, int steps)
      {
         Start = start;
         End = end;
         Steps = steps;
      }

      public Position PositionFor(Position start, int moves)
      {
         int square = start.Square + moves;

         if (start.AtLadder())
         {
            if (square <= Steps)
               return Position.OnLadder(square);

            if (square == Steps + 1)
               return Position.Heaven;
         }

         if (start.AtBoard())
         {
            if (square <= End)
               return Position.OnBoard(square);

            if (square <= End + Steps)
               return Position.OnLadder(square - End);

            if (square == End + Steps + 1)
               return Position.Heaven;            
         }

         if (start.AtHome())
         {
            if (moves == 5)
               return Position.OnBoard(Start);
         }
         
         throw new Exception("Invalid new position!");
      }
   }
}