using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Services
{
    public interface ITestimonialServices
    {
        public Testimonial Create(Testimonial testimonial);
        public List<Testimonial> GetAll();
        public Testimonial Update(Testimonial testimonial);
        public Testimonial Delete(int id);
    }
}
