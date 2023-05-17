namespace LimeAirlinesSystem.Services.FAQs
{
    using LimeAirlinesSystem.Services.FAQs.Models;
    using LimeAirlinesSystem.Services.Flights.Models;
    using LimeAirlinesSystem.Services.Planes.Models;
    using System;
    using System.Collections.Generic;

    public interface IFAQService
    {
        FAQQueryServiceModel All();

        void Create(
            string imageUrl,
            string description,
            string title);

        bool Edit(
            int faqId,
            string imageUrl,
            string description,
            string title);

        void ChangeVisibility(int faqId);

        IEnumerable<FAQServiceModel> AllFAQs();

        bool FAQExists(string faqTitle);
        FAQServiceModel FAQDetails(int faqId);
    }
}
