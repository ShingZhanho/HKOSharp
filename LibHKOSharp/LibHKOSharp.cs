// LibHKOSharp.cs is the file for main function of LibHKOSharp

namespace LibHKOSharp {
    public partial class LibHKOSharp {
        #region Constructors

        /// <summary>
        /// Initializes a new LibHKOSharp instance.
        /// </summary>
        /// <param name="language">Language of information to get. English is default language</param>
        public LibHKOSharp(Language language = Language.English) {
            Language = language;
        }

        #endregion

        #region Fields

        public Language Language { get; set; }

        #endregion
        
    }

    public enum Language {
        English,
        TraditionChinese,
        SimplifiedChinese
    }
}