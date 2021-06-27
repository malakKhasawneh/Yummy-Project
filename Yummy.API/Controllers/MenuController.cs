using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yummy.Core.Data;
using Yummy.Core.DTO;
using Yummy.Core.Services;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly IMenuServices MenuService;
        public MenuController(IMenuServices menuServices)
        {
            MenuService = menuServices;
        }
        [Authorize("Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(Menu), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Menu), StatusCodes.Status400BadRequest)]
        public Menu Create([FromBody] Menu book)
        {
            return MenuService.Create(book);
        }
        [Authorize("Admin")]
        [Authorize("Customer")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Menu>), StatusCodes.Status200OK)]
        public List<Menu> GetAll()
        {
            return MenuService.GetAll();
        }
        [Authorize("Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(Menu), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Menu), StatusCodes.Status400BadRequest)]
        public Menu Update([FromBody] Menu book)
        {
            return MenuService.Update(book);
        }
        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public Menu Delete(int id)
        {
            return MenuService.Delete(id);

        }
        [Authorize("Customer")]
        [Authorize("Admin")]
        [HttpPost]
        [Route("MenuSearch")]
        [ProducesResponseType(typeof(List<Menu>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Menu>), StatusCodes.Status400BadRequest)]
        public List<Menu> Search([FromBody] MenuDTO menuDTO)
        {
            return MenuService.SearchMenu(menuDTO);
        }
    }
}
