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
            #endregion
        }
    }
}
