using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private IAppRepository _appRepository;
        public UsersController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _appRepository.GetUsers();
            return Ok(result);
        }
    }
}
