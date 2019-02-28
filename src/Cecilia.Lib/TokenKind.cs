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

        #region Sign and Punctions
        /// <summary>
        /// (
        /// </summary>
        LParen,
        /// <summary>
        /// )
        /// </summary>
        RParen,
        /// <summary>
        /// {
        /// </summary>
        LBracket,
        /// <summary>
        /// }
        /// </summary>
        RBracket
        #endregion
    }
}