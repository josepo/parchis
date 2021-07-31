using System;
using System.Collections.Generic;
using Xunit;

namespace Parchis.Tests
{
   public class PlayersTests
   {
      [Fact]
      public void NoRepeatedColorsAllowed()
      {
         Board board = new Board();

         Assert.Throws<Exception>(() =>
         {
            Players players = new Players();

            players.Add(
               new Player(Color.Yellow, new List<Token> {
                  new Token(Position.Home)
               }, board));

            players.Add(
               new Player(Color.Green, new List<Token> {
                  new Token(Position.Home)
               }, board));

            players.Add(
               new Player(Color.Yellow, new List<Token> {
                  new Token(Position.Home)
               }, board));                              
         });
      }

      [Fact]
      public void ThereIsAWinner()
      {
         Board board = new Board();

         Player loser = new Player(Color.Yellow, new List<Token> {
            new Token(Position.OnLadder(3))
         }, board);

         Player winner = new Player(Color.Blue, new List<Token> {
            new Token(Position.Heaven)
         }, board);

         IPlayers players = new Players();
         players.Add(loser);
         players.Add(winner);

         Assert.True(players.AnyWinner());
      }
   }
}
