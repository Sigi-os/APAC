using APAC.Garb.Data.DbContexts;
using APAC.Garb.Data.DbContexts.Implementations;
using APAC.Garb.Data.Models.Definition.Common;
using APAC.Garb.Data.Repository.Definition;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC.Garb.Data.Repository.Implementation
{
    public class RequestItemsRepository:IRequestItemsRepository
    {
        private readonly RequestItemContext _context;
        private readonly ILogger<RequestItemsRepository> _logger;

        public RequestItemsRepository(RequestItemContext context, ILogger<RequestItemsRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<ILookup>> GetRequestItems()
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            _logger.LogDebug($"Starting - {methodName}");
            var requestItems = new List<ILookup>();
            try
            {
                var result = await _context.RequestItems.ToListAsync();
                return result;
            }   
            catch(Exception ex)
            {
                _logger.LogError("Error Occured", ex.Message);
                throw new Exception("Occured in Repo", ex);
            }
            finally
            {
                _logger.LogDebug($"Successful Ending - {methodName}");
            }           
        }
    }
}
