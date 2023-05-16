namespace LimeAirlinesSystem.Services.Information
{
    using LimeAirlinesSystem.Services.FAQs.Models;
    using System;

    public interface IFAQService
    {
        FAQQueryServiceModel All();

        int Create(
            string imageUrl,
            string description,
            string title);

        bool Edit(
            int informationId,
            string imageUrl,
            string description,
            string title,
            bool isPublic);

        void ChangeVisibility(int faqId);
    }
}
