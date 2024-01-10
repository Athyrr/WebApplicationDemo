using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationDemo.ViewComponents
{
    public class RangeIntViewComponent : ViewComponent
    {
        private readonly IRandomGenService _randomGenService;

        public RangeIntViewComponent(IRandomGenService randomGenService)
        {
            _randomGenService = randomGenService;
        }
        public IViewComponentResult Invoke(int min, int max)
        {
            var num = _randomGenService.GetRandom(min, max);

            List<int> values = new() { min, num, max };

            return View(values);
        }

    }
}
