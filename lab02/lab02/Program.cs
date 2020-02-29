using System;
using PiELn2;

namespace lab02 {
  class Program {
    static void Main(string[] args) {
      decimal pi = 0;
      decimal e = 0;
      decimal ln2 = 0;

      PiELn2.PiELn2.calc(out pi, out e, out ln2);
      Console.WriteLine(" Pi = " + pi);
      Console.WriteLine("  E = " + e);
      Console.WriteLine("ln2 = " + ln2);
    }
  }
}
