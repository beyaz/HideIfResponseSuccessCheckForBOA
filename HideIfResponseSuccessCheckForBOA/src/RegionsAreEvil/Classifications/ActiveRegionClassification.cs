using BOA.DataFlow;

namespace RegionsAreEvil.Classifications
{
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = Constants.ActiveRegionClassificationTypeNames)]
    [Name(Constants.ActiveRegionName)]
    [DisplayName(Constants.ActiveRegionName)]
    [UserVisible(true)]
    [Order(After = Constants.OrderAfterPriority, Before = Constants.OrderBeforePriority)]
    internal sealed class ActiveRegionClassification : ClassificationFormatDefinition
    {
        #region Initialization

        // Methods
        public ActiveRegionClassification()
        {
            var option = OptionData.Context.Get(OptionData.Options);

            if (!option.MinimizeRegionsIsEnabled)
            {
                return;
            }

            ForegroundColor = Colors.DarkGray;
            FontRenderingSize = option.ActiveRegionSize;
            ForegroundOpacity = option.ActiveRegionOpacity;
        }

        #endregion
    }
}