using System;
using System.IO;
using System.Threading.Tasks;

namespace WorkWithFile {
  public static class WorkWithFile {
    public static void FileParse(string fileName, out int wholePart, out double fractionalPart, out string number, out int numBase) {
      wholePart = 0;
      fractionalPart = 0.0;
      numBase = 10;
      number = "";
      var pathPart = @"C:\Users\vmaxi\Desktop\3_6sem\РПКС\labs\lab05\lab05\"; // часть путь к файлу
      if (fileName.Length != 0) {
        try {
          using (StreamReader sr = new StreamReader(pathPart + fileName)) {
            var fromFileArr = sr.ReadToEnd().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (fromFileArr.Length != 2) {
              Console.ForegroundColor = ConsoleColor.Red;
              if (fromFileArr.Length > 2) {
                Console.WriteLine("В файле есть что-то лишнее.");
              } else {
                Console.WriteLine("В файле чего-то не хватает.");
              }
              System.Environment.Exit(1);
            }

            if (!double.TryParse(fromFileArr[0], out double number1)) {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("Число в файле является некорректным.");
              System.Environment.Exit(2);
            } else {
              number = fromFileArr[0];
            }

            if (!int.TryParse(fromFileArr[1], out int number2)) {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("Система счисления не является числом.");
              System.Environment.Exit(3);
            }

            numBase = int.Parse(fromFileArr[1]); //сс

            if (numBase < 2 || numBase > 36) {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("Система счисления в файле является некорректной.");
              System.Environment.Exit(4);
            }

            wholePart = int.Parse(fromFileArr[0].Split(',')[0]);
            fractionalPart = double.Parse(fromFileArr[0]) % wholePart;
          }
        }
        catch (Exception e) {
          Console.WriteLine(e.Message);
          System.Environment.Exit(5);
        }
      }
    }
  }
}
