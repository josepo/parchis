using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parchis
{
   public class Player
   {
      public Color Color { get; }
      private List<Token> Tokens { get; }
      private Board Board { get; }
      private IDice Dice { get; }

      public Player(Color color, List<Token> tokens, Board board, IDice dice)
      {
         Color = color;
         Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
         Board = board ?? throw new ArgumentNullException(nameof(board));
         Dice = dice ?? throw new ArgumentNullException(nameof(dice));
      }

      public void Move()
      {
         Token token = Tokens.First();
         int moves = Dice.Roll();

         token.Position = Board.NextPosition(token.Position, moves, Color);
      }

      public bool Won() => Tokens.All(t => t.Position.AtHeaven());
      public Player Clone() => new Player(Color, Tokens, Board, Dice);

      public override string ToString()
      {
         StringBuilder builder =
            new StringBuilder().AppendLine("Player " + Color);

         for (int i = 0; i < Tokens.Count; i++)
            builder = builder.AppendLine($"{ i }: " + Tokens[i]);

         return builder.ToString();
      }
   }
}