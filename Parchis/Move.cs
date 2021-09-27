using System;
using System.Text;

namespace Parchis
{
   public class Move
   {
      public string TokenId { get; private set; }
      public Position Destination { get; private set; }

      public bool Eats { get; private set; }

      public Token Eaten { get; private set; }

      public Move(string tokenId, Position destination)
      {
         TokenId = tokenId ?? throw new ArgumentNullException(nameof(tokenId));

         Destination = destination ?? 
            throw new ArgumentNullException(nameof(destination));
      }

      public Move WouldEat(Token eaten)
      {
         return new Move(TokenId, Destination)
         {
            Eats = true,
            Eaten = eaten
         };
      }

      public override string ToString()
      {
         StringBuilder builder = new StringBuilder(
            $"{ TokenId } moves to { Destination }");

         if (Eats)
            builder.Append($" eating { Eaten.Id }");

         return builder.ToString();
      }
   }
}