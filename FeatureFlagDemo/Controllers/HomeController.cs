using FeatureFlagDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System.Diagnostics;

namespace FeatureFlagDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeatureManager _featureManager;

        public HomeController(IFeatureManagerSnapshot featureSnapshot)
        {
            _featureManager = featureSnapshot;
        }

        [FeatureGate(MyFeatureFlags.Home)]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Descripcion de la aplicación.";

            if (await _featureManager.IsEnabledAsync(MyFeatureFlags.CustomViewData))
            {
                ViewData["Message"] = $"Esto solo se ve si '{MyFeatureFlags.CustomViewData}' esta habilitado.";
            };

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [FeatureGate(MyFeatureFlags.Beta)]
        public IActionResult Beta()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
