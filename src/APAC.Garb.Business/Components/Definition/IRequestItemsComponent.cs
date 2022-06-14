using APAC.Garb.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APAC.Garb.Business.Components.Definition
{
    public interface IRequestItemsComponent
    {
        Task<List<Lookup>> GetGarbs();
    }
}
