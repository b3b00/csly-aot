using System;
using System.Data;
using sly.parser;
using sly.parser.generator;

namespace ns
{
    public class Program {


        public static void UnTrim(SimpleExpressionParser p)
        {
            try
            {
                p.PLUS(1, null, 2);
                p.MINUS(1, null, 2);
                p.TIMES(1, null, 2);
                p.DIVIDE(1, null, 2);
                p.FACTORIAL(1,  null);
                p.primaryvalue_DOUBLE(null);
                p.primaryvalue_LPAREN_SimpleExpressionParserexpressions_RPAREN(null, 1, null);
                p.root_SimpleExpressionParserexpressions(1);
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"untrim exception : {e.Message}");
            }
        }
        
        
        public static void Main(string[] args ) {
            
            Console.WriteLine("start");
            var parserInstance = new SimpleExpressionParser();
            
            Console.WriteLine("instance built");
            UnTrim(parserInstance);
            Console.WriteLine("untrimmed");
        var builder = new ParserBuilder<SimpleExpressionToken, double>();
        Console.WriteLine("builder built.");
        var built = builder.BuildParser(parserInstance, ParserType.EBNF_LL_RECURSIVE_DESCENT, "root");
        
        if (built.IsOk)
        {
            Console.WriteLine("parser built OK.");    
            Console.WriteLine(built.Result.Configuration.Dump());
            foreach (var nonTerminal in built.Result.Configuration.NonTerminals)
            {
                Console.WriteLine(nonTerminal.Key);
            }
            var r = built.Result.Parse(string.Join(" ", args));
            Console.WriteLine("parse done");
            if (r.IsOk)
            {
                Console.WriteLine("parse OK");
                Console.WriteLine(r.Result);
            }
            else
            {
                foreach (var error in r.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
        }
        else
        {
            Console.WriteLine("parser construction KO");
            foreach (var error in built.Errors)
            {
                Console.WriteLine($"[{error.Code}] {error.Message}");
            }
        }

        }
    }
}