using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Models.ViewComponents
{
    [ViewComponent(Name = "Birim")]
    public class BirimGridComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default");
        }
    }
}
