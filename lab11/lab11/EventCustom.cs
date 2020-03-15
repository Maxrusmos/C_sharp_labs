using System;
using System.Collections.Generic;
using System.Text;

namespace EventCustomOp {
  public class EventCustom : EventArgs {
    public string _message;

    public EventCustom() {
      this._message = "Деление на ноль";
    }

    public override string ToString() {
      return this._message; 
    }
  }
}
