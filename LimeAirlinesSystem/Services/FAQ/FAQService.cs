namespace LimeAirlinesSystem.Services.FAQs
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Services.FAQs.Models;
    using LimeAirlinesSystem.Services.Flights.Models;
    using LimeAirlinesSystem.Services.Planes.Models;
    using Microsoft.Extensions.Primitives;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography.Xml;

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
        public FAQQueryServiceModel AllShow()
        {
            var faqQuery = this.data.FAQs;
            var allfaqs = GetFAQs(faqQuery);
            var faqs = allfaqs.Where(x => x.IsPublic);

            return new FAQQueryServiceModel
            {
                FAQs = faqs
            };

        }


        public void Create(string imageUrl, string description, string title)
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
        }

        public bool Edit(
            int Id, 
            string imageUrl, 
            string description,
            string title)
        {
            var faqData = this.data.FAQs.Find(Id);

            if (faqData == null)
            {
                return false;
            }

            faqData.Description = description;
            faqData.Title = title;
            faqData.ImageUrl = imageUrl;


            this.data.SaveChanges();

            return true;
        }

        public void ChangeVisibility(int Id)
        {
            var faq = this.data.FAQs.Find(Id);

            faq.IsPublic = !faq.IsPublic;

            this.data.SaveChanges();
        }

        private IEnumerable<FAQServiceModel> GetFAQs(IQueryable<FAQ> faqQuery)
        => faqQuery
        .ProjectTo<FAQServiceModel>(this.mapper)
        .ToList();

        public IEnumerable<FAQServiceModel> AllFAQs()
            => this.data
            .FAQs
            .ProjectTo<FAQServiceModel>(this.mapper)
            .ToList();

        public bool FAQExists(string faqTitle)
        => this.data
        .FAQs
        .Any(f => f.Title == faqTitle);

        public FAQServiceModel FAQDetails(int Id)
            => this.data
            .FAQs
            .Where(f => f.Id == Id)
            .ProjectTo<FAQServiceModel>(this.mapper)
            .FirstOrDefault();

        public int LikeFAQ(int Id, string userId)
        {
            var faqToLike = this.data.FAQs.Find(Id);


            if (faqToLike.Likes.Contains(userId))
            {
                faqToLike.Likes.Remove(userId);
            }

            else
            {
                faqToLike.Likes.Add(userId);
            }

            this.data.SaveChanges();

            return faqToLike.Likes.Count();
        }
    }
}
