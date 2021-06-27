using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Repository
{
    public interface ITestimonialRepository
    {
        int Create(Testimonial Data);
        List<Testimonial> GetAll();
        int Update(Testimonial Data);
        int Delete(int id);
    }
}
