namespace Cecilia.Lib
{
    public enum TokenKind
    {
        #region Exception
        Unknown,
        #endregion

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



        #region Keywords
        /// <summary>
        /// const
        /// </summary>
        ConstKeyword,
        #endregion
    }
}