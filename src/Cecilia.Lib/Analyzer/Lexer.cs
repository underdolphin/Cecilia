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
using Cecilia.Lib.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace Cecilia.Lib.Analyzer
{
    public class Lexer
    {
        private LexerUtils Utils { get; set; }

        public Lexer()
        {
            Utils = new LexerUtils();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetStr"></param>
        /// <returns></returns>
        public List<(SyntaxKind kind, int nextPos, string tokenStr)> GetTokenList(string targetStr)
        {
            // 文字列の長さが0なら直接空白であることを返す
            var tokenList = new List<(SyntaxKind kind, int nextPos, string tokenStr)>();
            if (targetStr.Length == 0)
            {
                (SyntaxKind kind, int nextPos, string tokenStr) ret = (SyntaxKind.Empty, 0, null);
                tokenList.Add(ret);
                return tokenList;
            }

            int getPos = 0;
            while (targetStr.Length > getPos)
            {
                var tokenInfo = GetTokenKind(targetStr, getPos);
                tokenList.Add(tokenInfo);
                getPos = tokenInfo.nextPos;
            }
            return tokenList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetStr">Cecilia source on read text line.</param>
        /// <param name="nextPos">Next analyzing position.</param>
        /// <returns></returns>
        public (SyntaxKind kind, int nextPos, string tokenStr) GetTokenKind(string targetStr, int nextPos)
        {
            char targetChar = targetStr[nextPos];
            int nextPos2 = nextPos + 1; // １つ先読み用
            int nextPos3 = nextPos2 + 1; // 2つ先読み用

            // new line
            if (targetChar.Equals('\r'))
            {
                if (targetStr.Length > nextPos2 && targetStr[nextPos2].Equals('\n'))
                {
                    return (SyntaxKind.NewLine, ++nextPos2, null);
                }
                return (SyntaxKind.NewLine, ++nextPos, null);
            }

            if (targetChar.Equals('\n'))
            {
                return (SyntaxKind.NewLine, ++nextPos, null);
            }

            if (char.IsWhiteSpace(targetChar))
            {
                // 読み取り対象位置の文字が空白だった場合、位置を一つ進め処理を終了
                return (SyntaxKind.Whitespace, ++nextPos, null);
            }

            if (targetStr.Length > nextPos && Utils.IsSyntaxPunctuation(targetChar))
            {
                if (targetStr.Length > nextPos2 && Utils.IsSyntaxPunctuation(targetStr[nextPos2]))
                {
                    if (targetStr.Length > nextPos3 && Utils.IsSyntaxPunctuation(targetStr[nextPos3]))
                    {
                        // 3文字記号演算子
                        var triplePuctuationResult = TriplePunctuationLexer(targetStr.Substring(nextPos, 3), nextPos);
                        if (triplePuctuationResult.kind != SyntaxKind.Unknown)
                        {
                            return (triplePuctuationResult.kind, triplePuctuationResult.nextPos, null);
                        }
                    }
                    // 2文字記号演算子
                    var doublePuctuationResult = DoublePunctuationLexer(targetStr.Substring(nextPos, 2), nextPos);
                    if (doublePuctuationResult.kind != SyntaxKind.Unknown)
                    {
                        return (doublePuctuationResult.kind, doublePuctuationResult.nextPos, null);
                    }
                }

                // 1文字記号演算子
                var singlePuctuationResult = SinglePunctuationLexer(targetChar, nextPos);
                if (singlePuctuationResult.kind != SyntaxKind.Unknown)
                {
                    return (singlePuctuationResult.kind, singlePuctuationResult.nextPos, null);
                }
            }

            // number
            var IntegerStr = "";
            if (char.IsDigit(targetChar) || targetChar == '.')
            {
                IntegerStr += targetChar;
                nextPos++;
                int i;
                for (i = nextPos; i < targetStr.Length; i++)
                {
                    if (!char.IsDigit(targetStr[i]) && targetStr[i] != '.')
                    {
                        break;
                    }
                    IntegerStr += targetStr[i];
                }
                var judge = (JudgeIntegerOrFloating(IntegerStr));
                return (judge.kind, i, judge.numberStr);
            }

            // identifier and keyword
            var IdentifierStr = "";
            if (char.IsLetter(targetChar))
            {
                IdentifierStr += targetChar;
                nextPos++;
                int i;
                for (i = nextPos; i < targetStr.Length; i++)
                {
                    if (!char.IsLetterOrDigit(targetStr[i]))
                    {
                        break;
                    }
                    IdentifierStr += targetStr[i];
                }
                var judge = JudgeKeywordOrIdentifier(IdentifierStr);
                return (judge.kind, i, judge.idStr);
            }

            return (SyntaxKind.Unknown, 0, null);
        }

        private (SyntaxKind kind, int nextPos) DoublePunctuationLexer(string targetStr, int nextPos)
        {
            /* 対象の文字列が2文字でトークンを構成する場合、
             * すぐに種類を判定し、位置を2つ進め処理を終了
             */
            switch (targetStr)
            {
                case "//":
                    return (SyntaxKind.SingleLineComment, nextPos += 2);
                case "/*":
                    return (SyntaxKind.MultiLineCommentStart, nextPos += 2);
                case "*/":
                    return (SyntaxKind.MultiLineCommentEnd, nextPos += 2);
                case "||":
                    return (SyntaxKind.BarBar, nextPos += 2);
                case "&&":
                    return (SyntaxKind.AmpAmp, nextPos += 2);
                case "--":
                    return (SyntaxKind.MinusMinus, nextPos += 2);
                case "++":
                    return (SyntaxKind.PlusPlus, nextPos += 2);
                case "??":
                    return (SyntaxKind.QuestionQuestion, nextPos += 2);
                case "==":
                    return (SyntaxKind.EqualsEquals, nextPos += 2);
                case "!=":
                    return (SyntaxKind.ExclamationEquals, nextPos += 2);
                case "=>":
                    return (SyntaxKind.Arrow, nextPos += 2);
                case "<=":
                    return (SyntaxKind.LessThanEqual, nextPos += 2);
                case ">=":
                    return (SyntaxKind.GreaterThanEqual, nextPos += 2);
                case "<<":
                    return (SyntaxKind.LessThanLessThan, nextPos += 2);
                case ">>":
                    return (SyntaxKind.GreaterThanGreaterThan, nextPos += 2);
                case "+=":
                    return (SyntaxKind.PlusEqual, nextPos += 2);
                case "-=":
                    return (SyntaxKind.MinusEqual, nextPos += 2);
                case "*=":
                    return (SyntaxKind.AsteriskEqual, nextPos += 2);
                case "/=":
                    return (SyntaxKind.SlashEqual, nextPos += 2);
                case "|=":
                    return (SyntaxKind.BarEqual, nextPos += 2);
                case "^=":
                    return (SyntaxKind.CaretEqual, nextPos += 2);
                default:
                    return (SyntaxKind.Unknown, nextPos += 2);
            }
        }

        private (SyntaxKind kind, int nextPos) TriplePunctuationLexer(string targetStr, int nextPos)
        {
            /* 対象の文字列が3文字でトークンを構成する場合、
             * すぐに種類を判定し、位置を3つ進め処理を終了
             */
            switch (targetStr)
            {
                case "<<=":
                    return (SyntaxKind.LessThanLessThanEqual, nextPos += 3);
                case ">>=":
                    return (SyntaxKind.GreaterThanGreaterThanEqual, nextPos += 3);
                default:
                    return (SyntaxKind.Unknown, nextPos += 3);
            }
        }

        /// <summary>
        /// 1文字の記号の解析
        /// </summary>
        /// <param name="targetChar"></param>
        /// <param name="nextPos"></param>
        /// <returns></returns>
        private (SyntaxKind kind, int nextPos) SinglePunctuationLexer(char targetChar, int nextPos)
        {
            /* 対象の文字列が1文字でトークンを構成する場合、
             * すぐに種類を判定し、位置を一つ進め処理を終了
             */
            switch (targetChar)
            {
                case '(':
                    return (SyntaxKind.LParen, ++nextPos);
                case ')':
                    return (SyntaxKind.RParen, ++nextPos);
                case '{':
                    return (SyntaxKind.LBrace, ++nextPos);
                case '}':
                    return (SyntaxKind.RBrace, ++nextPos);
                case '[':
                    return (SyntaxKind.LBracket, ++nextPos);
                case ']':
                    return (SyntaxKind.RBracket, ++nextPos);
                case '!':
                    return (SyntaxKind.Exclamation, ++nextPos);
                case '$':
                    return (SyntaxKind.Dollar, ++nextPos);
                case '%':
                    return (SyntaxKind.Parcent, ++nextPos);
                case '^':
                    return (SyntaxKind.Caret, ++nextPos);
                case '&':
                    return (SyntaxKind.Ampersand, ++nextPos);
                case '*':
                    return (SyntaxKind.Asterisk, ++nextPos);
                case '-':
                    return (SyntaxKind.Minus, ++nextPos);
                case '+':
                    return (SyntaxKind.Plus, ++nextPos);
                case '=':
                    return (SyntaxKind.Equals, ++nextPos);
                case '|':
                    return (SyntaxKind.Bar, ++nextPos);
                case '\\':
                    return (SyntaxKind.Backslash, ++nextPos);
                case ':':
                    return (SyntaxKind.Colon, ++nextPos);
                case ';':
                    return (SyntaxKind.SemiColon, ++nextPos);
                case '\"':
                    return (SyntaxKind.DoubleQuote, ++nextPos);
                case '\'':
                    return (SyntaxKind.SingleQuote, ++nextPos);
                case '<':
                    return (SyntaxKind.LessThan, ++nextPos);
                case '>':
                    return (SyntaxKind.GreaterThan, ++nextPos);
                case ',':
                    return (SyntaxKind.Comma, ++nextPos);
                case '.':
                    return (SyntaxKind.Dot, ++nextPos);
                case '?':
                    return (SyntaxKind.Question, ++nextPos);
                case '#':
                    return (SyntaxKind.Hash, ++nextPos);
                case '/':
                    return (SyntaxKind.Slash, ++nextPos);
                default:
                    return (SyntaxKind.Unknown, ++nextPos);
            }
        }

        /// <summary>
        /// その文字列がキーワードか識別子か区別する
        /// </summary>
        /// <param name="targetStr">String to be judge</param>
        /// <returns></returns>
        private (SyntaxKind kind, string idStr) JudgeKeywordOrIdentifier(string targetStr)
        {
            switch (targetStr)
            {
                case "void":
                    return (SyntaxKind.VoidType, null);
                case "int8":
                    return (SyntaxKind.ByteType, null);
                case "int16":
                    return (SyntaxKind.UByteType, null);
                case "int32":
                    return (SyntaxKind.ShortType, null);
                case "int64":
                    return (SyntaxKind.UShortType, null);
                case "uint8":
                    return (SyntaxKind.IntType, null);
                case "uint16":
                    return (SyntaxKind.UIntType, null);
                case "uint32":
                    return (SyntaxKind.LongType, null);
                case "uint64":
                    return (SyntaxKind.ULongType, null);
                case "half":
                    return (SyntaxKind.HalfType, null);
                case "float":
                    return (SyntaxKind.FloatType, null);
                case "double":
                    return (SyntaxKind.DoubleType, null);
                case "bool":
                    return (SyntaxKind.BoolType, null);
                case "char":
                    return (SyntaxKind.CharType, null);
                case "string":
                    return (SyntaxKind.StringType, null);
                case "object":
                    return (SyntaxKind.ObjectType, null);
                case "namespace":
                    return (SyntaxKind.Namespace, null);
                case "public":
                    return (SyntaxKind.Public, null);
                case "private":
                    return (SyntaxKind.Private, null);
                case "protected":
                    return (SyntaxKind.Protected, null);
                case "internal":
                    return (SyntaxKind.Internal, null);
                case "using":
                    return (SyntaxKind.Using, null);
                case "var":
                    return (SyntaxKind.VarKeyword, null);
                case "const":
                    return (SyntaxKind.ConstKeyword, null);
                case "switch":
                    return (SyntaxKind.SwitchKeyword, null);
                case "loop":
                    return (SyntaxKind.LoopKeyword, null);
                case "macro":
                    return (SyntaxKind.MacroKeyword, null);
                case "return":
                    return (SyntaxKind.ReturnKeyword, null);
                default:
                    return (SyntaxKind.Identifier, targetStr);
            }
        }

        /// <summary>
        /// その文字列が整数か小数区別する
        /// </summary>
        /// <param name="targetStr">String to be judge</param>
        /// <returns></returns>
        private (SyntaxKind kind, string numberStr) JudgeIntegerOrFloating(string targetStr)
        {
            int dotCount = targetStr.Where(c => c == '.').Count();
            switch (dotCount)
            {
                case 1:
                    return (SyntaxKind.FloatingLiteral, targetStr);
                case 0:
                    return (SyntaxKind.IntegerLiteral, targetStr);
                default:
                    return (SyntaxKind.Unknown, null);
            }
        }
    }
}
