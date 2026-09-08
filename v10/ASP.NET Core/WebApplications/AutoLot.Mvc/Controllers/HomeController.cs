// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - HomeController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Mvc.Controllers;

[Route("[controller]/[action]")]
public class HomeController(
    IAppLogger logger) : Controller
{
    //[Route("/MyHomePage")]
    [Route("/")]
    [Route("/[controller]")]
    [Route("/[controller]/[action]")]
    [HttpGet]
    public IActionResult Index(
        [FromServices]
        IOptionsSnapshot<DealerInfo> dealerOptionsSnapshot)
    {
        //logger.LogAppError("Test error");
        return View(dealerOptionsSnapshot.Value);
    }

    [HttpGet]
    public IActionResult GetServiceOne(
        [FromKeyedServices(nameof(SimpleServiceOne))]
        ISimpleService service)
    {
        return View(
            "SimpleService",
            service.SayHello());
    }

    [HttpGet]
    public IActionResult GetServiceTwo(
        [FromKeyedServices(nameof(SimpleServiceTwo))]
        ISimpleService service)
    {
        return View(
            "SimpleService",
            service.SayHello());
    }

    [HttpGet]
    public IActionResult GrantConsent()
    {
        HttpContext.Features
            .Get<ITrackingConsentFeature>()
            .GrantConsent();
        return RedirectToAction(
            nameof(Index),
            nameof(HomeController)
                .RemoveControllerSuffix(),
            new { area = "" });
    }

    [HttpGet]
    public IActionResult WithdrawConsent()
    {
        HttpContext.Features
            .Get<ITrackingConsentFeature>()
            .WithdrawConsent();
        return RedirectToAction(
            nameof(Index),
            nameof(HomeController)
                .RemoveControllerSuffix(),
            new { area = "" });
    }

    [HttpGet]
    public async Task<IActionResult> RazorSyntaxAsync(
        [FromServices]
        ICarDataService carDataService)
    {
        var car = await carDataService.FindAsync(1);
        return View(car);
    }

    [HttpGet]
    public IActionResult Validation()
    {
        var vm =
            new AddToCartViewModelMvc
            {
                Id = 1,
                ItemId = 1,
                StockQuantity = 2,
                Quantity = 0
            };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ValidationAsync(
        AddToCartViewModelMvc viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        await Task.Delay(5000);

        return RedirectToAction(
            nameof(Validation),
            nameof(HomeController)
                .RemoveControllerSuffix());
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(
        Duration = 0,
        Location = ResponseCacheLocation.None,
        NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}