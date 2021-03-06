﻿using System;
using System.IO.Compression;
using System.IO;

namespace FileCompressOp {
  sealed class FileCompress {
    public static void Compress(string sourceFile, string compressedFile) {
      try {
        using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate)) {
          using (FileStream targetStream = File.Create(compressedFile)) {
            using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress)) {
              sourceStream.CopyTo(compressionStream);
              Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                  sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
            }
          }
        }
      }
      catch (AggregateException ex) {
        foreach (var e in ex.InnerExceptions) {
          throw e;
        }
      }
    }
  }
}