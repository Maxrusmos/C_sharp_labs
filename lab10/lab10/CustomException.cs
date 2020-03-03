using System;

namespace CExeption {
  public class CustomException : Exception {
    public CustomException(string message) : base(message) { }
  }
}
