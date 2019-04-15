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
        VoidType,
        /// <summary>
        /// byte -- 8bit integer
        /// </summary>
        ByteType,
        /// <summary>
        /// ubyte -- 8bit unsigned integer
        /// </summary>
        UByteType,
        /// <summary>
        /// short -- 16bit integer 
        /// </summary>
        ShortType,
        /// <summary>
        /// ushort -- 16bit unsigned integer
        /// </summary>
        UShortType,
        /// <summary>
        /// int -- 32bit integer 
        /// </summary>
        IntType,
        /// <summary>
        /// uint -- 32bit unsigned integer
        /// </summary>
        UIntType,
        /// <summary>
        /// long -- 64bit integer
        /// </summary>
        LongType,
        /// <summary>
        /// ulong -- 64bit unsigned integer
        /// </summary>
        ULongType,
        /// <summary>
        /// half -- 16bit floating-point
        /// </summary>
        HalfType,
        /// <summary>
        /// float -- 32bit floating-point
        /// </summary>
        FloatType,
        /// <summary>
        /// double -- 64bit floating-point
        /// </summary>
        DoubleType,
        #endregion

        #region other basic type keywords
        /// <summary>
        /// bool
        /// </summary>
        BoolType,
        /// <summary>
        /// char
        /// </summary>
        CharType,
        #endregion

        #region other special support keywords
        /// <summary>
        /// string
        /// </summary>
        StringType,
        /// <summary>
        /// object
        /// </summary>
        ObjectType,
        #endregion
        #endregion

        #region namespace and access modifier keywords
        /// <summary>
        /// namespace
        /// </summary>
        Namespace,
        /// <summary>
        /// public
        /// </summary>
        Public,
        /// <summary>
        /// private
        /// </summary>
        Private,
        /// <summary>
        /// protected
        /// </summary>
        Protected,
        /// <summary>
        /// internal
        /// </summary>
        Internal,
        /// <summary>
        /// using
        /// </summary>
        Using,
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
        /// <summary>
        /// return
        /// </summary>
        ReturnKeyword,
        #endregion

        #region syntax group
        UsingDirective
        #endregion
    }
}