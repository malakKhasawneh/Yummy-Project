using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class MenuServices : IMenuServices
    {
        private readonly IMenuRepository MenuRepository;
        public MenuServices(IMenuRepository menuRepository)
        {
            MenuRepository = menuRepository;
        }

        public Menu Create(Menu role)
        {
            MenuRepository.Create(role);
            return new Menu();
        }

        public List<Menu> GetAll()
        {
            return MenuRepository.GetAll();

        }

        public Menu Update(Menu menu)
        {
            MenuRepository.Update(menu);
            return menu;
        }

        public Menu Delete(int id)
        {
            MenuRepository.Delete(id);
            return new Menu();
        }
        public List<Menu> SearchMenu(MenuDTO menuDTO)
        {
            return MenuRepository.SearchMenu(menuDTO);
        }

    }
}
