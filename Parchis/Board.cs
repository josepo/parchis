using System;
using System.Collections.Generic;

namespace Parchis
{
   public interface IBoard
   {
      IEnumerable<Move> GetCandidates(Color color, int moves);
      bool AnyWinner();
      bool AnyBlue();
      bool AnyRed();
      bool AnyYellow();
      bool AnyGreen();
      Color Winner();
      void Move(Move move);
   }

   internal class Board : IBoard
   {
      private const int Start = 1;
      private const int End = 68;

      public Tokens Tokens { get; private set; }

      public static Paths Paths = new Paths()
      {
         Yellow = new Path(4, 68, End),
         Red = new Path(38, 34, End),
         Blue = new Path(21, 17, End),
         Green = new Path(55, 51, End)
      };

      public Board(Tokens tokens)
      {
         Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
      }

      public IEnumerable<Move> GetCandidates(Color color, int moves) =>
         Tokens.CandidatesFor(color, moves);

      public void Move(Move move)
      {
         Tokens.Move(move.TokenId, move.Destination);

         if (move.Eats)
            Tokens.Move(move.Eaten.Id, Position.Home);
      }

      public bool AnyWinner() => Tokens.AnyWinner();

      public bool AnyBlue() => Tokens.AnyOf(Color.Blue);
      public bool AnyRed() => Tokens.AnyOf(Color.Red);
      public bool AnyYellow() => Tokens.AnyOf(Color.Yellow);
      public bool AnyGreen() => Tokens.AnyOf(Color.Green);
      public Color Winner() => Tokens.Winner();

      public override string ToString() => "Board \n\n" + Tokens.ToString();
   }
}