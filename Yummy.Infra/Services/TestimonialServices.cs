using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class TestimonialServices : ITestimonialServices
    {
        private readonly ITestimonialRepository TestimonialRepository;

        public TestimonialServices(ITestimonialRepository testimonialRepository)
        {
            TestimonialRepository = testimonialRepository;
        }
        public Testimonial Create(Testimonial testimonial)
        {
            TestimonialRepository.Create(testimonial);
            return new Testimonial();
        }
        public List<Testimonial> GetAll()
        {
            return TestimonialRepository.GetAll();
        }
        public Testimonial Update(Testimonial testimonial)
        {
            TestimonialRepository.Update(testimonial);
            return new Testimonial();
        }
        public Testimonial Delete(int id)
        {
            TestimonialRepository.Delete(id);
            return new Testimonial();
        }
    }
}
