using System;
using System.Text;

namespace Parchis
{
   internal class Token
   {
      public Position Position { get; private set;}
      private Path Path { get; }

      public Token(Position position, Path path)
      {
         Position = position ?? throw new ArgumentNullException(nameof(position));
         Path = path ?? throw new ArgumentNullException(nameof(path));
      }

      public bool AtHome()
      {
         return (Position.Section == Board.Section.Home);
      }

      public bool AtBoard()
      {
         return (Position.Section == Board.Section.Board);
      }

      public bool AtLadder()
      {
         return (Position.Section == Board.Section.Ladder);
      }

      public bool At(int square)
      {
         return (Position.Square == square);
      }

      public void Move(int moves)
      {
         int end = Path.End;
         int square = Position.Square + moves;

         Position = (square <= end) ?
            Position.OnBoard(square) : 
            Position.OnLadder(square - end);
      }

      public override string ToString()
      {
         return
            new StringBuilder()
               .Append("Token ")
               .Append($"at { Position.Section } ")
               .ToString();
      }
   }
}