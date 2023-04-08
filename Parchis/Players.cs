using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageExt;

namespace Parchis
{
   public interface IPlayers
   {
      Player Current { get; }

      Option<Move> NextMove(int roll);
      void EndTurn();
   }

   internal class Players : IPlayers
   {
      public Player Current { get; private set; }

      private List<Player> _players = new List<Player>();
      private IBoard Board { get; }

      public Players(IBoard board)
      {
         Board = board ?? throw new ArgumentNullException(nameof(board));

         if (board.AnyBlue())
            _players.Add(new Player(Color.Blue));

         if (board.AnyRed())
            _players.Add(new Player(Color.Red));

         if (board.AnyYellow())
            _players.Add(new Player(Color.Yellow));

         if (board.AnyGreen())
            _players.Add(new Player(Color.Green));

         if (!_players.Any())
            throw new Exception("Not even one player in the game!");

         Current = _players.First();
      }

      public Option<Move> NextMove(int roll)
      {
         Moves candidates =
            Board.GetCandidates(Current.Color, roll);

         return Current.SelectMove(candidates);
      }

      public void EndTurn()
      {
         if (_players.Count == 1)
            throw new Exception("Only one player!");

         Color nextColor = Current.Color.Next();

         while (!_players.Any(p => p.Color.Is(nextColor)))
            nextColor = nextColor.Next();

         Current = _players.Single(p => p.Color.Is(nextColor));
      }

      public override string ToString()
      {
         StringBuilder builder = new StringBuilder();

         foreach (Player player in _players)
            builder = builder.AppendLine(player.ToString());

         return builder.ToString();
      }
   }
}