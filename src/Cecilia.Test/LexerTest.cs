using Cecilia.Lib;
using Xunit;

namespace Cecilia.Test
{
    public class LexerTest
    {
        [Fact(DisplayName = "GetTokenKindTest")]
        public void GetTokenKindTest()
        {
            Assert.Equal((TokenKind.Whitespace, 1), new Lexer().GetTokenKind(" ", 0));
            #region Sign and punction test
            Assert.Equal((TokenKind.LParen, 1), new Lexer().GetTokenKind("(", 0));
            Assert.Equal((TokenKind.RParen, 1), new Lexer().GetTokenKind(")", 0));
            Assert.Equal((TokenKind.LBrace, 1), new Lexer().GetTokenKind("{", 0));
            Assert.Equal((TokenKind.RBrace, 1), new Lexer().GetTokenKind("}", 0));
            Assert.Equal((TokenKind.LBracket, 1), new Lexer().GetTokenKind("[", 0));
            Assert.Equal((TokenKind.RBracket, 1), new Lexer().GetTokenKind("]", 0));
            Assert.Equal((TokenKind.Exclamation, 1), new Lexer().GetTokenKind("!", 0));
            Assert.Equal((TokenKind.Dollar, 1), new Lexer().GetTokenKind("$", 0));
            Assert.Equal((TokenKind.Parcent, 1), new Lexer().GetTokenKind("%", 0));
            Assert.Equal((TokenKind.Caret, 1), new Lexer().GetTokenKind("^", 0));
            Assert.Equal((TokenKind.Ampersand, 1), new Lexer().GetTokenKind("&", 0));
            Assert.Equal((TokenKind.Asterisk, 1), new Lexer().GetTokenKind("*", 0));
            Assert.Equal((TokenKind.Minus, 1), new Lexer().GetTokenKind("-", 0));
            Assert.Equal((TokenKind.Plus, 1), new Lexer().GetTokenKind("+", 0));
            Assert.Equal((TokenKind.Equals, 1), new Lexer().GetTokenKind("=", 0));
            Assert.Equal((TokenKind.Bar, 1), new Lexer().GetTokenKind("|", 0));
            Assert.Equal((TokenKind.Backslash, 1), new Lexer().GetTokenKind("\\", 0));
            Assert.Equal((TokenKind.Colon, 1), new Lexer().GetTokenKind(":", 0));
            Assert.Equal((TokenKind.SemiColon, 1), new Lexer().GetTokenKind(";", 0));
            Assert.Equal((TokenKind.DoubleQuote, 1), new Lexer().GetTokenKind("\"", 0));
            Assert.Equal((TokenKind.SingleQuote, 1), new Lexer().GetTokenKind("'", 0));
            Assert.Equal((TokenKind.LessThan, 1), new Lexer().GetTokenKind("<", 0));
            Assert.Equal((TokenKind.GreaterThan, 1), new Lexer().GetTokenKind(">", 0));
            Assert.Equal((TokenKind.Comma, 1), new Lexer().GetTokenKind(",", 0));
            Assert.Equal((TokenKind.Dot, 1), new Lexer().GetTokenKind(".", 0));
            Assert.Equal((TokenKind.Question, 1), new Lexer().GetTokenKind("?", 0));
            Assert.Equal((TokenKind.Hash, 1), new Lexer().GetTokenKind("#", 0));
            Assert.Equal((TokenKind.Slash, 1), new Lexer().GetTokenKind("/", 0));
            #endregion
        }
    }
}
