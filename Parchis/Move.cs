using System;
using System.Text;
using LanguageExt;

namespace Parchis
{
   public class Move
   {
      public string TokenId { get; private set; }
      public Position Origin { get; private set; }
      public Position Destination { get; private set; }
      public Option<Token> Eaten { get; private set; }

      public Move(Token token, Position destination)
      {
         if (token == null)
            throw new ArgumentNullException(nameof(token));

         TokenId = token.Id;
         Origin = token.Position;

         Destination = destination ??
            throw new ArgumentNullException(nameof(destination));
      }

      public Move(Token token, Position destination, Option<Token> eaten)
         : this(token, destination)
      {
         Eaten = eaten;
      }

      public override string ToString()
      {
         StringBuilder builder = new StringBuilder(
            $"{TokenId} from {Origin} to {Destination}");

         builder.Append(
            Eaten.Match(t => $", eating {t.Id}", ""));

         return builder.ToString();
      }
   }
}