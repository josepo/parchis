using System;

namespace Parchis
{
   class Program
   {
      static void Main(string[] args)
      {
         Game game = GameFactory.For(Color.Green, Color.Blue);

         Console.Clear();
         Console.WriteLine(game);

         while (!game.End())
         {
            Console.ReadKey(false);
            Console.Clear();

            game.Move();

            Console.WriteLine(game);
         }

         Console.WriteLine($"Player { game.Winner() } wins the game");
      }
   }
}
