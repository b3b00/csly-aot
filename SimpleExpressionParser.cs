using sly.lexer;
using sly.parser.generator;
using System.Collections.Generic;
using sly.parser.parser;

namespace ns
{
    [ParserRoot("root")]
    public class SimpleExpressionParser
    {
        [Production("root : SimpleExpressionParser_expressions")]
        public double root_SimpleExpressionParserexpressions(double p0)
        {
            return p0;
        }

        [Infix("PLUS", Associativity.Right, 10)]
        public double PLUS(double left, Token<SimpleExpressionToken> oper, double right)
        {
            return left + right;
        }

        [Infix("MINUS", Associativity.Left, 10)]
        public double MINUS(double left, Token<SimpleExpressionToken> oper, double right)
        {
            return left - right;
        }

        [Infix("TIMES", Associativity.Right, 50)]
        public double TIMES(double left, Token<SimpleExpressionToken> oper, double right)
        {
            return left * right;
        }

        [Infix("DIVIDE", Associativity.Left, 50)]
        public double DIVIDE(double left, Token<SimpleExpressionToken> oper, double right)
        {
            return left / right;
        }

        [Prefix("MINUS", Associativity.Left, 100)]
        public double MINUS(Token<SimpleExpressionToken> oper, double value)
        {
            return -value;
        }

        [Postfix("FACTORIAL", Associativity.Left, 100)]
        public double FACTORIAL(double value, Token<SimpleExpressionToken> oper)
        {
            return value;
        }

        [Operand]
        [Production("primary_value : DOUBLE")]
        public double primaryvalue_DOUBLE(Token<SimpleExpressionToken> p0)
        {
            return p0.DoubleValue;
        }
        [Operand]
        [Production("primary_value : LPAREN SimpleExpressionParser_expressions RPAREN")]
        public double primaryvalue_LPAREN_SimpleExpressionParserexpressions_RPAREN(Token<SimpleExpressionToken> p0, double p1, Token<SimpleExpressionToken> p2)
        {
            return p1;
        }
    }
}