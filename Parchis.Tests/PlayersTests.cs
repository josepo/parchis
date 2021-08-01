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

      [Fact]
      public void RedIsNextFromGreen()
      {
         Players players = new Players();

         players.Add(PlayerBuilder.Blue());
         players.Add(PlayerBuilder.Red());
         players.Add(PlayerBuilder.Green());
         players.Add(PlayerBuilder.Yellow());

         Player next = players.Next(Color.Green);

         Assert.Equal(Color.Red, next.Color);
      }

      [Fact]
      public void YellowIsNextFromRedWhenNoBlue()
      {
         Players players = new Players();

         players.Add(PlayerBuilder.Green());
         players.Add(PlayerBuilder.Red());
         players.Add(PlayerBuilder.Yellow());

         Player next = players.Next(Color.Red);

         Assert.Equal(Color.Yellow, next.Color);         
      }
   }
}
