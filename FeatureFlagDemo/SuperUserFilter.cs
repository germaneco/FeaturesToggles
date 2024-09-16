using Microsoft.FeatureManagement;

namespace FeatureFlagDemo.FeatureManagement.FeatureFilters
{
    public class SuperUserFilter : IFeatureFilter
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            return Task.FromResult(false);
        }
    }
}
