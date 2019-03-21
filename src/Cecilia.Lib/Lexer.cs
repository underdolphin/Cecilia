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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cecilia.Lib
{
    public class Lexer
    {
        string IdentifierStr { get; set; }
        string IntegerStr { get; set; }
        string FloatingStr { get; set; }

        private LexerUtils Utils { get; set; }

        public Lexer()
        {
            IdentifierStr = "";
            IntegerStr = "";
            FloatingStr = "";
            Utils = new LexerUtils();
        }

        public List<SyntaxKind> LexicalEngine(string targetStr)
        {
            throw new NotImplementedException();
        }

        public List<(SyntaxKind kind, int nextPos, string tokenStr)> GetNextTokenKind(string targetStr)
        {
            var tokenList = new List<(SyntaxKind kind, int nextPos, string tokenStr)>();
            if (targetStr.Length == 0)
            {
                (SyntaxKind kind, int nextPos, string tokenStr) ret = (SyntaxKind.EmptyRow, 0, null);
                tokenList.Add(ret);
                return tokenList;
            }

            int getPos = 0;
            while (targetStr.Length > getPos)
            {
                var tokenInfo = GetTokenKind(targetStr, getPos);
                switch (tokenInfo.kind)
                {
                    case SyntaxKind.Identifier:
                        (SyntaxKind kind, int nextPos, string tokenStr) idElement = (tokenInfo.kind, tokenInfo.nextPos, IdentifierStr);
                        tokenList.Add(idElement);
                        break;
                    default:
                        (SyntaxKind kind, int nextPos, string tokenStr) element = (tokenInfo.kind, tokenInfo.nextPos, null);
                        tokenList.Add(element);
                        break;
                }
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
        public (SyntaxKind kind, int nextPos) GetTokenKind(string targetStr, int nextPos)
        {
            char targetChar = targetStr[nextPos];
            if (char.IsWhiteSpace(targetChar))
            {
                // 読み取り対象位置の文字が空白だった場合、位置を一つ進め処理を終了
                return (SyntaxKind.Whitespace, ++nextPos);
            }

            int nextPos2 = nextPos + 1; // １つ先読み用
            int nextPos3 = nextPos2 + 1; // 2つ先読み用

            if (targetStr.Length > nextPos && Utils.IsSyntaxPunctuation(targetChar))
            {
                if (targetStr.Length > nextPos2 && Utils.IsSyntaxPunctuation(targetStr[nextPos2]))
                {
                    if (targetStr.Length > nextPos3 && Utils.IsSyntaxPunctuation(targetStr[nextPos3]))
                    {
                        // 3文字記号演算子
                        var triplePuctuationResult = TriplePunctuationLexer(targetStr, nextPos);
                        if (triplePuctuationResult.kind != SyntaxKind.Unknown)
                        {
                            return triplePuctuationResult;
                        }
                    }
                    // 2文字記号演算子
                    var doublePuctuationResult = DoublePunctuationLexer(targetStr, nextPos);
                    if (doublePuctuationResult.kind != SyntaxKind.Unknown)
                    {
                        return doublePuctuationResult;
                    }
                }

                // 1文字記号演算子
                var singlePuctuationResult = SinglePunctuationLexer(targetChar, nextPos);
                if (singlePuctuationResult.kind != SyntaxKind.Unknown)
                {
                    return singlePuctuationResult;
                }
            }

            // number
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
                return (JudgeIntegerOrFloating(IntegerStr), i);
            }

            // identifier and keyword
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
                return (JudgeKeywordOrIdentifier(IdentifierStr), i);
            }

            return (SyntaxKind.Unknown, 0);
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
        private SyntaxKind JudgeKeywordOrIdentifier(string targetStr)
        {
            switch (targetStr)
            {
                case "void":
                    return SyntaxKind.VoidKeyword;
                case "int8":
                    return SyntaxKind.Int8Keyword;
                case "int16":
                    return SyntaxKind.Int16Keyword;
                case "int32":
                    return SyntaxKind.Int32Keyword;
                case "int64":
                    return SyntaxKind.Int64Keyword;
                case "uint8":
                    return SyntaxKind.UInt8Keyword;
                case "uint16":
                    return SyntaxKind.UInt16Keyword;
                case "uint32":
                    return SyntaxKind.UInt32Keyword;
                case "uint64":
                    return SyntaxKind.UInt64Keyword;
                case "half":
                    return SyntaxKind.HalfKeyword;
                case "float":
                    return SyntaxKind.FloatKeyword;
                case "double":
                    return SyntaxKind.DoubleKeyword;
                case "bool":
                    return SyntaxKind.BoolKeyword;
                case "char":
                    return SyntaxKind.CharKeyword;
                case "string":
                    return SyntaxKind.StringKeyword;
                case "object":
                    return SyntaxKind.ObjectKeyword;
                case "namespace":
                    return SyntaxKind.NamespaceKeyword;
                case "public":
                    return SyntaxKind.PublicKeyword;
                case "private":
                    return SyntaxKind.PrivateKeyword;
                case "protected":
                    return SyntaxKind.ProtectedKeyword;
                case "internal":
                    return SyntaxKind.InternalKeyword;
                case "using":
                    return SyntaxKind.UsingKeyword;
                default:
                    return SyntaxKind.Identifier;
            }
        }

        /// <summary>
        /// その文字列が整数か小数区別する
        /// </summary>
        /// <param name="targetStr">String to be judge</param>
        /// <returns></returns>
        private SyntaxKind JudgeIntegerOrFloating(string targetStr)
        {
            int dotCount = targetStr.Where(c => c == '.').Count();
            switch (dotCount)
            {
                case 1:
                    return SyntaxKind.FloatingLiteral;
                case 0:
                    return SyntaxKind.IntegerLiteral;
                default:
                    return SyntaxKind.Unknown;
            }
        }
    }
}
