using AutoMapper;
using AutoMapper.QueryableExtensions;
using LimeAirlinesSystem.Data;
using LimeAirlinesSystem.Data.Models;
using LimeAirlinesSystem.Services.FAQs.Models;
using LimeAirlinesSystem.Services.Flights.Models;
using LimeAirlinesSystem.Services.Information.Models;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace LimeAirlinesSystem.Services.Information
{
    public class FAQService : IFAQService
    {
        private readonly AirlineDbContext data;
        private readonly IConfigurationProvider mapper;

        public FAQService(AirlineDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }


        public FAQQueryServiceModel All()
        {
            var faqQuery = this.data.FAQs;
            var faqs = GetFAQs(faqQuery);

            return new FAQQueryServiceModel
            {
                FAQs = faqs
            };

        }

        public int Create(string imageUrl, string description, string title)
        {
            var faqData = new FAQ
            {
                ImageUrl = imageUrl,
                Description = description,
                Title = title,
                IsPublic = true
            };

            this.data.FAQs.Add(faqData);
            this.data.SaveChanges();

            return 
        }

        public bool Edit(
            int informationId, 
            string imageUrl, 
            string description,
            string title,
            bool isPublic)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeVisibility(int faqId)
        {
            var faq = this.data.FAQs.Find(faqId);

            faq.IsPublic = !faq.IsPublic;

            this.data.SaveChanges();
        }

        private IEnumerable<FAQServiceModel> GetFAQs(IQueryable<FAQ> faqQuery)
        => faqQuery
        .ProjectTo<FAQServiceModel>(this.mapper)
        .ToList();
    }
}
