using System;
using System.Text;
using LanguageExt;

namespace Parchis
{
   public class Move
   {
      public string TokenId { get; private set; }
      public Position Destination { get; private set; }

      public Option<Token> Eaten { get; private set; }

      public Move(string tokenId, Position destination)
      {
         TokenId = tokenId ?? throw new ArgumentNullException(nameof(tokenId));

         Destination = destination ?? 
            throw new ArgumentNullException(nameof(destination));
      }

      public Move(string tokenId, Position destination, Option<Token> eaten)
         : this(tokenId, destination)
      {
         Eaten = eaten;
      }

      public override string ToString()
      {
         StringBuilder builder = new StringBuilder(
            $"{ TokenId } moves to { Destination }");

         builder.Append(
            Eaten.Match(t => $", eating { t.Id }", ""));

         return builder.ToString();
      }
   }
}