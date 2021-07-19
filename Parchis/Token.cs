using System.Text;

namespace Parchis
{
   internal class Token
   {
      internal enum TokenStatus { Home, Board, Heaven };

      private TokenStatus Status { get; set; }

      public Token()
      {
         Status = TokenStatus.Home;
      }

      public override string ToString()
      {
         return
            new StringBuilder()
               .Append("Token ")
               .Append($"at { Status } ")
               .ToString();
      }
   }
}