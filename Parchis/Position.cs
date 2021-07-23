using System;

namespace Parchis
{
   public class Position
   {
      public static Position Home = new Position(Board.Section.Home);
      public static Position OnBoard(int square) => new Position(Board.Section.Board, square);
      public static Position OnLadder(int square) => new Position(Board.Section.Ladder, square);
      public static Position Heaven = new Position(Board.Section.Heaven);

      public Board.Section Section { get; }
      public int Square { get; }

      private Position(Board.Section section)
      {
         Section = section;
      }

      private Position(Board.Section section, int square)
      {
         if ((section == Board.Section.Home) || (section == Board.Section.Heaven))
            throw new Exception($"Section { section } does not allow squares");

         Section = section;
         Square = square;
      }

      public bool AtHome() => Section == Board.Section.Home;
      public bool AtHeaven() => Section == Board.Section.Heaven;
      public bool AtBoard() => Section == Board.Section.Board;
      public bool AtLadder() => Section == Board.Section.Ladder;
      public bool At(int square) => Square == square;
   }
}