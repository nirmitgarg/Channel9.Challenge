using AutoMapper;
using Channel9.Challenge.Dto;
using Channel9.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Channel9.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthcheckController : ControllerBase
    {       
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Healthy";
        }
    }
}
