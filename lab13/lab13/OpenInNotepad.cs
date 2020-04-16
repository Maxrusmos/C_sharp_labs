using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OpenInNotepadOp {
  class OpenInNotepad {
    public static void openFile(List<string> list, int count) {
      try {
        Process.Start("C:/Windows/System32/notepad.exe", list[count - 1]);
      }
      //исправить (шайтан)
      catch {
        throw new ArgumentException("Не удалось открыть файл", nameof(list));
      }
    }
  }
}
