using System;

namespace Parchis
{
   internal class Path
   {
      public static Path Yellow = new Path(4, 68);
      public static Path Red = new Path(38, 34);
      public static Path Blue = new Path(21, 17);
      public static Path Green = new Path(55, 51);

      public int Start { get; }
      public int End { get; }
      public int Steps { get; } = 7;

      public Path(int start, int end)
      {
         Start = start;
         End = end;
      }

      public Position NextPosition(Position start, int moves)
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