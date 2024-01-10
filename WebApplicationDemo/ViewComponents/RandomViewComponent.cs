using Business.Services;
using Microsoft.AspNetCore.Mvc;


namespace WebApplicationDemo.ViewComponents
{
    public class RandomViewComponent : ViewComponent
    {
        IRandomGenService _randomGenService;

        public RandomViewComponent(IRandomGenService randomGenService)
        {
            _randomGenService = randomGenService;
        }

        public IViewComponentResult Invoke(int min, int max)
        {

            var rd = _randomGenService.GetRandom(min, max);

            return View(rd);
        }
    }
}
