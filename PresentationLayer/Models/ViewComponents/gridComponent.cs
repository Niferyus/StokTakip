using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Models.ViewComponents
{
    [ViewComponent(Name = "Marka")]
    public class gridComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default");
        }
    }
}
