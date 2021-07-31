using System.Collections.Generic;

namespace Parchis.Tests
{
   public class PlayerBuilder
   {
      private Color _color;
      private List<Token> _tokens = new List<Token>();

      private PlayerBuilder(Color color)
      {
         _color = color;
      }

      public static PlayerBuilder Blue() => new PlayerBuilder(Color.Blue);
      public static PlayerBuilder Yellow() => new PlayerBuilder(Color.Yellow);
      public static PlayerBuilder Green() => new PlayerBuilder(Color.Green);
      public static PlayerBuilder Red() => new PlayerBuilder(Color.Red);

      public PlayerBuilder Token(Position position)
      {
         _tokens.Add(new Token(position));

         return this;
      }

      public PlayerBuilder Token(Token token)
      {
         _tokens.Add(token);

         return this;
      }

      public static implicit operator Player(PlayerBuilder builder)
      {
         return new Player(builder._color, builder._tokens, new Board());
      }
   }
}