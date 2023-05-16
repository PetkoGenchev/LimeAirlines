namespace LimeAirlinesSystem.Controllers
{
    using LimeAirlinesSystem.Services.Home;
    using Microsoft.AspNetCore.Mvc;
    using LimeAirlinesSystem.Areas.Admin;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using LimeAirlinesSystem.Services.Information;
    using AutoMapper;

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
                .All()
                .FAQs;

            return View(faqs);
        }


        public IActionResult ChangeVisibility(int faqId)
        {
            this.faqs.ChangeVisibility(faqId);

            return RedirectToAction(nameof(All));
        }
    }
}