using System;
using System.Collections.Generic;
using System.Text;

namespace EventCustomOp {
  public class EventCustom : EventArgs {
    public double _real, _imaginary;

    public EventCustom(double r, double i) {
      this._real = r;
      this._imaginary = i;
    }
  }
}
