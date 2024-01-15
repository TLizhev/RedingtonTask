using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedingtonTask.Domain.Entities;
using RedingtonTask.Domain.Services;
using RedingtonTask.Web.Models;

namespace RedingtonTask.Web.Controllers
{
    public class CalculationController(ICalculationService calculationService) : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProbabilityViewModel probabilityViewModel)
        {
            if (!ModelState.IsValid)
                return View(probabilityViewModel);

            var probability = new Probability()
            {
                FirstValue = probabilityViewModel.FirstValue,
                SecondValue = probabilityViewModel.SecondValue,
                FunctionType = probabilityViewModel.FunctionType,
            };

            var result = calculationService.Calculate(probability);

            return RedirectToAction("Result", new
            {
                result
            });
        }

        public IActionResult Result(decimal result)
        {
            ViewBag.Result = result;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
