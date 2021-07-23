using System;

namespace Parchis
{
   class Program
   {
      static void Main(string[] args)
      {
         Game game = GameFactory.For(Color.Green, Color.Blue);

         while (!game.End())
         {
            game.Move();

            Console.WriteLine(game);
         }

         Console.WriteLine(game);
      }
   }
}
