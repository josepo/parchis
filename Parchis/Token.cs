using System;
using System.Linq;
using System.Collections.Generic;

namespace Parchis
{
   public class Token
   {
      public static Token Blue = new Token(Color.Blue, Position.Home);
      public static Token Red = new Token(Color.Red, Position.Home);
      public static Token Yellow = new Token(Color.Yellow, Position.Home);
      public static Token Green = new Token(Color.Green, Position.Home);

      public Color Color { get; private set; }
      public Position Position { get; private set; }

      private Token(Color color, Position position)
      {
         Color = color;
         Position = position ?? throw new ArgumentNullException(nameof(position));
      }

      public Token To(Position position) => new Token(Color, position);
      public Token ToHome() => new Token(Color, Position.Home);
      public Token ToBoard(int square) => new Token(Color, Position.OnBoard(square));
      public Token ToLadder(int square) => new Token(Color, Position.OnLadder(square));
      public Token ToHeaven() => new Token(Color, Position.Heaven);

      public bool CanGoTo(Position next, IEnumerable<Token> tokens)
      {
         if (next == null)
            return false;

         if (next.AtHeaven())
            return true;

         return !tokens.Any(t => t.Color == Color && t.Position.Same(next));
      }

      public override string ToString() => $"Token { Color } at { Position.ToString() } ";
   }
}