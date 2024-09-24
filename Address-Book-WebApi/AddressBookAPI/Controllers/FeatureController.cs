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
        public async Task<IActionResult> IsFeatureEnabled(string feature) => Ok(await featureManager.IsEnabledAsync(feature));
    }
}
