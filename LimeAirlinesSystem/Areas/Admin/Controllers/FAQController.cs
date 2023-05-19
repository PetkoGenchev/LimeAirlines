namespace LimeAirlinesSystem.Areas.Admin.Controllers
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

    public class FAQController : AdminController
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


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(FAQFormModel faq)
        {
            if (this.faqs.FAQExists(faq.Title))
            {
                this.ModelState.AddModelError(nameof(faq.Title), "FAQ already exists.");
            }

            if (!ModelState.IsValid)
            {
                return View(faq);
            }

            this.faqs.Create(
                faq.Title,
                faq.Description,
                faq.ImageUrl);

            return RedirectToAction(nameof(All));
        }


        [Authorize]
        public IActionResult Edit(int Id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var faq = this.faqs.FAQDetails(Id);

            var faqForm = this.mapper.Map<FAQFormModel>(faq);

            return View(faqForm);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Edit(int Id, FAQFormModel faq)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(faq);
            }

            var edited = this.faqs.Edit(
                Id,
                faq.Title,
                faq.Description,
                faq.ImageUrl);

            if (!edited)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));

        }



        public IActionResult ChangeVisibility(int Id)
        {
            this.faqs.ChangeVisibility(Id);

            return RedirectToAction(nameof(All));
        }
    }
}
