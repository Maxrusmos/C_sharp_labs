using System;
using ComplexOp;

namespace EventCustomOp {
  public sealed class EventCustom : EventArgs {
    private ComplexNum _numLeft;
    private ComplexNum _numRight;

    public EventCustom(ComplexNum numerator, ComplexNum denumerator) {
      _numLeft = numerator;
      _numRight = denumerator;
    }

    public override string ToString() {
      return $"Деление на ноль {_numLeft} / {_numRight}";
    }
  }
}
