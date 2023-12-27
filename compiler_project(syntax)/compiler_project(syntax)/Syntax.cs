using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_project_syntax_
{
    public class Syntax
    {
        public List<Token> tokens;
        public int i=0;

        public Syntax(List<Token> tokens)
        {
            this.tokens = tokens;
            
        }

        public void Parse()
        {
            try
            {
                // Start parsing from the first token
                ParseExpression();

                // If parsing is successful and there are no extra tokens, the syntax is correct
                if (i == tokens.Count)
                {
                    Console.WriteLine("Syntax is correct!");
                }
                else
                {
                    Console.WriteLine($"Syntax error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void ParseExpression()
        {
            // An expression can start with either a number or an identifier
            if (IsNumber() || IsIdentifier())
            {
                // Consume the token and move to the next one
                ConsumeToken();

                // If there is an operator (+ or -), recursively parse the rest of the expression
                if (IsOperator())
                {
                    ConsumeToken();
                    ParseExpression();
                }
            }
            else
            {
                // If the token is not a number or an identifier, raise an error
                throw new Exception($"Unexpected token '{tokens[i].element}' at position {i}");
            }
        }

        private bool IsNumber()
        {
            return i < tokens.Count && tokens[i].Type == TokenType.Number;
        }

        private bool IsIdentifier()
        {
            return i < tokens.Count && tokens[i].Type == TokenType.Identifier;
        }

        private bool IsOperator()
        {
            return i < tokens.Count && tokens[i].Type == TokenType.Operator;
        }

        private void ConsumeToken()
        {
            // Move to the next token
            i++;
        }
    }
}
