using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yummy.Core.Data;
using Yummy.Core.Services;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleServices RoleService;
        public RoleController(IRoleServices roleServices)
        {
            RoleService = roleServices;
        }
        [Authorize("Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status400BadRequest)]
        public Role Create([FromBody] Role book)
        {
            return RoleService.Create(book);
        }
        [Authorize("Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        public List<Role> GetAll()
        {
            return RoleService.GetAll();
        }
        [Authorize("Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status400BadRequest)]
        public Role Update([FromBody] Role book)
        {
            return RoleService.Update(book);
        }
        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public Role Delete(int id)
        {
            return RoleService.Delete(id);

        }
    }
}
