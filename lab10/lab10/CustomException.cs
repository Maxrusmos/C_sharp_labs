using System;

namespace CExeption {
  public class CustomException : ArgumentException {
    public CustomException(string message) : base(message) { }
  }
}
