using APAC.Garb.Business.Components.Definition;
using APAC.Garb.Business.Models;
using APAC.Garb.Data.Repository.Definition;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APAC.Garb.Business.Components.Implementation
{
    public class RequestItemsComponent: IRequestItemsComponent
    {
        private readonly IRequestItemsRepository _repository;
        private readonly ILogger<IRequestItemsComponent> _logger;
        private readonly IMapper _mapper;

        public RequestItemsComponent(IRequestItemsRepository repository, ILogger<IRequestItemsComponent>logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<Lookup>> GetGarbs()
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            _logger.LogDebug($"Starting - {methodName}");
            try
            {
                var garbs = await _repository.GetRequestItems();
                var result = _mapper.Map<List<Lookup>>(garbs);
                return result;
            }
            catch(Exception ex)
            {   
                _logger.LogTrace($"Error - {methodName}");
                throw ex;
            }


        }
    }
}

