namespace LimeAirlinesSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using LimeAirlinesSystem.Services.FAQs;
    using AutoMapper;
    using LimeAirlinesSystem.Infrastructure.Extensions;

    public class FAQController : Controller
    {
        private readonly IFAQService faqs;
        private readonly IMapper mapper;

        public FAQController(IFAQService faqs, IMapper mapper)
        {
            this.faqs = faqs;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            var faqs = this.faqs
                .AllShow()
                .FAQs;

            return View(faqs);
        }


        public JsonResult LikeFAQ([FromBody] int Id)
        {
            var countOfLikes =  this.faqs.LikeFAQ(Id, this.User.Id());

            return Json(countOfLikes);
        }
    }
}
