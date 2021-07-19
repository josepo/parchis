using System;

namespace Parchis
{
   class Program
   {
      static void Main(string[] args)
      {
         Game game = new Game
         (
            new Board(),
            new Players
            {
               new Player(Color.Green),
               new Player(Color.Blue)
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
