using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parchis
{
   public class Tokens
   {
      private List<Token> _tokens { get; set; }

      public Tokens(params Token[] tokens)
      {
         _tokens = tokens.ToList() ?? throw new ArgumentNullException(nameof(tokens));
      }

      public IEnumerable<Token> At(Position position) => 
         _tokens.Where(t => t.Position.Same(position));

      public Token Get(string id) => _tokens.Single(t => t.Id == id);

      public void Move(string id, Position position)
      {
         _tokens[GetIndex(id)] = Get(id).To(position);
      }

      private int GetIndex(string id) => _tokens.FindIndex(t => t.Id == id);
      public bool AnyWinner() => Winners().Any();
      public bool AnyOf(Color color) => _tokens.Any(t => t.Color.Is(color));
      public Color Winner() => Winners().Single();

      private IEnumerable<Color> Winners() =>
         _tokens
            .GroupBy(t => t.Color)
            .Where(g => g.All(t => t.Position.AtHeaven()))
            .Select(g => g.Key);

      public IEnumerable<Token> GetByColor(Color color)
         => _tokens.Where(t => t.Color.Is(color));

      public override string ToString()
      {
         StringBuilder builder = new StringBuilder();

         foreach(IGrouping<Color, Token> group in _tokens.GroupBy(t => t.Color))
         {
            builder = builder.Append($" { group.Key, 10 }:");

            foreach(Token token in group)
               builder = builder.Append($"\t{ token.Position, -10 }");

            builder = builder.AppendLine();
         }

         return builder.ToString();
      }
   }
}