namespace Parchis
{
   public class Path
   {
      public int Start { get; }
      public int End { get; }
      public int Steps { get; }

      public Path(int start, int end, int steps)
      {
         Start = start;
         End = end;
         Steps = steps;
      }
   }
}