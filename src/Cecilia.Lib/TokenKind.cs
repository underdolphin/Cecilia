namespace Cecilia.Lib
{
    public enum TokenKind
    {
        #region Exception
        Unknown,
        #endregion

        #region Ignores
        Whitespace,
        #endregion

        #region Sign and Punctions and Symbols
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
        RBrace
        #endregion
    }
}