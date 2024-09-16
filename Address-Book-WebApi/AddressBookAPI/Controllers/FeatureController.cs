using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace AddressBookAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class FeatureController(IFeatureManager featureManager) : ControllerBase
    {
        [HttpGet]
        public async Task<bool> IsFeatureEnabled(string feature)
        {
            return await featureManager.IsEnabledAsync(feature);
        }
    }
}
