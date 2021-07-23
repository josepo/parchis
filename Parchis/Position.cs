using System;

namespace Parchis
{
   public class Position
   {
      public static Position Home = new Position(Board.Section.Home);
      public static Position OnBoard(int square) => new Position(Board.Section.Board, square);

      public Board.Section Section { get; }
      public int Square { get; }

      public Position(Board.Section section)
      {
         Section = section;
      }

      public Position(Board.Section section, int square)
      {
         if ((section == Board.Section.Home) || (section == Board.Section.Heaven))
            throw new Exception($"Section { section } does not allow squares");

         Section = section;
         Square = square;
      }
   }
}