﻿namespace FeatureFlagDemo.FeatureManagement.FeatureFilters
{
    public class BrowserFilterSettings
    {
        public IList<string> AllowedBrowsers { get; set; } = new List<string>();
    }
}
