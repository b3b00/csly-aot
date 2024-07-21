using sly.lexer;
using sly.lexer.fsm;
using sly.i18n;

namespace ns
{
    public enum SimpleExpressionToken
    {
        [Double]
        DOUBLE,
        [AlphaId]
        IDENTIFIER,
        [Sugar("+")]
        PLUS,
        [Sugar("++")]
        INCREMENT,
        [Sugar("-")]
        MINUS,
        [Sugar("*")]
        TIMES,
        [Sugar("/")]
        DIVIDE,
        [Sugar("(")]
        LPAREN,
        [Sugar(")")]
        RPAREN,
        [Sugar("!")]
        FACTORIAL,
    }
}