using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OpenInNotepadOp {
  class OpenInNotepad {
    public static void openFile(List<string> list, int count) {
      try {
        Process.Start("C:/Windows/System32/notepad.exe", list[count - 1]);
      }
      catch (AggregateException ex){
        foreach (var e in ex.InnerExceptions) {
          throw e;
        }
      }
    }
  }
}
