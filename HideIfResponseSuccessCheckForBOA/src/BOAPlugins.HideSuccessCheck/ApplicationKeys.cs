using System;
using BOA.DataFlow;

namespace BOAPlugins.HideSuccessCheck
{
    public static class ApplicationKeys
    {
        #region Static Fields
        public static DataKey<Exception> CurrentError = new DataKey<Exception>(nameof(CurrentError));
        #endregion
    }
}