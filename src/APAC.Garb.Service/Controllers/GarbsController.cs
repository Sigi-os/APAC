using APAC.Garb.Business.Components.Definition;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APAC.Garb.Service.Controllers
{
    
    [Route("api/garbRequest/[action]")]
    public class GarbsController : ControllerBase
    {
        private readonly IRequestItemsComponent _component;
        private readonly ILogger<GarbsController> _logger;
        private readonly IMapper _mapper;        

        public GarbsController(IRequestItemsComponent component, ILogger<GarbsController> logger, IMapper mapper)
        {
            _component = component;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGarbs()
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.Name;
            _logger.LogDebug($"Start - {methodName}");

            try
            {
                var result = await _component.GetGarbs();
                if(result.Count <= 0)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
