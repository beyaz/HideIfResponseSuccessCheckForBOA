using BOA.DataFlow;

namespace ___.RegionsAreEvil.Configurations
{
    public static class OptionData
    {
        public static readonly DataKey<OptionsModel> Options = new DataKey<OptionsModel>(nameof(Options));

        static DataContext context;
        public static DataContext Context
        {
            get
            {
                if (context != null)
                {
                    return null;
                }

                context = new DataContext
                {
                    {Options, new OptionsReader().TryReadFromFile() ?? new OptionsModel()}
                };

                return context;
            }
        }
    }
}