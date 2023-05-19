namespace LimeAirlinesSystem.Controllers
{
    using LimeAirlinesSystem.Services.Home;
    using Microsoft.AspNetCore.Mvc;
    using LimeAirlinesSystem.Areas.Admin;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using LimeAirlinesSystem.Services.FAQs;
    using AutoMapper;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Models.FAQs;
    using Microsoft.AspNetCore.Authorization;
    using LimeAirlinesSystem.Data.Models;
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
