using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scanner
{
    public class TokenProcessor
    {
        private static readonly List<string> Keywords = new List<string>
    {
        "if", "else", "elseif", "for", "while", "do",
        "return", "public", "private", "protected", "package",
        "new", "int", "double", "float", "const", // Removed duplicate "static"
        "char", "goto", "boolean", "long", "void", "this",
        "try", "catch", "true", "print", "enter", "String"
    };

        private static readonly List<string> Symbols = new List<string>
    {
        "!", "&", "^", "%", "$", "#", "@", "?", "~",
        "(", ")", "{", "}", ";", "'"
    };

        private static readonly List<string> Operations = new List<string>
    {
        "+", "-", "*", "/", "="
    };

        private static readonly List<string> LogicalOperations = new List<string>
    {
        "||", "&&", "==", "<=", ">=", ">", "<"
    };

        private static readonly string IdentifierPattern = "[a-zA-Z]+";
        private static readonly string DigitPattern = "[0-9]+";
        private static readonly string CommentPattern = @"\/\*.*\*\/"; // Matches comments between /* and */
        private static readonly string OutputPattern = @"'\w'"; // Matches a single character within single quotes

        public static void ScanToken(string token, ref int line)
        {
            try
            {
                string tokenCategory = GetTokenCategory(token);

                Console.WriteLine($"<{token},{tokenCategory}>");

                if (token.EndsWith(";"))
                {
                    line++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in token at line {line}: {e.Message}");
            }
        }

        private static string GetTokenCategory(string token)
        {
            if (Keywords.Contains(token))
                return "Keyword";

            if (Symbols.Contains(token))
                return "Symbol";

            if (Operations.Contains(token))
                return "Operation";

            if (LogicalOperations.Contains(token))
                return "Logical Operation";

            if (Regex.IsMatch(token, IdentifierPattern))
                return "Identifier";

            if (Regex.IsMatch(token, CommentPattern))
                return "Comment";

            if (Regex.IsMatch(token, DigitPattern))
                return "Digit";

            if (Regex.IsMatch(token, OutputPattern))
                return "Output to the user";

            throw new InvalidOperationException($"Unknown token category for '{token}'");
        }
    }
}
