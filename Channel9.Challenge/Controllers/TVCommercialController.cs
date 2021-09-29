using AutoMapper;
using Channel9.Challenge.Dto;
using Channel9.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Channel9.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TVCommercialController : ControllerBase
    {
        private readonly ITVCommercialService _service;
        private readonly IMapper _mapper;

        public TVCommercialController(ITVCommercialService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult ProcessCommercialBreaks(Dictionary<string, int> rules)
        {
            var result = _service.GetOptimizedCommercialBreaks(rules);

            var response = _mapper.Map<List<OptimizedCommercialBreak>>(result);

            return Ok(response);
        }
    }
}
