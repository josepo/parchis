using System;
using Xunit;

namespace Parchis.Tests
{
   public class PlayersTests
   {
      [Fact]
      public void NoRepeatedColorsAllowed()
      {
         Assert.Throws<Exception>(() =>
         {
            Players players = new Players();

            players.Add(PlayerBuilder.Yellow());
            players.Add(PlayerBuilder.Green());
            players.Add(PlayerBuilder.Yellow());
         });
      }

      [Fact]
      public void ThereIsAWinner()
      {
         IPlayers players = new Players();
         
         players.Add(PlayerBuilder.Red().Token(Position.OnLadder(3)));
         players.Add(PlayerBuilder.Blue().Token(Position.Heaven));

         Assert.True(players.AnyWinner());
      }

      [Fact]
      public void Winner()
      {
         IPlayers players = new Players();
         
         players.Add(PlayerBuilder.Red().Token(Position.OnLadder(3)));
         players.Add(PlayerBuilder.Blue().Token(Position.Heaven));

         Assert.Equal(Color.Blue, players.Winner());
      }
   }
}
