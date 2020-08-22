// LibHKOSharp.cs is the file for main function of LibHKOSharp

using System;
using System.Runtime.CompilerServices;

namespace HKOSharp {
    public static partial class LibHKOSharp {
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