using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenOp {
  public class Token {
    public enum TokenType {
      Variable, Operation
    }

    private string _value;
    public string Value => _value;

    private TokenType _type;
    public TokenType Type => _type;

    public Token(string value, TokenType type) {
      _value = value;
      _type = type;
    }
  }
}
