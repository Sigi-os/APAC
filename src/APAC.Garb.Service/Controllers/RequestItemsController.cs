using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APAC.Garb.Service.Controllers
{
    public class RequestItemsController : ControllerBase
    {
        private readonly ILogger<RequestItemsController> _logger;
        private readonly IMapper _mapper;
        //private readonly 
        public RequestItemsController(ILogger<RequestItemsController> logger, IMapper mapper)
        {
           

        }
    }
}
