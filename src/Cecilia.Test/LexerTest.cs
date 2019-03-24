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
            Assert.Equal((SyntaxKind.Whitespace, 1, null), new Lexer().GetTokenKind(" ", 0));

            Assert.Equal((SyntaxKind.LParen, 1, null), new Lexer().GetTokenKind("(", 0));
            Assert.Equal((SyntaxKind.RParen, 1, null), new Lexer().GetTokenKind(")", 0));
            Assert.Equal((SyntaxKind.LBrace, 1, null), new Lexer().GetTokenKind("{", 0));
            Assert.Equal((SyntaxKind.RBrace, 1, null), new Lexer().GetTokenKind("}", 0));
            Assert.Equal((SyntaxKind.LBracket, 1, null), new Lexer().GetTokenKind("[", 0));
            Assert.Equal((SyntaxKind.RBracket, 1, null), new Lexer().GetTokenKind("]", 0));
            Assert.Equal((SyntaxKind.Exclamation, 1, null), new Lexer().GetTokenKind("!", 0));
            Assert.Equal((SyntaxKind.Dollar, 1, null), new Lexer().GetTokenKind("$", 0));
            Assert.Equal((SyntaxKind.Parcent, 1, null), new Lexer().GetTokenKind("%", 0));
            Assert.Equal((SyntaxKind.Caret, 1, null), new Lexer().GetTokenKind("^", 0));
            Assert.Equal((SyntaxKind.Ampersand, 1, null), new Lexer().GetTokenKind("&", 0));
            Assert.Equal((SyntaxKind.Asterisk, 1, null), new Lexer().GetTokenKind("*", 0));
            Assert.Equal((SyntaxKind.Minus, 1, null), new Lexer().GetTokenKind("-", 0));
            Assert.Equal((SyntaxKind.Plus, 1, null), new Lexer().GetTokenKind("+", 0));
            Assert.Equal((SyntaxKind.Equals, 1, null), new Lexer().GetTokenKind("=", 0));
            Assert.Equal((SyntaxKind.Bar, 1, null), new Lexer().GetTokenKind("|", 0));
            Assert.Equal((SyntaxKind.Backslash, 1, null), new Lexer().GetTokenKind("\\", 0));
            Assert.Equal((SyntaxKind.Colon, 1, null), new Lexer().GetTokenKind(":", 0));
            Assert.Equal((SyntaxKind.SemiColon, 1, null), new Lexer().GetTokenKind(";", 0));
            Assert.Equal((SyntaxKind.DoubleQuote, 1, null), new Lexer().GetTokenKind("\"", 0));
            Assert.Equal((SyntaxKind.SingleQuote, 1, null), new Lexer().GetTokenKind("'", 0));
            Assert.Equal((SyntaxKind.LessThan, 1, null), new Lexer().GetTokenKind("<", 0));
            Assert.Equal((SyntaxKind.GreaterThan, 1, null), new Lexer().GetTokenKind(">", 0));
            Assert.Equal((SyntaxKind.Comma, 1, null), new Lexer().GetTokenKind(",", 0));
            Assert.Equal((SyntaxKind.Dot, 1, null), new Lexer().GetTokenKind(".", 0));
            Assert.Equal((SyntaxKind.Question, 1, null), new Lexer().GetTokenKind("?", 0));
            Assert.Equal((SyntaxKind.Hash, 1, null), new Lexer().GetTokenKind("#", 0));
            Assert.Equal((SyntaxKind.Slash, 1, null), new Lexer().GetTokenKind("/", 0));
        }
        #endregion

        #region Double punction test
        [Fact(DisplayName = "GetDoublePunctuationTokenTest")]
        public void GetDoublePunctuationTokenTest()
        {
            Assert.Equal((SyntaxKind.SingleLineComment, 2, null), new Lexer().GetTokenKind("//", 0));
            Assert.Equal((SyntaxKind.MultiLineCommentStart, 2, null), new Lexer().GetTokenKind("/*", 0));
            Assert.Equal((SyntaxKind.MultiLineCommentEnd, 2, null), new Lexer().GetTokenKind("*/", 0));

            Assert.Equal((SyntaxKind.BarBar, 2, null), new Lexer().GetTokenKind("||", 0));
            Assert.Equal((SyntaxKind.AmpAmp, 2, null), new Lexer().GetTokenKind("&&", 0));
            Assert.Equal((SyntaxKind.MinusMinus, 2, null), new Lexer().GetTokenKind("--", 0));
            Assert.Equal((SyntaxKind.PlusPlus, 2, null), new Lexer().GetTokenKind("++", 0));
            Assert.Equal((SyntaxKind.QuestionQuestion, 2, null), new Lexer().GetTokenKind("??", 0));
            Assert.Equal((SyntaxKind.EqualsEquals, 2, null), new Lexer().GetTokenKind("==", 0));
            Assert.Equal((SyntaxKind.ExclamationEquals, 2, null), new Lexer().GetTokenKind("!=", 0));
            Assert.Equal((SyntaxKind.Arrow, 2, null), new Lexer().GetTokenKind("=>", 0));
            Assert.Equal((SyntaxKind.LessThanEqual, 2, null), new Lexer().GetTokenKind("<=", 0));
            Assert.Equal((SyntaxKind.GreaterThanEqual, 2, null), new Lexer().GetTokenKind(">=", 0));
            Assert.Equal((SyntaxKind.LessThanLessThan, 2, null), new Lexer().GetTokenKind("<<", 0));
            Assert.Equal((SyntaxKind.GreaterThanGreaterThan, 2, null), new Lexer().GetTokenKind(">>", 0));
            Assert.Equal((SyntaxKind.PlusEqual, 2, null), new Lexer().GetTokenKind("+=", 0));
            Assert.Equal((SyntaxKind.MinusEqual, 2, null), new Lexer().GetTokenKind("-=", 0));
            Assert.Equal((SyntaxKind.AsteriskEqual, 2, null), new Lexer().GetTokenKind("*=", 0));
            Assert.Equal((SyntaxKind.SlashEqual, 2, null), new Lexer().GetTokenKind("/=", 0));
            Assert.Equal((SyntaxKind.BarEqual, 2, null), new Lexer().GetTokenKind("|=", 0));
            Assert.Equal((SyntaxKind.CaretEqual, 2, null), new Lexer().GetTokenKind("^=", 0));
            Assert.Equal((SyntaxKind.CaretEqual, 2, null), new Lexer().GetTokenKind("^=", 0));
        }
        #endregion

        #region Triple punction test
        [Fact(DisplayName = "GetTriplePunctuationTokenTest")]
        public void GetTriplePunctuationTokenTest()
        {
            Assert.Equal((SyntaxKind.LessThanLessThanEqual, 3, null), new Lexer().GetTokenKind("<<=", 0));
            Assert.Equal((SyntaxKind.GreaterThanGreaterThanEqual, 3, null), new Lexer().GetTokenKind(">>=", 0));
        }
        #endregion

        #region embedded type keywords test
        [Fact(DisplayName = "EmbeddedTypeKeywordTest")]
        public void GetEmbeddedTypeKeywordTest()
        {
            Assert.Equal((SyntaxKind.VoidKeyword, 4, null), new Lexer().GetTokenKind("void", 0));
            Assert.Equal((SyntaxKind.Int8Keyword, 4, null), new Lexer().GetTokenKind("int8", 0));
            Assert.Equal((SyntaxKind.Int16Keyword, 5, null), new Lexer().GetTokenKind("int16", 0));
            Assert.Equal((SyntaxKind.Int32Keyword, 5, null), new Lexer().GetTokenKind("int32", 0));
            Assert.Equal((SyntaxKind.Int64Keyword, 5, null), new Lexer().GetTokenKind("int64", 0));
            Assert.Equal((SyntaxKind.UInt8Keyword, 5, null), new Lexer().GetTokenKind("uint8", 0));
            Assert.Equal((SyntaxKind.UInt16Keyword, 6, null), new Lexer().GetTokenKind("uint16", 0));
            Assert.Equal((SyntaxKind.UInt32Keyword, 6, null), new Lexer().GetTokenKind("uint32", 0));
            Assert.Equal((SyntaxKind.UInt64Keyword, 6, null), new Lexer().GetTokenKind("uint64", 0));
            Assert.Equal((SyntaxKind.HalfKeyword, 4, null), new Lexer().GetTokenKind("half", 0));
            Assert.Equal((SyntaxKind.FloatKeyword, 5, null), new Lexer().GetTokenKind("float", 0));
            Assert.Equal((SyntaxKind.DoubleKeyword, 6, null), new Lexer().GetTokenKind("double", 0));
            Assert.Equal((SyntaxKind.BoolKeyword, 4, null), new Lexer().GetTokenKind("bool", 0));
            Assert.Equal((SyntaxKind.CharKeyword, 4, null), new Lexer().GetTokenKind("char", 0));
            Assert.Equal((SyntaxKind.StringKeyword, 6, null), new Lexer().GetTokenKind("string", 0));
            Assert.Equal((SyntaxKind.ObjectKeyword, 6, null), new Lexer().GetTokenKind("object", 0));
        }
        #endregion

        #region identifier test
        [Fact(DisplayName = "GetIdentifierTest")]
        public void GetIdentifierTest()
        {
            Assert.Equal((SyntaxKind.Identifier, 8, "xxxx0123"), new Lexer().GetTokenKind("xxxx0123", 0));
        }
        #endregion

        #region number test
        [Fact(DisplayName = "GetNumberTest")]
        public void GetNumberTest()
        {
            Assert.Equal((SyntaxKind.IntegerLiteral, 3, "123"), new Lexer().GetTokenKind("123", 0));
            Assert.Equal((SyntaxKind.FloatingLiteral, 7, "123.456"), new Lexer().GetTokenKind("123.456", 0));
            Assert.Equal((SyntaxKind.Unknown, 7, null), new Lexer().GetTokenKind("12.3.45", 0));
        }
        #endregion

        #region namespace and access modifier keywords test
        [Fact(DisplayName = "GetNamespaceAccessModifierTest")]
        public void GetNamespaceAccessModifierTest()
        {
            Assert.Equal((SyntaxKind.NamespaceKeyword, 9, null), new Lexer().GetTokenKind("namespace", 0));
            Assert.Equal((SyntaxKind.PublicKeyword, 6, null), new Lexer().GetTokenKind("public", 0));
            Assert.Equal((SyntaxKind.PrivateKeyword, 7, null), new Lexer().GetTokenKind("private", 0));
            Assert.Equal((SyntaxKind.ProtectedKeyword, 9, null), new Lexer().GetTokenKind("protected", 0));
            Assert.Equal((SyntaxKind.InternalKeyword, 8, null), new Lexer().GetTokenKind("internal", 0));
            Assert.Equal((SyntaxKind.UsingKeyword, 5, null), new Lexer().GetTokenKind("using", 0));
        }
        #endregion

        #region flow and definition keywords test
        [Fact(DisplayName = "GetFlowAndDefinitionTest")]
        public void GetFlowAndDefinitionTest()
        {
            Assert.Equal((SyntaxKind.VarKeyword, 3, null), new Lexer().GetTokenKind("var", 0));
            Assert.Equal((SyntaxKind.ConstKeyword, 5, null), new Lexer().GetTokenKind("const", 0));
            Assert.Equal((SyntaxKind.SwitchKeyword, 6, null), new Lexer().GetTokenKind("switch", 0));
            Assert.Equal((SyntaxKind.LoopKeyword, 4, null), new Lexer().GetTokenKind("loop", 0));
            Assert.Equal((SyntaxKind.MacroKeyword, 5, null), new Lexer().GetTokenKind("macro", 0));
        }
        #endregion 
    }
}