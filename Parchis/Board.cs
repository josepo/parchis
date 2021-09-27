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
      public Tokens Tokens { get; private set; }
      private ICandidate Candidate { get; set; }

      public static Paths Paths = new Paths()
      {
         Yellow = new Path(4, 68, 68),
         Red = new Path(38, 34, 68),
         Blue = new Path(21, 17, 68),
         Green = new Path(55, 51, 68)
      };

      public Board(Tokens tokens, ICandidate candidate)
      {
         Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
         Candidate = candidate ?? throw new ArgumentNullException(nameof(candidate));
      }

      public IEnumerable<Move> GetCandidates(Color color, int moves)
         => Candidate.For(color, moves);

      public void Move(Move move)
      {
         Tokens.Move(move.TokenId, move.Destination);

         move.Eaten.IfSome(t => {
            Tokens.Move(t.Id, Position.Home);
         });
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