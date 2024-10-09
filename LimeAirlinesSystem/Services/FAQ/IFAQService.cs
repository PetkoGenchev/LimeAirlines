namespace LimeAirlinesSystem.Services.FAQs
{
    using LimeAirlinesSystem.Services.FAQs.Models;
    using System.Collections.Generic;

    public interface IFAQService
    {
        FAQQueryServiceModel All();
        FAQQueryServiceModel AllShow();

        void Create(
            string imageUrl,
            string description,
            string title);

        bool Edit(
            int Id,
            string imageUrl,
            string description,
            string title);

        void ChangeVisibility(int Id);

        IEnumerable<FAQServiceModel> AllFAQs();

        bool FAQExists(string faqTitle);
        FAQServiceModel FAQDetails(int Id);

        int LikeFAQ(int Id, string userId);
    }
}
