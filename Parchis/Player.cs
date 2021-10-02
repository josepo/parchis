using LanguageExt;

namespace Parchis
{
   public class Player
   {
      public Color Color { get; }

      public Player(Color color)
      {
         Color = color;
      }

      public Option<Move> SelectMove(Moves moves) => moves.First();
   }
}