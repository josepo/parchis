using System;

namespace Parchis
{
   class Program
   {
      static void Main(string[] args)
      {
         Board board = new Board();

         Game game = new Game
         (
            new Players
            {
               new Player(Color.Green, board),
               new Player(Color.Blue, board)
            }
         );

         while (!game.End())
         {
            game.Move();

            Console.WriteLine(game);
         }

         Console.WriteLine(game);
      }
   }
}
