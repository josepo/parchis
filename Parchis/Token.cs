using System;
using System.Text;

namespace Parchis
{
   internal class Token
   {
      public Position Position { get; }

      public Token() : this (Position.Home) {}

      public Token(Position position)
      {
         Position = position ?? throw new ArgumentNullException(nameof(position));
      }

      public bool AtHome()
      {
         return (Position.Section == Board.Section.Home);
      }

      public bool AtBoard()
      {
         return (Position.Section == Board.Section.Board);
      }

      public bool At(int square)
      {
         return (Position.Square == square);
      }

      public Token Move(int moves)
      {
         return new Token(
            new Position(Board.Section.Board, Position.Square + moves));
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