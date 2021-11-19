using System;

namespace Parchis
{
   class Program
   {
      static void Main(string[] args)
      {
         Game game = GameFactory.New();
         BoardPrinter printer = new BoardPrinter(game);

         Console.Clear();
         Console.WriteLine(game);
         Console.WriteLine(printer);

         while (!game.End())
         {
            Console.ReadKey(false);
            Console.Clear();

            game.Move();

            Console.WriteLine(game);
            Console.WriteLine(printer);
         }

         Console.WriteLine($"Player { game.Winner() } wins the game");
      }
   }
}
