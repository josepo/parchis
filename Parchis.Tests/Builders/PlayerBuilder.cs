using System.Collections.Generic;

namespace Parchis.Tests
{
   public class PlayerBuilder
   {
      private Color _color;
      private IDice _dice;
      private IBoard _board;

      private PlayerBuilder(Color color)
      {
         _color = color;
         _dice = new Dice();

         Tokens tokens = new Tokens();
         _board = new Board(tokens, new Candidate(tokens));
      }

      public static PlayerBuilder Blue() => new PlayerBuilder(Color.Blue);
      public static PlayerBuilder Yellow() => new PlayerBuilder(Color.Yellow);
      public static PlayerBuilder Green() => new PlayerBuilder(Color.Green);
      public static PlayerBuilder Red() => new PlayerBuilder(Color.Red);

      public PlayerBuilder Dice(IDice dice)
      {
         _dice = dice;

         return this;
      }

      public PlayerBuilder Board(IBoard board)
      {
         _board = board;

         return this;
      }

      public static implicit operator Player(PlayerBuilder builder) =>
         new Player(builder._color, builder._board, builder._dice);
   }
}