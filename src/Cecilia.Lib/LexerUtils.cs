using System.Collections.Generic;
using System.Linq;

namespace Cecilia.Lib
{
    public class LexerUtils
    {
        public static List<char> SyntaxPunctuationsTable { get; } = new List<char> {
            '(',
            ')',
            '{',
            '}',
            '[',
            ']',
            '!',
            '!',
            '$',
            '%',
            '^',
            '&',
            '*',
            '-',
            '+',
            '=',
            '|',
            '\\',
            ':',
            ';',
            '\"',
            '\'',
            '<',
            '>',
            ',',
            '.',
            '?',
            '#',
            '/',
        };

        public bool IsSyntaxPunctuation(char targetChar)
        {
            return SyntaxPunctuationsTable.Any(x => x == targetChar);
        }
    }
}
