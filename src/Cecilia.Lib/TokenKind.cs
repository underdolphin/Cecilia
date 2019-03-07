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
namespace Cecilia.Lib
{
    public enum TokenKind
    {
        #region Exception
        Unknown,
        #endregion

        LexerEnd,
        Whitespace,
        SingleLineComment,
        MultiLineCommentStart,
        MultiLineCommentEnd,

        #region Single Charactor Punctuations
        /// <summary>
        /// (
        /// </summary>
        LParen,
        /// <summary>
        /// )
        /// </summary>
        RParen,
        /// <summary>
        /// [
        /// </summary>
        LBracket,
        /// <summary>
        /// ]
        /// </summary>
        RBracket,
        /// <summary>
        /// {
        /// </summary>
        LBrace,
        /// <summary>
        /// }
        /// </summary>
        RBrace,
        /// <summary>
        /// !
        /// </summary>
        Exclamation,
        /// <summary>
        /// $
        /// </summary>
        Dollar,
        /// <summary>
        /// %
        /// </summary>
        Parcent,
        /// <summary>
        /// ^
        /// </summary>
        Caret,
        /// <summary>
        /// &
        /// </summary>
        Ampersand,
        /// <summary>
        /// *
        /// </summary>
        Asterisk,
        /// <summary>
        /// -
        /// </summary>
        Minus,
        /// <summary>
        /// +
        /// </summary>
        Plus,
        /// <summary>
        /// =
        /// </summary>
        Equals,
        /// <summary>
        /// |
        /// </summary>
        Bar,
        /// <summary>
        /// \
        /// </summary>
        Backslash,
        /// <summary>
        /// :
        /// </summary>
        Colon,
        /// <summary>
        /// ;
        /// </summary>
        SemiColon,
        /// <summary>
        /// "
        /// </summary>
        DoubleQuote,
        /// <summary>
        /// '
        /// </summary>
        SingleQuote,
        /// <summary>
        /// <
        /// </summary>
        LessThan,
        /// <summary>
        /// >
        /// </summary>
        GreaterThan,
        /// <summary>
        /// ,
        /// </summary>
        Comma,
        /// <summary>
        /// .
        /// </summary>
        Dot,
        /// <summary>
        /// ?
        /// </summary>
        Question,
        /// <summary>
        /// #
        /// </summary>
        Hash,
        /// <summary>
        /// /
        /// </summary>
        Slash,
        #endregion

        #region Double Charactor Punctuations
        /// <summary>
        /// ||
        /// </summary>
        BarBar,
        /// <summary>
        /// &&
        /// </summary>
        AmpAmp,
        /// <summary>
        /// --
        /// </summary>
        MinusMinus,
        /// <summary>
        /// ++
        /// </summary>
        PlusPlus,
        /// <summary>
        /// ??
        /// </summary>
        QuestionQuestion,
        /// <summary>
        /// ==
        /// </summary>
        EqualsEquals,
        /// <summary>
        /// !=
        /// </summary>
        ExclamationEquals,
        /// <summary>
        /// =>
        /// </summary>
        Arrow,
        /// <summary>
        /// <=
        /// </summary>
        LessThanEqual,
        /// <summary>
        /// >=
        /// </summary>
        GreaterThanEqual,
        /// <summary>
        /// <<
        /// </summary>
        LessThanLessThan,
        /// <summary>
        /// >>
        /// </summary>
        GreaterThanGreaterThan,
        /// <summary>
        /// +=
        /// </summary>
        PlusEqual,
        /// <summary>
        /// -=
        /// </summary>
        MinusEqual,
        /// <summary>
        /// *=
        /// </summary>
        AsteriskEqual,
        /// <summary>
        /// /=
        /// </summary>
        SlashEqual,
        /// <summary>
        /// |=
        /// </summary>
        BarEqual,
        /// <summary>
        /// ^=
        /// </summary>
        CaretEqual,
        #endregion

        #region Triple character punctuation
        /// <summary>
        /// <<=
        /// </summary>
        LessThanLessThanEqual,
        /// <summary>
        /// >>=
        /// </summary>
        GreaterThanGreaterThanEqual,
        #endregion

        #region Keywords
        /// <summary>
        /// const
        /// </summary>
        ConstKeyword,
        #endregion
    }
}