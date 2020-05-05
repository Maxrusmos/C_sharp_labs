namespace MVVM {
  public class Token {
    public enum TokenType {
      Variable, Operation
    }

    public string Value { get; private set; }
    public TokenType Type { get; private set; }

    public Token(string value, TokenType type) {
      Value = value;
      Type = type;
    }
  }
}
