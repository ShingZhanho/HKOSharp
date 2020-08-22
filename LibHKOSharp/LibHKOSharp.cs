// LibHKOSharp.cs is the file for main function of LibHKOSharp

using System;
using System.Runtime.CompilerServices;

namespace HKOSharp {
    public partial class LibHKOSharp {
        #region Constructors

        // /// <summary>
        // /// Initializes a new LibHKOSharp instance.
        // /// </summary>
        // public LibHKOSharp() {
        // }

        #endregion

        #region Fields


        #endregion

        #region Methods

        internal static string GetLanguageParameter(Language language) {
            return language switch {
                Language.English => "&lang=en",
                Language.TraditionChinese => "&lang=tc",
                Language.SimplifiedChinese => "&lang=sc",
                _ => "&lang=en"
            };
        }

        #endregion
    }

    public enum Language {
        English,
        TraditionChinese,
        SimplifiedChinese
    }
}