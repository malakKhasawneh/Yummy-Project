using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository RoleRepository;
        public RoleServices(IRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
        }

        public Role Create(Role role)
        {
            RoleRepository.Create(role);
            return new Role();
        }

        public List<Role> GetAll()
        {
            return RoleRepository.GetAll();

        }

        public Role Update(Role role)
        {
            RoleRepository.Update(role);
            return role;
        }

        public Role Delete(int id)
        {
            RoleRepository.Delete(id);
            return new Role();
        }


    }
}
