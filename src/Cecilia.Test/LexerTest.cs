/* Copyright 2019 masato sueda

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License. */
using Cecilia.Lib;
using Xunit;

namespace Cecilia.Test
{
    public class LexerTest
    {
        #region Sign and punction test
        [Fact(DisplayName = "GetSinglePunctuationTokenTest")]
        public void GetSinglePunctuationTokenTest()
        {
            Assert.Equal((TokenKind.Whitespace, 1), new Lexer().GetTokenKind(" ", 0));

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
        }
        #endregion

        #region Double punction test
        [Fact(DisplayName = "GetDoublePunctuationTokenTest")]
        public void GetDoublePunctuationTokenTest()
        {
            Assert.Equal((TokenKind.SingleLineComment, 2), new Lexer().GetTokenKind("//", 0));
            Assert.Equal((TokenKind.MultiLineCommentStart, 2), new Lexer().GetTokenKind("/*", 0));
            Assert.Equal((TokenKind.MultiLineCommentEnd, 2), new Lexer().GetTokenKind("*/", 0));

            Assert.Equal((TokenKind.BarBar, 2), new Lexer().GetTokenKind("||", 0));
            Assert.Equal((TokenKind.AmpAmp, 2), new Lexer().GetTokenKind("&&", 0));
            Assert.Equal((TokenKind.MinusMinus, 2), new Lexer().GetTokenKind("--", 0));
            Assert.Equal((TokenKind.PlusPlus, 2), new Lexer().GetTokenKind("++", 0));
            Assert.Equal((TokenKind.QuestionQuestion, 2), new Lexer().GetTokenKind("??", 0));
            Assert.Equal((TokenKind.EqualsEquals, 2), new Lexer().GetTokenKind("==", 0));
            Assert.Equal((TokenKind.ExclamationEquals, 2), new Lexer().GetTokenKind("!=", 0));
            Assert.Equal((TokenKind.Arrow, 2), new Lexer().GetTokenKind("=>", 0));
            Assert.Equal((TokenKind.LessThanEqual, 2), new Lexer().GetTokenKind("<=", 0));
            Assert.Equal((TokenKind.GreaterThanEqual, 2), new Lexer().GetTokenKind(">=", 0));
            Assert.Equal((TokenKind.LessThanLessThan, 2), new Lexer().GetTokenKind("<<", 0));
            Assert.Equal((TokenKind.GreaterThanGreaterThan, 2), new Lexer().GetTokenKind(">>", 0));
            Assert.Equal((TokenKind.PlusEqual, 2), new Lexer().GetTokenKind("+=", 0));
            Assert.Equal((TokenKind.MinusEqual, 2), new Lexer().GetTokenKind("-=", 0));
            Assert.Equal((TokenKind.AsteriskEqual, 2), new Lexer().GetTokenKind("*=", 0));
            Assert.Equal((TokenKind.SlashEqual, 2), new Lexer().GetTokenKind("/=", 0));
            Assert.Equal((TokenKind.BarEqual, 2), new Lexer().GetTokenKind("|=", 0));
            Assert.Equal((TokenKind.CaretEqual, 2), new Lexer().GetTokenKind("^=", 0));
        }
        #endregion

        #region Triple punction test
        [Fact(DisplayName = "GetTriplePunctuationTokenTest")]
        public void GetTriplePunctuationTokenTest()
        {
            Assert.Equal((TokenKind.LessThanLessThanEqual, 3), new Lexer().GetTokenKind("<<=", 0));
            Assert.Equal((TokenKind.GreaterThanGreaterThanEqual, 3), new Lexer().GetTokenKind(">>=", 0));
        }
        #endregion

        #region embedded type keywords test
        [Fact(DisplayName = "EmbeddedTypeKeywordTest")]
        public void GetEmbeddedTypeKeywordTest()
        {
            Assert.Equal((TokenKind.VoidKeyword, 4), new Lexer().GetTokenKind("void", 0));
            Assert.Equal((TokenKind.Int8Keyword, 4), new Lexer().GetTokenKind("int8", 0));
            Assert.Equal((TokenKind.Int16Keyword, 5), new Lexer().GetTokenKind("int16", 0));
            Assert.Equal((TokenKind.Int32Keyword, 5), new Lexer().GetTokenKind("int32", 0));
            Assert.Equal((TokenKind.Int64Keyword, 5), new Lexer().GetTokenKind("int64", 0));
            Assert.Equal((TokenKind.UInt8Keyword, 5), new Lexer().GetTokenKind("uint8", 0));
            Assert.Equal((TokenKind.UInt16Keyword, 6), new Lexer().GetTokenKind("uint16", 0));
            Assert.Equal((TokenKind.UInt32Keyword, 6), new Lexer().GetTokenKind("uint32", 0));
            Assert.Equal((TokenKind.UInt64Keyword, 6), new Lexer().GetTokenKind("uint64", 0));
            Assert.Equal((TokenKind.HalfKeyword, 4), new Lexer().GetTokenKind("half", 0));
            Assert.Equal((TokenKind.FloatKeyword, 5), new Lexer().GetTokenKind("float", 0));
            Assert.Equal((TokenKind.DoubleKeyword, 6), new Lexer().GetTokenKind("double", 0));
            Assert.Equal((TokenKind.BoolKeyword, 4), new Lexer().GetTokenKind("bool", 0));
            Assert.Equal((TokenKind.CharKeyword, 4), new Lexer().GetTokenKind("char", 0));
            Assert.Equal((TokenKind.StringKeyword, 6), new Lexer().GetTokenKind("string", 0));
            Assert.Equal((TokenKind.ObjectKeyword, 6), new Lexer().GetTokenKind("object", 0));
        }
        #endregion

        #region identifier test
        [Fact(DisplayName = "GetIdentifierTest")]
        public void GetIdentifierTest()
        {
            Assert.Equal((TokenKind.Identifier, 8), new Lexer().GetTokenKind("xxxx0123", 0));
        }
        #endregion

        #region namespace and access modifier keywords test
        [Fact(DisplayName = "GetNamespaceAccessModifierTest")]
        public void GetNamespaceAccessModifierTest()
        {
            Assert.Equal((TokenKind.NamespaceKeyword, 9), new Lexer().GetTokenKind("namespace", 0));
            Assert.Equal((TokenKind.PublicKeyword, 6), new Lexer().GetTokenKind("public", 0));
            Assert.Equal((TokenKind.PrivateKeyword, 7), new Lexer().GetTokenKind("private", 0));
            Assert.Equal((TokenKind.ProtectedKeyword, 9), new Lexer().GetTokenKind("protected", 0));
            Assert.Equal((TokenKind.InternalKeyword, 8), new Lexer().GetTokenKind("internal", 0));
            Assert.Equal((TokenKind.UsingKeyword, 5), new Lexer().GetTokenKind("using", 0));
        }
        #endregion
    }
}
