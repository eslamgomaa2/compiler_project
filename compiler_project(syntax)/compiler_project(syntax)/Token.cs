using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_project_syntax_
{
    public enum TokenType
    {
        Identifier,
        Number,
        Operator,
        SpecialCharacter,
        Keyword
    }
    public class Token
    {
        public TokenType Type { get; set; }
        public string element { get; set; }

        public Token(TokenType type, string element)
        {
            Type = type;
            element = element;
        }

        public override string ToString()
        {
            return $"({Type}, {element})";
        }
    }

}
