using System;

namespace Parchis
{
   public class Position
   {
      public static Position Home = new Position(Section.Home);
      public static Position OnBoard(int square) => new Position(Section.Board, square);
      public static Position OnLadder(int square) => new Position(Section.Ladder, square);
      public static Position Heaven = new Position(Section.Heaven);

      public Section Section { get; }
      public int Square { get; }

      private Position(Section section)
      {
         Section = section;
      }

      private Position(Section section, int square)
      {
         if ((section == Section.Home) || (section == Section.Heaven))
            throw new Exception($"Section { section } does not allow squares");

         Section = section;
         Square = square;
      }

      public bool AtHome() => Section == Section.Home;
      public bool AtHeaven() => Section == Section.Heaven;
      public bool AtBoard() => Section == Section.Board;
      public bool AtBoard(int square) => (Section == Section.Board) && (Square == square);
      public bool AtLadder() => Section == Section.Ladder;
      public bool AtLadder(int square) => (Section == Section.Ladder) && (Square == square);

      public override string ToString()
      {
         string result = Section.ToString();

         if (AtBoard() || AtLadder())
            result += $" { Square }";

         return result;
      }
   }
}