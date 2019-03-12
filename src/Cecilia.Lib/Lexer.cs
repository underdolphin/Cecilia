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

namespace Cecilia.Lib
{
    public class Lexer
    {
        public string IdentifierStr { get; set; }
        public string Integer32Str { get; set; }
        public string Integer64Str { get; set; }
        public string IntegerFloatStr { get; set; }
        public string IntegerDoubleStr { get; set; }

        private LexerUtils Utils { get; set; }

        public Lexer()
        {
            Utils = new LexerUtils();
        }

        public List<TokenKind> LexicalEngine(string targetStr)
        {
            throw new NotImplementedException();
        }

        public List<TokenKind> GetNextTokenKind(string targetStr)
        {
            return null;
        }

        public (TokenKind kind, int nextPos) GetTokenKind(string targetStr, int nextPos)
        {
            char targetChar = targetStr[nextPos];
            if (char.IsWhiteSpace(targetChar))
            {
                // 読み取り対象位置の文字が空白だった場合、位置を一つ進め処理を終了
                return (TokenKind.Whitespace, ++nextPos);
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
                        if (triplePuctuationResult.kind != TokenKind.Unknown)
                        {
                            return triplePuctuationResult;
                        }
                    }
                    // 2文字記号演算子
                    var doublePuctuationResult = DoublePunctuationLexer(targetStr, nextPos);
                    if (doublePuctuationResult.kind != TokenKind.Unknown)
                    {
                        return doublePuctuationResult;
                    }
                }

                // 1文字記号演算子
                var singlePuctuationResult = SinglePunctuationLexer(targetChar, nextPos);
                if (singlePuctuationResult.kind != TokenKind.Unknown)
                {
                    return singlePuctuationResult;
                }
            }



            return (TokenKind.Unknown, 0);
        }

        private (TokenKind kind, int nextPos) DoublePunctuationLexer(string targetStr, int nextPos)
        {
            /* 対象の文字列が2文字でトークンを構成する場合、
             * すぐに種類を判定し、位置を2つ進め処理を終了
             */
            switch (targetStr)
            {
                case "//":
                    return (TokenKind.SingleLineComment, nextPos += 2);
                case "/*":
                    return (TokenKind.MultiLineCommentStart, nextPos += 2);
                case "*/":
                    return (TokenKind.MultiLineCommentEnd, nextPos += 2);
                case "||":
                    return (TokenKind.BarBar, nextPos += 2);
                case "&&":
                    return (TokenKind.AmpAmp, nextPos += 2);
                case "--":
                    return (TokenKind.MinusMinus, nextPos += 2);
                case "++":
                    return (TokenKind.PlusPlus, nextPos += 2);
                case "??":
                    return (TokenKind.QuestionQuestion, nextPos += 2);
                case "==":
                    return (TokenKind.EqualsEquals, nextPos += 2);
                case "!=":
                    return (TokenKind.ExclamationEquals, nextPos += 2);
                case "=>":
                    return (TokenKind.Arrow, nextPos += 2);
                case "<=":
                    return (TokenKind.LessThanEqual, nextPos += 2);
                case ">=":
                    return (TokenKind.GreaterThanEqual, nextPos += 2);
                case "<<":
                    return (TokenKind.LessThanLessThan, nextPos += 2);
                case ">>":
                    return (TokenKind.GreaterThanGreaterThan, nextPos += 2);
                case "+=":
                    return (TokenKind.PlusEqual, nextPos += 2);
                case "-=":
                    return (TokenKind.MinusEqual, nextPos += 2);
                case "*=":
                    return (TokenKind.AsteriskEqual, nextPos += 2);
                case "/=":
                    return (TokenKind.SlashEqual, nextPos += 2);
                case "|=":
                    return (TokenKind.BarEqual, nextPos += 2);
                case "^=":
                    return (TokenKind.CaretEqual, nextPos += 2);
                default:
                    return (TokenKind.Unknown, nextPos += 2);
            }
        }

        private (TokenKind kind, int nextPos) TriplePunctuationLexer(string targetStr, int nextPos)
        {
            /* 対象の文字列が3文字でトークンを構成する場合、
             * すぐに種類を判定し、位置を3つ進め処理を終了
             */
            switch (targetStr)
            {
                case "<<=":
                    return (TokenKind.LessThanLessThanEqual, nextPos += 3);
                case ">>=":
                    return (TokenKind.GreaterThanGreaterThanEqual, nextPos += 3);
                default:
                    return (TokenKind.Unknown, nextPos += 3);
            }
        }

        /// <summary>
        /// 1文字の記号の解析
        /// </summary>
        /// <param name="targetChar"></param>
        /// <param name="nextPos"></param>
        /// <returns></returns>
        private (TokenKind kind, int nextPos) SinglePunctuationLexer(char targetChar, int nextPos)
        {
            /* 対象の文字列が1文字でトークンを構成する場合、
             * すぐに種類を判定し、位置を一つ進め処理を終了
             */
            switch (targetChar)
            {
                case '(':
                    return (TokenKind.LParen, ++nextPos);
                case ')':
                    return (TokenKind.RParen, ++nextPos);
                case '{':
                    return (TokenKind.LBrace, ++nextPos);
                case '}':
                    return (TokenKind.RBrace, ++nextPos);
                case '[':
                    return (TokenKind.LBracket, ++nextPos);
                case ']':
                    return (TokenKind.RBracket, ++nextPos);
                case '!':
                    return (TokenKind.Exclamation, ++nextPos);
                case '$':
                    return (TokenKind.Dollar, ++nextPos);
                case '%':
                    return (TokenKind.Parcent, ++nextPos);
                case '^':
                    return (TokenKind.Caret, ++nextPos);
                case '&':
                    return (TokenKind.Ampersand, ++nextPos);
                case '*':
                    return (TokenKind.Asterisk, ++nextPos);
                case '-':
                    return (TokenKind.Minus, ++nextPos);
                case '+':
                    return (TokenKind.Plus, ++nextPos);
                case '=':
                    return (TokenKind.Equals, ++nextPos);
                case '|':
                    return (TokenKind.Bar, ++nextPos);
                case '\\':
                    return (TokenKind.Backslash, ++nextPos);
                case ':':
                    return (TokenKind.Colon, ++nextPos);
                case ';':
                    return (TokenKind.SemiColon, ++nextPos);
                case '\"':
                    return (TokenKind.DoubleQuote, ++nextPos);
                case '\'':
                    return (TokenKind.SingleQuote, ++nextPos);
                case '<':
                    return (TokenKind.LessThan, ++nextPos);
                case '>':
                    return (TokenKind.GreaterThan, ++nextPos);
                case ',':
                    return (TokenKind.Comma, ++nextPos);
                case '.':
                    return (TokenKind.Dot, ++nextPos);
                case '?':
                    return (TokenKind.Question, ++nextPos);
                case '#':
                    return (TokenKind.Hash, ++nextPos);
                case '/':
                    return (TokenKind.Slash, ++nextPos);
                default:
                    return (TokenKind.Unknown, ++nextPos);
            }
        }
    }
}
