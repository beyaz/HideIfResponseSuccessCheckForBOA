using BOA.DataFlow;

namespace BOAPlugins.HideSuccessCheck
{
    class DataContextBuilder
    {
        #region Public Methods
        public DataContext Build()
        {
            var context = new DataContext();

            context.OpenNewLayer("Services");
            {
                //context.Add(ServiceKeys.Logger, new Logger {Context = context});
            }

            context.OnInsert(ApplicationKeys.CurrentError, () => Log(context));

            return context;
        }
        #endregion

        #region Methods
        static void Log(DataContext context)
        {
            var exception = context.Get(ApplicationKeys.CurrentError);

            Logger.Push(exception);

            context.Remove(ApplicationKeys.CurrentError);
        }
        #endregion
    }
}