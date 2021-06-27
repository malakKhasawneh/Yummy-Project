using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class MealServices : IMealServices
    {
        private readonly IMealRepository MealRepository;
        public MealServices(IMealRepository mealRepository)
        {
            MealRepository = mealRepository;
        }

        public Meal Create(Meal meal)
        {
            MealRepository.Create(meal);
            return new Meal();
        }


        public List<Meal> GetAll()
        {
            return MealRepository.GetAll();
        }
        public Meal Update(Meal meal)
        {
            MealRepository.Update(meal);
            return new Meal();
        }
        public Meal Delete(int id)
        {
            MealRepository.Delete(id);
            return new Meal();
        }
    }
}
