using System;
using ___.RegionsAreEvil.Configurations;
using BOA.DataFlow;
using BOAPlugins.HideSuccessCheck;

namespace BOA.DataFlow
{
}
namespace RegionsAreEvil.Classifications
{
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = Constants.InactiveRegionClassificationTypeNames)]
    [Name(Constants.InactiveRegionName)]
    [DisplayName(Constants.InactiveRegionName)]
    [UserVisible(true)]
    [Order(After = Constants.OrderAfterPriority, Before = Constants.OrderBeforePriority)]
    internal sealed class InactiveRegionClassification : ClassificationFormatDefinition
    {
        #region Initialization
        
        // Methods
        public InactiveRegionClassification()
        {
            var option = OptionData.Context.Get(OptionData.Options);
            if (!option.MinimizeRegionsIsEnabled)
            {
                return;
            }
            ForegroundColor = Colors.Gray;
            FontRenderingSize = option.InActiveRegionSize;
            ForegroundOpacity = option.InActiveRegionOpacity;
        }

        #endregion
    }
}