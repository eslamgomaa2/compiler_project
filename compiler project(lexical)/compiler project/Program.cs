using System;
using System.Collections.Generic;
using System.Linq;

public enum TokenType
{
    Identifier,
    Number,
    Operator,
    special_character,
    Keyword
}

public class Token
{
    public TokenType Type { get; set; }
    public string Lexeme { get; set; }

    public Token(TokenType type, string lexeme)
    {
        Type = type;
        Lexeme = lexeme;
    }

    public override string ToString()
    {
        return $"({Type}, {Lexeme})";
    }
}

public class Lexer
{
    private readonly string sourceCode;
    private int currentPosition = 0;

    private static readonly char[] Operators = { '+', '-', '*', '/', '=' };
    private static readonly char[] special_character = { '(', ')', '{', '}', ',', ';' };
    private static readonly string[] Keywords = { "if", "else", "while", "int", "float" };

    public Lexer(string sourceCode)
    {
        this.sourceCode = sourceCode;
    }

    public List<Token> Analyze()
    {
        List<Token> tokens = new List<Token>();

        while (currentPosition < sourceCode.Length)
        {
            char currentChar = sourceCode[currentPosition];

            if (char.IsWhiteSpace(currentChar))
            {
                currentPosition++; 
            }
            else if (char.IsLetter(currentChar))
            {
                string identifier = ReadWhile(char.IsLetterOrDigit);
                TokenType type = Keywords.Contains(identifier) ? TokenType.Keyword : TokenType.Identifier;
                tokens.Add(new Token(type, identifier));
            }
            else if (char.IsDigit(currentChar))
            {
                tokens.Add(new Token(TokenType.Number, ReadWhile(char.IsDigit)));
            }
            else if (Operators.Contains(currentChar))
            {
                tokens.Add(new Token(TokenType.Operator, currentChar.ToString()));
                currentPosition++;
            }
            else if (special_character.Contains(currentChar))
            {
                tokens.Add(new Token(TokenType.special_character, currentChar.ToString()));
                currentPosition++;
            }
            else
            {
                Console.WriteLine($"Error: Unknown character '{currentChar}' at position {currentPosition}");
                currentPosition++;
            }
        }

        return tokens;
    }

    private string ReadWhile(Func<char, bool> condition)
    {
        int start = currentPosition;
        while (currentPosition < sourceCode.Length && condition(sourceCode[currentPosition]))
        {
            currentPosition++;
        }
        return sourceCode.Substring(start, currentPosition - start);
    }
}

class Program
{
    static void Main()
    {
        string sourceCode = "int main() { return 0; }";
        Lexer lexer = new Lexer(sourceCode);
        List<Token> tokens = lexer.Analyze();

        foreach (Token token in tokens)
        {
            Console.WriteLine(token);
        }
    }
}
