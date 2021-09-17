using System;

namespace Parchis
{
   public class Token
   {
      public static Token Blue(string id) => new Token(id, Color.Blue, Position.Home);
      public static Token Red(string id) => new Token(id, Color.Red, Position.Home);
      public static Token Yellow(string id) => new Token(id, Color.Yellow, Position.Home);
      public static Token Green(string id) => new Token(id, Color.Green, Position.Home);

      public string Id { get; private set; }
      public Color Color { get; private set; }
      public Position Position { get; private set; }

      private Token(string id, Color color, Position position)
      {
         Id = id;
         Color = color;
         Position = position ?? throw new ArgumentNullException(nameof(position));
      }

      public Token To(Position position)
      {
         if (Position.AtHeaven())
            throw new Exception("Trying to move token from heaven!");

         return new Token(Id, Color, position);
      }

      public Token ToHome() => new Token(Id, Color, Position.Home);
      public Token ToBoard(int square) => new Token(Id, Color, Position.OnBoard(square));
      public Token ToLadder(int square) => new Token(Id, Color, Position.OnLadder(square));
      public Token ToHeaven() => new Token(Id, Color, Position.Heaven);

      public override string ToString() => $"Token { Color } at { Position.ToString() } ";
   }
}