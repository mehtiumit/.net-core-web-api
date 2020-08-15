using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/adds")]
    public class AddsController : Controller
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public AddsController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAdds()
        {
            var adds = _appRepository.GetAdds();
            var addsToReturn = _mapper.Map<List<AddForListDto>>(adds);
            return Ok(addsToReturn);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] Add add)
        {
            _appRepository.Add(add);
            _appRepository.SaveAll();
            return Ok(add);
        }

        [HttpGet]
        [Route("detail")]
        public IActionResult GetAddById(int id)
        {
            var add = _appRepository.GetAddsById(id);
            var addInfo = _mapper.Map<List<AddInfoDto>>(add);
            return Ok(addInfo);
        }
        [HttpGet]
        [Route("photos")]
        //parametre kısmı http kısmına yazılır ?addid=1
        public IActionResult GetPhotosByAdd(int addId)
        {
            var photos = _appRepository.GetPhotosByAdd(addId);
            return Ok(photos);
        }
    }
}
