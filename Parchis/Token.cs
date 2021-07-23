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

      public bool AtHome() => Position.AtHome();
      public bool AtBoard() => Position.AtBoard();
      public bool AtLadder() => Position.AtLadder();
      public bool AtHeaven() => Position.AtHeaven();
      public bool At(int square) => Position.At(square);

      public void Move(int moves)
      {
         Position = Path.PositionFor(Position, moves);
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