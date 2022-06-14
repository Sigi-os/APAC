using System;
using System.Collections.Generic;
using System.Text;

namespace APAC.Garb.Data.Models.Definition.Common
{
    public interface ILookup
    {        
        /// <inheritdocs />
        int Id { get; set; }
        string Name { get; set;  }
        string Code { get; set; } 
    }
}
