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
namespace Cecilia.Lib.Syntax
{
    public enum SyntaxKind
    {
        #region Exception
        Unknown,
        #endregion

        #region lexer state
        Empty,
        Whitespace,
        Identifier,
        NewLine,
        #endregion

        #region number
        IntegerLiteral,
        FloatingLiteral,
        #endregion

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

        #region Comment
        /// <summary>
        /// //
        /// </summary>
        SingleLineComment,
        /// <summary>
        /// /*
        /// </summary>
        MultiLineCommentStart,
        /// <summary>
        /// */
        /// </summary>
        MultiLineCommentEnd,
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

        #region Compiler embedded type keywords
        #region Number basic type keywords
        /// <summary>
        /// void
        /// </summary>
        VoidKeyword,
        /// <summary>
        /// int8
        /// </summary>
        Int8Keyword,
        /// <summary>
        /// int16
        /// </summary>
        Int16Keyword,
        /// <summary>
        /// int32
        /// </summary>
        Int32Keyword,
        /// <summary>
        /// int64
        /// </summary>
        Int64Keyword,
        /// <summary>
        /// uint8
        /// </summary>
        UInt8Keyword,
        /// <summary>
        /// uint16
        /// </summary>
        UInt16Keyword,
        /// <summary>
        /// uint32
        /// </summary>
        UInt32Keyword,
        /// <summary>
        /// uint64
        /// </summary>
        UInt64Keyword,
        /// <summary>
        /// half -- 16bit floating-point
        /// </summary>
        HalfKeyword,
        /// <summary>
        /// float -- 32bit floating-point
        /// </summary>
        FloatKeyword,
        /// <summary>
        /// double -- 64bit floating-point
        /// </summary>
        DoubleKeyword,
        #endregion

        #region other basic type keywords
        /// <summary>
        /// bool
        /// </summary>
        BoolKeyword,
        /// <summary>
        /// char
        /// </summary>
        CharKeyword,
        #endregion

        #region other special support keywords
        /// <summary>
        /// string
        /// </summary>
        StringKeyword,
        /// <summary>
        /// object
        /// </summary>
        ObjectKeyword,
        #endregion
        #endregion

        #region namespace and access modifier keywords
        /// <summary>
        /// namespace
        /// </summary>
        NamespaceKeyword,
        /// <summary>
        /// public
        /// </summary>
        PublicKeyword,
        /// <summary>
        /// private
        /// </summary>
        PrivateKeyword,
        /// <summary>
        /// protected
        /// </summary>
        ProtectedKeyword,
        /// <summary>
        /// internal
        /// </summary>
        InternalKeyword,
        /// <summary>
        /// using
        /// </summary>
        UsingKeyword,
        #endregion

        #region flow and definition keywords
        /// <summary>
        /// var
        /// </summary>
        VarKeyword,
        /// <summary>
        /// const
        /// </summary>
        ConstKeyword,
        /// <summary>
        /// switch
        /// </summary>
        SwitchKeyword,
        /// <summary>
        /// loop
        /// </summary>
        LoopKeyword,
        /// <summary>
        /// macro
        /// </summary>
        MacroKeyword,
        #endregion
    }
}