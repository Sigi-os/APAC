using APAC.Garb.Data.Models.Definition.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APAC.Garb.Data.Repository.Definition
{
    public interface IRequestItemsRepository
    {
        Task<List<ILookup>> GetRequestItems();
    }
}
