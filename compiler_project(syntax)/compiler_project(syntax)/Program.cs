using compiler_project_syntax_;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Example tokens (generated from lexical analysis phase)
        List<Token> tokens = new List<Token>
        {
            new Token(TokenType.Number, "10"),
            new Token(TokenType.Operator, "+"),
            new Token(TokenType.Identifier, "x"),
            new Token(TokenType.Operator, "-"),
            new Token(TokenType.Number, "5"),
            new Token(TokenType.SpecialCharacter, ";")
        };

        // Create a SyntaxAnalyzer and parse the tokens
        Syntax syntaxAnalyzer = new Syntax(tokens);
        syntaxAnalyzer.Parse();
    }
}
