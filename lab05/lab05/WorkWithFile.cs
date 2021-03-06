﻿using System;
using System.IO;
using CorrectEnter;

namespace WorkWithFile {
  public static class WorkWithFile {
    public static void FileParse(string fileName, out int wholePart, out double fractionalPart, out string number, out int numBase) {
      wholePart = 0;
      fractionalPart = 0.0;
      numBase = 10;
      number = "";
      var pathPart = @"C:\Users\vmaxi\Desktop\3_6sem\РПКС\labs\lab05\lab05\"; 
      if (fileName.Length != 0) {
        try {
          using (StreamReader sr = new StreamReader(pathPart + fileName)) {
            var fromFileArr = sr.ReadToEnd().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (fromFileArr.Length != 2) {
              Console.ForegroundColor = ConsoleColor.Red;
              if (fromFileArr.Length > 2) {
                throw new ArgumentException("В файле есть что-то лишнее" + Environment.NewLine);
              } else {
                throw new ArgumentException("В файле чего то не хватает" + Environment.NewLine);
              }
            }

            CorrectEnter.CorrectEnter.CorrectEnterFile(fromFileArr[0]); 
            number = fromFileArr[0];
            CorrectEnter.CorrectEnter.CorrectEnterBase(fromFileArr[1]);
            numBase = int.Parse(fromFileArr[1]); 
            wholePart = int.Parse(fromFileArr[0].Split(',')[0]);
            fractionalPart = double.Parse(fromFileArr[0]) % wholePart;
          }
        }
        catch (FileNotFoundException e) {
          Console.WriteLine(e.Message);
        }
      }
    }
  }
}
